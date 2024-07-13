using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Engine
{
    public class Busqueda
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int RecompensaExperiencia { get; set; }
        public int RecompensaOro { get; set; }
        public Objeto RewardItem { get; set; }
        public List<ArticuloDeFinalizacionMision> QuestCompletionItems { get; set; }
        public Busqueda(int id, string name, string description, int rewardExperiencePoints, int rewardGold)
        {
            ID = id;
            Nombre = name;
            Descripcion = description;
            RecompensaExperiencia = rewardExperiencePoints;
            RecompensaOro = rewardGold;
            QuestCompletionItems = new List<ArticuloDeFinalizacionMision>();
        }
    }
}
