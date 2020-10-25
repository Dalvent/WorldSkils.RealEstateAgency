using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RealtorEventApi.Entities;

namespace RealtorEventApi.Controllers
{
    public class RealtorEventsController : ApiController
    {
        private RealtorEventModel db = new RealtorEventModel();

        // GET: api/RealtorEvents
        public IQueryable<RealtorEvent> GetRealtorEvent()
        {
            return db.RealtorEvent;
        }

        // GET: api/RealtorEvents/RealtorId/5
        //[Route("RealtorId/[realtorId]")]
        [ResponseType(typeof(RealtorEvent))]
        public IQueryable<RealtorEvent> GetRealtorEvents(int id)
        {
            return db.RealtorEvent
                .Where(item => item.RealtorId == id);
        }

        // POST: api/RealtorEvents
        [ResponseType(typeof(RealtorEvent))]
        public IHttpActionResult PostRealtorEvent(RealtorEvent realtorEvent)
        {
            
            if(realtorEvent == null) 
                return BadRequest();

            if(realtorEvent.Uuid == null)
                ModelState.AddModelError("Uuid", "can't be null.");
            if(db.RealtorEvent
                .Where(item => item.RealtorId == realtorEvent.RealtorId)
                .FirstOrDefault() == null)
            {
                ModelState.AddModelError("Realtor", "is not exist in databse.");
            }
            if(RealtorEvent.IsRealtorEventType(realtorEvent.Type))
            {
                ModelState.AddModelError("Type", "is not type.");
            }

            if(ModelState.IsValid)
            {
                return BadRequest();
            }

            db.RealtorEvent.Add(realtorEvent);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: api/RealtorEvents/6534d6d1-184b-4728-b70f-75da1af36583
        [ResponseType(typeof(RealtorEvent))]
        public IHttpActionResult DeleteRealtorEvent(string id)
        {
            RealtorEvent realtorEvent = db.RealtorEvent
                .Where(item => item.Uuid == id)
                .FirstOrDefault();
            if (realtorEvent == null)
            {
                return NotFound();
            }

            db.RealtorEvent.Remove(realtorEvent);
            db.SaveChanges();

            return Ok(realtorEvent);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}