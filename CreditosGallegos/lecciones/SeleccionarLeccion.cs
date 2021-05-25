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
    public partial class SeleccionarLeccion : Form
    {
        public SeleccionarLeccion()
        {
            InitializeComponent();
        }
        public void CargarLeccionName(DataGridView dvg)
        {
            try
            {
                DataTable dtsLeccion = new DataTable();
                string comprobacion = "select L.ID_LECCION,N.DESCRIPCION as Nivel,L.Descripcion from lecciones L JOIN NIVELES N ON L.niveles_id_nivel=N.id_nivel where L.DESCRIPCION like '" + Convert.ToString(this.textBoxLeccionName.Text).ToLower() + "%'order by L.id_leccion";

                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {
                    da.Fill(dtsLeccion);
                    dvg.DataSource = dtsLeccion;
                }
                else
                {
                   dataGridViewCargaLeccion.DataSource = "";
                    MessageBox.Show("La lección no existe", "aviso", MessageBoxButtons.OK);
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
        public void cargarLeccion(DataGridView dvg)
        {
            try
            {
                DataTable dtLec = new DataTable();
                string comprobacion = "select L.ID_LECCION,N.DESCRIPCION as Nivel,L.Descripcion from lecciones L JOIN NIVELES N ON L.niveles_id_nivel=N.id_nivel where L.ID_LECCION='" + this.textBoxSidLeccion.Text + "'";
                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {

                    da.Fill(dtLec);
                    dvg.DataSource = dtLec;
                }
                else
                {
                    dataGridViewCargaLeccion.DataSource = "";
                    MessageBox.Show("La lección no existe", "aviso", MessageBoxButtons.OK);
                }
            }


            catch (Oracle.DataAccess.Client.OracleException)
            {
                dataGridViewCargaLeccion.DataSource = "";
                MessageBox.Show("Formato invalido", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void btncbuscar_Click(object sender, EventArgs e)
        {
            this.cargarLeccion(this.dataGridViewCargaLeccion);
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

        private void textBoxLeccionName_TextChanged(object sender, EventArgs e)
        {
            this.CargarLeccionName(this.dataGridViewCargaLeccion);
        }
    }
}
