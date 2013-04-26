using System;
using System.Net;
using System.Net.Mail;
using System.Drawing;


namespace SendMailViaGmail
{
    class Emailer
    {
        MailAddress dropbox = new MailAddress("yamd_fbc7@sendtodropbox.com", "YAMD");
        const string sendersPassword = "d0n0tsh@r3";
        const string senderAddress = "yamdmotiondetection@gmail.com";
        MailAddress sender = new MailAddress(senderAddress, "YAMD Software");
        MailAddress recipient;

        public Emailer()
        {
            recipient = new MailAddress("yamdmotiondetection@gmail.com");
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
            
            string subject = magnitudeLevel + "-level Event Detected";
            string body = "Beginning at " + beginTime.ToString("T") + " on " + beginTime.ToString("yyyy-M-d")
                + ", YAMD detected motion for " + endTime.Subtract(beginTime).ToString() + " ending at " + endTime.ToString("T")
                + ". See the attachment for an image taken at the beginning of the event.\n"
                + "\n\nFollow this link to watch the video captured:\n" + videoLink; 

            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(senderAddress, sendersPassword),
                    Timeout = 20000
                };
                MailMessage message = new MailMessage(sender, recipient);

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

        public void sendToDropbox(string videoLocation)
        {
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(senderAddress, sendersPassword),
                    Timeout = 20000
                };
                MailMessage message = new MailMessage(sender, dropbox);
                Attachment attachment = new Attachment(videoLocation);

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
