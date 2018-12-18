using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advocateMVC.Models.Feedback
{
    public interface IEmailService
    {
        void Send(EmailMessage message);
    }
}
