using MikhunaAPI.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace MikhunaAPI.Controllers
{
    public class CalificacionsController : ApiController
    {
        private MikhunaDB db = new MikhunaDB();

        // GET: api/Calificacions 
        public IQueryable<Calificacions> GetCalificacions()
        {
            return db.Calificacions;
        }

        // GET: api/Calificacions/5
        [ResponseType(typeof(Calificacions))]
        public IHttpActionResult GetCalificacions(int id)
        {
            Calificacions calificacions = db.Calificacions.Find(id);
            if (calificacions == null)
            {
                return NotFound();
            }

            return Ok(calificacions);
        }

        // PUT: api/Calificacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFavoritos(int id, Calificacions calificacions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calificacions.CalificacionID)
            {
                return BadRequest();
            }

            db.Entry(calificacions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionsExists(id))
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

        // POST: api/Calificacions
        [ResponseType(typeof(Calificacions))]
        public IHttpActionResult PostCalificacions(Calificacions calificacions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calificacions.Add(calificacions);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calificacions.CalificacionID }, calificacions);
        }

        // DELETE: api/Calificacions/5
        [ResponseType(typeof(Calificacions))]
        public IHttpActionResult DeleteCalificacion(int id)
        {
            Calificacions calificacions = db.Calificacions.Find(id);
            if (calificacions == null)
            {
                return NotFound();
            }

            db.Calificacions.Remove(calificacions);
            db.SaveChanges();

            return Ok(calificacions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalificacionsExists(int id)
        {
            return db.Calificacions.Count(e => e.CalificacionID == id) > 0;
        }
    }
}
