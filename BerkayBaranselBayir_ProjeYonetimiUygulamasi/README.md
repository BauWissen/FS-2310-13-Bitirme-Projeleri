# BerkayBaranselBayir_ProjeYonetimiUygulamasi YonetimSell
Bu proje, kullanıcılara geliştirdikleri projelerde proje detaylarını saklama, görev takibi ve diğer kullanıcılarla iletişim konusunda yardım etmeyi amaçlamaktadır. ASP.NET Core MVC ile kar amacı gütmeden, eğitim ve kişisel gelişim amacıyla hazırlanmıştır. 

## Özellikler

- Kullanıcılar, hesap oluşturabilir, oturum açabilir ve profil bilgilerini güncelleyebilir.
- Kullanıcılar, projeler oluşturabilir, düzenleyebilir ve silme işlemleri yapabilir.
- Kullanıcılar, birbirlerine istek yollayarak arkadaş ekleyebilir ve bu sayede kendi aralarında mesajlaşabilir veya projelerinde takım arkadaşı olarak ekleyebilirler.
- Kullanıcılar, projelere görevler atayabilir ve görev durumlarını güncelleyebilirler.
- Proje sahipleri takım arkadaşlarının görev detaylarına dosya ekleyebilirler.
- Aboneliği olmayan kullanıcılar üç adetten fazla proje oluşturamaz ve üç adetten fazla takım arkadaşı ekleyemezler.
- Görevleri "beklemede" ve "hatalı" buttonlarına tıklayıp durumunu değiştirebilir veya aynı butona tekrar tıklayıp tekrar "devam ediyor" durumuna döndürebilirsiniz.
- Tamamlanan görevlerin durumları sadece proje sahibi tarafından değiştirilebilir.
- Bir proje silindiğindiğinde, tamamen kaldırılana kadar temel bilgileri saklanır fakat ilgili projeye ait görevler ve takım arkadaşı bilgileri saklanmaz.  
- Tablolardaki verilerin detayına butonlardan ya da ilgili satıra çift tıklayarak ulaşabilirsiniz
- Proje ve görevlerin, durum ve önceliklerini detayına girmeden tablo üzerinde güncelleyebilirsiniz.
- Projelerin ilerlemesi toplam görev ve tamamlanan görev sayısına göre hesaplanıp tablodaki ilerleme kolonundaki barda görebilirsiniz.
- Proje ve görevlerin kalan süreleri de hesaplanıp tablolarda bar üzerinde gösterilir

## Kullanım

1. Uygulamayı başlatın: `dotnet watch run`
2. Tarayıcınızda `https://localhost:7051` veya `http://localhost:5205` adresine gidin.
3. Yeni hesap oluşturun veya mevcut bir hesapla oturum açın.
4. Projeler oluşturun, düzenleyin ve silin.
5. Arkadaş ekleyip, takım arkadaşı olarak projenize dahil edin.
6. Takım arkadaşlarınıza görev atayın.

## Kullanılan Paketler

- Microsoft.AspNetCore.Identity.EntityFrameworkCore(7.0.17)
- Microsoft.EntityFrameworkCore.Design(7.0.17)
- Microsoft.EntityFrameworkCore.Sqlite(7.0.17)
- Riok.Mapperly(3.4.0)
- Bootstrap 5
- Iyzipay (2.1.61)
- Jquery (3.4.1)
- Dropzone
- SweetAlert2

## Örnek Kullanıcı Bilgileri

- SuperAdmin:
    * kullanıcı adı: baransel | şifre: Qwe123.
    * kullanıcı adı: enginniyazi | şifre: Qwe123.
- Admin:
    * kullanıcı adı: lebron | şifre: Qwe123.
    * kullanıcı adı: admin | şifre: Qwe123.
- Customer:
    * kullanıcı adı: customer | şifre: Qwe123.

## Örnek Veriler

- customer kullanıcısı:
    * 4 adet arkadaşı mevcut
    * 3 adet aktif projesi (Test Proje 1, Test Proje 2, Test Proje 4)
    * 1 adet silinmiş projesi (Test Proje 3,)
    * Test Proje 1'in içindeki Test Görev 1 isimli görevde 3 adet örnek dosya var (görevin atandığı kullanıcı: baransel)
    * 5 adet deneme mesajı mevcut(mesajlaştığı kullanıcı: baransel)
- baransel kullanıcısı:
    * Aboneliği mevcut
    * Atanmış 5 adet görevi mevcut, biri tamamlanmış
    * 5 adet deneme mesajı mevcut(mesajlaştığı kullanıcı: customer)

## Eklenecek ve düzeltilecekler

- Proje, Görev ve Aboneliklerin bitiş tarihlerinde otomatik olarak durum değişiklikleri
- Frontend tasarımı değişiklikleri
- Daha fazla istatistiksel veri 
- Proje oluştururken veya görev atarken, daha fazla veri ve detay imkanı
- SOLID prensiplerine göre projenin tekrar düzenlenmesi
- Ne yazıkki kullanıcıların profil resimlerini güncellerken olumlu ya da olumsuz durumda bir yönlendirme yapılmıyor, sadece Dropzone'nun görsel bir geri bildirimi mevcut bu durumun düzeltilmesi
- Aboneliğe göre yapılabilecek işlemlerin tekrar düzeniplenip daha geniş çaplı hale getirilmesi
- Oluşturulan Projede Takım Arkadaşlarının rollerine göre yapabileceklerinin belirlenip eklenmesi
- Saklanan dosyaların(png, jpeg, pdf...) wwwroot klasörü yerine farklı bir clouda taşınması(Microsoft Azure Blob Storage, Google Cloud Storage, Amazon S3 (Simple Storage Service) vb.)

## Katkılar
* Geliştirdiğim uygulamayı denedikten sonra katkılarınızı bekliyorum! Pull Request gönderebilir veya bana aşağıdaki adreslerden ulaşabilirsiniz;
    - Email: bbaranselbayir@gmail.com
    - [GitHub](https://github.com/bbaransel)
    - [Linkedin](www.linkedin.com/in/berkay-baransel-bayir-334465282)