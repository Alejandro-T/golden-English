using Ge;
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

namespace GoldenE.alumnos
{
    public partial class ActualizarNiveles : Form
    {
        public ActualizarNiveles()
        {
            InitializeComponent();
        }

        private void btncActu_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand act = new OracleCommand("ACTUALIZANIVELES", Conexion.conectar());
                act.CommandType = System.Data.CommandType.StoredProcedure;

                act.Parameters.Add("id_nivel_in", OracleDbType.Int16).Value = textBoxNid.Text;

                act.Parameters.Add("nivel_descripcion", OracleDbType.Varchar2).Value = textBoxAdescripcion.Text;

                //
                string comprobacion2 =
                    "SELECT ID_NIVEL from niveles where ID_NIVEL='" + textBoxIdNivel.Text + "'";
                OracleCommand cp2 = new OracleCommand(comprobacion2, Conexion.conectar());
                OracleDataReader dr2 = cp2.ExecuteReader();
                if (dr2.Read())
                {
                    act.ExecuteNonQuery();
                    MessageBox.Show("Dato actualizado con exito", "exito", MessageBoxButtons.OK);
                    this.cargarNivel(this.dataGridViewCargaNivel);
                    this.Limpiar();
                }
                else
                {
                    MessageBox.Show("El nivel no existe", "aviso", MessageBoxButtons.OK);
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
 
        private void dataGridViewCargaAlumno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewCargaNivel.Rows[e.RowIndex];
                this.textBoxNid.Text = row.Cells["ID_NIVEL"].Value.ToString();
                this.textBoxAdescripcion.Text = row.Cells["descripcion"].Value.ToString();
            }
        }

        public void CargarNivelDescripcion(DataGridView dvg)
        {
            try
            {
                DataTable dtsNiv = new DataTable();
                string comprobacion = "select ID_NIVEL, descripcion from niveles where DESCRIPCION like '" + Convert.ToString(this.textBoxBdescripcion.Text).ToLower() + "%' order by id_nivel";

                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {
                    da.Fill(dtsNiv);
                    dvg.DataSource = dtsNiv;
                }
                else
                {
                    dataGridViewCargaNivel.DataSource = "";
                    MessageBox.Show("El nivel no existe", "aviso", MessageBoxButtons.OK);
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
                DataTable dtniveles = new DataTable();
                string comprobacion = "Select ID_NIVEL,descripcion from niveles where ID_NIVEL='" + this.textBoxIdNivel.Text + "'";
                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {

                    da.Fill(dtniveles);
                    dvg.DataSource = dtniveles;
                }
                else
                {
                    dataGridViewCargaNivel.DataSource = "";
                    MessageBox.Show("El nivel no existe", "aviso", MessageBoxButtons.OK);
                }
            }


            catch (Oracle.DataAccess.Client.OracleException)
            {
                dataGridViewCargaNivel.DataSource = "";
                MessageBox.Show("Formato invalido", "Aviso", MessageBoxButtons.OK);
            }
        }
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.cargarNivel(this.dataGridViewCargaNivel);
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
            this.textBoxIdNivel.Clear();
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
            this.CargarNivelDescripcion(this.dataGridViewCargaNivel);
        }
      
    }
    
}
