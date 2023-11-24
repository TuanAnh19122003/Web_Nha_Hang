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
    public class HoadonController : Controller
    {
        private DBConnectNhaHang db = new DBConnectNhaHang();

        // GET: AdminArea/Hoadon
        public ActionResult Index()
        {
            var hoadons = db.Hoadons.Include(h => h.Khachhang).Include(h => h.Nhanvien);
            return View(hoadons.ToList());
        }

        // GET: AdminArea/Hoadon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        // GET: AdminArea/Hoadon/Create
        public ActionResult Create()
        {
            ViewBag.makh = new SelectList(db.Khachhangs, "makh", "tenkh");
            ViewBag.manv = new SelectList(db.Nhanviens, "manv", "macv");
            return View();
        }

        // POST: AdminArea/Hoadon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mahd,manv,makh,ngaythanhtoan,tongtien")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                db.Hoadons.Add(hoadon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.makh = new SelectList(db.Khachhangs, "makh", "tenkh", hoadon.makh);
            ViewBag.manv = new SelectList(db.Nhanviens, "manv", "macv", hoadon.manv);
            return View(hoadon);
        }

        // GET: AdminArea/Hoadon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            ViewBag.makh = new SelectList(db.Khachhangs, "makh", "tenkh", hoadon.makh);
            ViewBag.manv = new SelectList(db.Nhanviens, "manv", "macv", hoadon.manv);
            return View(hoadon);
        }

        // POST: AdminArea/Hoadon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mahd,manv,makh,ngaythanhtoan,tongtien")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoadon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.makh = new SelectList(db.Khachhangs, "makh", "tenkh", hoadon.makh);
            ViewBag.manv = new SelectList(db.Nhanviens, "manv", "macv", hoadon.manv);
            return View(hoadon);
        }

        // GET: AdminArea/Hoadon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        // POST: AdminArea/Hoadon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hoadon hoadon = db.Hoadons.Find(id);
            db.Hoadons.Remove(hoadon);
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
