using Microsoft.AspNet.Identity;
using Microsoft.Azure.Mobile.Server;
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
using XDogService.Models;

namespace XDogService.Controllers
{
    public class DogOwnersController : TableController<DogOwner>
    {
        private DogOwnerContext db = new DogOwnerContext();

        // GET: api/DogOwners
        public IQueryable<DogOwner> GetDogOwners()
        {
            return db.DogOwners;
        }

        // GET: api/DogOwners/5
        [ResponseType(typeof(DogOwner))]
        public IHttpActionResult GetDogOwner(string id)
        {
            DogOwner dogOwner = db.DogOwners.Find(id);
            if (dogOwner == null)
            {
                return NotFound();
            }

            return Ok(dogOwner);
        }

        // PUT: api/DogOwners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDogOwner(string id, DogOwner dogOwner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dogOwner.Id)
            {
                return BadRequest();
            }

            db.Entry(dogOwner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogOwnerExists(id))
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

        // POST: api/DogOwners
        [ResponseType(typeof(DogOwner))]
        public IHttpActionResult PostDogOwner(DogOwner dogOwner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dogOwner.UserId = User.Identity.GetUserId();

            db.DogOwners.Add(dogOwner);


            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DogOwnerExists(dogOwner.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dogOwner.Id }, dogOwner);
        }

        // DELETE: api/DogOwners/5
        [ResponseType(typeof(DogOwner))]
        public IHttpActionResult DeleteDogOwner(string id)
        {
            DogOwner dogOwner = db.DogOwners.Find(id);
            if (dogOwner == null)
            {
                return NotFound();
            }

            db.DogOwners.Remove(dogOwner);
            db.SaveChanges();

            return Ok(dogOwner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DogOwnerExists(string id)
        {
            return db.DogOwners.Count(e => e.Id == id) > 0;
        }
    }
}