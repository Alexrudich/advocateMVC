using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdvocatPlusAspCore.Models;
using AdvocatPlusAspCore.Models.Feedback;

namespace AdvocatPlusAspCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailAddress FromAndToEmailAddress;
        private IEmailService EmailService;
        public HomeController(EmailAddress _fromAddress, IEmailService _emailService)
        {
            FromAndToEmailAddress = _fromAddress;
            EmailService = _emailService;
        }
        [HttpGet]
        [Route("")] //need for highlighting <li> index by css
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contacts(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                EmailMessage msgToSend = new EmailMessage
                {
                    FromAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    ToAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    Content = $"Отправитель: {model.Contact.Name} { model.Contact.LastName}," + $" Email: {model.Contact.Email}. Сообщение: {model.Contact.Message}. Телефон: {model.Contact.PhoneNumber}",
                    Subject = "Новое сообщение с сайта"
                };
                EmailService.Send(msgToSend);
                return RedirectToAction("Index");
            }
            else
            {
                return Contacts();
            }
        }
    }
}
