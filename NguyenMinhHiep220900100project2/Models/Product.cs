using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NguyenMinhHiep220900100project2.Models;
namespace NguyenMinhHiep220900100project2.Models
{
    public class Product
    {
        public int MaSanPham { get; set; }  // Mã sản phẩm
        public string Ten { get; set; }     // Tên sản phẩm
        public decimal Gia { get; set; }    // Giá sản phẩm
        public string MoTa { get; set; }    // Mô tả sản phẩm
        public string ImageUrl { get; set; } // Đường dẫn ảnh sản phẩm
    }

}