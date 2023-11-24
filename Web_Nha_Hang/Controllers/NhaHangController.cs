using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Nha_Hang.Models;

namespace Web_Nha_Hang.Controllers
{
    public class NhaHangController : Controller
    {
        // GET: NhaHang
        private DBConnectNhaHang db = new DBConnectNhaHang();
        public ActionResult HomePage()
        {
            ViewBag.Username = Session["user"] as string;
            var listMenu = new DBConnectNhaHang().Monans.ToList();
            return View(listMenu);
        }
        public ActionResult Introduce()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult SpecialOffer()
        {
            return View();
        }
        public ActionResult Menu()
        {
            var listMenu = new DBConnectNhaHang().Monans.Include("DanhMuc").ToList();
            var listDanhMuc = new DBConnectNhaHang().Danhmucs.ToList(); // Thay DBConnectNhaHang bằng tên phù hợp
            ViewBag.ListDanhMuc = listDanhMuc;
            return View(listMenu);
        }
        public ActionResult MenuDetail(int id)
        {
            var product = new DBConnectNhaHang().Monans.FirstOrDefault(p => p.mamon == id);

            if (product == null)
            {
                return HttpNotFound(); // Hoặc chuyển hướng đến trang 404
            }

            return View(product);
        }
        public ActionResult Reserve_a_table([Bind(Include = "madb,maban,hoten,sdt,soluongkh,ngaydat,ghichu")] Datban datban)
        {

            if (ModelState.IsValid)
            {
                db.Datbans.Add(datban);
                db.SaveChanges();
                return RedirectToAction("Reserve_a_table");
            }

            ModelState.Clear();
            TempData["SuccessMessage"] = "Đặt bàn thành công!";
            ViewBag.maban = new SelectList(db.Bans, "maban", "tenban", datban.maban);
            return View(datban);
        }

    }
}