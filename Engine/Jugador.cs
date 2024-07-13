using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Jugador:CriaturaViviente
    {
        public int Oro { get; set; }
        public int PuntosDeExperiencia { get; set; }
        public int Nivel { get; set; }
        public List<ObjetoDelInventario> Inventario { get; set; }
        public List<BusquedaDelJugador> Busquedas { get; set; }
        public Jugador(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints, int level) : base(currentHitPoints, maximumHitPoints)
        {
            Oro = gold;
            PuntosDeExperiencia = experiencePoints;
            Nivel = level;
            Inventario = new List<ObjetoDelInventario>();
            Busquedas = new List<BusquedaDelJugador>();
        }
    }
}
