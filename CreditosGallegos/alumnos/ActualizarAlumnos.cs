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
    public partial class ActualizarAlumnos : Form
    {
        public ActualizarAlumnos()
        {
            InitializeComponent();
        }

        private void btncActu_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand act = new OracleCommand("ACTUALIZALUMNOS", Conexion.conectar());
                act.CommandType = System.Data.CommandType.StoredProcedure;

                act.Parameters.Add("id_alumno_in", OracleDbType.Int16).Value = textBoxSidAlumno.Text;
                act.Parameters.Add("alumno_id_genero", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxGeneros.SelectedValue);
                

                act.Parameters.Add("nombrein", OracleDbType.Varchar2).Value = textBoxAnombre.Text;
                act.Parameters.Add("paternoin", OracleDbType.Varchar2).Value = textBoxApaterno.Text;
                act.Parameters.Add("maternoin", OracleDbType.Varchar2).Value = textBoxAmaterno.Text;

                act.Parameters.Add("alumno_fecha_na", OracleDbType.Varchar2).Value = dateTimePicker1.Text;
                act.Parameters.Add("alumno_telefono", OracleDbType.Varchar2).Value = textBoxAtelefono.Text;
                act.Parameters.Add("alumno_direccion", OracleDbType.Varchar2).Value = textBoxAdireccion.Text;


                //
                string comprobacion2 =
                    "SELECT ID_ALUMNO from alumnos where ID_ALUMNO='" + textBoxSidAlumno.Text + "'";
                OracleCommand cp2 = new OracleCommand(comprobacion2, Conexion.conectar());
                OracleDataReader dr2 = cp2.ExecuteReader();
                if (dr2.Read())
                {
                    act.ExecuteNonQuery();
                    MessageBox.Show("Dato actualizado con exito", "exito", MessageBoxButtons.OK);
                    this.cargarAlumno(this.dataGridViewCargaAlumno);
                    this.Limpiar();
                }
                else
                {
                    MessageBox.Show("El Alumno no existe", "aviso", MessageBoxButtons.OK);
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
        private void dataGridViewCargaAlumno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewCargaAlumno.Rows[e.RowIndex];
                this.textBoxAnombre.Text = row.Cells["nombre"].Value.ToString();
                this.textBoxApaterno.Text = row.Cells["paterno"].Value.ToString();
                this.textBoxAmaterno.Text = row.Cells["materno"].Value.ToString();
                this.dateTimePicker1.Text = row.Cells["FECHA_NACIMIENTO"].Value.ToString();

                this.textBoxAtelefono.Text = row.Cells["telefono"].Value.ToString();
                this.textBoxAdireccion.Text = row.Cells["direccion"].Value.ToString();
                this.comboBoxGeneros.SelectedValue = row.Cells["SEXO_ID_SEXO"].Value.ToString();
            }
        }
        public void CargarAlumnoName(DataGridView dvg)
        {
            try
            {
                DataTable dtsAlu = new DataTable();
                string comprobacion = "select A.ID_ALUMNO,A.NOMBRE,A.PATERNO,A.MATERNO,G.DESCRIPCION AS SEXO ,A.TELEFONO,A.DIRECCION,A.FECHA_NACIMIENTO,A.sexo_id_sexo from alumnos A JOIN sexo G ON A.sexo_id_sexo=G.ID_sexo where A.NOMBRE like '" + Convert.ToString(this.textBoxBnombre.Text).ToLower() + "%'and A.PATERNO like'" + Convert.ToString(this.textBoxBPaterno.Text).ToLower() + "%' and A.MATERNO like'" + Convert.ToString(this.textBoxBMaterno.Text).ToLower() + "%' order by A.id_alumno";

                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {
                    da.Fill(dtsAlu);
                    dvg.DataSource = dtsAlu;
                }
                else
                {
                    dataGridViewCargaAlumno.DataSource = "";
                    MessageBox.Show("El alumno no existe", "aviso", MessageBoxButtons.OK);
                }
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
        public void cargarAlumno(DataGridView dvg)
        {
            try
            {
                DataTable dtalumnos = new DataTable();
                string comprobacion = "Select A.ID_ALUMNO,A.NOMBRE,A.PATERNO,A.MATERNO,G.DESCRIPCION AS SEXO ,A.TELEFONO,A.DIRECCION,A.FECHA_NACIMIENTO,A.sexo_id_sexo from alumnos A JOIN sexo G ON A.sexo_id_sexo=G.ID_sexo  where A.ID_ALUMNO='" + this.textBoxSidAlumno.Text + "'";
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
                    dataGridViewCargaAlumno.DataSource = "";
                    MessageBox.Show("El Alumno no existe", "aviso", MessageBoxButtons.OK);
                }
            }


            catch (Oracle.DataAccess.Client.OracleException)
            {
                dataGridViewCargaAlumno.DataSource = "";
                MessageBox.Show("Formato invalido", "Aviso", MessageBoxButtons.OK);
            }
        }
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.cargarAlumno(this.dataGridViewCargaAlumno);
            CargaComboBox.comboGenero(comboBoxGeneros);
        }

        private void ActualizarAlumnos_Load(object sender, EventArgs e)
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
            this.textBoxSidAlumno.Clear();
            this.textBoxAnombre.Clear();
            this.textBoxApaterno.Clear();
            this.textBoxAmaterno.Clear();
            this.textBoxAtelefono.Clear();
            this.textBoxAdireccion.Clear();

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

        private void textBoxBnombre_TextChanged(object sender, EventArgs e)
        {
            this.CargarAlumnoName(this.dataGridViewCargaAlumno);
        }

        private void textBoxBPaterno_TextChanged(object sender, EventArgs e)
        {
            this.CargarAlumnoName(this.dataGridViewCargaAlumno);
        }

        private void textBoxBMaterno_TextChanged(object sender, EventArgs e)
        {
            this.CargarAlumnoName(this.dataGridViewCargaAlumno);
        }
    }
    
}
