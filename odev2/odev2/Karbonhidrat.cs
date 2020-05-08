using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev2
{
    class Karbonhidrat : Besin
    {
        //Besin sınıfından kalıtım Inheritance alan Karbonhidrat sınıfındaki private alan
        private string _KarbonhidratAd;
        //besin sınıfından gelen besin adının ovverride edilmesi
        public override string BesinAdi
        {
            get { return _KarbonhidratAd; }
            set { _KarbonhidratAd = value; }
        }

    }
}
