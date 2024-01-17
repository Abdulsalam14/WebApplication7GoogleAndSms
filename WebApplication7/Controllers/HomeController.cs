using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Auth.Validation;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration = null)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult SendSms(string phoneNumber,string messageBody)
        {
            var accountSid = "ACcc1934df9b49da6b9284d6c98f4e8a40";
            var authToken = "42df5ae6de0bd3c46ff8132e8c30b116";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
             new PhoneNumber(phoneNumber));
            messageOptions.From = new PhoneNumber("+12024107097");
            messageOptions.Body = messageBody;

            var message = MessageResource.Create(messageOptions);

            ViewBag.Message = message;
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}