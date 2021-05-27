using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenE.gerente
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void buttonAula_Click(object sender, EventArgs e)
        {
            ComponentesReusables.AbrirFormEnPanel(new TraficoAulas(), panelContenedor);
        }
    }
}
