using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwilioSMSAPIWebApplication.Models;

namespace TwilioSMSAPIWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult SMS()
        {
            SMSModel sMS = new SMSModel();
            return View(sMS);
        }

        [HttpPost]
        public ActionResult SMS(SMSModel mdl)
        {
            string message = SmsController.SendSMS(mdl.to, mdl.body);
            ViewBag.msg = message;
            return View();
        }
    }
}
