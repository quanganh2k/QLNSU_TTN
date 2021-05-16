create database QLNHANSU
go

use QLNHANSU

go

create table PHONGBAN
(
	MaPB nvarchar(20) primary key not Null,
	TenPB nvarchar(50) 
)
go

create table CHUCVU
(
	MaCV nvarchar(20) primary key not Null,
	TenCV nvarchar(50)
)
go

create table LUONG
(
	MaLuong nvarchar(20) primary key not Null,
	BacLuong float,
	LuongCB float
)
go

create table NHANVIEN
(
	MaNV nvarchar(20) primary key not Null,
	TenNV nvarchar(50),
	NgaySinh date,
	GioiTinh nvarchar(10),
	QueQuan nvarchar(30),
	DiaChi nvarchar(50),
	MaPB nvarchar(20) references PHONGBAN(MaPB),
	MaCV nvarchar(20) references CHUCVU(MaCV),
	MaLuong nvarchar(20) references LUONG(MaLuong)
)
go

create table TAIKHOAN
(
	Username varchar(50),
	PW varchar(50)
)
go

insert into PHONGBAN values(N'MPB1',N'Giám đốc')
insert into PHONGBAN values(N'MPB2',N'Nhân sự')
insert into PHONGBAN values(N'MPB3',N'Kế toán')
insert into PHONGBAN values(N'MPB4',N'Bảo vệ')
insert into PHONGBAN values(N'MPB5',N'Marketing')
go

insert into CHUCVU values(N'MCV1',N'Giám đốc')
insert into CHUCVU values(N'MCV2',N'Kế toán')
insert into CHUCVU values(N'MCV3',N'Quản lý')
insert into CHUCVU values(N'MCV4',N'HR')
insert into CHUCVU values(N'MCV5',N'Content')
insert into CHUCVU values(N'MCV6',N'Bảo vệ')
go

insert into LUONG values(N'ML1',1,2000)
insert into LUONG values(N'ML2',2,4000)
insert into LUONG values(N'ML3',3,6000)
insert into LUONG values(N'ML4',4,8000)
insert into LUONG values(N'ML5',5,10000)
go

insert into NHANVIEN values(N'MNV1',N'Nguyễn Công Phượng','1995-12-12',N'Nam',N'Nghệ An',N'số 1 Đô Lương',N'MPB2',N'MCV4',N'ML2')
insert into NHANVIEN values(N'MNV2',N'Nguyễn Văn A','1996-12-12',N'Nam',N'Hà Nội',N'số 2 Lê Văn Lương',N'MPB3',N'MCV2',N'ML3')
insert into NHANVIEN values(N'MNV3',N'Nguyễn Diệu Anh','2000-11-20',N'Nữ',N'Hà Nội',N'số 8 Triều Khúc',N'MPB2',N'MCV4',N'ML2')
insert into NHANVIEN values(N'MNV4',N'Bùi Thảo An','1997-12-12',N'Nữ',N'Hải Phòng',N'số 20 Đồ Sơn',N'MPB5',N'MCV5',N'ML3')
insert into NHANVIEN values(N'MNV5',N'Quang Anh','2000-11-24',N'Nam',N'Hà Nội',N'Hoàng Quốc Việt',N'MPB1',N'MCV1',N'ML5')
insert into NHANVIEN values(N'MNV6',N'Nguyễn Công Tuấn','1995-12-12',N'Nam',N'Nghệ An',N'số 3 Đô Lương',N'MPB4',N'MCV6',N'ML1')
insert into NHANVIEN values(N'MNV7',N'Nguyễn Văn Vinh','1997-5-10',N'Nam',N'Bắc Giang',N'Lục Ngạn',N'MPB5',N'MCV5',N'ML2')
insert into NHANVIEN values(N'MNV8',N'Lê Văn Sơn','1995-12-12',N'Nam',N'Nghệ An',N'số 100 Đô Lương',N'MPB2',N'MCV4',N'ML2')
insert into NHANVIEN values(N'MNV9',N'Đinh Văn Thanh','1995-12-12',N'Nam',N'Nghệ An',N'Kim Liên',N'MPB1',N'MCV1',N'ML5')
insert into NHANVIEN values(N'MNV10',N'Lê Tú Anh','1997-4-2',N'Nữ',N'Nam Định',N'số 10 Lê Hồng Phong',N'MPB2',N'MCV3',N'ML4')
go

insert into TAIKHOAN values('admin','123456')







