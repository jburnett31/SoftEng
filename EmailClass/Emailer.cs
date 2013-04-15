using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace Project1
{
    class Emailer
    {
        static MailAddress fromAddress = new MailAddress("from@gmail.com", "From Name");
        static MailAddress toAddress = new MailAddress("to@example.com", "To Name");
        const string fromPassword = "fromPassword";
        const string subject = "Subject";
        const string body = "Body";

        SmtpClient smtp = new SmtpClient
           {
               Host = "smtp.gmail.com",
               Port = 587,
               EnableSsl = true,
               DeliveryMethod = SmtpDeliveryMethod.Network,
               UseDefaultCredentials = false,
               Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
           };
        using (MailMessage message = new MailMessage(fromAddress, toAddress)
                            {
                                Subject = subject,
                                Body = body
                            })
        {
           smtp.Send(message);
        }
    }
}
