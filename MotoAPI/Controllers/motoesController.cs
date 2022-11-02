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
using MotoAPI.Entities;
using MotoAPI.Models;

namespace MotoAPI.Controllers
{
    public class motoesController : ApiController
    {
        private MotoEntities db = new MotoEntities();

        // GET: api/motoes
        [ResponseType(typeof(List<MotoModel>))]
        public IHttpActionResult Getmoto()
        {
            return Ok (db.moto.ToList().ConvertAll(x=>new MotoModel(x)));
        }

        // GET: api/motoes/5
        [ResponseType(typeof(moto))]
        public IHttpActionResult Getmoto(int id)
        {
            moto moto = db.moto.Find(id);
            if (moto == null)
            {
                return NotFound();
            }

            return Ok(moto);
        }

        // PUT: api/motoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmoto(int id, moto moto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != moto.ID)
            {
                return BadRequest();
            }

            db.Entry(moto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!motoExists(id))
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

        // POST: api/motoes
        [ResponseType(typeof(moto))]
        public IHttpActionResult Postmoto(moto moto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.moto.Add(moto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = moto.ID }, moto);
        }

        // DELETE: api/motoes/5
        [ResponseType(typeof(moto))]
        public IHttpActionResult Deletemoto(int id)
        {
            moto moto = db.moto.Find(id);
            if (moto == null)
            {
                return NotFound();
            }

            db.moto.Remove(moto);
            db.SaveChanges();

            return Ok(moto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool motoExists(int id)
        {
            return db.moto.Count(e => e.ID == id) > 0;
        }
    }
}