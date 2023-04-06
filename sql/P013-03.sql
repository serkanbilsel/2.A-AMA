-- SQL ÝLE CRUD (Create,Read,Uptade,Delete) Kayýt Ýþlemleri

--insert into Personel (PersonelID, Adi, Soyadi) values (1, 'Alp', 'Arslan') -- Kayýt Ekleme

--insert into Personel  values (2, 'Murat', 'Yýlmaz') -- tüm kolonlara ver yollayacaksak kolon adlarýný belirtmemize gerek yok.

-- Kolon adlarýný vermediðimizde tüm kolonlara veriyollamak zorundayýz yoksa hata verir.

--Sql ile tablodaki verileri çekme
--select * from Personel -- Personel tablosundaki tüm kolonlardaki tüm verileri getir.
--select Adi, Soyadi from Personel -- Personel tablosundaki Adi ve soyadi daki tüm verileri getir

--SQL ile tablodaki verileri Güncelleme
--update Personel Set Adi = 'Mesut', Soyadi = 'Ilýca' --  Personel tablosundaki tüm kolonlardaki tüm verileri  Adi ve Soyad daki tüm verileri deðiþtirdi


--ÖNEMLÝ
--update Personel Set Adi = 'Alp', Soyadi = 'Arslan' where PersonelID = 2 ---- WHERE PERSONELID = 2 --PERSONELID DEÐERÝ 2 OLANLARI GÜNCELLE

-- Sql ile tablodaki verileri SÝLME
--delete from Personel --WHERE þartý olmazsa ütm kayýtlarý siler. GERÝ ALMAK ZOR !!!!
--delete from Personel  where PersonelID = 2
--select * from Personel

--SQL ile veritabaný yedeði ALMA
--Backup Database OrnekDb To Disk = 'C:\Users\serka\Desktop\DERS DOSYALARI\2.AÞAMA\sql\DbYedek.bak'

-- SQL ile tablodaki verileri temizleme
--Truncate Table Personel

-- SQL OPERATÖRLER--
-- Aritmetik Operatörler

--Toplama
--Select 10 + 8 As Toplam -- kolon adý Toplam olsun

-- Çýkartma
--Select 10 - 8 As Çýkartma  -- Çýkartma iþlemi 

-- Çarpma
--Select 9*2 As Çarpma -- Çarpma iþlemi

-- Bölme
--Select 10/2 As Bölme -- Bölme iþlemi

-- Modulo
--select 27 % 2 As Modulo