using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Q_LESS_Transport.ClientApp.Fv;
using Q_LESS_Transport.ClientApp.Models;
using Q_LESS_Transport.Dtos.Card;
using Q_LESS_Transport.Dtos.Transaction;
using Q_LESS_Transport.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Q_LESS_Transport.ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(bool isSuccess = false)
        {
            try
            {
                var apiRequest = ApiHelper.ApiRequest(Common._GUID_DEFAULT_VALUE, Api.CARDS_GET_LIST, Api.METHOD_GET);
                var result = apiRequest.Result.Content.ReadAsStringAsync().Result;
                var cardResource = JsonConvert.DeserializeObject<List<Card>>(result);
                ViewBag.IsSuccess = isSuccess;
                ViewBag.CardSelectList = new SelectList(cardResource, "Id", "Id");
                return View();
            }
            catch (Exception ex)
            {
                return View();
                throw ex;
            }

        }
        [HttpPost]
        public IActionResult Index(CardViewModel cardViewModel)
        {
            try
            {
                // get card information
                var apiGetCardReq = ApiHelper.ApiRequest(Common._GUID_DEFAULT_VALUE, Api.CARDS_GET_BY_ID + cardViewModel.CardId, Api.METHOD_GET);
                var carResult = apiGetCardReq.Result.Content.ReadAsStringAsync().Result;
                var cardResource = JsonConvert.DeserializeObject<Card>(carResult);

                // process transaction of exit train platform
                TransactionRequestResource transReq = new TransactionRequestResource();
                transReq.CardId = cardResource.Id;
                transReq.CardTypeDetailsId = cardResource.CardTypeDetailsId;
                transReq.TransactionCode = Common.TRANSACTION_CODE_FR;
                var apiSaveTransactionReq = ApiHelper.ApiRequest(Common._GUID_DEFAULT_VALUE, Api.TRANSACTION_SAVE, Api.METHOD_POST, transReq);
                var transResult = apiGetCardReq.Result.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index", new { isSuccess = true });
            }
            catch (Exception ex)
            {
                return View();
                throw ex;
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
