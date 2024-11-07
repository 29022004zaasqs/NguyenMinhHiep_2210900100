using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenMinhHiep220900100project2.Models
{
    public class CartItem
    {
        public int MaSanPham { get; set; }  // Mã sản phẩm
        public string TenSanPham { get; set; }  // Tên sản phẩm
        public decimal Gia { get; set; }  // Giá sản phẩm
        public int SoLuong { get; set; }  // Số lượng sản phẩm
    }
}
