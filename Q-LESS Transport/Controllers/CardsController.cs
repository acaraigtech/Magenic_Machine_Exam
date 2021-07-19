using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Repositories;
using Q_LESS_Transport.Domain.Services;
using Q_LESS_Transport.Dtos;
using Q_LESS_Transport.Dtos.Card;
using Q_LESS_Transport.Dtos.DiscountCard;
using Q_LESS_Transport.Presistence.Services.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Controllers
{
    [Route("/api/cards")]
    [Produces("application/json")]
    [ApiController]
    public class CardsController : Controller
    {
        private readonly ICardService _cardService;
        private readonly IDiscountCardService _discountCardService;
        private readonly IMapper _mapper;
        private readonly ICardTypeDetailsRepository _cardTypeDetailsRepository;

        public CardsController(IMapper mapper
            , ICardTypeDetailsRepository cardTypeDetailsRepository
            , ICardService cardService
            , IDiscountCardService discountCardService)
        {
            _cardService = cardService;
            _discountCardService = discountCardService;
            _mapper = mapper;
            _cardTypeDetailsRepository = cardTypeDetailsRepository;
        }

        /// <summary>
        /// Lists all card information.
        /// </summary>
        /// <returns>card information list.</returns>
        [HttpGet("getList")]
        [ProducesResponseType(typeof(IEnumerable<CardResource>), 200)]
        public async Task<IEnumerable<CardResource>> ListAsync()
        {
            var cardList = await _cardService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Card>, IEnumerable<CardResource>>(cardList);

            return resources;
        }

        /// <summary>
        /// Lists all card information based on the id.
        /// </summary>
        /// <returns>card information list.</returns>
        [HttpGet("getListById/{id}")]
        [ProducesResponseType(typeof(IEnumerable<CardResource>), 200)]
        public async Task<IEnumerable<CardResource>> ListByIdAsync(Guid id)
        {
            var cardList = await _cardService.ListByIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Card>, IEnumerable<CardResource>>(cardList);

            return resources;
        }

        /// <summary>
        /// card information based on the id.
        /// </summary>
        /// <returns>card information.</returns>
        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(CardResource), 200)]
        public async Task<CardResource> GetByIdAsync(Guid id)
        {
            var card = await _cardService.GetByIdAsync(id);
            var resources = _mapper.Map<Card, CardResource>(card);

            return resources;
        }

        /// <summary>
        /// Saves a new card information.
        /// </summary>
        /// <param name="resource">card information.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost("save")]
        [ProducesResponseType(typeof(CardResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> SaveAsync([FromBody] CardRequestResource request)
        {
            var cardTypeDetails = await _cardTypeDetailsRepository.SelectByIdAsync(request.Id);
            SaveCardResource resource = new SaveCardResource();
            DateTime dateTime = Date.StrToDateTime(DateTime.Now.AddDays(1).AddYears(cardTypeDetails.YearOfValidity));
            resource.ValidUntil = dateTime;
            resource.Balance = cardTypeDetails.InitialLoad;
            resource.CardTypeDetailsId = cardTypeDetails.Id;

            var card = _mapper.Map<SaveCardResource, Card>(resource);
            var cardResult = await _cardService.SaveAsync(card);

            if (!cardResult.Success)
            {
                return BadRequest(new ErrorResource(cardResult.Message));
            }

            var cardResource = _mapper.Map<Card, CardResource>(cardResult.Resource);

            if (request.DiscountCardId != null)
            {
                SaveDiscountCardResource saveDiscountCardResource = new SaveDiscountCardResource();
                saveDiscountCardResource.CardId = cardResource.Id;
                saveDiscountCardResource.IsSenior = request.IsSenior;
                saveDiscountCardResource.Id = request.DiscountCardId;

                var discountCard = _mapper.Map<SaveDiscountCardResource, DiscountCard>(saveDiscountCardResource);
                var discountCardResult = await _discountCardService.SaveAsync(discountCard);

                if (!discountCardResult.Success)
                {
                    return BadRequest(new ErrorResource(discountCardResult.Message));
                }
            }

            return Ok(cardResource);
        }
    }
}
