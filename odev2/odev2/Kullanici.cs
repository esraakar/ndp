using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev2
{
    public class Kullanici:IHesap
    {
        SqlConnection baglanti;
        //CONSTRUCTOR (YAPICI METOD)
        public Kullanici()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-G6ESTFT; initial Catalog=SaglikliYasam; Integrated Security=true");
        }

        //PRIVATE ALANLAR
        //ENCAPSULATION (SARMALAMA KAPSÜLLEME İŞLEMİ)
        private string _kullaniciAdi;
        private string _parola;
        private string _ad;
        private string _soyad;
        private string _cinsiyet;
        private int _yas;
        private double _kilo;
        private double _boy;
        
        //PROPERTY (Özellikler)        
        public string Ad { get => _ad; set => _ad = value; }
        public string Soyad { get => _soyad; set => _soyad = value; }
        public string Cinsiyet { get => _cinsiyet; set => _cinsiyet = value; }
        public int Yas { get => _yas; set => _yas = value; }
        public double Kilo { get => _kilo; set => _kilo = value; }
        public double Boy { get => _boy; set => _boy = value; }
        public string KullaniciAdi { get => _kullaniciAdi; set => _kullaniciAdi = value; }
        public string Parola { get => _parola; set => _parola = value; }

        //IHesap interface den Gelen Method girilen Boy Kilo Yas degerine göre;
        //aşşağıdaki formülle tüketilmesi gereken su miktarını hesaplıyor
        public double SuMiktari()
        {
            return _kilo * 0.033;
        }

        //Sınıfa ait Metotlar
        //Kullanıcı hesap oluştururken doldurulan bilgiler veritabanına gönderiliyor.
        public bool Ekle_Kayit()
        {
            bool kontrol = false;
            baglanti.Open(); // bağlantıyı açtık

            //Sorgumuzu yazdım. Ekleme işlemi yapan insert into sorgusu yazdım.
            SqlCommand ekle = new SqlCommand("insert into Kullanici(KullaniciAdi,Parola,Ad,Soyad,Boy,Kilo,Yas,Cinsiyet) values ('" + _kullaniciAdi + "','" + _parola + "','" + _ad + "','" + _soyad + "','" + _boy + "','" + _kilo + "','" + _yas + "','" + _cinsiyet + "')", baglanti);
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            if (ekle.ExecuteNonQuery() > 0)
            {
                kontrol = true;
            }
            ekle.Dispose();
            baglanti.Close();
            return kontrol;


        }
        //Kullanıcı bir güncelleme yaptığı zaman aşşağıdaki method veritabanındaki bilgileri güncelliyor
        public bool Bilgi_Guncelle()
        {
            bool kontrol = false;
            baglanti.Open();
            //Aile bilgisi tablosunun ilgili alanlarını değiştirecek olan güncelleme sorgusu.
            string kayit = "update Kullanici set Boy=@Boy,Kilo=@Kilo,Yas=@Yas,Cinsiyet=@Cinsiyet where KullaniciID=@Kullaniciadi";
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgunun içerisinde ilgili alanları doldurabilmek için aşağıdaki parametreleri oluşturdum.
            komut.Parameters.AddWithValue("@Boy", _boy);
            komut.Parameters.AddWithValue("@Kilo", _kilo);
            komut.Parameters.AddWithValue("@Yas", _yas);
            komut.Parameters.AddWithValue("@Cinsiyet", _cinsiyet);
            komut.Parameters.AddWithValue("@Kullaniciadi", _kullaniciAdi);
            if (komut.ExecuteNonQuery() > 0)
            {
                kontrol = true;
            }
            komut.Dispose();
            baglanti.Close();
            return kontrol;


        }
        //Kullanıcı kayıt olduktan sonra giriş kontrolünü kullanıcı adı şifre kontrolü yapan method.
        public bool GirisYap()
        {
            bool kontrol = false;
            baglanti.Open(); // bağlantıyı açtık

            //Sorgumuzu yazdım. Ekleme işlemi yapan insert into sorgusu yazdım.
            SqlCommand ekle = new SqlCommand("Select * from Kullanici where KullaniciAdi=@KullaniciAdi and  Parola=@Parola", baglanti);
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            ekle.Parameters.AddWithValue("KullaniciAdi", _kullaniciAdi);
            ekle.Parameters.AddWithValue("Parola", _parola);
            SqlDataAdapter adapter = new SqlDataAdapter(ekle);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            ekle.ExecuteNonQuery();
            if (dt.Rows.Count > 0)
            {
                kontrol = true;
            }
            ekle.Dispose();
            baglanti.Close();
            return kontrol;


        }
       
        //LIST <> kullanımı
        public List<string> GetBilgi()
        {
            List<string> bilgi = new List<string>();
            baglanti.Open(); // bağlantıyı açtık

            //Sorgumuzu yazdım. Ekleme işlemi yapan insert into sorgusu yazdım.
            SqlCommand ekle = new SqlCommand("Select Boy,Yas,Kilo,Ad,Soyad,Cinsiyet,KullaniciID from Kullanici where KullaniciAdi=@KullaniciAdi and  Parola=@Parola", baglanti);
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            ekle.Parameters.AddWithValue("KullaniciAdi", _kullaniciAdi);
            ekle.Parameters.AddWithValue("Parola", _parola);
            SqlDataReader dr = ekle.ExecuteReader();
            while (dr.Read())
            {
                bilgi.Add(dr["Boy"].ToString());
                bilgi.Add(dr["Kilo"].ToString());
                bilgi.Add(dr["Yas"].ToString());
                bilgi.Add(dr["Ad"].ToString());
                bilgi.Add(dr["Soyad"].ToString());
                bilgi.Add(dr["Cinsiyet"].ToString());
                bilgi.Add(dr["KullaniciID"].ToString());

            }


            baglanti.Close();


            return bilgi;
        }
       
    }
}
