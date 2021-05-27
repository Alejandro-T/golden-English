using GoldenE.alumnos;
using GoldenE.maestros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenE
{
    public partial class MainMaestro : Form
    {
        public MainMaestro()
        {
            InitializeComponent();
        }
       
        private void MainMaestro_Load(object sender, EventArgs e)
        {

        }

        private void buttonCalif_Click(object sender, EventArgs e)
        {
            ComponentesReusables.AbrirFormEnPanel(new CalifAuto(), panel2);
        }

        private void buttonReportes_Click(object sender, EventArgs e)
        {
            ComponentesReusables.AbrirFormEnPanel(new HorarioDiaMaetro(), panel2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult yes;
            yes = MessageBox.Show("¿Deseas salir?", "Aviso", MessageBoxButtons.YesNo);
            if (yes == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComponentesReusables.AbrirFormEnPanel(new HorarioSemanaMaestro(), panel2);
        }
    }
}
