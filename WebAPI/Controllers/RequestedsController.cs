using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RequestedsController : ApiController
    {
        private WebAPIDbContext db = new WebAPIDbContext();

        // GET: api/Requesteds
        public IQueryable<Requested> GetRequested()
        {
            return db.Requested;
        }

        // GET: api/Requesteds/5
        [ResponseType(typeof(Requested))]
        public IHttpActionResult GetRequested(int id)
        {
            Requested requested = db.Requested.Find(id);
            if (requested == null)
            {
                return NotFound();
            }

            return Ok(requested);
        }

        // PUT: api/Requesteds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequested(int id, Requested requested)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requested.feedbackId)
            {
                return BadRequest();
            }

            db.Entry(requested).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestedExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Requesteds
        [ResponseType(typeof(Requested))]
        public IHttpActionResult PostRequested(Requested requested)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Requested.Add(requested);
            if (db.SaveChanges() > 0)
            {
                //int sId = requested.senderId != null ? (int)requested.senderId : 0;
                //int rId = requested.recipientId != null ? (int)requested.recipientId : 0;
                //requested.sender = (User)new UserController().GetUser(sId);
                //requested.recipient = (User)new UserController().GetUser(rId);
                //SendEmails(requested.sender.email, requested.recipient.email, requested.comments);
                SendEmails("cabrera_sebastian@hotmail.com", "sergio.cabrera@uruit.com", requested.comments);
            }

            return CreatedAtRoute("DefaultApi", new { id = requested.feedbackId }, requested);
        }

        private void SendEmails(string senderEmail, string recipientEmail, string feedbackComment)
        {
            // Specify the file to be attached and sent.
            // This example assumes that a file named Data.xls exists in the
            // current working directory.
            //string file = "data.xls";
            // Create a message and set up the recipients.
            MailMessage message = new MailMessage(
               senderEmail, recipientEmail,
               "Pedido de Feedback!",
               feedbackComment);
            string p = "41297206a";
            // Create  the file attachment for this e-mail message.
            //Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            //ContentDisposition disposition = data.ContentDisposition;
            //disposition.CreationDate = System.IO.File.GetCreationTime(file);
            //disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            //disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            //// Add the file attachment to this e-mail message.
            //message.Attachments.Add(data);

            //Send the message.
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.mail.yahoo.com";
            client.EnableSsl = true;
            client.Port = 25;            
            client.UseDefaultCredentials = false;
            client.DeliveryMethod =  SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("cabrera_sebastian8@yahoo.com", p);
            
            // Add credentials if the SMTP server requires them.
            //client.Credentials = CredentialCache.DefaultNetworkCredentials;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                            ex.ToString());
            }
            //data.Dispose();



            MailMessage message2 = new MailMessage(
               "feedbapp@uruit.com", senderEmail,
               "Su pedido de feedback fue enviado!",
               "En breve la persona a la que le solicitaste feedback se contactara contigo.");         

            try
            {
                client.Send(message2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                            ex.ToString());
            }
        }

        // DELETE: api/Requesteds/5
        [ResponseType(typeof(Requested))]
        public IHttpActionResult DeleteRequested(int id)
        {
            Requested requested = db.Requested.Find(id);
            if (requested == null)
            {
                return NotFound();
            }

            db.Requested.Remove(requested);
            db.SaveChanges();

            return Ok(requested);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestedExists(int id)
        {
            return db.Requested.Count(e => e.feedbackId == id) > 0;
        }
    }
}