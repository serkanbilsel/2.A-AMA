-- SQL SORGULAMA --
--Select * from Products
--Select ProductName, UnitPrice from Products

-- Tablo kolonlarýna Alias takma isim verme
--Select ProductName as ÜrünAdý, UnitPrice as [Ürün Fiyatý] From Products -- Kolon adýnda iki kelime arasýnda boþluk býrakmak istersen [ köþeli parantez kullanýp arasýna yazmalýyýz ]

--Tabloya Alias takma isim verme
--Select p.ProductName as Ürünadý, p.UnitPrice as [Ürün Fiyatý] From Products p
-----------------------------------------------------------------------------------------------
--Tablodan veri okurken hesaplama
--Select p.ProductName as Ürünadý, p.UnitPrice as [Ürün Fiyatý],p.UnitsInStock as [Stoktaki Miktar], p.UnitsInStock * p.UnitPrice as[Toplam Kazanç] From Products p
---------------------------------------------------------------------------------------------------------
--SQL karþýlaþtýrma Operatörü
/*
SELECT * FROM Products where UnitPrice = 18 -- UnitPrice deðeri 18 olan ürünleri çekmek için
SELECT * FROM Products where UnitPrice > 18 -- UnitPrice deðeri 18 den büyük olan ürünleri çekmek için
SELECT * FROM Products where UnitPrice < 18 -- UnitPrice deðeri 18 den  küçük olan ürünleri çekmek için
SELECT * FROM Products where UnitPrice >= 18 -- UnitPrice deðeri 18 ve üzeri olan ürünleri çekmek için
SELECT * FROM Products where UnitPrice <= 18 -- UnitPrice deðeri 18 ve altý olan ürünleri çekmek için
SELECT * FROM Products where UnitPrice <> 18 -- UnitPrice deðeri 18 ve olmayan ürünleri çekmek için
*/
--------------------------------------------------------------------------------------------------------
-- MANTIKSAL IFADELER And ve OR Operaötür --
--SELECT * FROM Products where SupplierID = 1 and CategoryID = 1 -- ürünlerden SupplierID ve CategoryID deðeri 1 olanlarý getir
--SELECT * FROM Products where SupplierID = 1 or CategoryID = 1 -- ürünlerden SupplierID veya  CategoryID deðeri 1 olanlarý getir

-- Select Top ile üstten belirli sayýda kayýt seçme --
--Select Top(18) * from Products -- Üründen ilk 18 ürünü getir
--select top(18) ProductName, UnitPrice From Products -- ilk 18 ürünün Productname, ve Unitprice 'ýný getirdi
------------------------------------------------------------------------------
-- Order by ile sýra alma

--Select * from products order by UnitsInStock -- ürünleri UnitInStock kolonunda deðeri en küçükten büyüðe doðru sýralama.
--- TAM TERSÝ ----
--select * from Products order by UnitsInStock desc -- ürünleri UnitInstock kolonunda deðeri en büyükten en küçüðe sýralama
-----------------------------------------------------------------------------
-- Like ile arama, Filtreleme
--select * from Products where ProductName like 'a%' -- ürün adý A ile baþlayanlarý getir
--select * from Products where ProductName like '%a' -- ürün adý A ile bitenleri getir % den sonra sonuna yazýlýyor
--select * from Products where ProductName like '%as%' -- ürün adý içinde AS geçenleri getir
--select * from Products where ProductName like '_a%' -- ürün 2. Karakteri A ile olanlarýgetir
--select * from Products where ProductName like 'a__%' -- ürün adý A ile baþlayan ve en az 3 karakter uzunlukta olanlarýgetir
--select * from Products where ProductName like 'a%p' -- ürün adý A ile baþlayan ve P ile bitenleri getir

--TAM TERSÝ ÝÇÝN--
--select * from Products where ProductName Not like 'a%' -- ürün adý A ile baþlamayanlarý getir
---------------------------------------------------------------------------------------------------------
--SQL In-Not In Operatörü 
--select * from products where CategoryID In (1,3,5) -- ürünlerden kategorisi 1,3 ve 5 olanlarý getir
--select * from products where CategoryID Not In (1,3,5) -- ürünlerden kategorisi 1,3 ve 5 olmayanlarý getir.
--select * from products where CategoryID Not In (1,3,5) Order By CategoryID -- ürünlerden kategorisi 1,3 ve 5 olmayanlarý getir ve bküçükten büyüðüye doðru sýrala
-------------------------------------------------------------------------------------------
-- Ýç Ýçe iliþkili veri okuma
--select * from Customers where Country in ('Germany', 'UK') -- Müþterilerden ülkesi germany ve uk olanlarý getir
--select * from Customers where Country in (Select Country from Suppliers) -- müþterilerden ülkesi tedarikçilerdeki ülkeyle ayný olanlarý getir ( customers ) ( suppliers ) tedarikçi.
----------------------------------------------

--Sql Between Operatörü
--Select * from products where UnitPrice Between 18 and 41 -- ürünlerden fiyatý 18 ve 41 arasýnda olanlarý getir

--Sql Null alanlara göre sorgulama
--select * from Orders where ShipRegion is null -- sipari,þlerden ShipRegion kolonu null veri olanlarý getir
--select * from Orders where ShipRegion is not null -- sipariþlerden ShipRegion kolonu null veri olmayanlarý getir

-- Sql Distinct ile tekar eden kayýtlarý engelleme. Bu aþaðýdaki koddan sonra ayný ülkeleri listeliyor.
--select country from customers order by Country
--select Distinct country from customers order by Country -- Distinct tekrar edenleri engelliyor
--------------------------------------------------------------------------------

--Sql Joins ile Tablolarda birleþik sorgu oluþturma -- ( Joins birleþtirme )

--select * from Products 
--select * from Categories

--select Products.ProductName, Products.UnitsInStock, Categories.CategoryName FROM Products 
--JOIN Categories -- Products tablosunu join ile Categories tablosuyla birleþtir
--on Products.CategoryID = Categories.CategoryID --bu birleþtirme için products ve Categories tablosundaki ortak nokta olan CategoryID allanýný kullan.
------------------------------------------
-- Left Join
/*Select Customers.ContactName, Orders.OrderID From Customers -- Seçili kolonlarý getirir

left join Orders -- Customers ile Orders tablolarýný solda birleþtir, yani soldaki tablonun tüm verilerini saðldaki tabloda eþleþen kayýtlarý getir, eþleþme yoksa null da olsa müþteriyi getir.

on Customers.CustomerID = Orders.CustomerID -- 2 Tablonun ortak noktasý CustomerID deðerlerine göre eþleþme yap

*/
/*
-- Right Join -- Saðdaki tablodan tüm kayýtlarý, soldaki tablodan eþleþenleri getirir, eðer soldaki tabloda olmayan kayýt varsa null gelir.
Select Orders.OrderID, Employees.LastName, Employees.FirstName
From Orders
Right join Employees On Orders.EmployeeID = Employees.EmployeeID
*/
--------------------------------------------------
/*
-- SQL full Outer Join -- Allah ne verdiyse birleþtiriyor :D
Select Customers.ContactName, Orders.OrderID
FROM Customers Full Outer Join Orders on Customers.CustomerID = Orders.CustomerID
order by Customers.ContactName
*/


-- SQL Group By : SOnuçlarda verileri gruplayarak sunmamýzý saðlar
--select Country from Customers Group by Country

--select Country, COUNT(CustomerID) as [Müþteri Sayýsý] from Customers Group by Country -- Hangi ülkeden kaç müþterimiz var

exec CustOrderHist AROUT

