-- SQL SORGULAMA --
--Select * from Products
--Select ProductName, UnitPrice from Products

-- Tablo kolonlar�na Alias takma isim verme
--Select ProductName as �r�nAd�, UnitPrice as [�r�n Fiyat�] From Products -- Kolon ad�nda iki kelime aras�nda bo�luk b�rakmak istersen [ k��eli parantez kullan�p aras�na yazmal�y�z ]

--Tabloya Alias takma isim verme
--Select p.ProductName as �r�nad�, p.UnitPrice as [�r�n Fiyat�] From Products p
-----------------------------------------------------------------------------------------------
--Tablodan veri okurken hesaplama
--Select p.ProductName as �r�nad�, p.UnitPrice as [�r�n Fiyat�],p.UnitsInStock as [Stoktaki Miktar], p.UnitsInStock * p.UnitPrice as[Toplam Kazan�] From Products p
---------------------------------------------------------------------------------------------------------
--SQL kar��la�t�rma Operat�r�
/*
SELECT * FROM Products where UnitPrice = 18 -- UnitPrice de�eri 18 olan �r�nleri �ekmek i�in
SELECT * FROM Products where UnitPrice > 18 -- UnitPrice de�eri 18 den b�y�k olan �r�nleri �ekmek i�in
SELECT * FROM Products where UnitPrice < 18 -- UnitPrice de�eri 18 den  k���k olan �r�nleri �ekmek i�in
SELECT * FROM Products where UnitPrice >= 18 -- UnitPrice de�eri 18 ve �zeri olan �r�nleri �ekmek i�in
SELECT * FROM Products where UnitPrice <= 18 -- UnitPrice de�eri 18 ve alt� olan �r�nleri �ekmek i�in
SELECT * FROM Products where UnitPrice <> 18 -- UnitPrice de�eri 18 ve olmayan �r�nleri �ekmek i�in
*/
--------------------------------------------------------------------------------------------------------
-- MANTIKSAL IFADELER And ve OR Opera�t�r --
--SELECT * FROM Products where SupplierID = 1 and CategoryID = 1 -- �r�nlerden SupplierID ve CategoryID de�eri 1 olanlar� getir
--SELECT * FROM Products where SupplierID = 1 or CategoryID = 1 -- �r�nlerden SupplierID veya  CategoryID de�eri 1 olanlar� getir

-- Select Top ile �stten belirli say�da kay�t se�me --
--Select Top(18) * from Products -- �r�nden ilk 18 �r�n� getir
--select top(18) ProductName, UnitPrice From Products -- ilk 18 �r�n�n Productname, ve Unitprice '�n� getirdi
------------------------------------------------------------------------------
-- Order by ile s�ra alma

--Select * from products order by UnitsInStock -- �r�nleri UnitInStock kolonunda de�eri en k���kten b�y��e do�ru s�ralama.
--- TAM TERS� ----
--select * from Products order by UnitsInStock desc -- �r�nleri UnitInstock kolonunda de�eri en b�y�kten en k����e s�ralama
-----------------------------------------------------------------------------
-- Like ile arama, Filtreleme
--select * from Products where ProductName like 'a%' -- �r�n ad� A ile ba�layanlar� getir
--select * from Products where ProductName like '%a' -- �r�n ad� A ile bitenleri getir % den sonra sonuna yaz�l�yor
--select * from Products where ProductName like '%as%' -- �r�n ad� i�inde AS ge�enleri getir
--select * from Products where ProductName like '_a%' -- �r�n 2. Karakteri A ile olanlar�getir
--select * from Products where ProductName like 'a__%' -- �r�n ad� A ile ba�layan ve en az 3 karakter uzunlukta olanlar�getir
--select * from Products where ProductName like 'a%p' -- �r�n ad� A ile ba�layan ve P ile bitenleri getir

--TAM TERS� ���N--
--select * from Products where ProductName Not like 'a%' -- �r�n ad� A ile ba�lamayanlar� getir
---------------------------------------------------------------------------------------------------------
--SQL In-Not In Operat�r� 
--select * from products where CategoryID In (1,3,5) -- �r�nlerden kategorisi 1,3 ve 5 olanlar� getir
--select * from products where CategoryID Not In (1,3,5) -- �r�nlerden kategorisi 1,3 ve 5 olmayanlar� getir.
--select * from products where CategoryID Not In (1,3,5) Order By CategoryID -- �r�nlerden kategorisi 1,3 ve 5 olmayanlar� getir ve bk���kten b�y���ye do�ru s�rala
-------------------------------------------------------------------------------------------
-- �� ��e ili�kili veri okuma
--select * from Customers where Country in ('Germany', 'UK') -- M��terilerden �lkesi germany ve uk olanlar� getir
--select * from Customers where Country in (Select Country from Suppliers) -- m��terilerden �lkesi tedarik�ilerdeki �lkeyle ayn� olanlar� getir ( customers ) ( suppliers ) tedarik�i.
----------------------------------------------

--Sql Between Operat�r�
--Select * from products where UnitPrice Between 18 and 41 -- �r�nlerden fiyat� 18 ve 41 aras�nda olanlar� getir

--Sql Null alanlara g�re sorgulama
--select * from Orders where ShipRegion is null -- sipari,�lerden ShipRegion kolonu null veri olanlar� getir
--select * from Orders where ShipRegion is not null -- sipari�lerden ShipRegion kolonu null veri olmayanlar� getir

-- Sql Distinct ile tekar eden kay�tlar� engelleme. Bu a�a��daki koddan sonra ayn� �lkeleri listeliyor.
--select country from customers order by Country
--select Distinct country from customers order by Country -- Distinct tekrar edenleri engelliyor
--------------------------------------------------------------------------------

--Sql Joins ile Tablolarda birle�ik sorgu olu�turma -- ( Joins birle�tirme )

--select * from Products 
--select * from Categories

--select Products.ProductName, Products.UnitsInStock, Categories.CategoryName FROM Products 
--JOIN Categories -- Products tablosunu join ile Categories tablosuyla birle�tir
--on Products.CategoryID = Categories.CategoryID --bu birle�tirme i�in products ve Categories tablosundaki ortak nokta olan CategoryID allan�n� kullan.
------------------------------------------
-- Left Join
/*Select Customers.ContactName, Orders.OrderID From Customers -- Se�ili kolonlar� getirir

left join Orders -- Customers ile Orders tablolar�n� solda birle�tir, yani soldaki tablonun t�m verilerini sa�ldaki tabloda e�le�en kay�tlar� getir, e�le�me yoksa null da olsa m��teriyi getir.

on Customers.CustomerID = Orders.CustomerID -- 2 Tablonun ortak noktas� CustomerID de�erlerine g�re e�le�me yap

*/
/*
-- Right Join -- Sa�daki tablodan t�m kay�tlar�, soldaki tablodan e�le�enleri getirir, e�er soldaki tabloda olmayan kay�t varsa null gelir.
Select Orders.OrderID, Employees.LastName, Employees.FirstName
From Orders
Right join Employees On Orders.EmployeeID = Employees.EmployeeID
*/
--------------------------------------------------
/*
-- SQL full Outer Join -- Allah ne verdiyse birle�tiriyor :D
Select Customers.ContactName, Orders.OrderID
FROM Customers Full Outer Join Orders on Customers.CustomerID = Orders.CustomerID
order by Customers.ContactName
*/


-- SQL Group By : SOnu�larda verileri gruplayarak sunmam�z� sa�lar
--select Country from Customers Group by Country

--select Country, COUNT(CustomerID) as [M��teri Say�s�] from Customers Group by Country -- Hangi �lkeden ka� m��terimiz var

exec CustOrderHist AROUT

