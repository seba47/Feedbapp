﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RequestedsController : ApiController
    {
        private FeedbappContext db = new FeedbappContext();

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
            //Stopwatch timer = new Stopwatch();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //timer.Start();
            db.Requested.Add(requested);
            if (db.SaveChanges() > 0)
            {
                //timer.Stop();
                //Console.WriteLine(timer.ElapsedTicks);
                //timer.Reset();

                //timer.Start();
                SendEmails(requested);
                
                //timer.Stop();
                //Console.WriteLine(timer.ElapsedTicks);
            }
            return CreatedAtRoute("DefaultApi", new { id = requested.feedbackId }, requested);
        }

        protected void SendEmails(Requested requested)
        {
            int sId = requested.senderId != null ? (int)requested.senderId : 0;
            int rId = requested.recipientId != null ? (int)requested.recipientId : 0;
            requested.sender = db.Users.Find(sId);
            requested.recipient = db.Users.Find(rId);
            
            ThreadStart threadStart = delegate () {
                Shared.EmailService.SendEmail(requested.recipient.email, "Pedido de Feedback!", requested.comments + ". Responder a: " + requested.sender.email);
                Shared.EmailService.SendEmail(requested.sender.email, "Notificación FeedbApp", "Se ha enviado un mail a la persona que le solicitaste feedback");
            };
            Thread thread = new Thread(threadStart);
            thread.Start();
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