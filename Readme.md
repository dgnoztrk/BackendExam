# BackendExam Uygulamasý Hakkýnda

Uygulama .NET 7.0 ASP.NET MVC ile geliþtirildi.

Veritabaný Teknolojisi olarak MSSQL Kullanýldý, bu teknolojiye ek olarak proje alt yapýsýnda bu aþaðýda belirttiðim teknolojiler kullanýldý.

- Repository Pattern
- Unit Of Work
- CQRS (Mediatr)
- Clean Architecture
- DataTables
- Bootstrap

Veritabaný Þemasý aþaðýdaki gibidir.
![Veritabaný Þemasý](https://i.ibb.co/0f4VYw0/Backend-Exam-drawio.pnghttps://i.ibb.co/0f4VYw0/Backend-Exam-drawio.png)

Uygulamanýn çalýþtýrýlabilmesi için bilgisayarýnýzda mssql kurulu olmalýdýr, kurulu olan sürüme göre connection stringi appsettings üzerinden deðiþtirmeniz gerekebilir.

Örneðin, SQLExpress kullanýyorsanýz connectionstring'de geçen Server parametresinde yazan . (nokta) yerine .\sqlexpress yazmanýz gerekiyor.

Proje ilk çalýþtýrýldýðýnda veritabanýný oluþturmak için migration iþlemini baþlatacaktýr, olasý bir problem çýkmasý durumunda kullanabileceðiniz full sql script dosyasý proje ana dizininde BackendExam.sql ismi ile yer almaktadýr.