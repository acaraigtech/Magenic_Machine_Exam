using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Services;
using Q_LESS_Transport.Dtos.CardTypeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Controllers
{
    [Route("/api/cardTypeDetails")]
    [Produces("application/json")]
    [ApiController]
    public class CardTypeDetailsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICardTypeDetailsService _cardTypeDetailsService;

        public CardTypeDetailsController(IMapper mapper
            , ICardTypeDetailsService cardTypeDetailsService)
        {
            _mapper = mapper;
            _cardTypeDetailsService = cardTypeDetailsService;
        }

        /// <summary>
        /// Lists all card type details information.
        /// </summary>
        /// <returns>card type details information list.</returns>
        [HttpGet("getList")]
        [ProducesResponseType(typeof(IEnumerable<CardTypeDetailsResource>), 200)]
        public async Task<IEnumerable<CardTypeDetailsResource>> ListAsync()
        {
            var cardList = await _cardTypeDetailsService.ListAsync();
            var resources = _mapper.Map<IEnumerable<CardTypeDetails>, IEnumerable<CardTypeDetailsResource>>(cardList);

            return resources;
        }
    }
}
