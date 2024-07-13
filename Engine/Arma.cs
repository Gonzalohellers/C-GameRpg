using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Arma:Objeto
    {
        public int DanioMinimo { get; set; }
        public int Daniomaximo { get; set; }
        public Arma(int id, string name, string namePlural, int minimumDamage, int maximumDamage) : base(id, name, namePlural)
        {
            DanioMinimo = minimumDamage;
            Daniomaximo = maximumDamage;
        }
    }
}