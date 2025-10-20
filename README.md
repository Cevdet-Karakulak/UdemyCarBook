# 🚗 **BookCar | ASP.NET Core 8.0 & Onion Architecture Gerçek Dünya Projesi** 🚀

**BookCar**, **ASP.NET Core 8.0 Web API** teknolojileri ile geliştirilen, **Onion Architecture**, **CQRS**, **Mediator**, **Repository Pattern**, **JWT Authentication** ve **SignalR** gibi modern yazılım mimarisi yaklaşımlarını içeren **gerçek bir sektör projesidir.**

Bu proje, Murat Yücedağ tarafından hazırlanan “Asp.Net Core API ile Onion Architecture” eğitim serisinin uygulama projesidir. Amaç, katmanlı mimariler, tasarım desenleri ve kurumsal uygulama standartlarını pratikte öğrenmektir.

---

## 🎯 **Projenin Amacı**

- 🎓 Geliştiricilere **Onion Architecture** mimarisini gerçek bir örnek üzerinden öğretmek  
- 🧠 **CQRS & Mediator Pattern** uygulamalarını profesyonel senaryoda göstermek  
- 🧩 **Repository Pattern**, **DTO**, **Fluent Validation**, **JWT** ve **SignalR** konularını entegre bir sistemde uygulamak  
- 💼 Gerçek bir **Araç Kiralama (Car Rental)** sistemini uçtan uca simüle etmek  

---

## 🏗️ **Mimari Yapı**

Proje, katmanlı ve sürdürülebilir bir yapı olan **Onion Architecture (Soğan Mimarisi)** üzerine kurulmuştur.

| Katman | Açıklama |
|--------|-----------|
| 🏛️ **Domain** | Tüm entity’lerin ve iş kurallarının bulunduğu çekirdek katmandır. |
| ⚙️ **Application** | CQRS yapısına uygun Command & Query işlemlerini ve Mediator iş akışlarını barındırır. |
| 🧱 **Infrastructure (Persistence)** | Entity Framework Core üzerinden veri erişimi, Repository Pattern ve veri yönetimi işlemleri yapılır. |
| 🌐 **API** | RESTful endpoint’lerin bulunduğu, dış dünyaya açılan servis katmanıdır. |
| 💻 **WebUI (MVC)** | Kullanıcı arayüzü, Razor View’lar, ViewComponent’ler ve MVC Controller yapısı içerir. |
| 📦 **DTO** | Katmanlar arası taşınan veri modelleri, veri güvenliği ve performans için sadeleştirilmiştir. |

---

## ⚙️ **Kullanılan Teknolojiler**

<p align="center">
  <img src="https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/ASP.NET%20Core%20Web%20API-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/CQRS-FF6B6B?style=for-the-badge&logo=c-sharp&logoColor=white" />
  <img src="https://img.shields.io/badge/MediatR-007ACC?style=for-the-badge" />
  <img src="https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge" />
  <img src="https://img.shields.io/badge/Repository%20Pattern-009688?style=for-the-badge" />
  <img src="https://img.shields.io/badge/JWT%20Auth-FFB400?style=for-the-badge" />
  <img src="https://img.shields.io/badge/SignalR-0A66C2?style=for-the-badge" />
  <img src="https://img.shields.io/badge/FluentValidation-2E7D32?style=for-the-badge" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" />
</p>

---

## 💡 **Öne Çıkan Özellikler**

| Özellik | Açıklama |
|----------|-----------|
| 🔑 **JWT Authentication** | Token tabanlı güvenli kimlik doğrulama sistemi |
| 🔄 **CQRS + Mediator** | Komut ve sorguların ayrıldığı, performans odaklı mimari |
| 🧩 **Repository Pattern** | Veri erişiminin soyutlanması ve yönetilebilir hale getirilmesi |
| 📡 **SignalR Entegrasyonu** | Gerçek zamanlı bildirim ve canlı veri akışı |
| 📦 **Fluent Validation** | Veri doğrulama işlemleri için sade ve güçlü yapı |
| 📊 **Pivot Table Kullanımı** | Çoktan çoğa ilişki yönetimi için pivot tablo yapısı |
| 🧠 **DTO Yapısı** | Katmanlar arası veri transferinde güvenli ve sade modeller |
| 🧱 **Onion Architecture** | Katmanlar arası bağımlılığı minimize eden modern mimari yapı |

---

## 🔐 **Kimlik Doğrulama ve Yetkilendirme**

Proje, kullanıcı giriş/çıkış ve rol bazlı yetkilendirme işlemlerini **JWT (JSON Web Token)** sistemiyle yönetir.  
Her kullanıcı rolüne (admin, kullanıcı vb.) göre farklı erişim yetkileri tanımlanmıştır.

---

## 🔔 **Gerçek Zamanlı Bildirimler (SignalR)**

- Kiralama işlemleri, yeni araç ekleme veya güncellemelerde canlı bildirim sistemi çalışır.  
- Admin panelinde **anlık araç sayısı**, **rezervasyon durumu** gibi veriler **SignalR Hub** üzerinden güncellenir.  

---

## 🧰 **Ek Bileşenler**

- **FluentValidation** ile model doğrulama  
- **AutoMapper** ile Entity ↔ DTO dönüşümleri  
- **Swagger UI** ile API dokümantasyonu  
- **Postman Collection** ile test imkânı  

---

## 🧱 **Veritabanı & İlişkiler**

- **MSSQL** üzerinde Code-First yaklaşımı  
- **Car**, **Location**, **Reservation**, **Customer**, **Pricing**, **Brand** tabloları arası ilişkiler  
- Çoktan çoğa (many-to-many) ilişkiler **Pivot Table** üzerinden modellenmiştir.  

---

## 📸 **Ekran Görüntüleri**

> 🚧 Görseller eklenecek (Admin Paneli, API Swagger, Araç Listeleme, Kiralama Formu, SignalR Bildirim)

---

## ⚙️ **Kurulum & Çalıştırma**

```bash
# Depoyu klonlayın
git clone https://github.com/cevdetkarakulak/BookCar.git
cd BookCar

# Bağımlılıkları yükleyin
dotnet restore

# Veritabanını oluşturun
dotnet ef database update

# Uygulamayı başlatın
dotnet run
```

💡 **Not:**  
Veritabanı bağlantı dizesini (`appsettings.json`) kendi ortamınıza göre düzenlemeyi unutmayın.  

---

## 👨‍💻 **Geliştirici**

- **Cevdet Karakulak**  
- 🌐 [LinkedIn Profilim](https://www.linkedin.com/in/cevdet/)  
- 🌟 Yazılım geliştirme, ASP.NET Core ve mimari yapılarda uzmanlık  
