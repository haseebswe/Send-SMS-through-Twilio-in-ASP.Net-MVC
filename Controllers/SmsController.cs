using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace TwilioSMSAPIWebApplication.Controllers
{
    public class SmsController : TwilioController
    {
        public static string SendSMS(string to, string body)
        {
            var accoundSid = ConfigurationManager.AppSettings["AccountSid"];
            var authToken = ConfigurationManager.AppSettings["AuthToken"];
            TwilioClient.Init(accoundSid, authToken);
            var from = new PhoneNumber(ConfigurationManager.AppSettings["FromMobileNumber"]);
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: body);
            return message.Sid;
        }
    }
}