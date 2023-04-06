	-- SQL KOMUTLARI --
-- SQL ile Veritabaný oluþturma:
--create database OrnekDb -- komutu çalýþtýrmak için üst menüdeki  butonuna veya F5 e týklayabiliriz 
-- Eklenen veritabanýný görmek için sol pencerede Databases' a sað týk refresh demeliyiz!!

--alter database OrnekDb Modify name=OrnekDatabase -- Sql ile veritabaný adýný deðiþtirme

--drop database OrnekDatabase -- Sql ile veritabaný silme

-- sql ile veritabaný ve tablo oluþturma


/*create database OrnekDb -- OrnekDb veritabanýný oluþtur
go -- sonraki adýma devam et
use OrnekDb -- oluþturulan OrnekDb yi kullan
go -- sonraki adýma devam et --
Create Table Personel (PersonelID int, Adi varchar(50), Soyadi varchar(50)) -- Personel adýnda bir tablo oluþtur
*/


-- Boþ geçilme durumlarýný göndererek tablo oluþturma
/*use OrnekDb
go
Create Table Ogrenciler (Id int not null,  Adi varchar(50)  not null, Soyadi varchar(50) null)
*/

--Alter Table Personel Add Email varchar(50) -- Personel tablosuna sonradan Email Kolonu ekleme


--Alter Table Personel Add Ders varchar(50), Konu varchar(50) -- Birden fazla kolon ekleme

-- SATIRLARDAN BÝRÝNÝ SEÇÝP ÇALIÞTIRIRSAN SADECE O SATIRI ÇALIÞTIRIR

--Alter Table Personel Alter Column Email nvarchar(100) -- TABLODAKÝ KOLONU GÜNCELLEME

--Alter Table Personel Drop Column Email -- Tablodan kolon silme