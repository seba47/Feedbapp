using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.DataAccess;
using WebAPI.Models;
using WebAPI.Shared;

namespace WebAPI.Controllers
{
    public class OfferedsController : ApiController
    {
        private FeedbappContext db = new FeedbappContext();

        // GET: api/Offereds
        public IQueryable<Offered> GetOffered()
        {
            return db.Offered;
        }

        // GET: api/Offereds/5
        [ResponseType(typeof(Offered))]
        public IHttpActionResult GetOffered(int id)
        {
            Offered offered = db.Offered.Find(id);
            if (offered == null)
            {
                return NotFound();
            }

            return Ok(offered);
        }

        // PUT: api/Offereds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOffered(int id, Offered offered)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != offered.feedbackId)
            {
                return BadRequest();
            }

            db.Entry(offered).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferedExists(id))
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

        // POST: api/Offereds
        [ResponseType(typeof(Offered))]
        public IHttpActionResult PostOffered(Offered offered)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string tempComm = offered.comments;
            db.Offered.Add(offered);
            if (db.SaveChanges() > 0)
            {
                offered.comments = tempComm;
                SendEmails(offered);
            }
            return CreatedAtRoute("DefaultApi", new { id = offered.feedbackId }, offered);
        }

        protected void SendEmails(Offered offered)
        {
            int sId = offered.senderId != null ? (int)offered.senderId : 0;
            int rId = offered.recipientId != null ? (int)offered.recipientId : 0;
            offered.sender = db.Users.Find(sId);
            offered.recipient = db.Users.Find(rId);
            string offerBody = EmailService.getBody(offered, offered.sender.firstName, offered.sender.email, offered.recipient.firstName, offered.comments);
            ThreadStart threadStart = delegate ()
            {
                EmailService.SendEmail(EmailService.appEmail, offered.recipient.email, EmailService.offerSubject, offerBody);
                EmailService.SendEmail(EmailService.appEmail, offered.sender.email, EmailService.notificationSubject, EmailService.offerNotificationBody(offered.recipient.firstName));
            };
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        // DELETE: api/Offereds/5
        [ResponseType(typeof(Offered))]
        public IHttpActionResult DeleteOffered(int id)
        {
            Offered offered = db.Offered.Find(id);
            if (offered == null)
            {
                return NotFound();
            }

            db.Offered.Remove(offered);
            db.SaveChanges();

            return Ok(offered);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfferedExists(int id)
        {
            return db.Offered.Count(e => e.feedbackId == id) > 0;
        }
    }
}