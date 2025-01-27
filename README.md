   <header>
        <h1>Asp.Net Mvc5 ile Kütüphane Yönetim Sistemi</h1>
        <p>Bu proje bir kütüphanenin vitrin, admin ve kullanıcı olmak üzere 3 temel panelinden oluşuyor. Özellikle admin panelinin dashboard kısmı ile hem tasarımı güçlü bir arayüz hem de crud işlemlerinin ötesinde Entity Framework, Linq sorgular üzerinden Trigger, Procedure gibi SQL yapıları ile somut ve dinamik bir projedir. Hazır css, javascript ve bootstrap den yararlanılmıştır.</p>
    </header>

 <section>
        <h2>Projeye Genel Bakış</h2>
        <ul>
            <li><strong>👤 Kullanıcı Arayüzü:</strong> Hesap oluşturulup giriş yapıldıktan sonra Profilim, Duyurular, Kitaplarım, Kullanıcılar arasında Gelen, Giden ve Yeni mesaj gönderme işlemleri yapılabilmektedir.</li>
            <li><strong>👤 Admin Arayüzü:</strong> Projenin en kapsamlı kısmıdır. Url ile admin giriş paneline ulaşıldıktan sonra kullanıcı adı ve şifresi ile giriş yapan adminin aşağıdaki işlemlere erişimi bulunmaktadır.
              Ana Sayfa,Kategoriler,Kitaplar,Yazarlar,Üyeler,Personeller,Kitap ver - Kitap al,İstatistikler,Duyurular,İşlemler,Linq Kartlar,Ayarlar
              (Ancak burada yetkilendirme bulunmaktadır. Ör: B yetkisine sahip adminlerin Personeller, Kitap alıp verme ve Admin ayarları kısımlarına erişimi kısıtlanmıştır, bu başlıkları göremez.)</li>
            <li><strong>🖥️ Vitrin Paneli:</strong> Kitapların Listesi, Hakkımızda, İletişim ve Login başlıklarından oluşmaktadır.</li>
        </ul>
    </section>

 <section>
        <h2>Kullanılan Teknolojiler ve Uygulamalar</h2>
        <table>
            <thead>
                <tr>
                    <th>Teknoloji</th>
                    <th>Kullanım Amacı</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>🛠️ ASP.NET MVC</td>
                    <td>Web uygulamasının temel çerçevesi</td>
                </tr>
                <tr>
                    <td>🛠️ Sınıf Nesne ve OOP Kavramları</td>
                    <td>Web uygulamasının temel çerçevesi</td>
                </tr>
                <tr>
                    <td>🗂️ Entity Framework</td>
                    <td>Veritabanı işlemleri ve ORM</td>
                </tr>
                <tr>
                    <td>🏗️ Prosedür ve Trigger Kontrolleri</td>
                    <td>MSSQL'den Veritabanı işlemleri</td>
                </tr>
                <tr>
                    <td>🛢️ Microsoft SQL Server</td>
                    <td>Veritabanı yönetimi ve depolama</td>
                </tr>
                <tr>
                    <td>🌐 HTML - CSS - Bootstrap</td>
                    <td>Modern ve responsive arayüz tasarımı</td>
                </tr>
                <tr>
                    <td>📊 Chart.js</td>
                    <td>Dinamik grafik ve görselleştirme</td>
                </tr>
                <tr>
                    <td>✨ JavaScript</td>
                    <td>Etkileşimli ve dinamik kullanıcı deneyimi</td>
                </tr>
                <tr>
                    <td>🔍 LINQ</td>
                    <td>Veritabanı sorguları ve verilerle işlem</td>
                </tr>
            </tbody>
        </table>
    </section>
    <section>
        <h2>Veritabanı Diyagramı</h2>
    </section>
    
![tablolar](https://github.com/user-attachments/assets/982ffbf2-6e2c-4194-95b7-fd09442e6919)

   <section>
        <h2>Kullanıcı & Admin Arayüzü</h2>
   </section>
   
![1](https://github.com/user-attachments/assets/8b8bbacf-77f0-46c7-9836-e3edb02773a9)
![2](https://github.com/user-attachments/assets/f890580c-ca77-4552-8e12-89fb57a9ef5b)
![3](https://github.com/user-attachments/assets/2d8bd05f-da8e-4ff1-9f81-231b80280b47)
![4](https://github.com/user-attachments/assets/d9908e93-9397-429b-a5cd-5c45c8441bc9)
![5](https://github.com/user-attachments/assets/c504c70c-8075-4396-b195-50e263152bab)

![6](https://github.com/user-attachments/assets/afaff018-a63b-436b-9eb5-b0c35d68357f)
![login](https://github.com/user-attachments/assets/4aeef865-f743-4564-8dad-042d2f9b90c3)

![7](https://github.com/user-attachments/assets/a035f089-40ec-4754-ab59-b0cdedae52e7)
![8](https://github.com/user-attachments/assets/caa5a331-b8a0-45d6-91e0-15f41068f290)
![9](https://github.com/user-attachments/assets/86c662c4-f4fc-4133-a3d0-73185f6eac8d)
![10](https://github.com/user-attachments/assets/495f38a9-aa81-4db2-98f9-9d9321d7bed8)
![11](https://github.com/user-attachments/assets/cf76edf6-4d0c-458e-a1b1-dfe836bdc129)
![12](https://github.com/user-attachments/assets/560572c5-603d-41da-ba46-9399f9bc46f9)
![13](https://github.com/user-attachments/assets/7d5e1efd-33e8-4611-a4c7-e33da1380262)
![14](https://github.com/user-attachments/assets/d5d4b990-ab33-472a-a11a-e72392e38899)
![15](https://github.com/user-attachments/assets/08350d8f-eb72-473b-84da-274fcf48833f)
![16](https://github.com/user-attachments/assets/6d68c17e-6c32-4b6e-8955-23d1029b65c9)
![17](https://github.com/user-attachments/assets/6abdc60d-4144-4d9c-9e3c-0b6d40ee7b11)

