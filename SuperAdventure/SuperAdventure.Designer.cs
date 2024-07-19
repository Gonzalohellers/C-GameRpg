namespace SuperAdventure
{
    partial class SuperAdventure
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblHitPoints = new Label();
            lblGold = new Label();
            lblExperiencia = new Label();
            lblNivel = new Label();
            BtnUsarArma = new Button();
            label5 = new Label();
            cboPociones = new ComboBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            BtnOeste = new Button();
            BtnNorte = new Button();
            BtnEste = new Button();
            BtnSur = new Button();
            rtbMensajes = new RichTextBox();
            rtbUbicacion = new RichTextBox();
            dgvInventory = new DataGridView();
            dgvUbicacion = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUbicacion).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Puntos de Golpe:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 46);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 1;
            label2.Text = "Oro:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 74);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Experiencia:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 100);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 3;
            label4.Text = "Nivel:";
            // 
            // lblHitPoints
            // 
            lblHitPoints.AutoSize = true;
            lblHitPoints.Location = new Point(153, 20);
            lblHitPoints.Name = "lblHitPoints";
            lblHitPoints.Size = new Size(0, 15);
            lblHitPoints.TabIndex = 4;
            // 
            // lblGold
            // 
            lblGold.AutoSize = true;
            lblGold.Location = new Point(153, 46);
            lblGold.Name = "lblGold";
            lblGold.Size = new Size(0, 15);
            lblGold.TabIndex = 5;
            // 
            // lblExperiencia
            // 
            lblExperiencia.AutoSize = true;
            lblExperiencia.Location = new Point(153, 74);
            lblExperiencia.Name = "lblExperiencia";
            lblExperiencia.Size = new Size(0, 15);
            lblExperiencia.TabIndex = 6;
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.Location = new Point(153, 100);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(0, 15);
            lblNivel.TabIndex = 7;
            // 
            // BtnUsarArma
            // 
            BtnUsarArma.Location = new Point(642, 415);
            BtnUsarArma.Name = "BtnUsarArma";
            BtnUsarArma.Size = new Size(75, 23);
            BtnUsarArma.TabIndex = 8;
            BtnUsarArma.Text = "Usar Pociones";
            BtnUsarArma.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(641, 341);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 9;
            label5.Text = "Select Action";
            // 
            // cboPociones
            // 
            cboPociones.FormattingEnabled = true;
            cboPociones.Location = new Point(439, 415);
            cboPociones.Name = "cboPociones";
            cboPociones.Size = new Size(121, 23);
            cboPociones.TabIndex = 10;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(439, 368);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(641, 368);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Usar Arma";
            button1.UseVisualStyleBackColor = true;
            // 
            // BtnOeste
            // 
            BtnOeste.Location = new Point(397, 280);
            BtnOeste.Name = "BtnOeste";
            BtnOeste.Size = new Size(75, 23);
            BtnOeste.TabIndex = 13;
            BtnOeste.Text = "Oeste";
            BtnOeste.UseVisualStyleBackColor = true;
            BtnOeste.Click += btnWest_Click;
            // 
            // BtnNorte
            // 
            BtnNorte.Location = new Point(463, 242);
            BtnNorte.Name = "BtnNorte";
            BtnNorte.Size = new Size(75, 23);
            BtnNorte.TabIndex = 13;
            BtnNorte.Text = "Norte";
            BtnNorte.UseVisualStyleBackColor = true;
            BtnNorte.Click += btnNorth_Click;
            // 
            // BtnEste
            // 
            BtnEste.Location = new Point(538, 280);
            BtnEste.Name = "BtnEste";
            BtnEste.Size = new Size(75, 23);
            BtnEste.TabIndex = 14;
            BtnEste.Text = "Este";
            BtnEste.UseVisualStyleBackColor = true;
            BtnEste.Click += btnEast_Click;
            // 
            // BtnSur
            // 
            BtnSur.Location = new Point(463, 316);
            BtnSur.Name = "BtnSur";
            BtnSur.Size = new Size(75, 23);
            BtnSur.TabIndex = 15;
            BtnSur.Text = "Sur";
            BtnSur.UseVisualStyleBackColor = true;
            BtnSur.Click += btnSouth_Click;
            // 
            // rtbMensajes
            // 
            rtbMensajes.Location = new Point(260, 74);
            rtbMensajes.Name = "rtbMensajes";
            rtbMensajes.ReadOnly = true;
            rtbMensajes.Size = new Size(491, 162);
            rtbMensajes.TabIndex = 16;
            rtbMensajes.Text = "";
            // 
            // rtbUbicacion
            // 
            rtbUbicacion.Location = new Point(520, 12);
            rtbUbicacion.Name = "rtbUbicacion";
            rtbUbicacion.ReadOnly = true;
            rtbUbicacion.Size = new Size(276, 49);
            rtbUbicacion.TabIndex = 17;
            rtbUbicacion.Text = "";
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvInventory.Location = new Point(12, 149);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.ReadOnly = true;
            dgvInventory.Size = new Size(240, 116);
            dgvInventory.TabIndex = 18;
            // 
            // dgvUbicacion
            // 
            dgvUbicacion.AllowUserToAddRows = false;
            dgvUbicacion.AllowUserToDeleteRows = false;
            dgvUbicacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUbicacion.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvUbicacion.Location = new Point(12, 291);
            dgvUbicacion.Name = "dgvUbicacion";
            dgvUbicacion.ReadOnly = true;
            dgvUbicacion.Size = new Size(240, 114);
            dgvUbicacion.TabIndex = 19;
            // 
            // SuperAdventure
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvUbicacion);
            Controls.Add(dgvInventory);
            Controls.Add(rtbUbicacion);
            Controls.Add(rtbMensajes);
            Controls.Add(BtnSur);
            Controls.Add(BtnEste);
            Controls.Add(BtnNorte);
            Controls.Add(BtnOeste);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(cboPociones);
            Controls.Add(label5);
            Controls.Add(BtnUsarArma);
            Controls.Add(lblNivel);
            Controls.Add(lblExperiencia);
            Controls.Add(lblGold);
            Controls.Add(lblHitPoints);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SuperAdventure";
            Text = "My RP Game";
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUbicacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblHitPoints;
        private Label lblGold;
        private Label lblExperiencia;
        private Label lblNivel;
        private Button BtnUsarArma;
        private Label label5;
        private ComboBox cboPociones;
        private ComboBox comboBox1;
        private Button button1;
        private Button BtnOeste;
        private Button BtnNorte;
        private Button BtnEste;
        private Button BtnSur;
        private RichTextBox rtbMensajes;
        private RichTextBox rtbUbicacion;
        private DataGridView dgvInventory;
        private DataGridView dgvUbicacion;
    }
}
