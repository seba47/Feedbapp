using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace WebAPI.Shared
{
    public class EmailService
    {
        public static bool SendEmail(string from, string to, string subject, string body)
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient();
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in EmailService.SendEmail(): {0}", ex.ToString());
                return false;
            }
            return true;
        }
    }
}