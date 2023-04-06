	-- SQL KOMUTLARI --
-- SQL ile Veritaban� olu�turma:
--create database OrnekDb -- komutu �al��t�rmak i�in �st men�deki  butonuna veya F5 e t�klayabiliriz 
-- Eklenen veritaban�n� g�rmek i�in sol pencerede Databases' a sa� t�k refresh demeliyiz!!

--alter database OrnekDb Modify name=OrnekDatabase -- Sql ile veritaban� ad�n� de�i�tirme

--drop database OrnekDatabase -- Sql ile veritaban� silme

-- sql ile veritaban� ve tablo olu�turma


/*create database OrnekDb -- OrnekDb veritaban�n� olu�tur
go -- sonraki ad�ma devam et
use OrnekDb -- olu�turulan OrnekDb yi kullan
go -- sonraki ad�ma devam et --
Create Table Personel (PersonelID int, Adi varchar(50), Soyadi varchar(50)) -- Personel ad�nda bir tablo olu�tur
*/


-- Bo� ge�ilme durumlar�n� g�ndererek tablo olu�turma
/*use OrnekDb
go
Create Table Ogrenciler (Id int not null,  Adi varchar(50)  not null, Soyadi varchar(50) null)
*/

--Alter Table Personel Add Email varchar(50) -- Personel tablosuna sonradan Email Kolonu ekleme


--Alter Table Personel Add Ders varchar(50), Konu varchar(50) -- Birden fazla kolon ekleme

-- SATIRLARDAN B�R�N� SE��P �ALI�TIRIRSAN SADECE O SATIRI �ALI�TIRIR

--Alter Table Personel Alter Column Email nvarchar(100) -- TABLODAK� KOLONU G�NCELLEME

--Alter Table Personel Drop Column Email -- Tablodan kolon silme