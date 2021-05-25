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
    public partial class ActualizarCatalogo : Form
    {
        public ActualizarCatalogo()
        {
            InitializeComponent();
        }

        private void btncActu_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand act = new OracleCommand("ACTUALIZACATALOGO", Conexion.conectar());
                act.CommandType = System.Data.CommandType.StoredProcedure;
                act.Parameters.Add("id_catalogo_in", OracleDbType.Int16).Value = textBoxCid.Text;
                act.Parameters.Add("catalogo_descripcion", OracleDbType.Varchar2).Value = Convert.ToString(textBoxAdescripcion.Text).ToLower();

                //
                string comp = " select id_clase from tipo_clase where descripcion =lower('" + this.textBoxAdescripcion.Text + "')";
                OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
                OracleDataReader dre = cpe.ExecuteReader();
                if (dre.Read())
                {
                    MessageBox.Show("Existe una clase con el mismo nombre ", "aviso", MessageBoxButtons.OK);
                }
                else
                {
                    act.ExecuteNonQuery();
                    MessageBox.Show("Dato actualizado con exito", "exito", MessageBoxButtons.OK);
                    this.cargarClase(this.dataGridViewCargaClase);
                    this.Limpiar();
                }




                //aaaa
            }
            catch (OracleException ex)
            {
                switch (ex.Number)
                {
                    case 1722:
                        MessageBox.Show("Numero invalido(FormatException)--Error--" + ex.Number, "Aviso", MessageBoxButtons.OK);
                        break;
                    case 2292:
                        MessageBox.Show("No se puede eliminar el dato, porque existe una tabla hijo con ese dato", "Aviso", MessageBoxButtons.OK);
                        break;
                    default:
                        MessageBox.Show("Formato invalido--Error--" + ex.Number, "Aviso", MessageBoxButtons.OK);
                        break;
                }
            }
            finally
            {
                Conexion.cerrar();
            }
        }

        private void dataGridViewCargaClase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewCargaClase.Rows[e.RowIndex];
                this.textBoxCid.Text = row.Cells["ID_CLASE"].Value.ToString();
                this.textBoxAdescripcion.Text = row.Cells["descripcion"].Value.ToString();
            }
        }

        public void CargarClaseDescripcion(DataGridView dvg)
        {
            try
            {
                DataTable dtsClas = new DataTable();
                string comprobacion = "select ID_CLASE, descripcion from tipo_clase where DESCRIPCION like '" + Convert.ToString(this.textBoxBdescripcion.Text).ToLower() + "%' order by id_clase";

                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {
                    da.Fill(dtsClas);
                    dvg.DataSource = dtsClas;
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
                string comprobacion = "Select ID_CLASE,descripcion from tipo_clase where ID_CLASE='" + this.textBoxIdClase.Text + "'";
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
                    MessageBox.Show("La clase no existe", "aviso", MessageBoxButtons.OK);
                }
            }


            catch (Oracle.DataAccess.Client.OracleException)
            {
                dataGridViewCargaClase.DataSource = "";
                MessageBox.Show("Formato invalido", "Aviso", MessageBoxButtons.OK);
            }
        }
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.cargarClase(this.dataGridViewCargaClase);

        }

        private void ActualizarNiveles_Load(object sender, EventArgs e)
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
        public void Limpiar()
        {
            this.textBoxIdClase.Clear();
            this.textBoxAdescripcion.Clear();

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

        private void textBoxBdescripcion_TextChanged(object sender, EventArgs e)
        {
            this.CargarClaseDescripcion(this.dataGridViewCargaClase);
        }

    }

}