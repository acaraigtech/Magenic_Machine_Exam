using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Q_LESS_Transport.ClientApp.Fv;
using Q_LESS_Transport.ClientApp.Models;
using Q_LESS_Transport.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.ClientApp.Controllers
{
    public class ReloadingController : Controller
    {
        public IActionResult Index(bool isSuccess = false
            , double amount = 0.00
            , double change = 0.00
            , double customerMoney = 0.00
            , double newBalance = 0.00)
        {
            try
            {
                var apiRequest = ApiHelper.ApiRequest(Common._GUID_DEFAULT_VALUE, Api.CARDS_GET_LIST, Api.METHOD_GET);
                var result = apiRequest.Result.Content.ReadAsStringAsync().Result;
                var cardResource = JsonConvert.DeserializeObject<List<Card>>(result);
                ViewBag.IsSuccess = isSuccess;
                ViewBag.Amount = amount;
                ViewBag.Change = change;
                ViewBag.CustomerMoney = customerMoney;
                ViewBag.NewBalance = newBalance;
                ViewBag.CardSelectList = new SelectList(cardResource, "Id", "Id");
                return View(new TransactionResource());
            }
            catch (Exception ex)
            {
                return View();
                throw ex;
            }

        }

        [HttpPost]
        public IActionResult Index(TransactionResource resource)
        {
            try
            {
                resource.TransactionCode = Common.TRANSACTION_CODE_RL;
                var reqReloadTransApi = ApiHelper.ApiRequest(Common._GUID_DEFAULT_VALUE, Api.TRANSACTION_SAVE, Api.METHOD_POST, resource);
                var resReloadTransApi = reqReloadTransApi.Result.Content.ReadAsStringAsync().Result;
                var transResource = JsonConvert.DeserializeObject<TransactionResource>(resReloadTransApi);
                return RedirectToAction("Index"
                    , new
                    {
                        amount = transResource.Amount
                    ,
                        change = transResource.Change
                    ,
                        customerMoney = transResource.CustomerMoney
                    ,
                        newBalance = transResource.NewBalance
                    ,
                        IsSuccess = true
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
                throw ex;
            }

        }
    }
}
