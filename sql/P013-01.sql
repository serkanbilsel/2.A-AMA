-- Sql de yorum satýrý 
-- Sql komutlarý çalýþtýrmak için ssms üst menüsündeki New Query menüsüne týklýyoruz
-- Yazdýðýmýz sql komutlarýný üst menüdeki kaydet ikonuna týklayarak veya ctrl + s ile bilgisayarýmýza sql uzantýsýyla kaydedip daha sonra çift týklayarak smss programýyla bu dosyalarý açabiliriz.
-- Smss ile yeni veritabaný oluþturma
/*
çoklu yorum satýrý 
databses klasörüne sað týklayýp new database diyerek açýlan pencerede veritabanýna bir isim verip ok diyerek pencereyi kapatýyoruz
/*
-- Smss ile veritabanýna tablo ekleme
/* 
Veritabanýna + ya basarak geniþletim açýlan klasörlerden Tables'e sað taklayýp new table > Table yolunu izleyip Desing modunda tablo oluþturma ekranýný açýyoruz..
Açýlan ekranda Kolon adý, bu kolona eklenecek verilerin tipi ve boþ geçilip geeçilmeeyceði her satýr için ayarlýyoruz.
Tablo kolonlarýný ayarladýktan sonra üst menüden kaydet ikonuna veya cstrl + s e basarak bu tabloya bir isim verip kaydediyoruz.
Kaydettiðimiz tabloyu görmek için so ltaraftaki menüden veritabýnýmýzý ve içindeki tables  i + ye basrak açýp tables e sað týklayýp refresh menüsüne týklmamamýz gerekir.

Not :  Sql server' ý ilk kurduðumuzda tabloyu kaydettikten sonra deðiþikliðe izin vermezse SSMS den  TOOLS > OPTÝONS > DESÝNGER menüsünü açýp saðdaki seçeneklerden Prevent saving ile baþlayan iþareti kaldýrýyoruz
/*

--Oluþturduðumuz tablolara veri giriþi yapmak için 
--Ýlgili tabloya sað týklayýp açýlan menüden Edit Top 200 rows a basýyoruz.
--Daha önceden oluþturduðumuz bir tabloyu deðiþtirmek için Tabloya sað týklayýp açýlan menüden Desing menüsüne týklýyoruz. Açýlan tabloda deðiþiklikleri yapýp kaydet diyerek iþlemi tamamlýyoruz.
--PRIMARY KEY : Tablodaki her 