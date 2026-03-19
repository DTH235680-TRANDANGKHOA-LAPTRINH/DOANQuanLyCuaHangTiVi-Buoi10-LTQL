
USE QuanLyCuaHangTiVi; -- Nhớ đổi tên này nếu Database của bạn tên khác nhé
GO

-- ========================================================
-- PHẦN 1: LỆNH XÓA SẠCH DỮ LIỆU (Dọn dẹp trước khi nạp mới)
-- ========================================================
-- Lưu ý: Phải xóa bảng ChiTiet trước vì nó chứa khóa ngoại trỏ về các bảng khác
DELETE FROM ChiTietPhieuNhap;
DELETE FROM PhieuNhap;
DELETE FROM HoaDonChiTiet;
DELETE FROM HoaDon;

-- Sau đó mới xóa các bảng danh mục chính
DELETE FROM QuanLyTiVi;
DELETE FROM NhanVien;
DELETE FROM KhachHang;
GO

-- ========================================================
-- PHẦN 2: THÊM DỮ LIỆU MẪU ĐỂ CHẠY THỬ (INSERT)
-- ========================================================

-- 1. Thêm 3 dữ liệu bảng Nhân Viên
INSERT INTO NhanVien (MaNhanVien, HoTenNhanVien, TenDangNhap, MatKhau, QuyenHan, AnhChanDung, Luong)
VALUES 
('NV01', N'Trần Văn Sếp', 'chuquan', '123', N'Chủ quán', 'chuquan.jpg', 25000000),
('NV02', N'Nguyễn Văn Quản Lý', 'admin', '123', N'Quản lý', 'quanly.jpg', 15000000),
('NV03', N'Lê Thị Bán Hàng', 'nhanvien', '123', N'Nhân viên', 'nhanvien.jpg', 8000000);
GO

-- 2. Thêm 5 dữ liệu bảng Quản Lý TiVi
INSERT INTO QuanLyTiVi (MaTiVi, TenTiVi, HangSanXuat, NgayTao, DonGiaBan, KhuyenMai, SoLuongTon, AnhMinhHoa)
VALUES 
('TV01', N'Smart Tivi Samsung 4K 55 inch', N'Samsung', GETDATE(), 15000000, 500000, 10, 'samsung55.jpg'),
('TV02', N'Tivi Sony Bravia 65 inch', N'Sony', GETDATE(), 25000000, 1000000, 5, 'sony65.jpg'),
('TV03', N'Smart Tivi LG OLED 55 inch', N'LG', GETDATE(), 22000000, 800000, 8, 'lg55.jpg'),
('TV04', N'Tivi TCL 4K 50 inch', N'TCL', GETDATE(), 8500000, 300000, 15, 'tcl50.jpg'),
('TV05', N'Tivi Casper HD 32 inch', N'Casper', GETDATE(), 3500000, 100000, 20, 'casper32.jpg');
GO

-- 3. Thêm 5 dữ liệu bảng Khách Hàng (Đúng cấu trúc class KhachHang của bạn)
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, NgayThangNamSinh, SoDienThoai, DiaChi, CCCD)
VALUES 
('KH01', N'Lê Văn Khách', '1990-05-15', '0901234567', N'123 Đường ABC, TP.HCM', '079090123456'),
('KH02', N'Phạm Thị Mua Sắm', '1995-10-20', '0987654321', N'456 Đường XYZ, Hà Nội', '001095654321'),
('KH03', N'Ngô Tấn Tài', '1988-02-28', '0911223344', N'789 Đường Lê Lợi, Đà Nẵng', '048088112233'),
('KH04', N'Trần Thị Đẹp', '2000-12-12', '0944556677', N'321 Đường 30/4, Cần Thơ', '092000445566'),
('KH05', N'Đinh Trọng Tín', '1985-07-07', '0988776655', N'654 Đường Trần Phú, Hải Phòng', '031085998877');
GO

