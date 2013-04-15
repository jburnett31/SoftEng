using System;
using System.Net;
using System.Net.Mail;
using System.Drawing;


namespace SendMailViaGmail
{

    class Emailer
    {
        MailAddress sender = new MailAddress("volkertr@uni.edu", "YAMD Software");
        MailAddress recipient;

        public Emailer()
        {
            recipient = new MailAddress("bseaba@gmail.com");
        }

        public Emailer(string recipientAddress)
        {
            recipient = new MailAddress(recipientAddress);
        }

        public void setRecipient(string recipientAddress)
        {
            recipient = new MailAddress(recipientAddress);
        }

        public void sendNotification(DateTime beginTime, DateTime endTime,
                                    string imageLocation, string videoLink, string magnitudeLevel)
        {
            const string SendersPassword = "Treklov&(79";

            string subject = magnitudeLevel + "-level Event Detected";
            string body = "Beginning at " + beginTime.ToString("T") + " on " + beginTime.ToString("yyyy-M-d")
                + ", YAMD detected motion for " + endTime.Subtract(beginTime).ToString() + " ending at " + endTime.ToString("T")
                + ". See the attachment for an image taken at the beginning of the event.\n"
                + "\n\nFollow this link to watch the video captured:\n" + videoLink;
            /*"<A HREF=" + videoLink + ">Link to Video</A>  message.IsBodyHtml = true;"*/
            

            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("volkertr@uni.edu", SendersPassword),
                    Timeout = 20000
                };
                MailMessage message = new MailMessage(sender, recipient); /*replace with parameter*/

                message.Subject = subject;
                message.Body = body;
                Attachment attachment = new Attachment(imageLocation);
                
                message.Attachments.Add(attachment);
                smtp.Send(message);
                Console.WriteLine("Message Sent Successfully");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(SmtpDeliveryMethod.Network.ToString());
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
