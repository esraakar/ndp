using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev2
{
    abstract class Kisi
    {
        //Kapsüllenmiş private alanlar
        private double _boy;
        private double _kilo;
        private int _yas;
        
        //Parametresiz Constructor
        public Kisi() { }

        //3 parametreli constructor
        public Kisi(double _boy, double _kilo,int _yas)
        {
            this.Boy = _boy;
            this.Kilo = _kilo;
            this.Yas = _yas;
           
        }

        //Properties Özellikler
        public double Boy { get => _boy; set => _boy = value; }
        public double Kilo { get => _kilo; set => _kilo = value; }
        public int Yas { get => _yas; set => _yas = value; }


        //Pollymorphism uygulanan Method
        public abstract double KaloriHesapla();
    }
}
