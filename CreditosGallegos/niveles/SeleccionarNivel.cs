using Ge;
using Oracle.ManagedDataAccess.Client;
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
    public partial class SeleccionarNivel : Form
    {
        public SeleccionarNivel()
        {
            InitializeComponent();
        }
        public void CargarNivelName(DataGridView dvg)
        {
            try
            {
                DataTable dtsNivel = new DataTable();
                string comprobacion = "select N.ID_NIVEL,N.DESCRIPCION from NIVELES N where N.DESCRIPCION like '" + Convert.ToString(this.textBoxNivelName.Text).ToLower() + "%'order by N.descripcion";

                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {
                    da.Fill(dtsNivel);
                    dvg.DataSource = dtsNivel;
                }
                else
                {
                   dataGridViewCargaNivel.DataSource = "";
                    MessageBox.Show("El Nivel no existe", "aviso", MessageBoxButtons.OK);
                }



            }
            catch (OracleException ex)
            {
                switch (ex.Number)
                {
                    case 1722:
                        MessageBox.Show("--Error--" + ex.Number, "Aviso", MessageBoxButtons.OK);
                        break;
                    case 2292:
                        MessageBox.Show("No se puede eliminar el dato, porque existe una tabla hijo con ese dato", "Aviso", MessageBoxButtons.OK);
                        break;
                    default:
                        MessageBox.Show("Formato invalido--Error--" + ex.Number, "Aviso", MessageBoxButtons.OK);
                        break;
                }
            }


        }
        public void cargarNivel(DataGridView dvg)
        {
            try
            {
                DataTable dtalumnos = new DataTable();
                string comprobacion = "select N.ID_NIVEL,N.DESCRIPCION from NIVELES N where N.ID_NIVEL='" + this.textBoxSidNivel.Text + "'";
                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {

                    da.Fill(dtalumnos);
                    dvg.DataSource = dtalumnos;
                }
                else
                {
                    dataGridViewCargaNivel.DataSource = "";
                    MessageBox.Show("El Nivel no existe", "aviso", MessageBoxButtons.OK);
                }
            }


            catch (Oracle.DataAccess.Client.OracleException)
            {
                dataGridViewCargaNivel.DataSource = "";
                MessageBox.Show("Formato invalido", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void btncbuscar_Click(object sender, EventArgs e)
        {
            this.cargarNivel(this.dataGridViewCargaNivel);
        }

        private void SeleccionarNivel_Load(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true || groupBox2.Enabled == true)
            {



            }
            else
            {

                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                this.groupBox1.Hide();
                this.groupBox2.Hide();

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox1.Show();
                groupBox2.Hide();
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
                groupBox1.Hide();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                groupBox2.Show();
                groupBox1.Hide();
                checkBox1.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                groupBox2.Hide();
            }
        }

        private void textBoxNivelName_TextChanged(object sender, EventArgs e)
        {
            this.CargarNivelName(this.dataGridViewCargaNivel);
        }
    }
}
