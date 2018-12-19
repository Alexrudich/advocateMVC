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
            //ViewBag.Title = "Home";
            //ViewBag.Home = "class = active";
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                EmailMessage msgToSend = new EmailMessage
                {
                    FromAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    ToAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    Content = $"Вот ваше сообщение: Отправитель: {model.Name} + { model.LastName}," + $"Email: {model.Email}, Message: {model.Message}",
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