using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenMinhHiep220900100project2.Models
{
    public class ShoppingCart
{
    private List<CartItem> items = new List<CartItem>();  // Danh sách sản phẩm trong giỏ hàng

    // Thêm sản phẩm vào giỏ hàng
    public void AddItem(int maSanPham, string tenSanPham, decimal gia, int soLuong)
    {
        var existingItem = items.FirstOrDefault(i => i.MaSanPham == maSanPham);
        if (existingItem == null)
        {
            items.Add(new CartItem { MaSanPham = maSanPham, TenSanPham = tenSanPham, Gia = gia, SoLuong = soLuong });
        }
        else
        {
            existingItem.SoLuong += soLuong;  // Cập nhật số lượng nếu sản phẩm đã có trong giỏ hàng
        }
    }

    // Xóa sản phẩm khỏi giỏ hàng
    public void RemoveItem(int maSanPham)
    {
        items.RemoveAll(i => i.MaSanPham == maSanPham);
    }

    // Cập nhật số lượng sản phẩm
    public void UpdateItemQuantity(int maSanPham, int newQuantity)
    {
        var item = items.FirstOrDefault(i => i.MaSanPham == maSanPham);
        if (item != null)
        {
            item.SoLuong = newQuantity;
            if (item.SoLuong <= 0)
            {
                RemoveItem(maSanPham);  // Xóa sản phẩm nếu số lượng bằng 0
            }
        }
    }

    // Tính tổng giá trị giỏ hàng
    public decimal GetTotal()
    {
        return items.Sum(i => i.Gia * i.SoLuong);
    }

    // Lấy danh sách sản phẩm trong giỏ hàng
    public List<CartItem> GetItems()
    {
        return items;
    }

    // Xóa tất cả sản phẩm trong giỏ hàng
    public void Clear()
    {
        items.Clear();
    }
}
}