using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace advocateMVC.Models.Feedback
{
    public class ContactFormModel
    {
        [Required, Display(Name = "Имя")]
        public string Name { get; set; }
        [Required, Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required, Display(Name = "Адрес электронной почты"), EmailAddress]
        public string Email { get; set; }
        [Required, Display(Name = "Ваше сообщение")]
        public string Message { get; set; }
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
    }
}
