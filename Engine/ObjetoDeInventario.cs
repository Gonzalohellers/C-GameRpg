using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Engine
{
    public class ObjetoDelInventario
    {
        public Objeto Details { get; set; }
        public int Quantity { get; set; }
        public ObjetoDelInventario(Objeto details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}