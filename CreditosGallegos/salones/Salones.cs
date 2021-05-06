using GoldenE.alumnos;
using GoldenE.salones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenE.niveles
{
    public partial class Salones : Form
    {
        public Salones()
        {
            InitializeComponent();
        }
        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void buttonAgre_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new InsertarSalones());
        }

        private void buttonSelec_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new SeleccionarSalon());
        }

        private void buttonActu_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new ActualizarSalones());
        }
    }
}
