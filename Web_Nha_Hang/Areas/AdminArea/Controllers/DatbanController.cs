using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Web_Nha_Hang.Models;

namespace Web_Nha_Hang.Areas.AdminArea.Controllers
{
    public class DatbanController : Controller
    {
        private DBConnectNhaHang db = new DBConnectNhaHang();

        // GET: AdminArea/Datban
        public ActionResult Index(int? page)
        {
            int pageSize = 5; // Số lượng sản phẩm trên mỗi trang
            int pageNumber = (page ?? 1);
            var model = db.Datbans.Include(d => d.Ban).OrderBy(b => b.madb).ToPagedList(pageNumber, pageSize);
            return View(model);
        }

        // GET: AdminArea/Datban/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datban datban = db.Datbans.Find(id);
            if (datban == null)
            {
                return HttpNotFound();
            }
            return View(datban);
        }

        // GET: AdminArea/Datban/Create
        public ActionResult Create()
        {
            ViewBag.maban = new SelectList(db.Bans, "maban", "tenban");
            return View();
        }

        // POST: AdminArea/Datban/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "madb,maban,hoten,sdt,soluongkh,ngaydat,ghichu")] Datban datban)
        {
            if (ModelState.IsValid)
            {
                db.Datbans.Add(datban);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maban = new SelectList(db.Bans, "maban", "tenban", datban.maban);
            return View(datban);
        }

        // GET: AdminArea/Datban/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datban datban = db.Datbans.Find(id);
            if (datban == null)
            {
                return HttpNotFound();
            }
            ViewBag.maban = new SelectList(db.Bans, "maban", "tenban", datban.maban);
            return View(datban);
        }

        // POST: AdminArea/Datban/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "madb,maban,hoten,sdt,soluongkh,ngaydat,ghichu")] Datban datban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datban).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maban = new SelectList(db.Bans, "maban", "tenban", datban.maban);
            return View(datban);
        }

        // GET: AdminArea/Datban/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datban datban = db.Datbans.Find(id);
            if (datban == null)
            {
                return HttpNotFound();
            }
            return View(datban);
        }

        // POST: AdminArea/Datban/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Datban datban = db.Datbans.Find(id);
            db.Datbans.Remove(datban);
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
