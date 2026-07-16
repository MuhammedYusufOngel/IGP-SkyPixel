# 🦊 IGP-SkyPixel (OPGOdev2) - 2D Platform Oyunu

<div align="center">

![Unity Version](https://img.shields.io/badge/Unity-6000.4.5f1-000000?style=for-the-badge&logo=unity&logoColor=white)
![Language](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Render Pipeline](https://img.shields.io/badge/URP-2D%20Renderer-206BC4?style=for-the-badge)
![Platform](https://img.shields.io/badge/Platform-PC%20%2F%20Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

<p align="center">
  <b>Unity 6 (Universal Render Pipeline 2D) ile geliştirilmiş, akıcı fizik mekaniklerine, yapay zeka destekli düşmanlara ve gelişmiş kayıt sistemine sahip modern 2D Pixel Art Platform Oyunu.</b>
</p>

</div>

---

## 📖 Proje Hakkında

**IGP-SkyPixel (OPGOdev2)**, klasik 2D platform oyunlarının nostaljik havasını modern oyun programlama prensipleriyle birleştiren zengin içerikli bir Unity projesidir. **Ansimuz**'un sevilen *SunnyLand* piksel sanat paketinden ilham alınarak tasarlanan oyunda, oyuncular zorlu platformlarda ilerleyip elmasları toplarken farklı davranış modeline sahip düşmanlarla mücadele ederler.

Bu proje, **Object-Oriented Programming (OOP)** prensipleri, **Raycast/Physics2D zemin algılama mekanikleri**, **Olay/Durum tabanlı yapay zeka devriyeleri** ve **Binary Serialization ile kalıcı kayıt sistemi (Save/Load)** gibi gelişmiş oyun geliştirme yapılarını barındırır.

---

## ✨ Öne Çıkan Özellikler

### 🎮 1. Akıcı Karakter Kontrolleri ve Çatışma Mekaniği
- **Hassas Hareket & Zıplama (`PlayerCode`)**: Çift yönlü yatay hareket, `Physics2D.OverlapCircle` ile zemin (Ground) algılama, zıplama ve düşüş animasyonlarının (`isWalking`, `isJumping`, `isFalling`) gerçek zamanlı kontrolü.
- **Can ve Hasar Sistemi (`PlayerHitboxCode`)**: Oyuncunun 5 adet kalp (UI Image) ile temsil edilen canı bulunur. Düşman teması ile can eksilir ve ölüm animasyon efekti prefabı anında sahnede oluşturulur.
- **Düşman Ezme / Stomp Mekaniği (`PlayerFootCode`)**: Klasik platform oyunlarında olduğu gibi, oyuncu havadan düşerken (`linearVelocityY < 0`) bir düşmanın tepesine zıpladığında düşmanı etkisiz hale getirir, havaya doğru yukarı seker ve +10 skor kazanır.

---

### 🤖 2. Akıllı Düşman Yapay Zekaları (AI & Patrol Behaviors)
Her düşman türü, oyuncu deneyimini zenginleştirmek için kendine has devriye ve saldırı algoritmalarıyla donatılmıştır:

| Düşman Türü | davranış & Yapay Zeka Mekaniği | Sorumlu Kod |
| :--- | :--- | :--- |
| 🐶 **Köpek (Dog)** | `DogDetectionCode` ile oyuncuyu algılama alanına girdiğinde (`isAware`) tetiklenir. Oyuncunun X koordinatına göre yönünü çevirir, ivmeli şekilde hızlanarak koşturur ve saldırır. Uçurumdan düştüğünde otomatik olarak yok olur. | [DogCode.cs](file:///d:/Projects/OPGOdev2/Assets/Scripts/DogCode.cs) |
| 🐻 **Ayı (Bear)** | Belirli minimum (`minPosition`) ve maksimum (`maxPosition`) sınırlar arasında devriye gezer. `BearDetectionCode` ile oyuncuyu fark ettiğinde hızını anında **iki katına (`_velocity * 2`)** çıkararak amansızca takibe başlar. | [BearCode.cs](file:///d:/Projects/OPGOdev2/Assets/Scripts/BearCode.cs) |
| 🐰 **Tavşan (Bunny)** | Zemin üzerinde periyodik olarak zıplayarak ilerler (`_jumpingVelocity`). Her zıplama sayacına (`counter`) bağlı olarak belirli aralıklarla yön değiştirir ve kendi animasyon durumlarını (`isJumping`/`isFalling`) dinamik yönetir. | [BunnyCode.cs](file:///d:/Projects/OPGOdev2/Assets/Scripts/BunnyCode.cs) |
| 🐗 **Diğer Düşmanlar** | **Sırtlan (Hyena)**, **Domuz (Pig)** ve **Akbaba (Vulture)** gibi bölüm engelleri farklı hız ve devriye dinamikleriyle platform zorluğunu artırır. | `HyenaCode.cs`, `PigCode.cs`, `VultureCode.cs` |

---

### 💾 3. Binary Serialization ile Güvenli Kayıt (Save/Load) Sistemi
Proje, Unity'nin standart `PlayerPrefs` yapısı yerine çok daha güvenli, esnek ve performansa duyarlı olan **Binary Serialization (`BinaryFormatter`)** yapısını kullanır.

- **Neler Kaydedilir?**
  - 🧍 **Oyuncu (`PlayerData`)**: Oyuncunun o anki canı (`health`), 3 boyutlu konumu (`Vector3 position`), skoru (`score`) ve hayatta olma durumu (`isDead`).
  - 👾 **Düşmanlar (`EnemyData`)**: Sahnedeki tüm düşmanların anlık koordinatları ve aktiflik (`activeSelf`) durumları. (Öldürülen düşmanlar yükleme yapıldığında ölü kalmaya devam eder!)
  - 💎 **Ödüller / Elmaslar (`DiamondData`)**: Haritadaki tüm elmasların toplanıp toplanmadığı bilgisi (`activeSelf`) ve koordinatları.
- **Nasıl Çalışır?**  
  `SaveSystem.cs` sınıfı `Application.persistentDataPath` altında her bölüme özel (`player_1.data`, `enemies_1.data`, `gems_1.data`) binary dosyalar oluşturarak oyunun o anki anlık fotoğrafını (Snapshot) kaydeder ve geri yükler.

---

### 🎬 4. Bölüm ve Sahne Tasarımı (Scenes)
Proje 3 temel sahneden oluşur:
1. `Start.unity` (**Ana Menü**): Hareket eden sinematik arka plan ve oyuna başlama ekranı.
2. `1.Bölüm.unity` (**Bölüm 1**): Temel platform mekaniklerinin, elmasların ve köprü/ormana ait düşmanların yer aldığı giriş bölümü.
3. `2.Bölüm.unity` (**Bölüm 2**): Daha karmaşık platform yerleşimleri, artan düşman yoğunluğu ve gelişmiş engeller.

---

## 🕹️ Kontroller ve Tuş Atamaları

Oyunu oynarken veya test ederken aşağıdaki klavye kısayollarını kullanabilirsiniz:

| Tuş / Girdi | Eylem / İşlev | Açıklama |
| :---: | :--- | :--- |
| <kbd>A</kbd> / <kbd>D</kbd> veya <kbd>←</kbd> / <kbd>→</kbd> | **Yatay Hareket** | Karakteri sola veya sağa doğru yürütür/koşturur. |
| <kbd>Space (Boşluk)</kbd> | **Zıplama / Başlama** | Zemin üzerideyken zıplamayı sağlar. Ana menüde oyunu başlatır. |
| <kbd>Q</kbd> | **Hızlı Kaydet (Quick Save)** | Oyuncunun konumunu, canını, skorunu, düşman ve elmas durumlarını kaydeder. |
| <kbd>R</kbd> | **Hızlı Yükle (Quick Load)** | Son alınan kaydı (`.data` dosyalarını) okuyarak tüm haritayı o anki haline getirir. |
| <kbd>L</kbd> | **1. Bölüme Geç / Sıfırla** | Sahneyi hızlıca `1.Bölüm` olarak yeniden yükler (`SceneManager.LoadScene(1)`). |

---

## 📂 Proje Klasör ve Kod Mimarisi

```text
d:\Projects\OPGOdev2\
├── Assets\
│   ├── Animations\           # Karakter ve düşman animasyon kontrolcüleri (Animator Controllers)
│   ├── Datas\                # Veri ve Kayıt Sistemi Sınıfları
│   │   ├── SaveSystem.cs     # BinaryFormatter ile dosya yazma/okuma yöneticisi
│   │   ├── PlayerData.cs     # Oyuncu serileştirme veri modeli
│   │   ├── EnemyData.cs      # Düşman serileştirme veri modeli
│   │   └── DiamondData.cs    # Elmas/Ödül serileştirme veri modeli
│   ├── Prefabs\              # Oyuncu, Düşman, Ölüm Efekti ve Toplanabilir Obje Prefabları
│   ├── Scenes\               # Oyun Sahne Dosyaları (Start, 1.Bölüm, 2.Bölüm)
│   ├── Scripts\              # Oyun Mekanikleri ve Yapay Zeka Kodları
│   │   ├── PlayerCode.cs     # Oyuncu hareket, zemin kontrolü ve animasyonlar
│   │   ├── PlayerHitboxCode.cs # Oyuncu can/hasar alma, ölüm ve Save/Load tetikleyicisi
│   │   ├── PlayerFootCode.cs # Düşman ezme (Stomp) ve yukarı zıplama mekaniği
│   │   ├── ScoreManager.cs   # Singleton skor yöneticisi ve UI güncelleme
│   │   ├── EnemiesCode.cs    # Bölümdeki tüm düşmanların toplu kayıt/yükleme yöneticisi
│   │   ├── AwardsCode.cs     # Bölümdeki tüm elmasların toplu kayıt/yükleme yöneticisi
│   │   ├── DogCode.cs        # Köpek düşmanı devriye ve kovalama yapay zekası
│   │   ├── BearCode.cs       # Ayı düşmanı sınır devriyesi ve hızlanma yapay zekası
│   │   ├── BunnyCode.cs      # Tavşan düşmanı zıplama ve yön değiştirme yapay zekası
│   │   └── GemCode.cs        # Elmas toplama ve skor tetikleyicisi
│   └── SunnyLand_Artwork\    # Piksel sanat varlıkları (Tilemap, Karakter, Arka planlar)
└── ProjectSettings\          # Unity URP ve Girdi Sistemi (New Input System) ayarları
```

---

## 🚀 Kurulum ve Çalıştırma

1. **Gereksinimler:**
   - [Unity Hub](https://unity.com/download) ve **Unity 6 (6000.4.5f1 veya üstü)** kurulu olmalıdır.
   - IDE olarak **Visual Studio 2022** veya **JetBrains Rider** önerilir.

2. **Projeyi Açma:**
   - Depoyu yerel bilgisayarınıza klonlayın veya indirin:
     ```bash
     git clone https://github.com/MuhammedYusufOngel/IGP-SkyPixel.git
     ```
   - **Unity Hub** uygulamasını açın -> **Add (Ekle)** butonuna tıklayın ve klonladığınız `OPGOdev2` klasörünü seçin.
   - Projeyi Unity **6000.4.5f1** sürümü ile açın.

3. **Oyunu Başlatma:**
   - Unity editöründe **Project** penceresinden `Assets/Scenes/Start.unity` sahnesine çift tıklayın.
   - Editörün üst kısmındaki **Play (▶)** butonuna basarak oyunu deneyimleyin!

---

## 👨‍💻 Geliştirici & Katkıda Bulunanlar

- **Proje Geliştiricisi**: Muhammed Yusuf Öngel
- **Görsel Varlıklar (Artwork)**: Ansimuz (*SunnyLand Pixel Art Assets*)
- **Ders / Kapsam**: Oyun Programlama Geliştirme Ödevi 2 (OPGOdev2)

---

<p align="center">
  ⭐ Eğer bu projeyi beğendiyseniz GitHub üzerinde yıldız vermeyi unutmayın! ⭐
</p>
