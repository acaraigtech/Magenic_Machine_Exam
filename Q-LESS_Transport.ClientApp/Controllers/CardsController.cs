using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Q_LESS_Transport.ClientApp.Fv;
using Q_LESS_Transport.ClientApp.Models;
using Q_LESS_Transport.Dtos.Card;
using Q_LESS_Transport.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.ClientApp.Controllers
{
    public class CardsController : Controller
    {
        public IActionResult Index(bool isSuccess = false,
            double balance = 0.00
            , string cardId = ""
            , string validUntil = "")
        {
            try
            {
                var apiRequest = ApiHelper.ApiRequest(Common._GUID_DEFAULT_VALUE, Api.CARD_TYPE_DETAILS_GET_LIST, Api.METHOD_GET);
                var result = apiRequest.Result.Content.ReadAsStringAsync().Result;
                var cardTypeDetailsResources = JsonConvert.DeserializeObject<List<CardTypeDetailsResource>>(result);
                ViewBag.IsSuccess = isSuccess;
                ViewBag.Balance = balance;
                ViewBag.CardId = cardId;
                ViewBag.ValidUntil = validUntil;
                ViewBag.CardTypeDetailsSelectList = new SelectList(cardTypeDetailsResources, "Id", "Name");
                return View();
            } catch (Exception ex)
            {
                return View();
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Index(CardTypeDetailsResource cardTypeDetailsResource)
        {
            try
            {
                var saveCardReqApi = ApiHelper.ApiRequest(Common._GUID_DEFAULT_VALUE, Api.CARDS_SAVE, Api.METHOD_POST, cardTypeDetailsResource);
                var saveCardResult = saveCardReqApi.Result.Content.ReadAsStringAsync().Result;
                var saveCardResources = JsonConvert.DeserializeObject<CardResource>(saveCardResult);
                return RedirectToAction("Index", new
                {
                    isSuccess = true
                ,
                    balance = saveCardResources.Balance
                ,
                    cardId = saveCardResources.Id
                ,
                    validUntil = saveCardResources.ValidUntil
                });
            } catch (Exception ex)
            {
                return View();
                throw ex;
            }

        }
    }
}
