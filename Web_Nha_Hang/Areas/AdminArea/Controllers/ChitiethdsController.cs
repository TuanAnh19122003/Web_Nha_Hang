using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Nha_Hang.Models;

namespace Web_Nha_Hang.Areas.AdminArea.Controllers
{
    public class ChitiethdsController : Controller
    {
        private DBConnectNhaHang db = new DBConnectNhaHang();

        // GET: AdminArea/Chitiethds
        public ActionResult Index(int? page)
        {
/*          var chitiethds = db.Chitiethds.Include(c => c.Hoadon);
            return View(chitiethds.ToList());*/
            int pageSize = 5;
            int pageNumber = page ?? 1;
            var model = db.Chitiethds.Include(c => c.Hoadon).OrderBy(c => c.macthd).ToPagedList(pageNumber, pageSize);

            return View(model);
        }

        // GET: AdminArea/Chitiethds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiethd chitiethd = db.Chitiethds.Find(id);
            if (chitiethd == null)
            {
                return HttpNotFound();
            }
            return View(chitiethd);
        }

        // GET: AdminArea/Chitiethds/Create
        public ActionResult Create()
        {
            ViewBag.mahd = new SelectList(db.Hoadons, "mahd", "mahd");
            ViewBag.mamon = new SelectList(db.Monans, "mamon", "tenmon");
            return View();
        }

        // POST: AdminArea/Chitiethds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "macthd,mahd,mamon,soluong,dongia,thanhtien")] Chitiethd chitiethd)
        {
            if (ModelState.IsValid)
            {
                db.Chitiethds.Add(chitiethd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mahd = new SelectList(db.Hoadons, "mahd", "mahd", chitiethd.mahd);
            ViewBag.mamon = new SelectList(db.Monans, "mamon", "tenmon", chitiethd.mamon);

            return View(chitiethd);
        }

        // GET: AdminArea/Chitiethds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiethd chitiethd = db.Chitiethds.Find(id);
            if (chitiethd == null)
            {
                return HttpNotFound();
            }
            ViewBag.mahd = new SelectList(db.Hoadons, "mahd", "mahd", chitiethd.mahd);
            return View(chitiethd);
        }

        // POST: AdminArea/Chitiethds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "macthd,mahd,mamon,soluong,dongia,thanhtien")] Chitiethd chitiethd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitiethd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mahd = new SelectList(db.Hoadons, "mahd", "mahd", chitiethd.mahd);
            return View(chitiethd);
        }

        // GET: AdminArea/Chitiethds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiethd chitiethd = db.Chitiethds.Find(id);
            if (chitiethd == null)
            {
                return HttpNotFound();
            }
            return View(chitiethd);
        }

        // POST: AdminArea/Chitiethds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitiethd chitiethd = db.Chitiethds.Find(id);
            db.Chitiethds.Remove(chitiethd);
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
