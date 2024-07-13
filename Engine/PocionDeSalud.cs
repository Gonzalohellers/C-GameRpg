using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class PocionDeSalud:Objeto
    {
        public int CantidadDeVida { get; set; }
        public PocionDeSalud(int id, string name, string namePlural, int amountToHeal) : base(id, name, namePlural)
        {   
            CantidadDeVida = amountToHeal;
        }
    }
}
