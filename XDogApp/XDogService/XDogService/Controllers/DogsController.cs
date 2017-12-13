using ClientServerData.DataObjects;
using Microsoft.AspNet.Identity;
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
    public class DogsController : ApiController
    {
        private DogContext db = new DogContext();

        // GET: api/Dogs
        public IQueryable<Dog> GetDogs()
        {
            return db.Dogs;
        }

        // GET: api/Dogs/5
        [ResponseType(typeof(Dog))]
        public IHttpActionResult GetDog(string id)
        {
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return NotFound();
            }

            return Ok(dog);
        }

        // PUT: api/Dogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDog(string id, Dog dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dog.Id)
            {
                return BadRequest();
            }

            db.Entry(dog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(id))
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

        // POST: api/Dogs
        [ResponseType(typeof(Dog))]
        public IHttpActionResult PostDog(Dog dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dog.MainOwnerUserId = User.Identity.GetUserId();

            db.Dogs.Add(dog);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DogExists(dog.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dog.Id }, dog);
        }

        // DELETE: api/Dogs/5
        [ResponseType(typeof(Dog))]
        public IHttpActionResult DeleteDog(string id)
        {
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return NotFound();
            }

            db.Dogs.Remove(dog);
            db.SaveChanges();

            return Ok(dog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DogExists(string id)
        {
            return db.Dogs.Count(e => e.Id == id) > 0;
        }
    }
}