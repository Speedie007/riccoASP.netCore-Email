using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ricco.Email.Models;

namespace Ricco.Email.Controllers
{
    public class HomeController : Controller
    {
        //uses the System.Net.Mail Name space
        private SmtpClient smtpClient;

        public HomeController()
        {

        }

        public IActionResult Index()
        {

            MailModel Model = new MailModel()
            {
                AccountName = "Brendanw@mweb.co.za",
                AccountPassword = "speedie3",
                SMTP_HOST = "smtp.mweb.co.za",
                SMTP_PORT = 25,
                MessageBody = "",
                MessageSubject = "",
                FromAddress = "brendanw@mweb.co.za",
                ToAddress = "RiccoAssasin@gmil.com"
            };


            return View(Model);
        }

        [HttpPost]
        public IActionResult Index(MailModel Model)

        {
            smtpClient = new SmtpClient(Model.SMTP_HOST, Model.SMTP_PORT);

            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(Model.AccountName, Model.AccountPassword);

            smtpClient.Credentials = credentials;
            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress(Model.FromAddress);

            // Set destinations for the email message.
            MailAddress to = new MailAddress(Model.ToAddress);
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);


            message.Body = Model.MessageBody;

            message.Subject = Model.MessageSubject;

            smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            // The userState can be any object that allows your callback 
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            string userState = "ThisCanBeAnyThingYouWant";
            smtpClient.SendAsync(message, userState);
            // Clean up.
           // message.Dispose();

            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            //this.smtpClient.Dispose();
            base.Dispose(disposing);
        }


        static bool mailSent = false;

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;


            if (e.Error != null)
            {
                //Pop up error message
                string x = "";
            }
            else
            {
                // popup  successfully sent mesasage
                String dd = "";
            }
            mailSent = true;
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
