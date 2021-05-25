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

namespace GoldenE.Catalogo_Horario
{
    public partial class SeleccionarCatalogo : Form
    {
        public SeleccionarCatalogo()
        {
            InitializeComponent();
        }
        public void CargarClaseDescripcion(DataGridView dvg)
        {
            try
            {
                DataTable dtsClase = new DataTable();
                string comprobacion = "select ID_CLASE,DESCRIPCION from tipo_clase where DESCRIPCION like '" + Convert.ToString(this.textBoxClaseDescripcion.Text).ToLower() + "%'order by descripcion";

                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {
                    da.Fill(dtsClase);
                    dvg.DataSource = dtsClase;
                }
                else
                {
                   dataGridViewCargaClase.DataSource = "";
                    MessageBox.Show("La clase no existe", "aviso", MessageBoxButtons.OK);
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
        public void cargarClase(DataGridView dvg)
        {
            try
            {
                DataTable dtclases = new DataTable();
                string comprobacion = "select ID_CLASE,DESCRIPCION from tipo_clase where ID_CLASE='" + this.textBoxSidClase.Text + "'";
                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {

                    da.Fill(dtclases);
                    dvg.DataSource = dtclases;
                }
                else
                {
                    dataGridViewCargaClase.DataSource = "";
                    MessageBox.Show("El Nivel no existe", "aviso", MessageBoxButtons.OK);
                }
            }


            catch (Oracle.DataAccess.Client.OracleException)
            {
                dataGridViewCargaClase.DataSource = "";
                MessageBox.Show("Formato invalido", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void btncbuscar_Click(object sender, EventArgs e)
        {
            this.cargarClase(this.dataGridViewCargaClase);
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
            this.CargarClaseDescripcion(this.dataGridViewCargaClase);
        }
    }
}
