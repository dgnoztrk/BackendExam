# BackendExam Uygulamas� Hakk�nda

Uygulama .NET 7.0 ASP.NET MVC ile geli�tirildi.

Veritaban� Teknolojisi olarak MSSQL Kullan�ld�, bu teknolojiye ek olarak proje alt yap�s�nda bu a�a��da belirtti�im teknolojiler kullan�ld�.

- Repository Pattern
- Unit Of Work
- CQRS (Mediatr)
- Clean Architecture
- DataTables
- Bootstrap

Veritaban� �emas� a�a��daki gibidir.
![Veritaban� �emas�](https://i.ibb.co/0f4VYw0/Backend-Exam-drawio.pnghttps://i.ibb.co/0f4VYw0/Backend-Exam-drawio.png)

Uygulaman�n �al��t�r�labilmesi i�in bilgisayar�n�zda mssql kurulu olmal�d�r, kurulu olan s�r�me g�re connection stringi appsettings �zerinden de�i�tirmeniz gerekebilir.

�rne�in, SQLExpress kullan�yorsan�z connectionstring'de ge�en Server parametresinde yazan . (nokta) yerine .\sqlexpress yazman�z gerekiyor.

Proje ilk �al��t�r�ld���nda veritaban�n� olu�turmak i�in migration i�lemini ba�latacakt�r, olas� bir problem ��kmas� durumunda kullanabilece�iniz full sql script dosyas� proje ana dizininde BackendExam.sql ismi ile yer almaktad�r.