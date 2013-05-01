using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    class Dummy
    {
        static void Main(string[] args)
        {
            SendMailViaGmail.Emailer mailMan = new SendMailViaGmail.Emailer();
            mailMan.sendNotification(DateTime.Today, DateTime.Now, "C:\\Users\\Rachel\\Desktop\\Pictures\\bubbles\\comic.jpg", "Magnitude");
            //mailMan.sendToDropbox("C:\\Users\\Rachel\\Desktop\\Movies\\ButterflyMovie.wlmp"); //C:\\Users\\Rachel\\Desktop\\Pictures\\bubbles\\
        }
    }
}
