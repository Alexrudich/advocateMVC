using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using advocateMVC.Models.Feedback;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace advocateMVC.Controllers
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
        [HttpPost]
        public IActionResult Index(/*[Bind(Include = "Name, LastName, Email, Message")]*/ ContactModel model)
        {
            if (ModelState.IsValid)
            {
                EmailMessage msgToSend = new EmailMessage
                {
                    FromAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    ToAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    Content = $"Вот ваше сообщение: Отправитель: {model.Contact.Name} + { model.Contact.LastName}," + $"Email: {model.Contact.Email}, Message: {model.Contact.Message}",
                    Subject = "Форма обратной связи - Мой крутой сайт"
                };
                EmailService.Send(msgToSend);
                return RedirectToAction("Index");
            }
            else
            {
                return Index();
            }
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult LegalPersons()
        {
            return View();
        }
        public IActionResult PhysicalPersons()
        {
            return View();
        }
       
    }
}