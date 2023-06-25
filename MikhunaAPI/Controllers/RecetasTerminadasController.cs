﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MikhunaAPI.Models;

namespace MikhunaAPI.Controllers
{
    public class RecetasTerminadasController : Controller
    {
        private MikhunaDB db = new MikhunaDB();

        // GET: RecetasTerminadas
        public ActionResult Index()
        {
            var recetasTerminadas = db.RecetasTerminadas.Include(r => r.Recetas).Include(r => r.Usuarios);
            return View(recetasTerminadas.ToList());
        }

        // GET: RecetasTerminadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecetasTerminadas recetasTerminadas = db.RecetasTerminadas.Find(id);
            if (recetasTerminadas == null)
            {
                return HttpNotFound();
            }
            return View(recetasTerminadas);
        }

        // GET: RecetasTerminadas/Create
        public ActionResult Create()
        {
            ViewBag.RecetaID = new SelectList(db.Recetas, "RecetaID", "Nombre");
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NickName");
            return View();
        }

        // POST: RecetasTerminadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecetaTerminadaID,RecetaID,UsuarioID")] RecetasTerminadas recetasTerminadas)
        {
            if (ModelState.IsValid)
            {
                db.RecetasTerminadas.Add(recetasTerminadas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecetaID = new SelectList(db.Recetas, "RecetaID", "Nombre", recetasTerminadas.RecetaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NickName", recetasTerminadas.UsuarioID);
            return View(recetasTerminadas);
        }

        // GET: RecetasTerminadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecetasTerminadas recetasTerminadas = db.RecetasTerminadas.Find(id);
            if (recetasTerminadas == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecetaID = new SelectList(db.Recetas, "RecetaID", "Nombre", recetasTerminadas.RecetaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NickName", recetasTerminadas.UsuarioID);
            return View(recetasTerminadas);
        }

        // POST: RecetasTerminadas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecetaTerminadaID,RecetaID,UsuarioID")] RecetasTerminadas recetasTerminadas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recetasTerminadas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecetaID = new SelectList(db.Recetas, "RecetaID", "Nombre", recetasTerminadas.RecetaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NickName", recetasTerminadas.UsuarioID);
            return View(recetasTerminadas);
        }

        // GET: RecetasTerminadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecetasTerminadas recetasTerminadas = db.RecetasTerminadas.Find(id);
            if (recetasTerminadas == null)
            {
                return HttpNotFound();
            }
            return View(recetasTerminadas);
        }

        // POST: RecetasTerminadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecetasTerminadas recetasTerminadas = db.RecetasTerminadas.Find(id);
            db.RecetasTerminadas.Remove(recetasTerminadas);
            db.SaveChanges();
            return RedirectToAction("Index");
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