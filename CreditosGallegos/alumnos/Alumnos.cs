﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenE.alumnos
{
    public partial class Alumnos : Form
    {
        public Alumnos()
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
        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new InsertaAlumno());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new SeleccionAlumnos());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new ActualizarAlumnos());
        }
    }
}
