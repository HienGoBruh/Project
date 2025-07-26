CREATE DATABASE QL_CUAHANG_THOITRANG;
GO

USE QL_CUAHANG_THOITRANG;
GO

CREATE TABLE DANHMUCSP (
    IDDM NCHAR(10) PRIMARY KEY,
    TENDM NVARCHAR(100) NOT NULL
);

CREATE TABLE CHATLIEU (
    IDCL NCHAR(10) PRIMARY KEY,
    TENCL NVARCHAR(100) NOT NULL,
    MOTA NVARCHAR(255)
);

CREATE TABLE SANPHAM (
    IDSP NCHAR(10) PRIMARY KEY,
    IDDM NCHAR(10) FOREIGN KEY REFERENCES DANHMUCSP(IDDM),
    IDCL NCHAR(10) FOREIGN KEY REFERENCES CHATLIEU(IDCL),
    TENSP NVARCHAR(100) NOT NULL,
    DGNHAP DECIMAL(18,0),
    DGBAN DECIMAL(18,0),
    MOTA NVARCHAR(255)
);

CREATE TABLE HINHSP(
    IDHINH NCHAR(10) PRIMARY KEY,
    IDSP NCHAR(10),
    DUONGDAN NVARCHAR(255)
);

CREATE TABLE SIZE (
    IDSIZE NCHAR(10) PRIMARY KEY,
    TENSIZE NVARCHAR(10),
    MOTA NVARCHAR(255)
);

CREATE TABLE MAU (
    IDMAU NCHAR(10) PRIMARY KEY,
    TENMAU NVARCHAR(50),
    MOTA NVARCHAR(255)
);

CREATE TABLE SPTONKHO (
    IDTONKHO NCHAR(10) PRIMARY KEY,
    IDSP NCHAR(10) FOREIGN KEY REFERENCES SANPHAM(IDSP),
    IDSIZE NCHAR(10) FOREIGN KEY REFERENCES SIZE(IDSIZE),
    IDMAU NCHAR(10) FOREIGN KEY REFERENCES MAU(IDMAU),
    SOLUONG INT
);

CREATE TABLE NHANVIEN (
    IDNV NCHAR(10) PRIMARY KEY,
    HOTEN NVARCHAR(100),
    GIOITINH NVARCHAR(10),
    NAMSINH INT,
    EMAIL NVARCHAR(100),
    SDT NVARCHAR(20),
    DIACHI NVARCHAR(255)
);

CREATE TABLE HINHNV(
    IDHINH NCHAR(10) PRIMARY KEY,
    IDNV NCHAR(10),
    DUONGDAN NVARCHAR(255)
);

CREATE TABLE KHACHHANG (
    IDKH NCHAR(10) PRIMARY KEY,
    HOTEN NVARCHAR(100),
    GIOITINH NVARCHAR(10),
    NAMSINH INT,
    EMAIL NVARCHAR(100),
    SDT NVARCHAR(20),
	DIACHI NVARCHAR(255)
);

CREATE TABLE HOADONBAN (
    IDHDB NCHAR(10) PRIMARY KEY,
    IDNV NCHAR(10) FOREIGN KEY REFERENCES NHANVIEN(IDNV),
    IDKH NCHAR(10) FOREIGN KEY REFERENCES KHACHHANG(IDKH),
    NGAYLAP DATE,
    GIAMGIA DECIMAL(18,0),
    TONGTIEN DECIMAL(18,0)
);

CREATE TABLE CHITIETHDB (
    IDCTHDB NCHAR(10) PRIMARY KEY,
    IDHDB NCHAR(10) FOREIGN KEY REFERENCES HOADONBAN(IDHDB),
    IDSP NCHAR(10) FOREIGN KEY REFERENCES SANPHAM(IDSP),
    SOLUONG INT,
    IDSIZE NCHAR(10) FOREIGN KEY REFERENCES SIZE(IDSIZE),
    IDMAU NCHAR(10) FOREIGN KEY REFERENCES MAU(IDMAU),
    DONGIA DECIMAL(18,0)
);

CREATE TABLE NHACUNGCAP (
    IDNCC NCHAR(10) PRIMARY KEY,
    TENNCC NVARCHAR(100),
    DIACHI NVARCHAR(255),
    SDT NVARCHAR(20),
    EMAIL NVARCHAR(100)
);

CREATE TABLE HOADONNHAP (
    IDHDN NCHAR(10) PRIMARY KEY,
    IDNV NCHAR(10) FOREIGN KEY REFERENCES NHANVIEN(IDNV),
    IDNCC NCHAR(10) FOREIGN KEY REFERENCES NHACUNGCAP(IDNCC),
    NGAYLAP DATE,
    TRANGTHAI NVARCHAR(50),
    TONGTIEN DECIMAL(18,0)
);

CREATE TABLE CHITIETHDN (
    IDCTHDN NCHAR(10) PRIMARY KEY,
    IDHDN NCHAR(10) FOREIGN KEY REFERENCES HOADONNHAP(IDHDN),
    IDSP NCHAR(10) FOREIGN KEY REFERENCES SANPHAM(IDSP),
    SOLUONG INT,
    IDSIZE NCHAR(10) FOREIGN KEY REFERENCES SIZE(IDSIZE),
    IDMAU NCHAR(10) FOREIGN KEY REFERENCES MAU(IDMAU),
    DONGIA DECIMAL(18,0)
);

CREATE TABLE TAIKHOAN (
    IDUSER NCHAR(10) PRIMARY KEY,
    HOTEN NVARCHAR(100),
    TENDN NVARCHAR(50) UNIQUE,
    MATKHAU NVARCHAR(100),
    NHOM NVARCHAR(50)
);

CREATE TABLE CHUCNANG (
    IDCN NCHAR(10) PRIMARY KEY,
    TENCN NVARCHAR(100)
);

CREATE TABLE PHANQUYEN (
    IDPQ NCHAR(10) PRIMARY KEY,
    IDUSER NCHAR(10) FOREIGN KEY REFERENCES TAIKHOAN(IDUSER),
    IDCN NCHAR(10) FOREIGN KEY REFERENCES CHUCNANG(IDCN)
);



-- INSERT DỮ LIỆU
-- BẢNG CHATLIEU
INSERT INTO CHATLIEU (IDCL, TENCL, MOTA) VALUES
('CL01', N'Cotton', N'Chất liệu mềm mại, thấm hút tốt'),
('CL02', N'Polyester', N'Chất liệu tổng hợp, bền màu'),
('CL03', N'Linen', N'Chất liệu thoáng mát, dễ chịu'),
('CL04', N'Silk', N'Chất liệu mịn, bóng'),
('CL05', N'Wool', N'Chất liệu giữ nhiệt tốt'),
('CL06', N'Leather', N'Chất liệu da thật'),
('CL07', N'Spandex', N'Co giãn tốt'),
('CL08', N'Nylon', N'Chất liệu tổng hợp, bền'),
('CL09', N'Rayon', N'Chất liệu nhân tạo'),
('CL10', N'Flannel', N'Chất liệu nỉ ấm áp'),
('CL11', N'Denim', N'Vải bò dày dặn'),
('CL12', N'Chiffon', N'Vải nhẹ, mỏng'),
('CL13', N'Twill', N'Vải dệt chéo bền'),
('CL14', N'Satin', N'Vải bóng, mượt'),
('CL15', N'Cashmere', N'Lông dê mềm mại');

-- BẢNG DANHMUCSP
INSERT INTO DANHMUCSP (IDDM, TENDM) VALUES
('DM01', N'Áo thun'),
('DM02', N'Quần jean'),
('DM03', N'Đầm'),
('DM04', N'Áo khoác'),
('DM05', N'Chân váy'),
('DM06', N'Giày thể thao'),
('DM07', N'Túi xách'),
('DM08', N'Phụ Kiện'),
('DM09', N'Váy dạ hội'),
('DM10', N'Áo sơ mi'),
('DM11', N'Quần short'),
('DM12', N'Áo len'),
('DM13', N'Đồ thể thao'),
('DM14', N'Khăn tắm'),
('DM15', N'Dép');

-- BẢNG SANPHAM
INSERT INTO SANPHAM (IDSP, IDDM, IDCL, TENSP, DGNHAP, DGBAN, MOTA) VALUES
('SP01', 'DM01', 'CL01', N'Áo thun cotton basic', 50000, 120000, N'Áo thun chất cotton thấm hút tốt, phù hợp mặc hàng ngày'),
('SP02', 'DM02', 'CL11', N'Quần jean xanh nam', 150000, 300000, N'Quần jean nam chất denim, kiểu dáng hiện đại'),
('SP03', 'DM03', 'CL12', N'Đầm chiffon công sở', 200000, 450000, N'Đầm nhẹ nhàng, thoáng mát cho môi trường công sở'),
('SP04', 'DM04', 'CL08', N'Áo khoác gió nữ', 180000, 380000, N'Áo khoác chất nylon, chắn gió tốt'),
('SP05', 'DM05', 'CL03', N'Chân váy linen dài', 100000, 220000, N'Chân váy dài chất liệu thoáng mát, nhẹ nhàng'),
('SP06', 'DM06', 'CL06', N'Giày thể thao da thật', 400000, 750000, N'Giày thể thao bền đẹp, chất liệu da cao cấp'),
('SP07', 'DM07', 'CL06', N'Túi xách da bò', 350000, 690000, N'Túi xách thời trang, chất liệu da thật'),
('SP08', 'DM08', 'CL02', N'Nón lưỡi trai thể thao', 40000, 95000, N'Nón chất liệu bền màu, thích hợp thể thao ngoài trời'),
('SP09', 'DM09', 'CL14', N'Váy dạ hội satin đỏ', 500000, 1200000, N'Váy dạ hội bóng mượt, sang trọng'),
('SP10', 'DM10', 'CL01', N'Áo sơ mi trắng cotton', 90000, 210000, N'Áo sơ mi nam nữ basic, chất cotton thấm hút'),
('SP11', 'DM11', 'CL07', N'Quần short thể thao', 60000, 150000, N'Quần short co giãn, thích hợp vận động'),
('SP12', 'DM12', 'CL05', N'Áo len giữ nhiệt', 120000, 290000, N'Áo len ấm, chất liệu wool cao cấp'),
('SP13', 'DM13', 'CL07', N'Bộ đồ thể thao co giãn', 180000, 400000, N'Bộ đồ tập gym thoải mái, đàn hồi tốt'),
('SP14', 'DM14', 'CL01', N'Khăn tắm cotton mềm', 30000, 75000, N'Khăn tắm thấm hút, êm dịu cho da'),
('SP15', 'DM15', 'CL06', N'Dép da quai chéo', 80000, 180000, N'Dép chất da thật, bền và thời trang'),
('SP16', 'DM03', 'CL09', N'Đầm maxi hoa nhí', 220000, 520000, N'Đầm maxi in hoa nhỏ, chất voan mềm mại, tôn dáng'),
('SP17', 'DM04', 'CL08', N'Áo khoác jean unisex', 250000, 580000, N'Áo khoác jean cổ điển, phù hợp cả nam và nữ'),
('SP18', 'DM12', 'CL10', N'Sweater oversize len', 180000, 420000, N'Sweater dày dặn dáng rộng, giữ ấm tốt'),
('SP19', 'DM07', 'CL04', N'Balo du lịch chống nước', 300000, 650000, N'Balo vải nylon chống nước, nhiều ngăn tiện dụng'),
('SP20', 'DM08', 'CL13', N'Đồng hồ thời trang nam', 350000, 900000, N'Đồng hồ dây da, mặt kính sapphire, kiểu dáng lịch lãm');


-- BẢNG HINHSP

INSERT INTO HINHSP (IDHINH, IDSP, DUONGDAN) VALUES
('HSP01', 'SP01', N'aothuncottonbasic.jpg'),
('HSP02', 'SP02', N'quanjeanxanhnam.jpg'),
('HSP03', 'SP03', N'damchiffoncso.jpg'),
('HSP04', 'SP04', N'aogionu.jpg'),
('HSP05', 'SP05', N'chanvaylinendai.jpg'),
('HSP06', 'SP06', N'giaythethaodathat.jpg'),
('HSP07', 'SP07', N'tuisachdabo.jpg'),
('HSP08', 'SP08', N'nonluoitraithethao.jpg'),
('HSP09', 'SP09', N'vaydahoisatindo.jpg'),
('HSP10', 'SP10', N'aosomitrangcotton.jpg'),
('HSP11', 'SP11', N'quansortthethao.jpg'),
('HSP12', 'SP12', N'aolengiunhiet.jpg'),
('HSP13', 'SP13', N'bodothethaocogian.jpg'),
('HSP14', 'SP14', N'khantamcottonmem.jpg'),
('HSP15', 'SP15', N'depdaquaicheo.jpg'),
('HSP16', 'SP16', N'dammaxihoanhi.jpg'),
('HSP17', 'SP17', N'aokhoacjeanunis.jpg'),
('HSP18', 'SP18', N'sweateroversize.jpg'),
('HSP19', 'SP19', N'balodulichchongnc.jpg'),
('HSP20', 'SP20', N'donghothoitrangnam.jpg');

-- BẢNG SIZE
INSERT INTO SIZE (IDSIZE, TENSIZE, MOTA) VALUES
('SZ01', N'S', N'Cỡ nhỏ'),
('SZ02', N'M', N'Cỡ vừa'),
('SZ03', N'L', N'Cỡ lớn'),
('SZ04', N'XL', N'Cỡ rất lớn'),
('SZ05', N'XXL', N'Cỡ ngoại cỡ');

-- BẢNG MAU
INSERT INTO MAU (IDMAU, TENMAU, MOTA) VALUES
('M01', N'Đen', N'Màu đen truyền thống'),
('M02', N'Trắng', N'Màu trắng tinh khiết'),
('M03', N'Xanh dương', N'Màu xanh biển'),
('M04', N'Đỏ', N'Màu đỏ nổi bật'),
('M05', N'Vàng', N'Màu vàng năng động');

-- BẢNG SP TỒN KHO
INSERT INTO SPTONKHO (IDTONKHO, IDSP, IDSIZE, IDMAU, SOLUONG) VALUES
('TK01', 'SP16', 'SZ05', 'M03', 27),
('TK02', 'SP01', 'SZ05', 'M04', 40),
('TK03', 'SP07', 'SZ05', 'M02', 24),
('TK04', 'SP04', 'SZ01', 'M05', 40),
('TK05', 'SP12', 'SZ02', 'M03', 34),
('TK06', 'SP10', 'SZ02', 'M05', 38),
('TK07', 'SP02', 'SZ03', 'M02', 35),
('TK08', 'SP09', 'SZ01', 'M01', 58),
('TK09', 'SP11', 'SZ01', 'M04', 29),
('TK10', 'SP06', 'SZ01', 'M05', 18),
('TK11', 'SP13', 'SZ01', 'M05', 19),
('TK12', 'SP15', 'SZ05', 'M01', 23),
('TK13', 'SP08', 'SZ01', 'M03', 41),
('TK14', 'SP14', 'SZ05', 'M02', 25),
('TK15', 'SP05', 'SZ03', 'M05', 38),
('TK16', 'SP20', 'SZ04', 'M02', 57),
('TK17', 'SP03', 'SZ02', 'M05', 28),
('TK18', 'SP17', 'SZ04', 'M05', 37),
('TK19', 'SP01', 'SZ05', 'M01', 27),
('TK20', 'SP18', 'SZ01', 'M02', 56),
('TK21', 'SP19', 'SZ04', 'M02', 28),
('TK22', 'SP02', 'SZ01', 'M02', 58),
('TK23', 'SP16', 'SZ01', 'M02', 50),
('TK24', 'SP07', 'SZ01', 'M02', 49),
('TK25', 'SP09', 'SZ02', 'M03', 29);

-- BẢNG NHANVIEN
INSERT INTO NHANVIEN (IDNV, HOTEN, GIOITINH, NAMSINH, EMAIL, SDT, DIACHI) VALUES
('NV01', N'Nguyễn Văn A', N'Nam', 1995, 'a.nguyen@example.com', '0912345678', N'Hà Nội'),
('NV02', N'Trần Thị B', N'Nữ', 1997, 'b.tran@example.com', '0987654321', N'TP. Hồ Chí Minh'),
('NV03', N'Trần Ngọc Bảo', N'Nam', 1997, 'b.bao@example.com', '0954633213', N'Đà Nẵng'),
('NV04', N'Đặng Nguyệt Quế', N'Nữ', 1993, 'b.que@example.com', '0328299043', N'Hải Phòng');

-- BẢNG KHACHHANG
INSERT INTO KHACHHANG (IDKH, HOTEN, GIOITINH, NAMSINH, EMAIL, SDT, DIACHI) VALUES
('KH01', N'Phạm Văn C', N'Nam', 1990, 'c.pham@example.com', '0933333333', N'Đà Nẵng'),
('KH02', N'Lê Thị D', N'Nữ', 1988, 'd.le@example.com', '0944444444', N'Hải Phòng'),
('KH03', N'Trần Minh Khoa', N'Nam', 1995, 'khoa.tran@example.com', '0911111111', N'TP.HCM'),
('KH04', N'Nguyễn Thị Hoa', N'Nữ', 1992, 'hoa.nguyen@example.com', '0922222222', N'Hà Nội'),
('KH05', N'Đặng Quốc Anh', N'Nam', 1987, 'anh.dang@example.com', '0935555555', N'Cần Thơ'),
('KH06', N'Lý Thị Mai', N'Nữ', 1993, 'mai.ly@example.com', '0946666666', N'Vũng Tàu'),
('KH07', N'Hoàng Văn Tâm', N'Nam', 1990, 'tam.hoang@example.com', '0957777777', N'Thừa Thiên Huế'),
('KH08', N'Bùi Thị Lan', N'Nữ', 1996, 'lan.bui@example.com', '0968888888', N'Bắc Ninh'),
('KH09', N'Phan Minh Tuấn', N'Nam', 1989, 'tuan.phan@example.com', '0979999999', N'Biên Hòa'),
('KH10', N'Võ Thị Ngọc', N'Nữ', 1991, 'ngoc.vo@example.com', '0980000000', N'Quảng Nam');

-- BẢNG HINHNV
INSERT INTO HINHNV(IDHINH, IDNV, DUONGDAN) VALUES
('HNV01', 'NV01', N'nguyenvana.jpg'),
('HNV02', 'NV02', N'tranthib.jpg'),
('HNV03', 'NV03', N'tranngocbao.jpg'),
('HNV04', 'NV04', N'dangnguyetque.jpg');

-- BẢNG NHACC
INSERT INTO NHACUNGCAP (IDNCC, TENNCC, DIACHI, SDT, EMAIL) VALUES
('NCC01', N'Công ty May Việt Tín', N'Q.1, TP.HCM', '0909123456', 'viettin@maymacth.com'),
('NCC02', N'Công ty Thời Trang Xinh', N'Q.3, TP.HCM', '0909345678', 'lienhe@thoitrangxinh.vn'),
('NCC03', N'Xưởng Giày Việt', N'Q.Bình Thạnh, TP.HCM', '0909765432', 'giayviet.contact@gmail.com'),
('NCC04', N'Khăn Cotton Việt Nhật', N'Q.5, TP.HCM', '0909988776', 'hotro@vietnhatcotton.com'),
('NCC05', N'Công ty MaxStyle', N'Q.Tân Bình, TP.HCM', '0911122334', 'info@maxstyle.vn');

-- BẢNG HOADONBAN
INSERT INTO HOADONBAN (IDHDB, IDNV, IDKH, NGAYLAP, GIAMGIA, TONGTIEN) VALUES
('HDB01', 'NV01', 'KH01', '2024-05-01', 25000, 435000),
('HDB02', 'NV02', 'KH02', '2024-05-05', 100000, 2760000),
('HDB03', 'NV02', 'KH03', '2024-05-10', 50000, 775000),
('HDB04', 'NV01', 'KH04', '2024-05-12', 50000, 885000),
('HDB05', 'NV02', 'KH05', '2024-05-15', 50000, 1120000),
('HDB06', 'NV01', 'KH06', '2024-05-18', 75000, 1885000),
('HDB07', 'NV02', 'KH07', '2024-05-20', 25000, 455000),
('HDB08', 'NV02', 'KH08', '2024-05-22', 75000, 1225000),
('HDB09', 'NV02', 'KH09', '2024-05-25', 50000, 1150000),
('HDB10', 'NV01', 'KH10', '2024-05-28', 75000, 1545000);

-- CHI TIẾT HOADONBAN
INSERT INTO CHITIETHDB (IDCTHDB, IDHDB, IDSP, SOLUONG, IDSIZE, IDMAU, DONGIA) VALUES
('CTHDB01', 'HDB01', 'SP01', 2, 'SZ02', 'M01', 120000),
('CTHDB02', 'HDB01', 'SP05', 1, 'SZ02', 'M05', 220000),
('CTHDB03', 'HDB02', 'SP12', 3, 'SZ01', 'M04', 290000),
('CTHDB04', 'HDB02', 'SP07', 1, 'SZ03', 'M02', 690000),
('CTHDB05', 'HDB02', 'SP20', 1, 'SZ04', 'M05', 900000),
('CTHDB06', 'HDB03', 'SP03', 1, 'SZ05', 'M01', 450000),
('CTHDB07', 'HDB03', 'SP11', 2, 'SZ02', 'M03', 150000),
('CTHDB08', 'HDB03', 'SP14', 1, 'SZ03', 'M04', 75000),
('CTHDB09', 'HDB04', 'SP10', 4, 'SZ01', 'M02', 210000),
('CTHDB10', 'HDB04', 'SP08', 1, 'SZ05', 'M05', 95000),
('CTHDB11', 'HDB05', 'SP06', 1, 'SZ04', 'M01', 750000),
('CTHDB12', 'HDB05', 'SP18', 1, 'SZ02', 'M03', 420000),
('CTHDB13', 'HDB06', 'SP09', 1, 'SZ03', 'M04', 1200000),
('CTHDB14', 'HDB06', 'SP04', 2, 'SZ01', 'M01', 380000),
('CTHDB15', 'HDB07', 'SP15', 1, 'SZ05', 'M02', 180000),
('CTHDB16', 'HDB07', 'SP02', 1, 'SZ02', 'M05', 300000),
('CTHDB17', 'HDB08', 'SP19', 2, 'SZ01', 'M03', 650000),
('CTHDB18', 'HDB09', 'SP13', 3, 'SZ05', 'M01', 400000),
('CTHDB19', 'HDB10', 'SP16', 2, 'SZ03', 'M02', 520000),
('CTHDB20', 'HDB10', 'SP17', 1, 'SZ04', 'M05', 580000);

-- BẢNG HOADONNHAP
INSERT INTO HOADONNHAP (IDHDN, IDNV, IDNCC, NGAYLAP, TRANGTHAI, TONGTIEN) VALUES
('HDN01', 'NV01', 'NCC01', '2025-04-10', N'Đã nhập', 21400000),
('HDN02', 'NV02', 'NCC02', '2025-04-11', N'Đã nhập', 45530000),
('HDN03', 'NV03', 'NCC03', '2025-04-12', N'Đã nhập', 10420000),
('HDN04', 'NV04', 'NCC04', '2025-04-13', N'Đã nhập', 27940000),
('HDN05', 'NV01', 'NCC05', '2025-04-14', N'Đã nhập', 86370000);

-- CHI TIẾT HDNHAP
INSERT INTO CHITIETHDN (IDCTHDN, IDHDN, IDSP, SOLUONG, IDSIZE, IDMAU, DONGIA) VALUES
('CTHDN01', 'HDN01', 'SP01', 40, 'SZ05', 'M04', 50000),
('CTHDN02', 'HDN01', 'SP05', 38, 'SZ03', 'M05', 100000),
('CTHDN03', 'HDN01', 'SP07', 24, 'SZ05', 'M02', 350000),
('CTHDN04', 'HDN01', 'SP06', 18, 'SZ01', 'M05', 400000),
('CTHDN05', 'HDN02', 'SP02', 35, 'SZ03', 'M02', 150000),
('CTHDN06', 'HDN02', 'SP09', 58, 'SZ01', 'M01', 500000),
('CTHDN07', 'HDN02', 'SP04', 40, 'SZ01', 'M05', 180000),
('CTHDN08', 'HDN02', 'SP12', 34, 'SZ02', 'M03', 120000),
('CTHDN09', 'HDN03', 'SP10', 38, 'SZ02', 'M05', 90000),
('CTHDN10', 'HDN03', 'SP11', 29, 'SZ01', 'M04', 60000),
('CTHDN11', 'HDN03', 'SP13', 19, 'SZ01', 'M05', 180000),
('CTHDN12', 'HDN03', 'SP15', 23, 'SZ05', 'M01', 80000),
('CTHDN13', 'HDN04', 'SP08', 41, 'SZ01', 'M03', 40000),
('CTHDN14', 'HDN04', 'SP14', 25, 'SZ05', 'M02', 30000),
('CTHDN15', 'HDN04', 'SP20', 57, 'SZ04', 'M02', 350000),
('CTHDN16', 'HDN04', 'SP03', 28, 'SZ02', 'M05', 200000),
('CTHDN17', 'HDN05', 'SP17', 37, 'SZ04', 'M05', 250000),
('CTHDN18', 'HDN05', 'SP18', 56, 'SZ01', 'M02', 180000),
('CTHDN19', 'HDN05', 'SP19', 28, 'SZ04', 'M02', 300000),
('CTHDN20', 'HDN05', 'SP16', 27, 'SZ05', 'M03', 220000),
('CTHDN21', 'HDN05', 'SP01', 27, 'SZ05', 'M01', 50000),
('CTHDN22', 'HDN05', 'SP07', 49, 'SZ01', 'M02', 350000),
('CTHDN23', 'HDN05', 'SP02', 58, 'SZ01', 'M02', 150000),
('CTHDN24', 'HDN05', 'SP16', 50, 'SZ01', 'M02', 220000),
('CTHDN25', 'HDN05', 'SP09', 29, 'SZ02', 'M03', 500000),
('CTHDN26', 'HDN01', 'SP01', 40, 'SZ01', 'M01', 50000),
('CTHDN27', 'HDN01', 'SP01', 40, 'SZ02', 'M01', 50000),
('CTHDN28', 'HDN02', 'SP02', 40, 'SZ02', 'M05', 150000),
('CTHDN29', 'HDN02', 'SP03', 40, 'SZ05', 'M01', 200000),
('CTHDN30', 'HDN02', 'SP04', 40, 'SZ01', 'M01', 180000),
('CTHDN31', 'HDN03', 'SP05', 40, 'SZ02', 'M05', 100000),
('CTHDN32', 'HDN03', 'SP06', 40, 'SZ04', 'M01', 400000),
('CTHDN33', 'HDN01', 'SP07', 40, 'SZ03', 'M02', 350000),
('CTHDN34', 'HDN04', 'SP08', 40, 'SZ05', 'M05', 40000),
('CTHDN35', 'HDN04', 'SP09', 40, 'SZ03', 'M04', 500000),
('CTHDN36', 'HDN04', 'SP10', 40, 'SZ01', 'M02', 90000),
('CTHDN37', 'HDN05', 'SP11', 40, 'SZ02', 'M03', 60000),
('CTHDN38', 'HDN05', 'SP12', 40, 'SZ01', 'M04', 120000),
('CTHDN39', 'HDN05', 'SP13', 40, 'SZ05', 'M01', 180000),
('CTHDN40', 'HDN01', 'SP14', 40, 'SZ03', 'M04', 30000),
('CTHDN41', 'HDN02', 'SP15', 40, 'SZ05', 'M02', 80000),
('CTHDN42', 'HDN03', 'SP16', 40, 'SZ03', 'M02', 220000),
('CTHDN43', 'HDN04', 'SP18', 40, 'SZ02', 'M03', 180000),
('CTHDN44', 'HDN05', 'SP19', 40, 'SZ01', 'M03', 300000),
('CTHDN45', 'HDN01', 'SP20', 40, 'SZ04', 'M05', 350000);

-- BẢNG TAIKHOAN
INSERT TAIKHOAN (IDUSER, HOTEN, TENDN, MATKHAU, NHOM)
VALUES
('U01', N'Trần Hiền', 'hien', 123, 'admin'),
('U02', N'Nguyễn Lương Bằng', 'bang', 123, 'user'),
('U03', N'Ngô Quyền', 'quyen', 123, 'user'),
('U04', N'Đặng Văn Quý', 'quy', 123, 'admin');

-- BẢNG CHUCNANG
INSERT CHUCNANG (IDCN, TENCN)
VALUES
('CN01', N'QL Tài Khoản'),
('CN02', N'Phân Quyền'),
('CN03', N'QL Chức Năng'),
('CN04', N'QL Chất Liệu'),
('CN05', N'QL Mặt Hàng'),
('CN06', N'QL Nhân Viên'),
('CN07', N'QL Khách Hàng'),
('CN08', N'QL Hóa Đơn'),
('CN09', N'Chi Tiết Hóa Đơn'),
('CN10', N'Tìm Kiếm'),
('CN11', N'Báo cáo');

-- BẢNG PHANQUYEN
INSERT PHANQUYEN(IDPQ, IDUSER, IDCN)
VALUES
('PQ01', 'U02', 'CN03'),
('PQ02', 'U02', 'CN04'),
('PQ03', 'U02', 'CN05'),
('PQ04', 'U02', 'CN06'),
('PQ05', 'U02', 'CN09'),
('PQ06', 'U03', 'CN07'),
('PQ07', 'U03', 'CN08'),
('PQ08', 'U03', 'CN09'),
('PQ09', 'U03', 'CN10');