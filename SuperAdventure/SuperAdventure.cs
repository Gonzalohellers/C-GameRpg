using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Engine;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Jugador _player;
        private Monstruo _currentMonster;

        public SuperAdventure()
        {
            InitializeComponent();

            _player = new Jugador(10, 10, 20, 0, 1);
            MoveTo(Mundo.LocationByID(Mundo.LOCATION_ID_HOME));
            _player.Inventario.Add(new ObjetoDelInventario(Mundo.ItemByID(Mundo.ITEM_ID_RUSTY_SWORD), 1));

            lblHitPoints.Text = _player.GolpesActuales.ToString();
            lblGold.Text = _player.Oro.ToString();
            lblExperiencia.Text = _player.PuntosDeExperiencia.ToString();
            lblNivel.Text = _player.Nivel.ToString();
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.Ubicacion.LocationToNorth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.Ubicacion.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.Ubicacion.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.Ubicacion.LocationToWest);
        }

        private void MoveTo(Ubicacion newLocation)
        {
            //Does the location have any required items
            if (newLocation.ItemRequiredToEnter != null)
            {
                // See if the player has the required item in their inventory
                bool playerHasRequiredItem = false;

                foreach (ObjetoDelInventario ii in _player.Inventario)
                {
                    if (ii.Details.ID == newLocation.ItemRequiredToEnter.ID)
                    {
                        // We found the required item
                        playerHasRequiredItem = true;
                        break; // Exit out of the foreach loop
                    }
                }

                if (!playerHasRequiredItem)
                {
                    // We didn't find the required item in their inventory, so display a message and stop trying to move
                    rtbMensajes.Text += "Debes tener un(a) " + newLocation.ItemRequiredToEnter.Nombre + " para entrar a esta ubicación." + Environment.NewLine;
                    return;
                }
            }

            // Update the player's current location
            _player.Ubicacion = newLocation;

            // Show/hide available movement buttons
            BtnNorte.Visible = (newLocation.LocationToNorth != null);
            BtnEste.Visible = (newLocation.LocationToEast != null);
            BtnSur.Visible = (newLocation.LocationToSouth != null);
            BtnOeste.Visible = (newLocation.LocationToWest != null);

            // Display current location name and description
            rtbUbicacion.Text = newLocation.Nombre + Environment.NewLine;
            rtbUbicacion.Text += newLocation.Descripcion + Environment.NewLine;

            // Completely heal the player
            _player.GolpesActuales = _player.PuntoMaximoDeGolpes;

            // Update Hit Points in UI
            lblHitPoints.Text = _player.GolpesActuales.ToString();

            // Does the location have a quest?
            if (newLocation.QuestAvailableHere != null)
            {
                // See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = false;
                bool playerAlreadyCompletedQuest = false;

                foreach (BusquedaDelJugador playerQuest in _player.Busquedas)
                {
                    if (playerQuest.Details.ID == newLocation.QuestAvailableHere.ID)
                    {
                        playerAlreadyHasQuest = true;

                        if (playerQuest.IsCompleted)
                        {
                            playerAlreadyCompletedQuest = true;
                        }
                    }
                }

                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = true;

                        foreach (ArticuloDeFinalizacionMision qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                        {
                            bool foundItemInPlayersInventory = false;

                            // Check each item in the player's inventory, to see if they have it, and enough of it
                            foreach (ObjetoDelInventario ii in _player.Inventario)
                            {
                                // The player has this item in their inventory
                                if (ii.Details.ID == qci.Detalles.ID)
                                {
                                    foundItemInPlayersInventory = true;

                                    if (ii.Quantity < qci.Cantidad)
                                    {
                                        // The player does not have enough of this item to complete the quest
                                        playerHasAllItemsToCompleteQuest = false;

                                        // There is no reason to continue checking for the other quest completion items
                                        break;
                                    }

                                    // We found the item, so don't check the rest of the player's inventory
                                    break;
                                }
                            }

                            // If we didn't find the required item, set our variable and stop looking for other items
                            if (!foundItemInPlayersInventory)
                            {
                                // The player does not have this item in their inventory
                                playerHasAllItemsToCompleteQuest = false;

                                // There is no reason to continue checking for the other quest completion items
                                break;
                            }
                        }

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            rtbMensajes.Text += Environment.NewLine;
                            rtbMensajes.Text += "Has completado la misión '" + newLocation.QuestAvailableHere.Nombre + "'." + Environment.NewLine;

                            // Remove quest items from inventory
                            foreach (ArticuloDeFinalizacionMision qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                            {
                                foreach (ObjetoDelInventario ii in _player.Inventario)
                                {
                                    if (ii.Details.ID == qci.Detalles.ID)
                                    {
                                        // Subtract the quantity from the player's inventory that was needed to complete the quest
                                        ii.Quantity -= qci.Cantidad;
                                        break;
                                    }
                                }
                            }

                            // Give quest rewards
                            rtbMensajes.Text += "Recibes: " + Environment.NewLine;
                            rtbMensajes.Text += newLocation.QuestAvailableHere.RecompensaExperiencia.ToString() + " Puntos de Experiencia" + Environment.NewLine;
                            rtbMensajes.Text += newLocation.QuestAvailableHere.RecompensaOro.ToString() + " Oro" + Environment.NewLine;
                            rtbMensajes.Text += newLocation.QuestAvailableHere.RewardItem.Nombre + Environment.NewLine;
                            rtbMensajes.Text += Environment.NewLine;

                            _player.PuntosDeExperiencia += newLocation.QuestAvailableHere.RecompensaExperiencia;
                            _player.Oro += newLocation.QuestAvailableHere.RecompensaOro;

                            // Add the reward item to the player's inventory
                            bool addedItemToPlayerInventory = false;

                            foreach (ObjetoDelInventario ii in _player.Inventario)
                            {
                                if (ii.Details.ID == newLocation.QuestAvailableHere.RewardItem.ID)
                                {
                                    // They have the item in their inventory, so increase the quantity by one
                                    ii.Quantity++;

                                    addedItemToPlayerInventory = true;

                                    break;
                                }
                            }

                            // They didn't have the item, so add it to their inventory, with a quantity of 1
                            if (!addedItemToPlayerInventory)
                            {
                                _player.Inventario.Add(new ObjetoDelInventario(newLocation.QuestAvailableHere.RewardItem, 1));
                            }

                            // Mark the quest as completed
                            // Find the quest in the player's quest list
                            foreach (BusquedaDelJugador pq in _player.Busquedas)
                            {
                                if (pq.Details.ID == newLocation.QuestAvailableHere.ID)
                                {
                                    // Mark it as completed
                                    pq.IsCompleted = true;

                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    // The player does not already have the quest

                    // Display the messages
                    rtbMensajes.Text += "Recibes la misión " + newLocation.QuestAvailableHere.Nombre + "." + Environment.NewLine;
                    rtbMensajes.Text += newLocation.QuestAvailableHere.Descripcion + Environment.NewLine;
                    rtbMensajes.Text += "Para completarla, regresa con:" + Environment.NewLine;
                    foreach (ArticuloDeFinalizacionMision qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Cantidad == 1)
                        {
                            rtbMensajes.Text += qci.Cantidad.ToString() + " " + qci.Detalles.Nombre + Environment.NewLine;
                        }
                        else
                        {
                            rtbMensajes.Text += qci.Cantidad.ToString() + " " + qci.Detalles.NombrePlural + Environment.NewLine;
                        }
                    }
                    rtbMensajes.Text += Environment.NewLine;

                    // Add the quest to the player's quest list
                    _player.Busquedas.Add(new BusquedaDelJugador(newLocation.QuestAvailableHere));
                }
            }

            // Does the location have a monster?
            if (newLocation.MonsterLivingHere != null)
            {
                rtbMensajes.Text += "Ves un(a) " + newLocation.MonsterLivingHere.Nombre + Environment.NewLine;

                // Make a new monster, using the values from the standard monster in the World.Monster list
                Monstruo standardMonster = Mundo.MonsterByID(newLocation.MonsterLivingHere.ID);

                _currentMonster = new Monstruo(standardMonster.ID, standardMonster.Nombre, standardMonster.DanioMaximo,
                    standardMonster.RecompensaExperiencia, standardMonster.RecompensaOro, standardMonster.GolpesActuales, standardMonster.PuntoMaximoDeGolpes);

                foreach (ItemDelBotin lootItem in standardMonster.TableroDeItems)
                {
                    _currentMonster.TableroDeItems.Add(lootItem);
                }

                comboBox1.Visible = true;
                cboPociones.Visible = true;
                BtnUsarArma.Visible = true;
                button1.Visible = true;
            }
            else
            {
                _currentMonster = null;

                comboBox1.Visible = false;
                cboPociones.Visible = false;
                BtnUsarArma.Visible = false;
                button1.Visible = false;
            }

            // Refresh player's inventory list
            dgvInventory.RowHeadersVisible = false;

            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Nombre";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Cantidad";

            dgvInventory.Rows.Clear();

            foreach (ObjetoDelInventario inventoryItem in _player.Inventario)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Details.Nombre, inventoryItem.Quantity.ToString() });
                }
            }

            // Refresh player's quest list
            dgvUbicacion.RowHeadersVisible = false;

            dgvUbicacion.ColumnCount = 2;
            dgvUbicacion.Columns[0].Name = "Nombre";
            dgvUbicacion.Columns[0].Width = 197;
            dgvUbicacion.Columns[1].Name = "Hecho?";

            dgvUbicacion.Rows.Clear();

            foreach (BusquedaDelJugador playerQuest in _player.Busquedas)
            {
                dgvUbicacion.Rows.Add(new[] { playerQuest.Details.Nombre, playerQuest.IsCompleted.ToString() });
            }

            // Refresh player's weapons combobox
            List<Arma> weapons = new List<Arma>();

            foreach (ObjetoDelInventario inventoryItem in _player.Inventario)
            {
                if (inventoryItem.Details is Arma)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Arma)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                comboBox1.Visible = false;
                BtnUsarArma.Visible = false;
            }
            else
            {
                comboBox1.DataSource = weapons;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "ID";

                comboBox1.SelectedIndex = 0;
            }

            // Refresh player's potions combobox
            List<PocionDeSalud> healingPotions = new List<PocionDeSalud>();

            foreach (ObjetoDelInventario inventoryItem in _player.Inventario)
            {
                if (inventoryItem.Details is PocionDeSalud)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((PocionDeSalud)inventoryItem.Details);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
                cboPociones.Visible = false;
                button1.Visible = false;
            }
            else
            {
                cboPociones.DataSource = healingPotions;
                cboPociones.DisplayMember = "Nombre";
                cboPociones.ValueMember = "ID";

                cboPociones.SelectedIndex = 0;
            }
        }
        private void UpdateInventoryListInUI()
        {
            dgvInventory.RowHeadersVisible = false;

            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";

            dgvInventory.Rows.Clear();

            foreach (ObjetoDelInventario inventoryItem in _player.Inventario)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Details.Nombre }, inventoryItem.Quantity.ToString());
                }
            }
        }
        

        private void UpdateQuestListInUI()
        {
            dgvUbicacion.RowHeadersVisible = false;

            dgvUbicacion.ColumnCount = 2;
            dgvUbicacion.Columns[0].Name = "Nombre";
            dgvUbicacion.Columns[0].Width = 197;
            dgvUbicacion.Columns[1].Name = "Hecho?";

            dgvUbicacion.Rows.Clear();

            foreach (BusquedaDelJugador playerQuest in _player.Busquedas)
            {
                dgvUbicacion.Rows.Add(new[] { playerQuest.Details.Nombre, playerQuest.IsCompleted.ToString() });
            }
        }

        private void UpdateWeaponListInUI()
        {
            List<Arma> weapons = new List<Arma>();

            foreach (ObjetoDelInventario inventoryItem in _player.Inventario)
            {
                if (inventoryItem.Details is Arma)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Arma)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                comboBox1.Visible = false;
                BtnUsarArma.Visible = false;
            }
            else
            {
                comboBox1.DataSource = weapons;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "ID";

                comboBox1.SelectedIndex = 0;
            }
        }

        private void UpdatePotionListInUI()
        {
            List<PocionDeSalud> healingPotions = new List<PocionDeSalud>();

            foreach (ObjetoDelInventario inventoryItem in _player.Inventario)
            {
                if (inventoryItem.Details is PocionDeSalud)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((PocionDeSalud)inventoryItem.Details);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
                cboPociones.Visible = false;
                button1.Visible = false;
            }
            else
            {
                cboPociones.DataSource = healingPotions;
                cboPociones.DisplayMember = "Name";
                cboPociones.ValueMember = "ID";

                cboPociones.SelectedIndex = 0;
            }
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {

        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {

        }
    }
}