using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webEval.Models;

namespace webEval.Controllers
{
    public class EvalsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Evals
        public ActionResult Index()
        {
            return View(db.Evals.ToList());
        }

        // GET: Evals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eval eval = db.Evals.Find(id);
            if (eval == null)
            {
                return HttpNotFound();
            }
            return View(eval);
        }

        // GET: Evals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdStudent,Name")] Eval eval)
        {
            if (ModelState.IsValid)
            {
                db.Evals.Add(eval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eval);
        }

        // GET: Evals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eval eval = db.Evals.Find(id);
            if (eval == null)
            {
                return HttpNotFound();
            }
            return View(eval);
        }

        // POST: Evals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdStudent,Name")] Eval eval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eval);
        }

        // GET: Evals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eval eval = db.Evals.Find(id);
            if (eval == null)
            {
                return HttpNotFound();
            }
            return View(eval);
        }

        // POST: Evals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eval eval = db.Evals.Find(id);
            db.Evals.Remove(eval);
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
