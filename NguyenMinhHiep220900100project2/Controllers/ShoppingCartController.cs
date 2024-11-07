using NguyenMinhHiep220900100project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenMinhHiep220900100project2.Controllers
{
    public class ShoppingCartController : Controller
    {
        // Giỏ hàng tĩnh
        private static ShoppingCart cart = new ShoppingCart();

        // Action xem giỏ hàng
        public ActionResult Index()
        {
            return View(cart.GetItems());
        }

        // Action thêm sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int maSanPham, string tenSanPham, decimal gia, int soLuong)
        {
            cart.AddItem(maSanPham, tenSanPham, gia, soLuong);
            return RedirectToAction("Index");
        }

        // Action cập nhật số lượng sản phẩm trong giỏ hàng
        [HttpPost]
        public ActionResult UpdateQuantity(int maSanPham, int soLuong)
        {
            cart.UpdateItemQuantity(maSanPham, soLuong);
            return RedirectToAction("Index");
        }

        // Action xóa sản phẩm khỏi giỏ hàng
        public ActionResult RemoveFromCart(int maSanPham)
        {
            cart.RemoveItem(maSanPham);
            return RedirectToAction("Index");
        }

        // Action "Mua Ngay" - Thêm sản phẩm vào giỏ hàng và đi đến trang thanh toán
        public ActionResult BuyNow(int maSanPham, int soLuong)
        {
            // Giả sử bạn đã có phương thức lấy thông tin sản phẩm từ database
            var sanPham = GetProductById(maSanPham);  // Thay thế với logic của bạn
            if (sanPham != null)
            {
                // Thêm sản phẩm vào giỏ hàng
                cart.AddItem(sanPham.MaSanPham, sanPham.Ten, sanPham.Gia, soLuong);
            }

            // Sau khi mua ngay, chuyển hướng đến giỏ hàng hoặc trang thanh toán
            return RedirectToAction("Checkout");
        }

        // Action thanh toán (chưa xử lý thực tế)
        public ActionResult Checkout()
        {
            // Xử lý thanh toán ở đây
            cart.Clear();  // Xóa giỏ hàng sau khi thanh toán
            return View();
        }

        // Phương thức giả để lấy sản phẩm từ database (thay bằng cách của bạn)
        private Product GetProductById(int maSanPham)
        {
            // Đây là ví dụ giả lập. Thay thế bằng việc lấy sản phẩm thực tế từ database.
            return new Product
            {
                MaSanPham = maSanPham,
                Ten = "Sản phẩm mẫu",
                Gia = 100000,
                MoTa = "Mô tả sản phẩm",
                ImageUrl = "/content/images/products/images.png"

            };
        }
    }

}
