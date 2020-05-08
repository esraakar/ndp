using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev2
{
    class Yag:Besin
    {
        //Besin sınıfından kalıtım Inheritance alan Yag sınıfındaki private alan
        private string _YagAd;
        //besin sınıfından gelen besin adının ovverride edilmesi
        public override string BesinAdi
        {
            get => _YagAd;
            set => _YagAd = value;
        }
    }
}
