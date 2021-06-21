using GoldenE.horarios;
using GoldenE.maestros;
using Ge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenE.recepcionista
{
    public partial class MainRecepcionista : Form
    {
        public MainRecepcionista()
        {
            InitializeComponent();
        }

        private void MainRecepcionista_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            timer1.Enabled = true;
            timer1.Interval = 100;
            label6.Text = publicas.nombre.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongTimeString();
        }

        private void buttonCalif_Click(object sender, EventArgs e)
        {
            ComponentesReusables.AbrirFormEnPanel(new AgregaHorario(), panel2);
        }

        private void buttonReportes_Click(object sender, EventArgs e)
        {
            ComponentesReusables.AbrirFormEnPanel(new cargaravance(), panel2);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult yes;
            yes = MessageBox.Show("¿Deseas salir?", "Aviso", MessageBoxButtons.YesNo);
            if (yes == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
