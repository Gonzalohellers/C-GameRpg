using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Engine
{
    public class Ubicacion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Objeto ItemRequiredToEnter { get; set; }
        public Busqueda QuestAvailableHere { get; set; }
        public Monstruo MonsterLivingHere { get; set; }
        public Ubicacion LocationToNorth { get; set; }
        public Ubicacion LocationToEast { get; set; }
        public Ubicacion LocationToSouth { get; set; }
        public Ubicacion LocationToWest { get; set; }
        public Ubicacion(int id, string name, string description, Objeto itemRequiredToEnter = null, Busqueda questAvailableHere = null, Monstruo monsterLivingHere = null)
        {
            ID = id;
            Nombre = name;
            Descripcion = description;
            ItemRequiredToEnter = itemRequiredToEnter;
            QuestAvailableHere = questAvailableHere;
            MonsterLivingHere = monsterLivingHere;
        }
    }
}
