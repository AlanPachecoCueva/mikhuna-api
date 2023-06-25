using MikhunaAPI.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace MikhunaAPI.Controllers
{
    public class RecetasController : ApiController
    {
        private MikhunaDB db = new MikhunaDB();

        // GET: api/Recetas 
        public IQueryable<Recetas> GetRecetas()
        {
            return db.Recetas;
        }

        // GET: api/Recetas/5
        [ResponseType(typeof(Recetas))]
        public IHttpActionResult GetRecetas(int id)
        {
            Recetas recetas = db.Recetas.Find(id);
            
            if (recetas == null)
            {
                
                return NotFound();
            }


            //Si la receta existe

            //Recuperamos los pasos de esa receta
            var aux = from b in db.Pasos
                      where b.RecetaID == id
                      select b;


            recetas.Pasos = aux.ToList();  

            //Recuperamos los ingredientes de esa receta
            var auxIngre = from b in db.Ingredientes
                           where b.RecetaID == id
                           select b;


            recetas.Ingredientes = auxIngre.ToList();

            //Recuperamos los comentarios de esa receta
            var auxComen = from b in db.Comentarios
                           where b.RecetaID == id
                           select b;


            recetas.Comentarios = auxComen.ToList();

            return Ok(recetas);
        }

        // PUT: api/Recetas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecetas(int id, Recetas recetas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recetas.RecetaID)
            {
                return BadRequest();
            }

            db.Entry(recetas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetasExists(id))
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

        // POST: api/Recetas
        [ResponseType(typeof(Recetas))]
        public IHttpActionResult PostRecetas(Recetas recetas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recetas.Add(recetas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recetas.RecetaID }, recetas);
        }

        // DELETE: api/Recetas/5
        [ResponseType(typeof(Recetas))]
        public IHttpActionResult DeleteReceta(int id)
        {
            Recetas recetas = db.Recetas.Find(id);
            if (recetas == null)
            {
                return NotFound();
            }

            db.Recetas.Remove(recetas);
            db.SaveChanges();

            return Ok(recetas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecetasExists(int id)
        {
            return db.Recetas.Count(e => e.RecetaID == id) > 0;
        }
    }
}
