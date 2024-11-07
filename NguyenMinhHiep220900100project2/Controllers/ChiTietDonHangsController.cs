using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NguyenMinhHiep220900100project2.Models;

namespace NguyenMinhHiep220900100project2.Controllers
{
    public class ChiTietDonHangsController : Controller
    {
        private QLBH2210900100NMH_Entities1 db = new QLBH2210900100NMH_Entities1();

        // GET: ChiTietDonHangs
        public ActionResult Index()
        {
            var chiTietDonHang = db.ChiTietDonHang.Include(c => c.DonHang).Include(c => c.SanPham);
            return View(chiTietDonHang.ToList());
        }

        // GET: ChiTietDonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaDonHang = new SelectList(db.DonHang, "MaDonHang", "TrangThai");
            ViewBag.MaSanPham = new SelectList(db.SanPham, "MaSanPham", "Ten");
            return View();
        }

        // POST: ChiTietDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChiTietDonHang,MaDonHang,MaSanPham,SoLuong,Gia,NgayTao,NgayCapNhat")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDonHang.Add(chiTietDonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDonHang = new SelectList(db.DonHang, "MaDonHang", "TrangThai", chiTietDonHang.MaDonHang);
            ViewBag.MaSanPham = new SelectList(db.SanPham, "MaSanPham", "Ten", chiTietDonHang.MaSanPham);
            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDonHang = new SelectList(db.DonHang, "MaDonHang", "TrangThai", chiTietDonHang.MaDonHang);
            ViewBag.MaSanPham = new SelectList(db.SanPham, "MaSanPham", "Ten", chiTietDonHang.MaSanPham);
            return View(chiTietDonHang);
        }

        // POST: ChiTietDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChiTietDonHang,MaDonHang,MaSanPham,SoLuong,Gia,NgayTao,NgayCapNhat")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietDonHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDonHang = new SelectList(db.DonHang, "MaDonHang", "TrangThai", chiTietDonHang.MaDonHang);
            ViewBag.MaSanPham = new SelectList(db.SanPham, "MaSanPham", "Ten", chiTietDonHang.MaSanPham);
            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // POST: ChiTietDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            db.ChiTietDonHang.Remove(chiTietDonHang);
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
