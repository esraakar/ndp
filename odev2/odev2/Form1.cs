using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev2
{
    public partial class Form1 : Form
    {
        public double karbonhidratkalori;
        public double yagkalori;
        public double proteinkalori;

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-G6ESTFT; initial Catalog=SaglikliYasam; Integrated Security=true");
        public Form1()
        {
            InitializeComponent();
        }

        //Kadın ve Erkeğe göre kalori miktarı hesaplayan içerisinde Çok Biçimlilik(Pollymorphism) bulunan method
        public void Hesap()
        {
            Kullanici k = new Kullanici();
            k.Boy = Convert.ToDouble(txtBoy.Text);
            k.Kilo = Convert.ToDouble(txtKilo.Text);
            k.Yas = Convert.ToInt32(txtYas.Text);
            k.Cinsiyet = comboBox1.Text;
            if (k.Cinsiyet == "Kadın")
            {
                double boy = Convert.ToDouble(txtBoy.Text); ;
                double kilo = Convert.ToDouble(txtKilo.Text); ; ;
                int yas=Convert.ToInt32(txtYas.Text); 
                Kadin kad = new Kadin(boy,kilo,yas);
              
                lblKalori.Text = kad.KaloriHesapla().ToString() + "\t Kcal'dir";
            }
            else if (comboBox1.Text == "Erkek")
            {
                double boy = Convert.ToDouble(txtBoy.Text); ;
                double kilo = Convert.ToDouble(txtKilo.Text); ; ;
                int yas = Convert.ToInt32(txtYas.Text);
                Erkek er = new Erkek(boy,kilo,yas);
                lblKalori.Text = er.KaloriHesapla().ToString() + "\t Kcal'dir";
            }
            if (k.SuMiktari() < 3)
            {
                lblSu.Text = "3 \t Litre'dir";
            }
            else
                lblSu.Text = k.SuMiktari().ToString() + "\t Litre'dir";
        }

        //Arayüzde kullanıcıyı karşılamak için Veritabanından gelen bilgiyi 1.Formdan 2.Forma taşıyan method
        public void GetBilgi()
        {

            txtBoy.Text = KullaniciHesabi.Bilgi[0];
            txtKilo.Text = KullaniciHesabi.Bilgi[1];
            txtYas.Text = KullaniciHesabi.Bilgi[2];
            comboBox1.Text = KullaniciHesabi.Bilgi[5];
            lblKullaniciAdi.Text = KullaniciHesabi.Bilgi[6];
            lblKullanici.Text = "Hoşgeldin " + KullaniciHesabi.Bilgi[3] + " " + KullaniciHesabi.Bilgi[4];
        }
        //İçerisinde Koşul Yapısı if else ,Döngüler foreach vs. Besin sınıfından alınan kalıtım ile Diyet listelerinin oluşturulması
        public  void NesneleriOlustur()
        {
            //Karbonhidratlar
            Karbonhidrat kh1 = new Karbonhidrat();
            kh1.BesinAdi = "Ekmek";
            kh1.Kalorimiktar = 50.61;
            Karbonhidrat kh2 = new Karbonhidrat();
            kh2.BesinAdi = "Pilav";
            kh2.Kalorimiktar = 21.57;
            Karbonhidrat kh3 = new Karbonhidrat();
            kh3.BesinAdi = "Makarna";
            kh3.Kalorimiktar = 25.12;
            karbonhidratkalori = kh1.Kalorimiktar + kh2.Kalorimiktar + kh3.Kalorimiktar;

            //YAĞLAR
            Yag Yag1 = new Yag();
            Yag1.BesinAdi = "Keçi Peyniri";
            Yag1.Kalorimiktar = 28.85;
            Yag Yag2 = new Yag();
            Yag2.BesinAdi = "Kaşar Peyniri";
            Yag2.Kalorimiktar = 25;
            Yag Yag3 = new Yag();
            Yag3.BesinAdi = "Beyaz Peynir";
            Yag3.Kalorimiktar = 21.2;
            yagkalori = Yag1.Kalorimiktar + Yag2.Kalorimiktar + Yag3.Kalorimiktar;
            //Proteinler 
            Protein prot1 = new Protein();
            prot1.BesinAdi = "Dana Eti";
            prot1.Kalorimiktar = 29.85;
            Protein prot2 = new Protein();
            prot2.BesinAdi = "Fırında Tavuk";
            prot2.Kalorimiktar = 27.07;
            Protein prot3 = new Protein();
            prot3.BesinAdi = "Izgara Balık";
            prot3.Kalorimiktar = 21.94;
            proteinkalori = prot1.Kalorimiktar + prot2.Kalorimiktar + prot3.Kalorimiktar;

            List<Besin> Diyet1 = new List<Besin>();
            Diyet1.Add(kh1);
            Diyet1.Add(Yag1);
            Diyet1.Add(prot1);
            foreach (var item in Diyet1)
            {
                listOruc.Items.Add(item.BesinAdi);
            }
            List<Besin> Diyet2 = new List<Besin>();
            Diyet2.Add(kh2);
            Diyet2.Add(Yag2);
            Diyet2.Add(prot2);
            foreach (var item in Diyet2)
            {
                listVejeteryan.Items.Add(item.BesinAdi);
            }
            List<Besin> Diyet3 = new List<Besin>();
            Diyet3.Add(kh3);
            Diyet3.Add(Yag3);
            Diyet3.Add(prot3);
            foreach (var item in Diyet3)
            {
                listSok.Items.Add(item.BesinAdi);
               

            }
            List<Karbonhidrat> kh = new List<Karbonhidrat>();
            kh.Add(kh1);
            kh.Add(kh2);
            kh.Add(kh3);
            List<Yag> yag = new List<Yag>();
            yag.Add(Yag1);
            yag.Add(Yag2);
            yag.Add(Yag3);
            List<Protein> protein = new List<Protein>();
            protein.Add(prot1);
            protein.Add(prot2);
            protein.Add(prot3);
            foreach (var item in kh)
            {
                cBoxKarbonhidrat.Items.Add(item.BesinAdi);
            }
            foreach (var item in yag)
            {
                cBoxYag.Items.Add(item.BesinAdi);
            }
            foreach (var item in protein)
            {
                cBoxProtein.Items.Add(item.BesinAdi);
            }


        }

        //Form1 başlatıldığında çalışıcak olan methodlar
        private void Form1_Load(object sender, EventArgs e)
        {
            NesneleriOlustur();
            GetBilgi();
            Hesap();
            VeriGetir();
            dgwYemek.Columns[4].Visible = false;
           
        }
        

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Hesap();
        }

        //Try Catch yapısının kullanıldığı alan kontrol yapıları...
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Kullanici k = new Kullanici();
                k.Boy = Convert.ToDouble(txtBoy.Text);
                k.Kilo = Convert.ToDouble(txtKilo.Text);
                k.Yas = Convert.ToInt32(txtYas.Text);
                k.Cinsiyet = comboBox1.Text;
                k.KullaniciAdi = lblKullaniciAdi.Text;
           
                if (k.Bilgi_Guncelle())
                {
                    MessageBox.Show("Güncelleme Başarılı !.");
                    Hesap();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                lblalinankalori.Text = karbonhidratkalori.ToString();
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
          
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                lblalinankalori.Text = yagkalori.ToString();
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
           
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                lblalinankalori.Text = proteinkalori.ToString();
                checkBox2.Checked = false;
                checkBox1.Checked = false;
            }
            
            
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtResimyol.Text = openFileDialog1.FileName;
            pictureBox1.ImageLocation = txtResimyol.Text;
        }
        public bool Ekle_Yemek()
        {
         
            
            bool kontrol = false;
            baglanti.Open(); // bağlantıyı açtık

            //Sorgumuzu yazdım. Ekleme işlemi yapan insert into sorgusu yazdım.
            SqlCommand ekle = new SqlCommand("insert into Yemek(Karbonhidrat,Yag,Protein,KullaniciID,Tarih,Resim) values ('" +cBoxKarbonhidrat.Text  + "','" +cBoxYag.Text  + "','" + cBoxProtein.Text + "','" + lblKullaniciAdi.Text  + "','" +dateTimePicker2.Text+ "','" + txtResimyol.Text + "')", baglanti);
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            if (ekle.ExecuteNonQuery() > 0)
            {
                kontrol = true;
            }
            ekle.Dispose();
            baglanti.Close();
            return kontrol;


        }
        public void VeriGetir()
        {
            string Tarih = dateTimePicker1.Text;
            string sql = "SELECT Karbonhidrat,Yag,Protein,Tarih,Resim from Yemek where KullaniciID='" + lblKullaniciAdi.Text + "' and Tarih='"+Tarih+"'";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = baglanti;
            adapter.SelectCommand = command;
            baglanti.Open();
            adapter.Fill(dt);
            dgwYemek.DataSource = dt;
            baglanti.Close();
            
        }
        //Switch case kullanımının bulunduğu method...
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            switch (Ekle_Yemek())
            {
                case true:
                    MessageBox.Show("Ekleme Başarılı.");
                    VeriGetir();
                    break;
                case false:
                    MessageBox.Show("Ekleme Başarısız.");
                    break;
                default:
                    MessageBox.Show("Alanları Kontrol edin !");
                    break;
            }
           
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            VeriGetir();
        }

        private void dgwYemek_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgwYemek.SelectedCells[0].RowIndex;
            pictureBox2.ImageLocation = dgwYemek.Rows[secilen].Cells[4].Value.ToString();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
