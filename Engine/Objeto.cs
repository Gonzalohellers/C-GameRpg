using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Engine
{
    public class Objeto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string NombrePlural { get; set; }
        public Objeto(int id, string name, string namePlural)
        {
            ID = id;
            Nombre = name;
            NombrePlural = namePlural;
        }
    }
}
