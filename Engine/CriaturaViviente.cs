using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class CriaturaViviente
    {
        public int PuntoMaximoDeGolpes { get; set; }
        public int GolpesActuales { get; set; }

        public CriaturaViviente(int currentHitPoints, int maximumHitPoints)
        {
            PuntoMaximoDeGolpes = currentHitPoints;
            GolpesActuales = maximumHitPoints;
        }

    }
}
