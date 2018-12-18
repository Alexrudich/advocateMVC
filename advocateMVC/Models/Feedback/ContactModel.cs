using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace advocateMVC.Models.Feedback
{
    public class ContactModel
    {
        [BindProperty]
        public ContactFormModel Contact { get; set; }
    }
}
