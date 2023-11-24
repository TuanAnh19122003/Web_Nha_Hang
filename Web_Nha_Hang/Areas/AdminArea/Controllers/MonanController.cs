using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Web_Nha_Hang.Models;

namespace Web_Nha_Hang.Areas.AdminArea.Controllers
{
    public class MonanController : Controller
    {
        private DBConnectNhaHang db = new DBConnectNhaHang();

        // GET: AdminArea/Monan
        public ActionResult Index(int? page)
        {
            int pageSize = 5; // Số lượng sản phẩm trên mỗi trang
            int pageNumber = (page ?? 1);
            var model = db.Monans.Include(m => m.Danhmuc).OrderBy(b => b.mamon).ToPagedList(pageNumber, pageSize);
            return View(model);
        }

        // GET: AdminArea/Monan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monan monan = db.Monans.Find(id);
            if (monan == null)
            {
                return HttpNotFound();
            }
            return View(monan);
        }

        // GET: AdminArea/Monan/Create
        public ActionResult Create()
        {
            ViewBag.madm = new SelectList(db.Danhmucs, "madm", "tendm");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mamon,tenmon,madm,anh,giatien,mota")] Monan monan, HttpPostedFileBase anh)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (anh != null && anh.ContentLength > 0)
                {
                    var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(anh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), newFileName);
                    anh.SaveAs(path);
                    monan.anh = newFileName;

                }

                // Save the rest of the model and perform other necessary actions
                db.Monans.Add(monan);
                db.SaveChanges();

                // Redirect to the Index action
                return RedirectToAction("Index");
            }

            ViewBag.madm = new SelectList(db.Danhmucs, "madm", "tendm", monan.madm);
            return View(monan);
        }


        // GET: AdminArea/Monan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monan monan = db.Monans.Find(id);
            if (monan == null)
            {
                return HttpNotFound();
            }
            ViewBag.madm = new SelectList(db.Danhmucs, "madm", "tendm", monan.madm);
            return View(monan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mamon,tenmon,madm,anh,giatien,mota")] Monan monan, HttpPostedFileBase anh)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (anh != null && anh.ContentLength > 0)
                {
                    var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(anh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), newFileName);
                    anh.SaveAs(path);
                    monan.anh = newFileName;
                }

                // Update the existing model and perform other necessary actions
                db.Entry(monan).State = EntityState.Modified;
                db.SaveChanges();

                // Redirect to the Index action
                return RedirectToAction("Index");
            }

            ViewBag.madm = new SelectList(db.Danhmucs, "madm", "tendm", monan.madm);
            return View(monan);
        }

        // GET: AdminArea/Monan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monan monan = db.Monans.Find(id);
            if (monan == null)
            {
                return HttpNotFound();
            }
            return View(monan);
        }

        // POST: AdminArea/Monan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Monan monan = db.Monans.Find(id);
            db.Monans.Remove(monan);
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
