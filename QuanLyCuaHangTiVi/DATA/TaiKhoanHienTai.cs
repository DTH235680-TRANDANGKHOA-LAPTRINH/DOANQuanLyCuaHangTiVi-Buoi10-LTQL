using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTiVi.DATA
{
    public static class TaiKhoanHienTai
    {
        // Biến này sẽ lưu toàn bộ thông tin của nhân viên đang đăng nhập
        public static NhanVien NhanVienDangNhap { get; set; }

        // Hàm hỗ trợ kiểm tra nhanh có phải quản lý không
        public static bool LaQuanLy()
        {
            if (NhanVienDangNhap != null && NhanVienDangNhap.QuyenHan == "Quản lý")
            {
                return true;
            }
            return false;
        }
    }
}
