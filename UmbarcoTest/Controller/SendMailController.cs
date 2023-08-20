using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using UmbarcoTest.Models;
using Umbraco.Web.Mvc;

namespace UmbarcoTest.Controller
{
    public class SendMailController : SurfaceController
    {
        public const string ViweFolder = "~/Views/Partials/Contact/";

        public ActionResult Index()
        {
            return PartialView(ViweFolder+"_SendMail.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SendMail model)
        {
            if (ModelState.IsValid)
            {
                Mail(model);
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private void Mail(SendMail model)
        {
            MailMessage msg = new MailMessage(model.Email, "abinathmukunthan@gmail.com");
            msg.Subject = "Umbraco Cold Banana Test Mail";
            msg.Body = model.Message;
            SmtpClient client = new SmtpClient("127.0.0.1", 25);
            client.Send(msg);

        }
    }
}