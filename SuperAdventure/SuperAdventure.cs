using Engine;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Jugador player;

        public SuperAdventure()
        {
            InitializeComponent();  // Asegúrate de que esto esté al principio
            Ubicacion test1 = new Ubicacion(1, "Your House", "This is your house");
            Ubicacion test2 = new Ubicacion(1, "Your House", "This is your house", null, null, null);
            player = new Jugador(50, 100, 20, 0, 1);
            lblHitPoints.Text = player.GolpesActuales.ToString();
            lblGold.Text = player.Oro.ToString();
            lblExperiencia.Text = player.PuntosDeExperiencia.ToString();
            lblNivel.Text = player.Nivel.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            lblGold.Text = "123";
        }

        private void BtnOeste_Click(object sender, EventArgs e)
        {

        }

        private void rtbMensajes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
