using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RevisoChalangeApp.Models;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace RevisoChalangeApp.Controllers
{
    public class ActiveprojectsController : Controller
    {
        private RevisoContext db = new RevisoContext();

        // GET: Activeprojects
        public ActionResult Index()
        {
            return View(db.Activeprojects.ToList());
        }

        public PartialViewResult SelectHours(int id)
        {
            ViewBag.PId = id;
            List<Workinghour> wh = new List<Workinghour>(db.Workinghours.Where(i => i.PId == id));
            return PartialView("_SelectHours", wh.ToList());
        }

            /* public ActionResult SelectHours(int? id)
             {            
                 if (id == null)
                 {
                     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                 }
                 ViewBag.PId = id;
                 var idParameter = new MySqlParameter("ProjectId", MySqlDbType.Int32)
                 {
                     Value = id
                 };
                 var idParam = new MySqlParameter { ParameterName = "ProjectId", Value = id };
                 var wh = db.Workinghours.SqlQuery("selectprojectshours", idParameter).ToList();
                 //var result = db.Workinghours.SqlQuery("selectprojectshours", parameters:idParameter);
                 //var hs = db.Workinghours.SqlQuery("selectprojectshours", parameters:idParam);
                 return PartialView(wh.ToList());
             }*/


            // GET: Activeprojects/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activeproject activeproject = db.Activeprojects.Find(id);
            if (activeproject == null)
            {
                return HttpNotFound();
            }
            return View(activeproject);
        }

        // GET: Activeprojects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activeprojects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PName,AuthorName,CustomerName,StartDate,EndDate")] Activeproject activeproject)
        {
            if (ModelState.IsValid)
            {
                db.Activeprojects.Add(activeproject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activeproject);
        }

        // GET: Activeprojects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activeproject activeproject = db.Activeprojects.Find(id);
            if (activeproject == null)
            {
                return HttpNotFound();
            }
            return View(activeproject);
        }

        // POST: Activeprojects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PName,AuthorName,CustomerName,StartDate,EndDate")] Activeproject activeproject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activeproject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activeproject);
        }

        // GET: Activeprojects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activeproject activeproject = db.Activeprojects.Find(id);
            if (activeproject == null)
            {
                return HttpNotFound();
            }
            return View(activeproject);
        }

        // POST: Activeprojects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activeproject activeproject = db.Activeprojects.Find(id);
            db.Activeprojects.Remove(activeproject);
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
