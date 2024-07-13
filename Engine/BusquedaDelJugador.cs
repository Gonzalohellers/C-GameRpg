using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Engine
{
    public class BusquedaDelJugador
    {
        public Busqueda Details { get; set; }
        public bool IsCompleted { get; set; }
        public BusquedaDelJugador(Busqueda details)
        {
            Details = details;
            IsCompleted = false;
        }
    }
}