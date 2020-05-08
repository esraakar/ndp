using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev2
{
    //Abstract Soyut sınıf örneği bu sınıftan nesne türetilemez
    //ancak ondan miras alan Besin Türleri Karbonhidrat Yağ ve Protein sınıfından nesne türetilebilir.
    abstract class Besin
    {
        private double _kalorimiktar;
        public abstract string BesinAdi { get; set; }
        public double Kalorimiktar { get => _kalorimiktar; set => _kalorimiktar = value; }

      
    }
}
