using MikhunaAPI.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace MikhunaAPI.Controllers
{
    public class FavoritosController : ApiController
    {
        private MikhunaDB db = new MikhunaDB();

        // GET: api/Favoritos 
        public IQueryable<Favoritos> GetFavoritos()
        {
            return db.Favoritos;
        }

        // GET: api/Favoritos/5
        [ResponseType(typeof(Favoritos))]
        public IHttpActionResult GetFavoritos(int id)
        {
            Favoritos favoritos = db.Favoritos.Find(id);
            if (favoritos == null)
            {
                return NotFound();
            }

            return Ok(favoritos);
        }

        // PUT: api/Favoritos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFavoritos(int id, Favoritos favoritos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favoritos.FavoritosID)
            {
                return BadRequest();
            }

            db.Entry(favoritos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoritosExists(id))
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

        // POST: api/Favoritos
        [ResponseType(typeof(Favoritos))]
        public IHttpActionResult PostFavoritos(Favoritos favoritos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Favoritos.Add(favoritos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = favoritos.FavoritosID }, favoritos);
        }

        // DELETE: api/Favoritos/5
        [ResponseType(typeof(Favoritos))]
        public IHttpActionResult DeleteFavorito(int id)
        {
            Favoritos favoritos = db.Favoritos.Find(id);
            if (favoritos == null)
            {
                return NotFound();
            }

            db.Favoritos.Remove(favoritos);
            db.SaveChanges();

            return Ok(favoritos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FavoritosExists(int id)
        {
            return db.Favoritos.Count(e => e.FavoritosID == id) > 0;
        }
    }
}
