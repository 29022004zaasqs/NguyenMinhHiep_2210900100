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
    public class SanPhamsController : Controller
    {
        private QLBH2210900100NMH_Entities1 db = new QLBH2210900100NMH_Entities1();

        // GET: SanPhams
        public ActionResult Index()
        {
            var sanPham = db.SanPham.Include(s => s.DanhMuc).ToList();
            return View(sanPham);
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            var danhMucs = db.DanhMuc.ToList();
            if (danhMucs == null || !danhMucs.Any())
            {
                // Nếu không có danh mục, bạn có thể hiển thị thông báo hoặc làm gì đó
                ViewBag.MaDanhMuc = new SelectList(new List<DanhMuc>(), "MaDanhMuc", "TenDanhMuc");
            }
            else
            {
                ViewBag.MaDanhMuc = new SelectList(danhMucs, "MaDanhMuc", "TenDanhMuc");
            }
            return View();
        }

        // POST: SanPhams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,Ten,MoTa,Gia,TonKho,MaDanhMuc,NgayTao,NgayCapNhat")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var danhMucs = db.DanhMuc.ToList();
            ViewBag.MaDanhMuc = new SelectList(danhMucs, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            var danhMucs = db.DanhMuc.ToList();
            ViewBag.MaDanhMuc = new SelectList(danhMucs, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,Ten,MoTa,Gia,TonKho,MaDanhMuc,NgayTao,NgayCapNhat")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var danhMucs = db.DanhMuc.ToList();
            ViewBag.MaDanhMuc = new SelectList(danhMucs, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
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
