using GoldenE.alumnos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenE.usuarios
{
    public partial class Usuarios : Form
    {
        public Usuarios()
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

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new SeleccionaUsuarios());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AgregarUsuario());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new ActualizarUsuarios());
        }
    }
}
