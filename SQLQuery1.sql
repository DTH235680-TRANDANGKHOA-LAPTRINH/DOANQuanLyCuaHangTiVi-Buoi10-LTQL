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

-- RESET LẠI CÁC CỘT ID (Cho các bảng tự tăng)
DBCC CHECKIDENT ('ChiTietTraGop', RESEED, 0);
DBCC CHECKIDENT ('TraGop', RESEED, 0);
DBCC CHECKIDENT ('HoaDonChiTiet', RESEED, 0);
DBCC CHECKIDENT ('HoaDon', RESEED, 0);
DBCC CHECKIDENT ('ChiTietPhieuNhap', RESEED, 0);
DBCC CHECKIDENT ('ChiPhiVanHanh', RESEED, 0);

PRINT N'--> BƯỚC 1: Đã dọn dẹp sạch sẽ dữ liệu cũ!';

-- ==========================================
-- BƯỚC 2: THÊM NHÂN VIÊN & KHÁCH HÀNG
-- ==========================================
-- Đã thêm NgaySinh và điều chỉnh Lương theo đúng yêu cầu
INSERT INTO NhanVien (MaNhanVien, HoTenNhanVien, NgaySinh, TenDangNhap, MatKhau, QuyenHan, AnhChanDung, Luong) VALUES 
('NV01', N'Nguyễn Văn Quản', '1985-01-01', 'admin', '123456', N'Quản lý', 'quanly.jpg', 15000000),
('NV02', N'Trần Thị Sale', '1992-05-10', 'nhanvien', '123456', N'Nhân viên', 'sale.jpg', 5000000),
('NV03', N'Lê Minh Góp', '1990-08-15', 'tragop', '123456', N'Nhân viên trả góp', 'tragop.jpg', 12000000),
('NV04', N'Phạm Kho', '1994-11-20', 'nhaphang', '123456', N'Nhân viên nhập hàng', 'kho.jpg', 5000000),
('NV05', N'Hoàng Vệ', '1980-03-05', 'baove', '123456', N'Bảo vệ', 'baove.jpg', 5000000),
('NV06', N'Đinh Thị Sạch', '1975-09-12', 'laocong', '123456', N'Lao công', 'laocong.jpg', 3000000);

-- Thêm 20 khách hàng mẫu (để dùng quay vòng cho 100 hóa đơn)
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, NgayThangNamSinh, SoDienThoai, DiaChi, CCCD) VALUES 
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

PRINT N'--> BƯỚC 2: Thêm Nhân Viên và Khách Hàng xong!';

-- ==========================================
-- BƯỚC 3: THÊM 17 DÒNG TIVI & PHIẾU NHẬP (Nhập 150 cái, Tồn 50 cái)
-- ==========================================
-- Giữ nguyên 15 TV cũ, thêm 2 TV mới có khuyến mãi 10%
-- Số lượng tồn được chia đều để tổng tồn kho là 50 cái (TV01->TV16 = 3 cái, TV17 = 2 cái)
INSERT INTO QuanLyTiVi (MaTiVi, TenTiVi, HangSanXuat, NgayTao, DonGiaBan, KhuyenMai, SoLuongTon, AnhMinhHoa) VALUES 
('TV01', N'Sony 4K 43 inch', 'Sony', GETDATE(), 10000000, 0, 3, 'tv01.jpg'),
('TV02', N'Sony 4K 50 inch', 'Sony', GETDATE(), 12000000, 0, 3, 'tv02.jpg'),
('TV03', N'Sony 4K 55 inch', 'Sony', GETDATE(), 15000000, 0, 3, 'tv03.jpg'),
('TV04', N'Sony OLED 65 inch', 'Sony', GETDATE(), 35000000, 0, 3, 'tv04.jpg'),
('TV05', N'Sony 8K 75 inch', 'Sony', GETDATE(), 70000000, 0, 3, 'tv05.jpg'),
('TV06', N'Samsung FHD 43 inch', 'Samsung', GETDATE(), 8000000, 0, 3, 'tv06.jpg'),
('TV07', N'Samsung 4K 50 inch', 'Samsung', GETDATE(), 11000000, 0, 3, 'tv07.jpg'),
('TV08', N'Samsung QLED 55 inch', 'Samsung', GETDATE(), 16000000, 0, 3, 'tv08.jpg'),
('TV09', N'Samsung Neo QLED 65', 'Samsung', GETDATE(), 32000000, 0, 3, 'tv09.jpg'),
('TV10', N'Samsung Frame 75', 'Samsung', GETDATE(), 45000000, 0, 3, 'tv10.jpg'),
('TV11', N'LG FHD 43 inch', 'LG', GETDATE(), 7500000, 0, 3, 'tv11.jpg'),
('TV12', N'LG 4K 50 inch', 'LG', GETDATE(), 10500000, 0, 3, 'tv12.jpg'),
('TV13', N'LG NanoCell 55 inch', 'LG', GETDATE(), 14000000, 0, 3, 'tv13.jpg'),
('TV14', N'LG OLED 65 inch', 'LG', GETDATE(), 34000000, 0, 3, 'tv14.jpg'),
('TV15', N'TCL 4K 55 inch', 'TCL', GETDATE(), 9000000, 0, 3, 'tv15.jpg'),
('TV16', N'TCL MiniLED 65 inch', 'TCL', GETDATE(), 25000000, 10, 3, 'tv16.jpg'), -- TV MỚI: KM 10%
('TV17', N'Hisense ULED 55 inch', 'Hisense', GETDATE(), 18000000, 10, 2, 'tv17.jpg'); -- TV MỚI: KM 10%

INSERT INTO PhieuNhap (MaPhieuNhap, NguoiGiaoHang, NgayNhap, GhiChu) VALUES 
('PN_01', N'Kho tổng miền Nam', GETDATE(), N'Nhập đủ 150 tivi cho cửa hàng');

-- Tổng số lượng nhập vào = 150. (TV01->TV15 nhập 9; TV16 nhập 8; TV17 nhập 7) => Tổng = 150
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaTiVi, SoLuongNhap, DonGiaNhap) VALUES 
('PN_01', 'TV01', 9, 7500000),  ('PN_01', 'TV02', 9, 9000000),
('PN_01', 'TV03', 9, 11500000), ('PN_01', 'TV04', 9, 26000000),
('PN_01', 'TV05', 9, 53000000), ('PN_01', 'TV06', 9, 6000000),
('PN_01', 'TV07', 9, 8500000),  ('PN_01', 'TV08', 9, 12000000),
('PN_01', 'TV09', 9, 24000000), ('PN_01', 'TV10', 9, 34000000),
('PN_01', 'TV11', 9, 5500000),  ('PN_01', 'TV12', 9, 8000000),
('PN_01', 'TV13', 9, 10500000), ('PN_01', 'TV14', 9, 26000000),
('PN_01', 'TV15', 9, 6800000),  ('PN_01', 'TV16', 8, 18000000),
('PN_01', 'TV17', 7, 13000000);

PRINT N'--> BƯỚC 3: Đã nhập 150 Tivi và set tồn kho 50!';

-- ==========================================
-- BƯỚC 4: TẠO 100 HÓA ĐƠN & BÁN 100 TIVI & TẠO 30 TRẢ GÓP (BẰNG VÒNG LẶP)
-- ==========================================
DECLARE @i INT = 1;
DECLARE @MaKH VARCHAR(20);
DECLARE @MaTV VARCHAR(20);
DECLARE @DonGia DECIMAL(18,0);
DECLARE @KhuyenMai DECIMAL(18,2);
DECLARE @MaHoaDonVuaTao INT;
DECLARE @MaTraGopVuaTao INT;
DECLARE @NgayLapHoaDon DATETIME;

-- Chạy vòng lặp 100 lần để sinh ra 100 hóa đơn
WHILE @i <= 100
BEGIN
    -- 1. Lấy tự động 1 Khách Hàng (xoay vòng từ KH01 đến KH20)
    SET @MaKH = 'KH' + RIGHT('0' + CAST(((@i - 1) % 20) + 1 AS VARCHAR), 2);
    
    -- 2. Lấy tự động 1 Tivi (xoay vòng để bán chính xác 100 cái)
    SET @MaTV = 'TV' + RIGHT('0' + CAST(((@i - 1) % 17) + 1 AS VARCHAR), 2);
    
    -- 3. Truy vấn lấy Đơn Giá và Khuyến Mãi của cái Tivi đó
    SELECT @DonGia = DonGiaBan, @KhuyenMai = KhuyenMai FROM QuanLyTiVi WHERE MaTiVi = @MaTV;
    SET @NgayLapHoaDon = DATEADD(day, -(@i % 30), GETDATE()); -- Rải đều ngày lập trong 30 ngày qua

    -- ==================================
    -- INSERT HÓA ĐƠN
    -- ==================================
    -- Nếu Hóa đơn <= 70 thì là nhân viên NV02 (Tiền mặt), nếu > 70 thì là NV03 (Trả góp)
    IF @i <= 70
        INSERT INTO HoaDon (MaNhanVien, MaKhachHang, NgayLap, GhiChuHoaDon)
        VALUES ('NV02', @MaKH, @NgayLapHoaDon, N'Thanh toán tiền mặt - Hóa đơn tự động');
    ELSE
        INSERT INTO HoaDon (MaNhanVien, MaKhachHang, NgayLap, GhiChuHoaDon)
        VALUES ('NV03', @MaKH, @NgayLapHoaDon, N'Mua trả góp - Hóa đơn tự động');

    -- Lấy ID của hóa đơn vừa tạo (Do HoaDon là IDENTITY)
    SET @MaHoaDonVuaTao = SCOPE_IDENTITY();

    -- ==================================
    -- INSERT CHI TIẾT HÓA ĐƠN
    -- ==================================
    -- Mỗi hóa đơn bán đúng 1 tivi
    INSERT INTO HoaDonChiTiet (HoaDonID, MaTiVi, SoLuongBan, DonGiaBan, KhuyenMai)
    VALUES (@MaHoaDonVuaTao, @MaTV, 1, @DonGia, @KhuyenMai);

    -- ==================================
    -- 30% HÓA ĐƠN LÀ TRẢ GÓP (TỪ HÓA ĐƠN 71 ĐẾN 100)
    -- ==================================
    IF @i > 70
    BEGIN
        -- Tính toán tiền bạc cho việc trả góp
        DECLARE @GiaSauKhuyenMai DECIMAL(18,0) = @DonGia - (@DonGia * ISNULL(@KhuyenMai, 0) / 100.0);
        DECLARE @TraTruoc DECIMAL(18,0) = @GiaSauKhuyenMai * 0.3; -- Trả trước 30%
        DECLARE @ConNo DECIMAL(18,0) = @GiaSauKhuyenMai - @TraTruoc;
        
        -- Insert vào bảng TraGop (MaTraGop tự tăng)
        INSERT INTO TraGop (MaHoaDon, PhiPhuThuDinhKy, LaiSuat, SoTienTraTruoc, SoTienConNo, KyHanTra)
        VALUES (@MaHoaDonVuaTao, 50000, 1.5, @TraTruoc, @ConNo, 2); -- Cố định trả trong 2 kỳ

        -- Lấy mã trả góp vừa sinh ra
        SET @MaTraGopVuaTao = SCOPE_IDENTITY();

        -- Insert Chi Tiết Trả Góp (Tháng thứ 1)
        INSERT INTO ChiTietTraGop (MaTraGop, KyThu, NgayCanDong, SoTienGoc, SoTienLai, TongTienDong, SoTienDaDong, SoTienPhat)
        VALUES (
            @MaTraGopVuaTao, 1, DATEADD(month, 1, @NgayLapHoaDon), 
            @ConNo/2, (@ConNo * 0.015), (@ConNo/2) + (@ConNo * 0.015) + 50000, 
            0, 0
        );

        -- Insert Chi Tiết Trả Góp (Tháng thứ 2)
        INSERT INTO ChiTietTraGop (MaTraGop, KyThu, NgayCanDong, SoTienGoc, SoTienLai, TongTienDong, SoTienDaDong, SoTienPhat)
        VALUES (
            @MaTraGopVuaTao, 2, DATEADD(month, 2, @NgayLapHoaDon), 
            @ConNo/2, (@ConNo * 0.015), (@ConNo/2) + (@ConNo * 0.015) + 50000, 
            0, 0
        );
    END

    -- Tăng biến đếm
    SET @i = @i + 1;
END

PRINT N'--> BƯỚC 4: Đã sinh thành công 100 Hóa Đơn và 30 Hợp Đồng Trả Góp!';

-- ==========================================
-- BƯỚC 5: THÊM CHI PHÍ VẬN HÀNH
-- ==========================================
SET IDENTITY_INSERT ChiPhiVanHanh ON;
INSERT INTO ChiPhiVanHanh (ID, Thang, Nam, TienDien, TienNuoc, TienMatBang, TienBaoTri) VALUES 
(1, MONTH(GETDATE()), YEAR(GETDATE()), 3000000, 400000, 20000000, 500000), 
(2, MONTH(GETDATE())-1, YEAR(GETDATE()), 3200000, 450000, 20000000, 200000);
SET IDENTITY_INSERT ChiPhiVanHanh OFF;

PRINT N'--> HOÀN TẤT TOÀN BỘ SCRIPT DATABASE!';
GO