using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RealtorEventApi.Entities;

namespace RealtorEventApi.Controllers
{
    public class RealtorsController : ApiController
    {
        private RealtorEventModel db = new RealtorEventModel();
        private Random random = new Random();
        // GET: api/Realtors
        public IQueryable<Realtor> GetRealtor()
        {
            return db.Realtor;
        }

        // GET: api/Realtors/5
        [ResponseType(typeof(Realtor))]
        public IHttpActionResult GetRealtor(int id)
        {
            Realtor realtor = db.Realtor.Find(id);
            if (realtor == null)
            {
                return NotFound();
            }

            return Ok(realtor);
        }

        // GET: api/Realtors/Random
        [HttpGet()]
        [Route("Random")]
        [ResponseType(typeof(Realtor))]
        public IHttpActionResult GetRandomRealtor()
        {
            return GetRealtor(random.Next(0, db.Realtor.Count()));
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