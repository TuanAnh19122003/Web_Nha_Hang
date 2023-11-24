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
using System.Web.UI;
using Web_Nha_Hang.Models;

namespace Web_Nha_Hang.Areas.AdminArea.Controllers
{
    public class KhachhangController : Controller
    {
        private DBConnectNhaHang db = new DBConnectNhaHang();

        // GET: AdminArea/Khachhang
        public ActionResult Index(int? page)
        {
            int pageSize = 5; // Số lượng sản phẩm trên mỗi trang
            int pageNumber = (page ?? 1);
            var model = db.Khachhangs.OrderBy(b => b.makh).ToPagedList(pageNumber, pageSize);
            return View(model);
        }

        // GET: AdminArea/Khachhang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // GET: AdminArea/Khachhang/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "makh,tenkh,anh,sdt,email,diachi")] Khachhang khachhang, HttpPostedFileBase anh)
        {
            if (ModelState.IsValid)
            {
                if (anh != null && anh.ContentLength > 0)
                {
                    var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(anh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), newFileName);
                    anh.SaveAs(path);
                    khachhang.anh = newFileName;
                }

                // Save the rest of the model and perform other necessary actions
                db.Khachhangs.Add(khachhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachhang);
        }


        // GET: AdminArea/Khachhang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "makh,tenkh,anh,sdt,email,diachi")] Khachhang khachhang, HttpPostedFileBase anh) {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem có tập tin ảnh mới được chọn hay không
                if (anh != null && anh.ContentLength > 0)
                {
                    // Nếu có, thì thực hiện upload tập tin mới và cập nhật đường dẫn trong model
                    var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(anh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), newFileName);
                    anh.SaveAs(path);
                    khachhang.anh = newFileName;
                }
                else
                {
                    // Nếu không có tập tin mới, giữ nguyên đường dẫn ảnh hiện tại trong model
                    khachhang.anh = db.Khachhangs.Where(k => k.makh == khachhang.makh).Select(k => k.anh).FirstOrDefault();
                }

                // Cập nhật thông tin khác trong model và lưu vào cơ sở dữ liệu
                db.Entry(khachhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachhang);

        }

        // GET: AdminArea/Khachhang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // POST: AdminArea/Khachhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Khachhang khachhang = db.Khachhangs.Find(id);
            db.Khachhangs.Remove(khachhang);
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
