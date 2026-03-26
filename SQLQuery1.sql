USE QuanLyCuaHangTiVi;
GO

-- ==========================================
-- BƯỚC 1: XÓA VÀ DỌN DẸP DỮ LIỆU CŨ 
-- ==========================================
DELETE FROM ChiTietTraGop;
DELETE FROM TraGop;
DELETE FROM HoaDonChiTiet;
DELETE FROM HoaDon;
DELETE FROM ChiTietPhieuNhap;
DELETE FROM PhieuNhap;
DELETE FROM QuanLyTiVi;
DELETE FROM KhachHang;
DELETE FROM NhanVien;
DELETE FROM ChiPhiVanHanh;

-- RESET LẠI CÁC CỘT ID
DBCC CHECKIDENT ('ChiTietTraGop', RESEED, 0);
DBCC CHECKIDENT ('HoaDonChiTiet', RESEED, 0);
DBCC CHECKIDENT ('HoaDon', RESEED, 0);
DBCC CHECKIDENT ('ChiTietPhieuNhap', RESEED, 0);
DBCC CHECKIDENT ('ChiPhiVanHanh', RESEED, 0);

-- [ĐOẠN FIX LỖI]: Tắt toàn bộ IDENTITY_INSERT có thể đang bị kẹt từ phiên chạy trước
SET IDENTITY_INSERT ChiTietTraGop OFF;
SET IDENTITY_INSERT HoaDon OFF;
SET IDENTITY_INSERT HoaDonChiTiet OFF;
SET IDENTITY_INSERT ChiPhiVanHanh OFF;

PRINT N'--> Đã dọn dẹp sạch sẽ dữ liệu cũ và gỡ kẹt ID!';

-- ==========================================
-- BƯỚC 2: THÊM NHÂN VIÊN & KHÁCH HÀNG (GIỮ NGUYÊN)
-- ==========================================
INSERT INTO NhanVien (MaNhanVien, HoTenNhanVien, TenDangNhap, MatKhau, QuyenHan, AnhChanDung, Luong) VALUES 
('NV01', N'Nguyễn Văn Quản', 'admin', '123456', N'Quản lý', 'quanly.jpg', 20000000),
('NV02', N'Trần Thị Sale', 'sale01', '123456', N'Nhân viên', 'sale.jpg', 8000000),
('NV03', N'Lê Minh Thép', 'baove', '123456', N'Bảo vệ', 'baove.jpg', 6000000),
('NV04', N'Phạm Thị Sạch', 'laocong', '123456', N'Lao công', 'laocong.jpg', 5500000);

INSERT INTO KhachHang (MaKhachHang, TenKhachHang, NgayThangNamSinh, SoDienThoai, DiaChi, CCCD) VALUES 
('KH_DA', N'Công ty TNHH Dự Án Khách Sạn', '1990-01-01', '0900000001', N'Quận 1, TP.HCM', '079123456789'),
('KH_TG', N'Hệ thống Karaoke VVIP', '1985-05-10', '0988888888', N'Quận 3, TP.HCM', '079987654321'),
('KH01', N'Nguyễn Văn An', '1985-02-14', '0901111111', N'Tân Châu, An Giang', '089085000001'),
('KH02', N'Trần Thị Bình', '1990-05-20', '0902222222', N'Châu Đốc, An Giang', '089090000002'),
('KH03', N'Lê Hoàng Cường', '1982-11-08', '0903333333', N'Quận 1, TP.HCM', '079082000003'),
('KH04', N'Phạm Thu Dung', '1995-07-15', '0904444444', N'Quận 7, TP.HCM', '079095000004'),
('KH05', N'Hoàng Trọng Ân', '1988-09-22', '0905555555', N'Long Xuyên, An Giang', '089088000005'),
('KH06', N'Đỗ Mỹ Linh', '1998-12-01', '0906666666', N'Quận 3, TP.HCM', '079098000006'),
('KH07', N'Võ Tấn Phát', '1975-03-30', '0907777777', N'Tân Châu, An Giang', '089075000007'),
('KH08', N'Bùi Thị Hạnh', '1980-08-19', '0908888888', N'Quận 10, TP.HCM', '079080000008'),
('KH09', N'Đặng Khắc Nhu', '1992-01-25', '0909999999', N'Gò Vấp, TP.HCM', '079092000009'),
('KH10', N'Ngô Tùng Lâm', '1987-06-12', '0910101010', N'Chợ Mới, An Giang', '089087000010'),
('KH11', N'Dương Thúy Kiều', '1996-04-05', '0911111111', N'Tân Bình, TP.HCM', '079096000011'),
('KH12', N'Lý Hải Hưng', '1983-10-10', '0912121212', N'Quận 5, TP.HCM', '079083000012'),
('KH13', N'Tô Hiểu Phương', '1991-02-28', '0913131313', N'Phú Tân, An Giang', '089091000013'),
('KH14', N'Hồ Bảo Trâm', '1999-09-09', '0914141414', N'Thủ Đức, TP.HCM', '079099000014'),
('KH15', N'Mai Hữu Thọ', '1978-11-11', '0915151515', N'Bình Thạnh, TP.HCM', '079078000015'),
('KH16', N'Chu Tấn Ngọc', '1986-07-22', '0916161616', N'Tri Tôn, An Giang', '089086000016'),
('KH17', N'Trịnh Yến Nhi', '2000-12-25', '0917171717', N'Quận 4, TP.HCM', '079100000017'),
('KH18', N'Đinh Quốc Đại', '1989-05-14', '0918181818', N'Tân Phú, TP.HCM', '079089000018'),
('KH19', N'Lâm Tuấn Hùng', '1993-08-08', '0919191919', N'Thoại Sơn, An Giang', '089093000019'),
('KH20', N'Thái Thanh Tâm', '1997-03-17', '0920202020', N'Quận 8, TP.HCM', '079097000020');

-- ==========================================
-- BƯỚC 3: THÊM 15 DÒNG TIVI & PHIẾU NHẬP (GIỮ NGUYÊN)
-- ==========================================
INSERT INTO QuanLyTiVi (MaTiVi, TenTiVi, HangSanXuat, NgayTao, DonGiaBan, KhuyenMai, SoLuongTon, AnhMinhHoa) VALUES 
('TV01', N'Sony 4K 43 inch', 'Sony', '2026-01-01', 10000000, 0, 0, 'tv01.jpg'),
('TV02', N'Sony 4K 50 inch', 'Sony', '2026-01-01', 12000000, 0, 0, 'tv02.jpg'),
('TV03', N'Sony 4K 55 inch', 'Sony', '2026-01-01', 15000000, 0, 1, 'tv03.jpg'),
('TV04', N'Sony OLED 65 inch', 'Sony', '2026-01-01', 35000000, 0, 2, 'tv04.jpg'),
('TV05', N'Sony 8K 75 inch', 'Sony', '2026-01-01', 70000000, 0, 2, 'tv05.jpg'),
('TV06', N'Samsung FHD 43 inch', 'Samsung', '2026-01-01', 8000000, 0, 3, 'tv06.jpg'),
('TV07', N'Samsung 4K 50 inch', 'Samsung', '2026-01-01', 11000000, 0, 3, 'tv07.jpg'),
('TV08', N'Samsung QLED 55 inch', 'Samsung', '2026-01-01', 16000000, 0, 3, 'tv08.jpg'),
('TV09', N'Samsung Neo QLED 65', 'Samsung', '2026-01-01', 32000000, 0, 3, 'tv09.jpg'),
('TV10', N'Samsung Frame 75', 'Samsung', '2026-01-01', 45000000, 0, 3, 'tv10.jpg'),
('TV11', N'LG FHD 43 inch', 'LG', '2026-01-01', 7500000, 0, 3, 'tv11.jpg'),
('TV12', N'LG 4K 50 inch', 'LG', '2026-01-01', 10500000, 0, 4, 'tv12.jpg'),
('TV13', N'LG NanoCell 55 inch', 'LG', '2026-01-01', 14000000, 0, 1, 'tv13.jpg'),
('TV14', N'LG OLED 65 inch', 'LG', '2026-01-01', 34000000, 0, 1, 'tv14.jpg'),
('TV15', N'TCL 4K 55 inch', 'TCL', '2026-01-01', 9000000, 0, 1, 'tv15.jpg');

INSERT INTO PhieuNhap (MaPhieuNhap, NguoiGiaoHang, NgayNhap, GhiChu) VALUES 
('PN_01_2026', N'Nhà phân phối miền Nam', '2026-01-02', N'Nhập 100 tivi đầu năm');

INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaTiVi, SoLuongNhap, DonGiaNhap) VALUES 
('PN_01_2026', 'TV01', 7, 7500000), ('PN_01_2026', 'TV02', 7, 9000000),
('PN_01_2026', 'TV03', 7, 11500000),('PN_01_2026', 'TV04', 7, 26000000),
('PN_01_2026', 'TV05', 7, 53000000),('PN_01_2026', 'TV06', 7, 6000000),
('PN_01_2026', 'TV07', 7, 8500000), ('PN_01_2026', 'TV08', 7, 12000000),
('PN_01_2026', 'TV09', 7, 24000000),('PN_01_2026', 'TV10', 7, 34000000),
('PN_01_2026', 'TV11', 6, 5500000), ('PN_01_2026', 'TV12', 6, 8000000),
('PN_01_2026', 'TV13', 6, 10500000),('PN_01_2026', 'TV14', 6, 26000000),
('PN_01_2026', 'TV15', 6, 6800000);

-- ==========================================
-- BƯỚC 4 & 5: TẠO HÓA ĐƠN & CHI TIẾT HÓA ĐƠN (GIỮ NGUYÊN)
-- ==========================================
SET IDENTITY_INSERT HoaDon ON;
-- HÓA ĐƠN TIỀN MẶT
INSERT INTO HoaDon (ID, MaNhanVien, MaKhachHang, NgayLap, GhiChuHoaDon) VALUES (1, 'NV02', 'KH_DA', '2026-02-10', N'Dự án KS (Tiền mặt - 30 TV)');
INSERT INTO HoaDon (ID, MaNhanVien, MaKhachHang, NgayLap, GhiChuHoaDon) VALUES 
(2, 'NV02', 'KH06', '2026-02-12', N'Tiền mặt - Mua 2 TV'), (3, 'NV02', 'KH07', '2026-02-12', N'Tiền mặt - Mua 2 TV'),
(4, 'NV02', 'KH08', '2026-02-14', N'Tiền mặt - Mua 2 TV'), (5, 'NV02', 'KH09', '2026-02-14', N'Tiền mặt - Mua 2 TV'),
(6, 'NV02', 'KH10', '2026-02-15', N'Tiền mặt - Mua 2 TV'), (7, 'NV02', 'KH11', '2026-02-15', N'Tiền mặt - Mua 2 TV'),
(8, 'NV02', 'KH12', '2026-02-18', N'Tiền mặt - Mua 2 TV'), (9, 'NV02', 'KH13', '2026-02-18', N'Tiền mặt - Mua 2 TV'),
(10, 'NV02', 'KH14', '2026-02-20', N'Tiền mặt - Mua 2 TV'),(11, 'NV02', 'KH15', '2026-02-20', N'Tiền mặt - Mua 2 TV'),
(12, 'NV02', 'KH16', '2026-02-22', N'Tiền mặt - Mua 1 TV'), (13, 'NV02', 'KH17', '2026-02-22', N'Tiền mặt - Mua 1 TV'),
(14, 'NV02', 'KH18', '2026-02-25', N'Tiền mặt - Mua 1 TV'), (15, 'NV02', 'KH19', '2026-02-25', N'Tiền mặt - Mua 1 TV'),
(16, 'NV02', 'KH20', '2026-02-28', N'Tiền mặt - Mua 1 TV');

-- HÓA ĐƠN TRẢ GÓP (HĐ 17 đến 22)
INSERT INTO HoaDon (ID, MaNhanVien, MaKhachHang, NgayLap, GhiChuHoaDon) VALUES (17, 'NV02', 'KH_TG', '2026-03-01', N'Dự án Karaoke (Trả góp - 10 TV)');
INSERT INTO HoaDon (ID, MaNhanVien, MaKhachHang, NgayLap, GhiChuHoaDon) VALUES 
(18, 'NV02', 'KH01', '2026-03-02', N'Trả góp - Mua 1 TV'), (19, 'NV02', 'KH02', '2026-03-03', N'Trả góp - Mua 1 TV'),
(20, 'NV02', 'KH03', '2026-03-04', N'Trả góp - Mua 1 TV'), (21, 'NV02', 'KH04', '2026-03-05', N'Trả góp - Mua 1 TV'),
(22, 'NV02', 'KH05', '2026-03-06', N'Trả góp - Mua 1 TV');
SET IDENTITY_INSERT HoaDon OFF;

SET IDENTITY_INSERT HoaDonChiTiet ON;
INSERT INTO HoaDonChiTiet (ID, HoaDonID, MaTiVi, SoLuongBan, DonGiaBan, KhuyenMai) VALUES 
(1, 1, 'TV01', 7, 10000000, 0), (2, 1, 'TV02', 7, 12000000, 0),
(3, 1, 'TV03', 6, 15000000, 0), (4, 1, 'TV04', 5, 35000000, 0),
(5, 1, 'TV05', 5, 70000000, 0);
INSERT INTO HoaDonChiTiet (ID, HoaDonID, MaTiVi, SoLuongBan, DonGiaBan, KhuyenMai) VALUES 
(6, 2, 'TV06', 2, 8000000, 0),  (7, 3, 'TV06', 2, 8000000, 0),
(8, 4, 'TV07', 2, 11000000, 0), (9, 5, 'TV07', 2, 11000000, 0),
(10, 6, 'TV08', 2, 16000000, 0), (11, 7, 'TV08', 2, 16000000, 0),
(12, 8, 'TV09', 2, 32000000, 0), (13, 9, 'TV09', 2, 32000000, 0),
(14, 10, 'TV10', 2, 45000000, 0), (15, 11, 'TV10', 2, 45000000, 0),
(16, 12, 'TV11', 1, 7500000, 0), (17, 13, 'TV11', 1, 7500000, 0),
(18, 14, 'TV11', 1, 7500000, 0), (19, 15, 'TV12', 1, 10500000, 0),
(20, 16, 'TV12', 1, 10500000, 0);
INSERT INTO HoaDonChiTiet (ID, HoaDonID, MaTiVi, SoLuongBan, DonGiaBan, KhuyenMai) VALUES 
(21, 17, 'TV13', 5, 14000000, 0), (22, 17, 'TV14', 5, 34000000, 0),
(23, 18, 'TV15', 1, 9000000, 0), (24, 19, 'TV15', 1, 9000000, 0),
(25, 20, 'TV15', 1, 9000000, 0), (26, 21, 'TV15', 1, 9000000, 0),
(27, 22, 'TV15', 1, 9000000, 0);
SET IDENTITY_INSERT HoaDonChiTiet OFF;

-- ==========================================
-- BƯỚC 6: DỮ LIỆU TRẢ GÓP & CHI TIẾT TRẢ GÓP (GIỮ NGUYÊN)
-- ==========================================

-- 1. Bảng TraGop
INSERT INTO TraGop (MaTraGop, MaHoaDon, LaiSuat, SoTienTraTruoc, SoTienConNo, KyHanTra) VALUES 
('TG_KARAOKE', 17, 1.50, 100000000, 142100000, 4),  
('TG_KH01', 18, 2.00, 3000000, 6120000, 2),  
('TG_KH02', 19, 2.00, 3000000, 6120000, 2),
('TG_KH03', 20, 2.00, 3000000, 6120000, 2),
('TG_KH04', 21, 2.00, 3000000, 6120000, 2),
('TG_KH05', 22, 2.00, 3000000, 6120000, 2);

-- 2. Bảng ChiTietTraGop (Phân bổ đủ kỳ cho từng hợp đồng)
-- Mỗi dòng tương ứng với một tháng khách phải đóng tiền.

-- Hợp đồng TG_KARAOKE (Kỳ hạn 4 tháng)
INSERT INTO ChiTietTraGop (MaTraGop, KyThu, NgayCanDong, SoTienGoc, SoTienLai, TongTienDong, DaThanhToan) VALUES 
('TG_KARAOKE', 1, '2026-04-01', 35000000, 525000, 35525000, 1),
('TG_KARAOKE', 2, '2026-05-01', 35000000, 525000, 35525000, 0),
('TG_KARAOKE', 3, '2026-06-01', 35000000, 525000, 35525000, 0),
('TG_KARAOKE', 4, '2026-07-01', 35000000, 525000, 35525000, 0);

-- Hợp đồng TG_KH01 (Kỳ hạn 2 tháng)
INSERT INTO ChiTietTraGop (MaTraGop, KyThu, NgayCanDong, SoTienGoc, SoTienLai, TongTienDong, DaThanhToan) VALUES 
('TG_KH01', 1, '2026-04-02', 3000000, 60000, 3060000, 0),
('TG_KH01', 2, '2026-05-02', 3000000, 60000, 3060000, 0);

-- Hợp đồng TG_KH02 (Kỳ hạn 2 tháng)
INSERT INTO ChiTietTraGop (MaTraGop, KyThu, NgayCanDong, SoTienGoc, SoTienLai, TongTienDong, DaThanhToan) VALUES 
('TG_KH02', 1, '2026-04-03', 3000000, 60000, 3060000, 0),
('TG_KH02', 2, '2026-05-03', 3000000, 60000, 3060000, 0);

-- Hợp đồng TG_KH03 (Kỳ hạn 2 tháng)
INSERT INTO ChiTietTraGop (MaTraGop, KyThu, NgayCanDong, SoTienGoc, SoTienLai, TongTienDong, DaThanhToan) VALUES 
('TG_KH03', 1, '2026-04-04', 3000000, 60000, 3060000, 0),
('TG_KH03', 2, '2026-05-04', 3000000, 60000, 3060000, 0);

-- Hợp đồng TG_KH04 (Kỳ hạn 2 tháng)
INSERT INTO ChiTietTraGop (MaTraGop, KyThu, NgayCanDong, SoTienGoc, SoTienLai, TongTienDong, DaThanhToan) VALUES 
('TG_KH04', 1, '2026-04-05', 3000000, 60000, 3060000, 0),
('TG_KH04', 2, '2026-05-05', 3000000, 60000, 3060000, 0);

-- Hợp đồng TG_KH05 (Kỳ hạn 2 tháng)
INSERT INTO ChiTietTraGop (MaTraGop, KyThu, NgayCanDong, SoTienGoc, SoTienLai, TongTienDong, DaThanhToan) VALUES 
('TG_KH05', 1, '2026-04-06', 3000000, 60000, 3060000, 0),
('TG_KH05', 2, '2026-05-06', 3000000, 60000, 3060000, 0);

-- ==========================================
-- BƯỚC 7: CHI PHÍ VẬN HÀNH (GIỮ NGUYÊN)
-- ==========================================
SET IDENTITY_INSERT ChiPhiVanHanh ON;
INSERT INTO ChiPhiVanHanh (ID, Thang, Nam, TienDien, TienNuoc, TienMatBang, TienBaoTri) VALUES 
(1, 1, 2026, 3000000, 400000, 20000000, 500000), 
(2, 2, 2026, 3200000, 450000, 20000000, 200000),   
(3, 3, 2026, 3500000, 500000, 20000000, 1000000);
SET IDENTITY_INSERT ChiPhiVanHanh OFF;

PRINT N'--> XONG! ĐÃ CẬP NHẬT FULL LỊCH TRÌNH TRẢ GÓP CHO TẤT CẢ HỢP ĐỒNG!';