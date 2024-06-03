drop database QLDL
Create database QLDL
use QLDL
/*tao bang customers*/
drop table BillExportDetails
drop table BillExport
drop table customer
create table customer(
CustomerId int identity ,
CustomerFullName Nvarchar(200),
Ngaydk Date,
Isdailycap2 int default 0,
CustomerWard nvarchar(20),
CustomerDistrict nvarchar(20),
CustomerCity nvarchar(20),
CustomerDiscount int default 0,
CustomerPhoneNumber varchar(100) not null,
CustomerEmail varchar(1000) not null,
CustomerPoint int default 0,
Constraint pk_Customer Primary key (CustomerId),
Constraint fk_province foreign key (CustomerCity) references provinces(code),
Constraint fk_district foreign key (CustomerDistrict) references districts(code),
Constraint fk_Ward foreign key (CustomerWard) references wards(code),
)
insert into customer(CustomerFullName,CustomerDiscount,CustomerCity,CustomerWard,CustomerPhoneNumber,CustomerEmail)
values(N'Khách',null,null,null,'0','0')
select * from customer

delete from customer where CustomerId=2
drop table customer
/*tao bang product*/
create table productgroup(
ProductGroupId int identity primary key,
   ProductGroupName Nvarchar(500) not null
 )
 insert into productgroup (ProductGroupName)
  values('dai'),('mao')
select * from productgroup      
create table product(
ProductId int identity,
ProductGroupName int,
ProductName Nvarchar(50) not null,
ProductPrice float not null,
ProductQuantity int default 0,
ProductInfo Nvarchar(100) not null,
ProductImageLink Varchar(1000),
constraint fk_grname foreign key (ProductGroupName) references productgroup(ProductGroupId),

constraint pk_Product Primary key(ProductId)

)

drop table product 
insert into product
(ProductGroupName,ProductName,ProductPrice,ProductQuantity,ProductInfo)
values
(1,	N'Vỏ gối 009',	310.15,	12,	N'Chất liệu: Modal'	),

delete from product where ProductId<50
delete from productgroup where ProductGroupId<50
select * from product

/*tao bang hoa don Nhap*/
create table BillImport(
BillImportId int identity,
BillImportDate Date not null default getdate(),
constraint pk_BillImport primary key(BillImportId))
select * from BillImport
drop table BillImport
delete from BillImport where BillImportId<50
delete from BillImportDetails where BillImportDetailsId<50
delete from BillExport where BillExportId<50
delete from BillExportDetails where BillExportDetailsId<50

/* tao bang chi tiet hoa don nhap*/
Create table BillImportDetails(
BillImportDetailsId int identity,
BillImportId int,
ProductId int,
Price float,
Quantity int,
constraint pk_BillImportDetails primary key (BillImportDetailsId),
constraint fk_BillImport foreign key (BillImportId) references BillImport(BillImportId),
constraint fk_BillImportProduct foreign key (ProductId) references Product(ProductId)
)
select * from BillImportDetails
drop table BillImportDetails
// tao bang hoa don xuat
create table BillExport(
BillExportId int identity,
CustomerId int,
BillExportDate Date not null default getdate(),
BillTotalMoney float,
BillPayPercent int,
BillDiscount int default 0,
constraint pk_BillExport primary key(BillExportId),
constraint fk_Customer foreign key (customerId) references Customer(CustomerId))
select * from BillExport

/*tao bang chi tiet hoa don xuat*/
Create table BillExportDetails(
BillExportDetailsId int identity,
BillExportId int,
ProductId int,
Quantity int,
constraint pk_BillExportDetails primary key (BillExportDetailsId),
constraint fk_BillExport foreign key (BillExportId) references BillExport(BillExportId),
constraint fk_BillExportProduct foreign key (ProductId) references Product(ProductId)
)
select * from BillExportDetails
delete from BillExportDetails where(BillExportDetailsId<20)
create table Users(
 
TaiKhoan Varchar(30)primary key,
MatKhau Varchar(30),
Vaitro int)
insert into Users values
('Admin','12345',1)
select * from Users
create table Receipts(
ReceiptsId int identity primary key,
CustomerId int,
TotalMoney float,
ReceiptsDate Date
constraint fk_ReceiptsCu foreign key (CustomerId) references Customer(CustomerId),
)

create table chietkhausp(
chietkhauid int identity primary key,
CustomerId int,
ProductId int,
chietkhau int
constraint fk_chietkhauCu foreign key (CustomerId) references Customer(CustomerId),
constraint fk_chietkhausp foreign key (ProductId) references Product(ProductId))



  

--Add dia gioi hanh chinh--
CREATE TABLE administrative_regions (
	id integer NOT NULL,
	name nvarchar(255) NOT NULL,
	name_en nvarchar(255) NOT NULL,
	code_name nvarchar(255) NULL,
	code_name_en nvarchar(255) NULL,
	CONSTRAINT administrative_regions_pkey PRIMARY KEY (id)
);


-- CREATE administrative_units TABLE
CREATE TABLE administrative_units (
	id integer NOT NULL,
	full_name nvarchar(255) NULL,
	full_name_en nvarchar(255) NULL,
	short_name nvarchar(255) NULL,
	short_name_en nvarchar(255) NULL,
	code_name nvarchar(255) NULL,
	code_name_en nvarchar(255) NULL,
	CONSTRAINT administrative_units_pkey PRIMARY KEY (id)
);


-- CREATE provinces TABLE
CREATE TABLE provinces (
	code nvarchar(20) NOT NULL,
	name nvarchar(255) NOT NULL,
	name_en nvarchar(255) NULL,
	full_name nvarchar(255) NOT NULL,
	full_name_en nvarchar(255) NULL,
	code_name nvarchar(255) NULL,
	administrative_unit_id integer NULL,
	administrative_region_id integer NULL,
	CONSTRAINT provinces_pkey PRIMARY KEY (code)
);


-- provinces foreign keys

ALTER TABLE provinces ADD CONSTRAINT provinces_administrative_region_id_fkey FOREIGN KEY (administrative_region_id) REFERENCES administrative_regions(id);
ALTER TABLE provinces ADD CONSTRAINT provinces_administrative_unit_id_fkey FOREIGN KEY (administrative_unit_id) REFERENCES administrative_units(id);

CREATE INDEX idx_provinces_region ON provinces(administrative_region_id);
CREATE INDEX idx_provinces_unit ON provinces(administrative_unit_id);


-- CREATE districts TABLE
CREATE TABLE districts (
	code nvarchar(20) NOT NULL,
	name nvarchar(255) NOT NULL,
	name_en nvarchar(255) NULL,
	full_name nvarchar(255) NULL,
	full_name_en nvarchar(255) NULL,
	code_name nvarchar(255) NULL,
	province_code nvarchar(20) NULL,
	administrative_unit_id integer NULL,
	CONSTRAINT districts_pkey PRIMARY KEY (code)
);


-- districts foreign keys

ALTER TABLE districts ADD CONSTRAINT districts_administrative_unit_id_fkey FOREIGN KEY (administrative_unit_id) REFERENCES administrative_units(id);
ALTER TABLE districts ADD CONSTRAINT districts_province_code_fkey FOREIGN KEY (province_code) REFERENCES provinces(code);

CREATE INDEX idx_districts_province ON districts(province_code);
CREATE INDEX idx_districts_unit ON districts(administrative_unit_id);



-- CREATE wards TABLE
CREATE TABLE wards (
	code nvarchar(20) NOT NULL,
	name nvarchar(255) NOT NULL,
	name_en nvarchar(255) NULL,
	full_name nvarchar(255) NULL,
	full_name_en nvarchar(255) NULL,
	code_name nvarchar(255) NULL,
	district_code nvarchar(20) NULL,
	administrative_unit_id integer NULL,
	CONSTRAINT wards_pkey PRIMARY KEY (code)
);
select * from wards where (code='00721')

-- wards foreign keys

ALTER TABLE wards ADD CONSTRAINT wards_administrative_unit_id_fkey FOREIGN KEY (administrative_unit_id) REFERENCES administrative_units(id);
ALTER TABLE wards ADD CONSTRAINT wards_district_code_fkey FOREIGN KEY (district_code) REFERENCES districts(code);

CREATE INDEX idx_wards_district ON wards(district_code);
CREATE INDEX idx_wards_unit ON wards(administrative_unit_id);

--import data
