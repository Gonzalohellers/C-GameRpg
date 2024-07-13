using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ArticuloDeFinalizacionMision
    {
        public Objeto Detalles { get; set; }
        public int Cantidad { get; set; }
        public ArticuloDeFinalizacionMision(Objeto details, int quantity)
        {
            Detalles = details;
            Cantidad = quantity;
        }
    }
}
