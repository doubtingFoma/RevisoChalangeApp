using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RevisoChalangeApp.Models;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace RevisoChalangeApp.Controllers
{
    public class WorkinghoursController : Controller
    {
        private RevisoContext db = new RevisoContext();

        // GET: Workinghours
        public ActionResult Index()
        {
            var workinghours = db.Workinghours.Include(w => w.Activeproject);
            return View(workinghours.ToList());
        }


        public ActionResult Start(int id)
        {
            Workinghour workinghour = new Workinghour();
            workinghour.PId = id;
           
            db.Workinghours.Add(workinghour);
            //db.Entry(workinghour).State = EntityState.Modified;
            db.SaveChanges();
            db.Entry(workinghour).State = EntityState.Modified;
            return RedirectToAction("Index");   
  
        }
        public ActionResult Pause(int id)
        {
            
            foreach (var workinghour in db.Workinghours)
            {
                if (workinghour.PId == id && workinghour.EndDT == null)
                {
                    workinghour.EndDT = DateTime.Now;
                    db.Workinghours.Add(workinghour);
                    //db.Entry(workinghour).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            
           return RedirectToAction("Index");

        }
        public ActionResult Stop(int id)
        {
            var apId = db.Activeprojects.Find(id);
          
            Activeproject activeproject = db.Activeprojects.Find(id);
            activeproject.EndDate = DateTime.Now;
            db.Activeprojects.Add(activeproject);
            //db.Entry(workinghour).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Workinghours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workinghour workinghour = db.Workinghours.Find(id);
            if (workinghour == null)
            {
                return HttpNotFound();
            }
            return View(workinghour);
        }

        // GET: Workinghours/Create
        public ActionResult Create()
        {
            ViewBag.PId = new SelectList(db.Activeprojects, "Id", "PName");
            return View();
        }

        // POST: Workinghours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PId,StartDT,EndDT")] Workinghour workinghour)
        {
            if (ModelState.IsValid)
            {
                db.Workinghours.Add(workinghour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PId = new SelectList(db.Activeprojects, "Id", "PName", workinghour.PId);
            return View(workinghour);
        }

        // GET: Workinghours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workinghour workinghour = db.Workinghours.Find(id);
            if (workinghour == null)
            {
                return HttpNotFound();
            }
            ViewBag.PId = new SelectList(db.Activeprojects, "Id", "PName", workinghour.PId);
            return View(workinghour);
        }

        // POST: Workinghours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PId,StartDT,EndDT")] Workinghour workinghour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workinghour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PId = new SelectList(db.Activeprojects, "Id", "PName", workinghour.PId);
            return View(workinghour);
        }

        // GET: Workinghours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workinghour workinghour = db.Workinghours.Find(id);
            if (workinghour == null)
            {
                return HttpNotFound();
            }
            return View(workinghour);
        }

        // POST: Workinghours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workinghour workinghour = db.Workinghours.Find(id);
            db.Workinghours.Remove(workinghour);
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
