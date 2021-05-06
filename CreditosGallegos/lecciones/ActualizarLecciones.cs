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
    public partial class ActualizarLecciones : Form
    {
        public ActualizarLecciones()
        {
            InitializeComponent();
        }

        private void btncActu_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand act = new OracleCommand("ACTUALIZALECCIONES", Conexion.conectar());
                act.CommandType = System.Data.CommandType.StoredProcedure;

                act.Parameters.Add("id_leccion_in", OracleDbType.Int16).Value = Convert.ToInt16(textBoxSid.Text);

                act.Parameters.Add("leccion_id_nivel", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxNiveles.SelectedValue);
                act.Parameters.Add("leccion_descripcion", OracleDbType.Varchar2).Value = textBoxAdescripcion.Text;
                //
                string comprobacion2 =
                    "SELECT ID_LECCION from lecciones where ID_LECCION='" + textBoxSid.Text + "'";
                OracleCommand cp2 = new OracleCommand(comprobacion2, Conexion.conectar());
                OracleDataReader dr2 = cp2.ExecuteReader();
                if (dr2.Read())
                {
                    act.ExecuteNonQuery();
                    MessageBox.Show("Dato actualizado con exito", "exito", MessageBoxButtons.OK);
                    this.cargarLeccion(this.dataGridViewCargaLeccion);
                    this.Limpiar();
                }
                else
                {
                    MessageBox.Show("La lección no existe", "aviso", MessageBoxButtons.OK);
                }

                //aaaa
            }
            catch (OracleException ex)
            {
                ManejoErrores.erroresOracle(ex);
            }
            catch (System.FormatException exe)
            {
                ManejoErrores.erroresSystem(exe);
            }



        }

        public void SeleccionacomboNivles()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string depto = "SELECT id_nivel,descripcion FROM niveles";
            OracleDataAdapter da = new OracleDataAdapter
                (depto, Ge.Conexion.conectar());
            OracleCommand cmd = new OracleCommand(depto, Ge.Conexion.conectar());

            OracleDataReader dr = cmd.ExecuteReader();
            da.Fill(ds);

            if (dr.Read())
            {
                comboBoxNiveles.DataSource = ds.Tables[0];
                comboBoxNiveles.DisplayMember = "descripcion";
                comboBoxNiveles.ValueMember = "id_nivel";
            }
            else
            {
                MessageBox.Show("no hay niveles existentes");
            }
        }

        private void dataGridViewCargaAlumno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewCargaLeccion.Rows[e.RowIndex];
                this.textBoxSid.Text = row.Cells["ID_LECCION"].Value.ToString();
                this.textBoxAdescripcion.Text = row.Cells["descripcion"].Value.ToString();
                this.comboBoxNiveles.SelectedValue = row.Cells["NIVELES_ID_NIVEL"].Value.ToString();
            }
        }

        public void CargarLeccionDescripcion(DataGridView dvg)
        {
            try
            {
                DataTable dtsLec = new DataTable();
                string comprobacion = "select L.ID_LECCION, N.Descripcion as Nivel, L.NIVELES_ID_NIVEL, L.descripcion from lecciones L JOIN niveles N ON N.id_nivel = L.niveles_id_nivel where L.DESCRIPCION like '" + Convert.ToString(this.textBoxBdescripcion.Text).ToLower() + "%' order by L.id_leccion";

                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {
                    da.Fill(dtsLec);
                    dvg.DataSource = dtsLec;
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
                DataTable dtlecciones = new DataTable();
                string comprobacion = "select L.ID_LECCION, N.Descripcion as Nivel, L.NIVELES_ID_NIVEL, L.descripcion from lecciones L JOIN niveles N ON N.id_nivel = L.niveles_id_nivel where L.ID_LECCION='" + this.textBoxIdLeccion.Text + "'";
                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {

                    da.Fill(dtlecciones);
                    dvg.DataSource = dtlecciones;
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
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.cargarLeccion(this.dataGridViewCargaLeccion);
            SeleccionacomboNivles();
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
            this.textBoxIdLeccion.Clear();
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
            this.CargarLeccionDescripcion(this.dataGridViewCargaLeccion);
        }
      
    }
    
}
