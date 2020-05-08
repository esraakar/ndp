using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev2
{
    public partial class KullaniciHesabi : Form
    {
        public static List<string> Bilgi;
        //public static string Kilo;
        //public static string Yas;
        public KullaniciHesabi()
        {
            InitializeComponent();
        }

        public void FormTemizle()
        {
            txtKullaniciK.Text = "";
            txtParolaK.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtBoy.Text = "";
            txtKilo.Text = "";
            txtYas.Text = "";
            cboxCinsiyet.Text = "";
        }
        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();
            k.KullaniciAdi = txtKullaniciK.Text;
            k.Parola = txtParolaK.Text;
            k.Ad = txtAd.Text;
            k.Soyad = txtSoyad.Text;
            k.Boy = Convert.ToDouble(txtBoy.Text);
            k.Kilo = Convert.ToDouble(txtKilo.Text);
            k.Yas = Convert.ToInt32(txtYas.Text);
            k.Cinsiyet = cboxCinsiyet.Text;
            if (k.Ekle_Kayit())
            {
                MessageBox.Show("Kaydınız Alındı.");
            }
            FormTemizle();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();
            k.KullaniciAdi = txtKullanici.Text;
            k.Parola = txtParola.Text;
            if (k.GirisYap())
            {
                Bilgi = k.GetBilgi();
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Parola Hatalı"); 
            }
            
        }
    }
}
