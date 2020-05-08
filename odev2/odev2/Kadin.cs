using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev2
{
    class Kadin:Kisi
    {
        //Kişi sınıfından alınan mirasla oluşturulan 3 parametreli Constructor Yapıcı Methodumuz.
        public Kadin(double _boy,double _kilo,int _yas): base(_boy,_kilo,_yas) { }

        //Pollymorphism çok biçimli mehod Erkek Kadın olarak değişen bir formülle hesaplanıyor
        public override double KaloriHesapla()
        {
            return 655 + (9.6 * Kilo) + (1.8 * Boy) - (4.7 * Yas);
        }
    }
}
