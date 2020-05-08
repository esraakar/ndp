using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev2
{
    class Protein:Besin
    {
        //Besin sınıfından kalıtım Inheritance alan Protein sınıfındaki private alan
        private string _ProteinAd;
        //besin sınıfından gelen besin adının ovverride edilmesi
        public override string BesinAdi
        {
            get => _ProteinAd;
            set => _ProteinAd = value;
        }
    }
}
