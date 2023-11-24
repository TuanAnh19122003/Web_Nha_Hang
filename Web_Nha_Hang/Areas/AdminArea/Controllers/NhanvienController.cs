using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Nha_Hang.Models;

namespace Web_Nha_Hang.Areas.AdminArea.Controllers
{
    public class NhanvienController : Controller
    {
        private DBConnectNhaHang db = new DBConnectNhaHang();

        // GET: AdminArea/Nhanvien
        public ActionResult Index()
        {
            var nhanviens = db.Nhanviens.Include(n => n.Chucvu);
            return View(nhanviens.ToList());
        }

        // GET: AdminArea/Nhanvien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // GET: AdminArea/Nhanvien/Create
        public ActionResult Create()
        {
            ViewBag.macv = new SelectList(db.Chucvus, "macv", "tencv");
            return View();
        }

        // POST: AdminArea/Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "manv,macv,tennv,anh,sdt,diachi,gioitinh,ngsinh")] Nhanvien nhanvien, HttpPostedFileBase anh)
        {
            if (ModelState.IsValid)
            {
                if (anh != null && anh.ContentLength > 0)
                {
                    var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(anh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), newFileName);
                    anh.SaveAs(path);
                    nhanvien.anh = newFileName;
                }

                // Save the rest of the model and perform other necessary actions
                db.Nhanviens.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.macv = new SelectList(db.Chucvus, "macv", "tencv", nhanvien.macv);
            return View(nhanvien);
        }

        // GET: AdminArea/Nhanvien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.macv = new SelectList(db.Chucvus, "macv", "tencv", nhanvien.macv);
            return View(nhanvien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "manv,macv,tennv,anh,sdt,diachi,gioitinh,ngsinh")] Nhanvien nhanvien, HttpPostedFileBase anh)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (anh != null && anh.ContentLength > 0)
                {
                    var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(anh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), newFileName);
                    anh.SaveAs(path);
                    nhanvien.anh = newFileName;
                }

                // Update the existing model and perform other necessary actions
                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.macv = new SelectList(db.Chucvus, "macv", "tencv", nhanvien.macv);
            return View(nhanvien);
        }

        // GET: AdminArea/Nhanvien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // POST: AdminArea/Nhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            db.Nhanviens.Remove(nhanvien);
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
