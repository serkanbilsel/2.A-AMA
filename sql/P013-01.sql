-- Sql de yorum sat�r� 
-- Sql komutlar� �al��t�rmak i�in ssms �st men�s�ndeki New Query men�s�ne t�kl�yoruz
-- Yazd���m�z sql komutlar�n� �st men�deki kaydet ikonuna t�klayarak veya ctrl + s ile bilgisayar�m�za sql uzant�s�yla kaydedip daha sonra �ift t�klayarak smss program�yla bu dosyalar� a�abiliriz.
-- Smss ile yeni veritaban� olu�turma
/*
�oklu yorum sat�r� 
databses klas�r�ne sa� t�klay�p new database diyerek a��lan pencerede veritaban�na bir isim verip ok diyerek pencereyi kapat�yoruz
/*
-- Smss ile veritaban�na tablo ekleme
/* 
Veritaban�na + ya basarak geni�letim a��lan klas�rlerden Tables'e sa� taklay�p new table > Table yolunu izleyip Desing modunda tablo olu�turma ekran�n� a��yoruz..
A��lan ekranda Kolon ad�, bu kolona eklenecek verilerin tipi ve bo� ge�ilip gee�ilmeeyce�i her sat�r i�in ayarl�yoruz.
Tablo kolonlar�n� ayarlad�ktan sonra �st men�den kaydet ikonuna veya cstrl + s e basarak bu tabloya bir isim verip kaydediyoruz.
Kaydetti�imiz tabloyu g�rmek i�in so ltaraftaki men�den veritab�n�m�z� ve i�indeki tables  i + ye basrak a��p tables e sa� t�klay�p refresh men�s�ne t�klmamam�z gerekir.

Not :  Sql server' � ilk kurdu�umuzda tabloyu kaydettikten sonra de�i�ikli�e izin vermezse SSMS den  TOOLS > OPT�ONS > DES�NGER men�s�n� a��p sa�daki se�eneklerden Prevent saving ile ba�layan i�areti kald�r�yoruz
/*

--Olu�turdu�umuz tablolara veri giri�i yapmak i�in 
--�lgili tabloya sa� t�klay�p a��lan men�den Edit Top 200 rows a bas�yoruz.
--Daha �nceden olu�turdu�umuz bir tabloyu de�i�tirmek i�in Tabloya sa� t�klay�p a��lan men�den Desing men�s�ne t�kl�yoruz. A��lan tabloda de�i�iklikleri yap�p kaydet diyerek i�lemi tamaml�yoruz.
--PRIMARY KEY : Tablodaki her 