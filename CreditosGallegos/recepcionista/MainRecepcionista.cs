using GoldenE.horarios;
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

        }

        private void buttonCalif_Click(object sender, EventArgs e)
        {
            ComponentesReusables.AbrirFormEnPanel(new AgregaHorario(), panel2);
        }

        private void buttonReportes_Click(object sender, EventArgs e)
        {
            ComponentesReusables.AbrirFormEnPanel(new cargaravance(), panel2);
        }
    }
}
