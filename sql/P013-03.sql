-- SQL �LE CRUD (Create,Read,Uptade,Delete) Kay�t ��lemleri

--insert into Personel (PersonelID, Adi, Soyadi) values (1, 'Alp', 'Arslan') -- Kay�t Ekleme

--insert into Personel  values (2, 'Murat', 'Y�lmaz') -- t�m kolonlara ver yollayacaksak kolon adlar�n� belirtmemize gerek yok.

-- Kolon adlar�n� vermedi�imizde t�m kolonlara veriyollamak zorunday�z yoksa hata verir.

--Sql ile tablodaki verileri �ekme
--select * from Personel -- Personel tablosundaki t�m kolonlardaki t�m verileri getir.
--select Adi, Soyadi from Personel -- Personel tablosundaki Adi ve soyadi daki t�m verileri getir

--SQL ile tablodaki verileri G�ncelleme
--update Personel Set Adi = 'Mesut', Soyadi = 'Il�ca' --  Personel tablosundaki t�m kolonlardaki t�m verileri  Adi ve Soyad daki t�m verileri de�i�tirdi


--�NEML�
--update Personel Set Adi = 'Alp', Soyadi = 'Arslan' where PersonelID = 2 ---- WHERE PERSONELID = 2 --PERSONELID DE�ER� 2 OLANLARI G�NCELLE

-- Sql ile tablodaki verileri S�LME
--delete from Personel --WHERE �art� olmazsa �tm kay�tlar� siler. GER� ALMAK ZOR !!!!
--delete from Personel  where PersonelID = 2
--select * from Personel

--SQL ile veritaban� yede�i ALMA
--Backup Database OrnekDb To Disk = 'C:\Users\serka\Desktop\DERS DOSYALARI\2.A�AMA\sql\DbYedek.bak'

-- SQL ile tablodaki verileri temizleme
--Truncate Table Personel

-- SQL OPERAT�RLER--
-- Aritmetik Operat�rler

--Toplama
--Select 10 + 8 As Toplam -- kolon ad� Toplam olsun

-- ��kartma
--Select 10 - 8 As ��kartma  -- ��kartma i�lemi 

-- �arpma
--Select 9*2 As �arpma -- �arpma i�lemi

-- B�lme
--Select 10/2 As B�lme -- B�lme i�lemi

-- Modulo
--select 27 % 2 As Modulo