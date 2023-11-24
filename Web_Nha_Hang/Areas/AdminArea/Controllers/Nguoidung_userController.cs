using PagedList;
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
    public class Nguoidung_userController : Controller
    {
        private DBConnectNhaHang db = new DBConnectNhaHang();

        // GET: AdminArea/Nguoidung_user
        public ActionResult Index(int? page)
        {
            int pageSize = 5; // Số lượng sản phẩm trên mỗi trang
            int pageNumber = (page ?? 1);
            var model = db.Nguoidungs.Include(n => n.Quyen).OrderBy(b => b.mand).ToPagedList(pageNumber, pageSize);
            return View(model);
        }

        // GET: AdminArea/Nguoidung_user/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoidung nguoidung = db.Nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(nguoidung);
        }

        // GET: AdminArea/Nguoidung_user/Create
        public ActionResult Create()
        {
            ViewBag.maquyen = new SelectList(db.Quyens, "maquyen", "tenquyen");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mand,taikhoan,matkhau,anh,maquyen,email")] Nguoidung nguoidung, HttpPostedFileBase anh)
        {
            if (ModelState.IsValid)
            {
                if (anh != null && anh.ContentLength > 0)
                {
                    var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(anh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), newFileName);
                    anh.SaveAs(path);
                    nguoidung.anh = newFileName;
                }

                // Save the rest of the model and perform other necessary actions
                db.Nguoidungs.Add(nguoidung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maquyen = new SelectList(db.Quyens, "maquyen", "tenquyen", nguoidung.maquyen);
            return View(nguoidung);
        }


        // GET: AdminArea/Nguoidung_user/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoidung nguoidung = db.Nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            ViewBag.maquyen = new SelectList(db.Quyens, "maquyen", "tenquyen", nguoidung.maquyen);
            return View(nguoidung);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mand,taikhoan,matkhau,anh,maquyen,email")] Nguoidung nguoidung, HttpPostedFileBase anh)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (anh != null && anh.ContentLength > 0)
                {
                    var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(anh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), newFileName);
                    anh.SaveAs(path);
                    nguoidung.anh = newFileName;
                }

                // Update the existing model and perform other necessary actions
                db.Entry(nguoidung).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.maquyen = new SelectList(db.Quyens, "maquyen", "tenquyen", nguoidung.maquyen);
            return View(nguoidung);
        }


        // GET: AdminArea/Nguoidung_user/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoidung nguoidung = db.Nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(nguoidung);
        }

        // POST: AdminArea/Nguoidung_user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nguoidung nguoidung = db.Nguoidungs.Find(id);
            db.Nguoidungs.Remove(nguoidung);
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
