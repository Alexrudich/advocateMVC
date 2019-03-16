using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocatPlusAspCore.Models.Feedback
{
    public class ContactModel
    {
        [BindProperty]
        public ContactFormModel Contact { get; set; }
    }
}
