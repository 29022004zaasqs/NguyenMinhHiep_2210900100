using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using NguyenMinhHiep220900100project2.Models;

namespace NguyenMinhHiep220900100project2.Controllers
{
    public class AccountController : Controller
    {
        private QLBH2210900100NMH_Entities1 db = new QLBH2210900100NMH_Entities1();

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra tên đăng nhập và mật khẩu
                var user = db.NguoiDung.FirstOrDefault(u => u.TenDangNhap == model.TenDangNhap && u.MatKhauHash == HashPassword(model.MatKhau));
                if (user != null)
                {
                    // Đăng nhập thành công, chuyển hướng đến trang chủ
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
            return View(model);
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra tên đăng nhập đã tồn tại
                if (db.NguoiDung.Any(u => u.TenDangNhap == model.TenDangNhap))
                {
                    ModelState.AddModelError("TenDangNhap", "Tên đăng nhập đã tồn tại.");
                    return View(model);
                }

                // Tạo người dùng mới
                NguoiDung newUser = new NguoiDung
                {
                    TenDangNhap = model.TenDangNhap,
                    MatKhauHash = HashPassword(model.MatKhau),
                    VaiTro = "Khách hàng",
                    NgayTao = DateTime.Now,
                    NgayCapNhat = DateTime.Now
                };

                db.NguoiDung.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // Phương thức băm mật khẩu
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
