﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalProject.Models;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage=new MimeMessage();
            MailboxAddress mailboxAddressFrom= new MailboxAddress("Admin", "*****@burayamailyazıla.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            //mimeMessage.Body=mailRequest.Body;

            var bodyBuilder=new BodyBuilder();
            bodyBuilder.TextBody=mailRequest.Body;
            mimeMessage.Body=bodyBuilder.ToMessageBody();

            mimeMessage.Subject=mailRequest.Subject;

            SmtpClient client= new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("*****@burayamailyazıla.com", "****buraya2adımşifreyazılacak");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
