using MikhunaAPI.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace MikhunaAPI.Controllers
{
    public class PasosController : ApiController
    {
        private MikhunaDB db = new MikhunaDB();

        // GET: api/Pasos 
        public IQueryable<Pasos> GetPasos()
        {
            return db.Pasos;
        }

        // GET: api/Pasos/5
        [ResponseType(typeof(Pasos))]
        public IHttpActionResult GetPasos(int id)
        {
            Pasos pasos = db.Pasos.Find(id);
            if (pasos == null)
            {
                return NotFound();
            }

            return Ok(pasos);
        }

        // PUT: api/Pasos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPasos(int id, Pasos pasos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pasos.PasosID)
            {
                return BadRequest();
            }

            db.Entry(pasos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasosExists(id))
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

        // POST: api/Pasos
        [ResponseType(typeof(Pasos))]
        public IHttpActionResult PostPasos(Pasos pasos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pasos.Add(pasos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pasos.PasosID }, pasos);
        }

        // DELETE: api/Pasos/5
        [ResponseType(typeof(Pasos))]
        public IHttpActionResult DeletePasos(int id)
        {
            Pasos pasos = db.Pasos.Find(id);
            if (pasos == null)
            {
                return NotFound();
            }

            db.Pasos.Remove(pasos);
            db.SaveChanges();

            return Ok(pasos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PasosExists(int id)
        {
            return db.Pasos.Count(e => e.PasosID == id) > 0;
        }
    }
}
