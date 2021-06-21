create database HoTenDB1
--bảng nhuowig dùng
create table UserAccount
(
ID INT IDENTITY(1,1) PRIMARY KEY,
UserName nvarchar(50)not null,
Password varchar(50) not null,
Status nvarchar(50),

)
--bảng loại sản phẩm 
create table Category
(
maloai nvarchar(10)not null PRIMARY KEY,
tenloai nvarchar(50)not null,
mota nvarchar(50),

)
--bảng sản phẩm
create table Product
(
masp nvarchar(10)not null PRIMARY KEY,
maloai nvarchar(10) not null foreign key (maloai) references Category,
tensp nvarchar(50)not null,
dongia money,
soluong int ,
Image nvarchar(200) null,
trangthai char(30)
	check (trangthai =N'Còn hàng'or trangthai=N'hết hàng'),

mota nvarchar(50),

)
--bảng khách hàng
create table  customer
(
maKH nvarchar(10)not null primary key,
tenKH nvarchar(50)not null,
diachiKH nvarchar(50)not null,
SDT varchar(10) null unique
	check (SDT like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
email varchar(50)null
	check(email like '[a-z]%@%'),

)
--bảng đơn hàng
create table donhang
(
maDH nvarchar(20)not null primary key,
maKH nvarchar(10) not null foreign key (maKH) references customer,
masp nvarchar(10) not null foreign key (masp) references Product,

ngaytaoDH datetime null default getdate()
	check (ngaytaoDH <= getdate()),
diachigiaohang nvarchar(50) not null,
SDTgiaohang nvarchar(10) null unique
	check (SDTgiaohang like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),

ngaythanhtoan datetime null default getdate(), 
	
ngaygiaohang datetime null  default getdate(),
trangthaiDonHang nvarchar(100)not null,
)


ALTER TABLE Product
  ADD mausac nvarchar(50);
