using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Engine
{
    public class Monstruo:CriaturaViviente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int DanioMaximo { get; set; }
        public int RecompensaExperiencia { get; set; }
        public int RecompensaOro { get; set; }
        public List<ItemDelBotin> TableroDeItems { get; set; }

        public Monstruo(int id, string name, int maximumDamage, int rewardExperiencePoints, int rewardGold, int currentHitPoints, int maximumHitPoints) : base(currentHitPoints, maximumHitPoints)
        {
            ID = id;
            Nombre = name;
            DanioMaximo = maximumDamage;
            RecompensaExperiencia = rewardExperiencePoints;
            RecompensaOro = rewardGold;
            TableroDeItems = new List<ItemDelBotin>();
        }
    }
}
