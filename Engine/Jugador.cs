using System;
using System.Collections;
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
        public Ubicacion Ubicacion { get; set; }
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
    

    public bool HasRequiredItemToEnterThisLocation(Ubicacion location)
    {
        if (location.ItemRequiredToEnter == null)
        {
            // There is no required item for this location, so return "true"
            return true;
        }

        // See if the player has the required item in their inventory
        foreach (ObjetoDelInventario ii in this.Inventario)
        {
            if (ii.Details.ID == location.ItemRequiredToEnter.ID)
            {
                // We found the required item, so return "true"
                return true;
            }
        }

        // We didn't find the required item in their inventory, so return "false"
        return false;
    }

    public bool HasThisQuest(Busqueda quest)
    {
        foreach (BusquedaDelJugador playerQuest in Busquedas)
        {
            if (playerQuest.Details.ID == quest.ID)
            {
                return true;
            }
        }
        return false;
    }

    public bool CompletedThisQuest(Busqueda quest)
    {
        foreach (BusquedaDelJugador playerQuest in Busquedas)
        {
            if (playerQuest.Details.ID == quest.ID)
            {
                return playerQuest.IsCompleted;
            }
        }
        return false;
    }

    public bool HasAllQuestCompletionItems(Busqueda quest)
    {
        // See if the player has all the items needed to complete the quest here
        foreach (ArticuloDeFinalizacionMision qci in quest.QuestCompletionItems)
        {
            bool foundItemInPlayersInventory = false;

            // Check each item in the player's inventory, to see if they have it, and enough of it
            foreach (ObjetoDelInventario ii in Inventario)
            {
                if (ii.Details.ID == qci.Detalles.ID) // The player has the item in their inventory
                {
                    foundItemInPlayersInventory = true;

                    if (ii.Quantity < qci.Cantidad) // The player does not have enough of this item to complete the quest
                    {
                        return false;
                    }
                }
            }

            // The player does not have any of this quest completion item in their inventory
            if (!foundItemInPlayersInventory)
            {
                return false;
            }
        }

        // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
        return true;
    }

    public void RemoveQuestCompletionItems(Busqueda quest)
    {
        foreach (ArticuloDeFinalizacionMision qci in quest.QuestCompletionItems)
        {
            foreach (ObjetoDelInventario ii in Inventario)
            {
                if (ii.Details.ID == qci.Detalles.ID)
                {
                    // Subtract the quantity from the player's inventory that was needed to complete the quest
                    ii.Quantity -= qci.Cantidad;
                    break;
                }
            }
        }
    }

    public void AddItemToInventory(Objeto itemToAdd)
    {
        foreach (ObjetoDelInventario ii in Inventario)
        {
            if (ii.Details.ID == itemToAdd.ID)
            {
                // They have the item in their inventory, so increase the quantity by one
                ii.Quantity++;

                return; // We added the item, and are done, so get out of this function
            }
        }

        // They didn't have the item, so add it to their inventory, with a quantity of 1
        Inventario.Add(new ObjetoDelInventario(itemToAdd, 1));
    }

    public void MarkQuestCompleted(Busqueda quest)
    {
        // Find the quest in the player's quest list
        foreach (BusquedaDelJugador pq in Busquedas)
        {
            if (pq.Details.ID == quest.ID)
            {
                // Mark it as completed
                pq.IsCompleted = true;

                return; // We found the quest, and marked it complete, so get out of this function
            }
        }
    }
}
}
