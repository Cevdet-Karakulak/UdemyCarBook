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

<img width="1897" height="901" alt="Image" src="https://github.com/user-attachments/assets/7c7af035-5335-4b55-9253-f2379771729c" />
<img width="1900" height="907" alt="Image" src="https://github.com/user-attachments/assets/864d5cd9-f3f0-434a-921a-3edab25cae72" />
<img width="1781" height="918" alt="Image" src="https://github.com/user-attachments/assets/9888980c-6071-49dc-a9be-e5b6c26dbed3" />
<img width="1895" height="901" alt="Image" src="https://github.com/user-attachments/assets/77ec3f15-ab31-4d1b-ac35-574a5627eca7" />
<img width="1895" height="913" alt="Image" src="https://github.com/user-attachments/assets/72e442e3-464b-45ab-90e2-b429f94cf9a3" />
<img width="1856" height="901" alt="Image" src="https://github.com/user-attachments/assets/fce897ff-4b78-4fca-8217-91f1d738cd5b" />
<img width="1883" height="903" alt="Image" src="https://github.com/user-attachments/assets/ced006e3-f41b-4463-984f-5989d34befdb" />
<img width="1571" height="904" alt="Image" src="https://github.com/user-attachments/assets/14f94d43-a746-4f9c-a86d-7e482d3a88b9" />
<img width="1700" height="902" alt="Image" src="https://github.com/user-attachments/assets/0fcbd2ce-536a-434b-84e4-49afde2c2cf2" />
<img width="1535" height="899" alt="Image" src="https://github.com/user-attachments/assets/cd488668-9011-436b-967e-1c95f14b36a4" />
<img width="1647" height="909" alt="Image" src="https://github.com/user-attachments/assets/47f84b0f-1cc1-402f-a2b6-a06b1f5aac6b" />
<img width="1546" height="897" alt="Image" src="https://github.com/user-attachments/assets/a0a16709-e259-4b96-a428-669029e7ebf6" />
<img width="1638" height="943" alt="Image" src="https://github.com/user-attachments/assets/09ceb86e-febd-4078-adcd-59bf605d7ee2" />
<img width="1672" height="899" alt="Image" src="https://github.com/user-attachments/assets/430c188e-ec91-4af3-8b7c-c1a54f54ca6c" />
<img width="1555" height="906" alt="Image" src="https://github.com/user-attachments/assets/df391dd5-bcfb-40b7-af7a-045ad970f839" />
<img width="1687" height="904" alt="Image" src="https://github.com/user-attachments/assets/9ab25efd-5efc-43a2-ae99-026c08b19383" />
<img width="1896" height="946" alt="Image" src="https://github.com/user-attachments/assets/cef81193-bc81-4c28-af60-90742a397aa3" />
<img width="1892" height="942" alt="Image" src="https://github.com/user-attachments/assets/36af9a35-0c21-4c0e-b1c3-336c978c4d54" />
<img width="1909" height="935" alt="Image" src="https://github.com/user-attachments/assets/a394f992-6d76-4613-8988-e7689ee63566" />
<img width="1892" height="908" alt="Image" src="https://github.com/user-attachments/assets/6f19aa83-dec5-40e2-9129-4fd6c28f5057" />
<img width="1900" height="904" alt="Image" src="https://github.com/user-attachments/assets/9fc3d633-87d0-4f24-a6f3-8402f7f0fa01" />
<img width="1900" height="900" alt="Image" src="https://github.com/user-attachments/assets/71d20115-1199-4979-9b4b-d3c72e7dbabb" />
<img width="1903" height="913" alt="Image" src="https://github.com/user-attachments/assets/18d7bee6-c6c7-4b3e-be21-45dede7f22ca" />
<img width="1739" height="937" alt="Image" src="https://github.com/user-attachments/assets/6de703a3-f89b-4c15-b213-923442e32b07" />
<img width="1827" height="903" alt="Image" src="https://github.com/user-attachments/assets/5855342a-fdfc-45c1-ac13-e92cb3c299b2" />
<img width="1576" height="910" alt="Image" src="https://github.com/user-attachments/assets/6ddf57eb-4920-4712-a50f-a055f63a5a98" />
<img width="1732" height="907" alt="Image" src="https://github.com/user-attachments/assets/07bd487c-fac7-45e0-8863-1e6741cc71f9" />

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
