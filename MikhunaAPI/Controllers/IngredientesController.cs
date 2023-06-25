using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using MikhunaAPI.Models;

namespace MikhunaAPI.Controllers
{
    public class IngredientesController : ApiController
    {
        private MikhunaDB db = new MikhunaDB();

        // GET: api/Ingredientes 
        public IQueryable<Ingredientes> GetIngredientes()
        {
            return db.Ingredientes;
        }

        // GET: api/Ingredientes/5
        [ResponseType(typeof(Ingredientes))]
        public IHttpActionResult GetIngredientes(int id)
        {
            Ingredientes ingredientes = db.Ingredientes.Find(id);
            if (ingredientes == null)
            {
                return NotFound();
            }

            return Ok(ingredientes);
        }

        // PUT: api/Ingredientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngredientes(int id, Ingredientes ingredientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredientes.IngredienteID)
            {
                return BadRequest();
            }

            db.Entry(ingredientes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientesExists(id))
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

        // POST: api/Ingredientes
        [ResponseType(typeof(Ingredientes))]
        public IHttpActionResult PostPasos(Ingredientes ingredientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ingredientes.Add(ingredientes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ingredientes.IngredienteID }, ingredientes);
        }

        // DELETE: api/Ingredientes/5
        [ResponseType(typeof(Ingredientes))]
        public IHttpActionResult DeleteIngredientes(int id)
        {
            Ingredientes ingredientes = db.Ingredientes.Find(id);
            if (ingredientes == null)
            {
                return NotFound();
            }

            db.Ingredientes.Remove(ingredientes);
            db.SaveChanges();

            return Ok(ingredientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientesExists(int id)
        {
            return db.Ingredientes.Count(e => e.IngredienteID == id) > 0;
        }
    }
}
