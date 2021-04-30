﻿using GoldenE;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ge
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public static int id=0;
        public Form1()
        {
            InitializeComponent();
        }
        
       
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Conexion.conectar();
                MessageBox.Show("Conexion Exitosa", "aviso", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Conexion con errores", "aviso", MessageBoxButtons.OK);
            }
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            
        }
        int posx = 0;
        int posy = 0;
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posx = e.X;
                posy = e.Y;
            }
            else
            {
                Left = Left + (e.X - posx);
                Top = Top + (e.Y - posy);
            }
        }
        public byte intento = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string hash = Helper.EncodePassword(string.Concat(this.textBoxUser.Text, this.textBoxPassword.Text));
            string comp = " select tipo_usuario_id_tipo_usuario from usuarios where id_usuario ='" + this.textBoxUser.Text + "'and contrasena='"+ hash + "'";
            OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
            OracleDataReader dre = cpe.ExecuteReader();
            if (dre.Read())
            {
                publicas.id_t_user = Convert.ToInt32(cpe.ExecuteScalar());

                //Mostar menu      
                
                this.Hide();
                InsertarCarreras m = new InsertarCarreras();
                m.Show();
               
                MessageBox.Show("BIENVENIDO " + textBoxUser.Text, "aviso", MessageBoxButtons.OK);
                
            }
            else
            {
                intento += 1;
                if (intento == 3)
                {
                    MessageBox.Show("Adios", "aviso", MessageBoxButtons.OK);
                    Application.Exit();
                }
                MessageBox.Show("Error no existe", "aviso", MessageBoxButtons.OK);
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            DialogResult yes;
            yes = MessageBox.Show("¿Desea salir?","Aviso",MessageBoxButtons.YesNo);
            if(yes == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult yes;
            yes = MessageBox.Show("¿Desea salir?", "Aviso", MessageBoxButtons.YesNo);
            if (yes == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
