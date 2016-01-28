using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Configuration;
using WebAPI.Models;

namespace WebAPI.Shared
{
    public class EmailService
    {
        public const string notificationSubject = "Notificación FeedbApp";
        public const string requestSubject = "Pedido de Feedback";
        public const string offerSubject = "Ofrecimiento de Feedback";
        public const string appEmail = "hello.feedbapp@gmail.com";

        public static string getBody(Feedback f, string from, string to, string comments)
        {
            string variableText = "te pidió";
            if (f.GetType() == typeof(Offered))
            {
                variableText = "ofreció darte";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Estimad@ {0}, <br /><br /> ", to);
            sb.AppendFormat("{0} {1} feedback mediante FeedbApp, la nueva aplicación de UruIT para facilitar las instancias de feedback.<br/><br/> ", from, variableText);
            sb.AppendFormat("Mensaje de {0}: <br/><span style='font-family:Calibri;font-style:italic;'>\"{1}\"</span><br /><br />", from, comments);
            sb.Append("Agendate una reunión!<br/><br/>");
            sb.Append("El equipo de FeedbApp");
            return sb.ToString();
        }

        public static string requestNotificationBody(string to)
        {
            return string.Format("Se le ha enviado un mail a {0} solicitando Feedback.<br/><br/>Gracias por usar FeedbApp", to);
        }

        public static string offerNotificationBody(string to)
        {
            return string.Format("Se le ha enviado un mail a {0} ofreciendo Feedback.<br/><br/>Gracias por usar FeedbApp", to);
        }

        public static bool SendEmail(string from, string to, string subject, string body)
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            message.IsBodyHtml = true;
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