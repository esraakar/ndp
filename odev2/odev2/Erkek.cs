using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev2
{
    class Erkek:Kisi
    {

        //Kişi sınıfından alınan mirasla oluşturulan 3 parametreli Constructor Yapıcı Methodumuz.
        public Erkek(double _boy, double _kilo,int _yas) : base(_boy,_kilo,_yas) { }

        //Pollymorphism çok biçimli mehod Erkek Kadın olarak değişen bir formülle hesaplanıyor
        public override double KaloriHesapla()
        {
            return 66 + (13.7 * Kilo) + (5 * Boy) - (6.8 * Yas);
        }
    }
}
