using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Philosophers_v3.Models.DataAccess;
using Philosophers_v3.Models.Entities;

namespace Philosophers_v3.Controllers
{
    public class PhilosophersController : Controller
    {
        private PhilosopherLibraryContext db = new PhilosopherLibraryContext();

        // GET: Philosophers
        public ActionResult Index()
        {
            var philosophers = db.Philosophers.Include(p => p.Area).Include(p => p.Nationality);
            return View(philosophers.ToList());
        }

        // GET: Philosophers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Philosopher philosopher = db.Philosophers.Find(id);
            if (philosopher == null)
            {
                return HttpNotFound();
            }
            return View(philosopher);
        }

        // GET: Philosophers/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "AreaName");
            ViewBag.NationalityID = new SelectList(db.Nationalities, "ID", "NationalityName");
            return View();
        }

        // POST: Philosophers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FistName,LastName,DateOfBirth,DateOfDeath,IsAlive,NationalityID,AreaID,Description")] Philosopher philosopher)
        {
            if (ModelState.IsValid)
            {
                db.Philosophers.Add(philosopher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaID = new SelectList(db.Areas, "ID", "AreaName", philosopher.AreaID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "ID", "NationalityName", philosopher.NationalityID);
            return View(philosopher);
        }

        // GET: Philosophers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Philosopher philosopher = db.Philosophers.Find(id);
            if (philosopher == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "AreaName", philosopher.AreaID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "ID", "NationalityName", philosopher.NationalityID);
            return View(philosopher);
        }

        // POST: Philosophers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FistName,LastName,DateOfBirth,DateOfDeath,IsAlive,NationalityID,AreaID,Description")] Philosopher philosopher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(philosopher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "AreaName", philosopher.AreaID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "ID", "NationalityName", philosopher.NationalityID);
            return View(philosopher);
        }

        // GET: Philosophers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Philosopher philosopher = db.Philosophers.Find(id);
            if (philosopher == null)
            {
                return HttpNotFound();
            }
            return View(philosopher);
        }

        // POST: Philosophers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Philosopher philosopher = db.Philosophers.Find(id);
            db.Philosophers.Remove(philosopher);
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
