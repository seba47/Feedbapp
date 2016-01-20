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

        public static bool SendEmail(string to , string subject, string body)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("/"/*HttpContext.Current.Request.ApplicationPath*/);
            SmtpSection smtp = ((MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings")).Smtp;
            MailMessage message = new MailMessage(smtp.From, to, subject, body);
            SmtpClient client = CreateSmtpClient(smtp);
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

        protected static SmtpClient CreateSmtpClient(SmtpSection smtp)
        {            
            var netConfig = smtp.Network;
            //Send the message.            
            SmtpClient client = new SmtpClient();
            client.Host = netConfig.Host;
            client.EnableSsl = netConfig.EnableSsl;
            client.Port = netConfig.Port;
            client.DeliveryMethod = smtp.DeliveryMethod;
            client.UseDefaultCredentials = netConfig.DefaultCredentials;
            client.Credentials = new NetworkCredential(netConfig.UserName, netConfig.Password);
            return client;
        }        
    }
}