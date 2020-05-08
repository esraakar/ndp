using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev2
{
    public interface IHesap
    {
        //Su Miktarını hesaplamak için oluşturulan interface alanları
        double Boy { get; set; }
        double Kilo { get; set; }
        int Yas { get; set; }
        double SuMiktari();
       
        

    }
}
