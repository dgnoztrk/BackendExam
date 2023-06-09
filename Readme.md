# BackendExam Uygulaması Hakkında

Uygulama .NET 7.0 ASP.NET MVC ile geliştirildi.

Veritabanı Teknolojisi olarak MSSQL Kullanıldı, bu teknolojiye ek olarak proje alt yapısında bu aşağıda belirttiğim teknolojiler kullanıldı.

- Repository Pattern
- Unit Of Work
- CQRS (Mediatr)
- Clean Architecture
- DataTables
- Bootstrap

Veritabanı Şeması aşağıdaki gibidir.
![Veritabanı Şeması](https://i.ibb.co/0f4VYw0/Backend-Exam-drawio.pnghttps://i.ibb.co/0f4VYw0/Backend-Exam-drawio.png)

Uygulamanın çalıştırılabilmesi için bilgisayarınızda mssql kurulu olmalıdır, kurulu olan sürüme göre connection stringi appsettings üzerinden değiştirmeniz gerekebilir.

Örneğin, SQLExpress kullanıyorsanız connectionstring'de geçen Server parametresinde yazan . (nokta) yerine .\sqlexpress yazmanız gerekiyor.

Proje ilk çalıştırıldığında veritabanını oluşturmak için migration işlemini başlatacaktır, olası bir problem çıkması durumunda kullanabileceğiniz full sql script dosyası proje ana dizininde BackendExam.sql ismi ile yer almaktadır.