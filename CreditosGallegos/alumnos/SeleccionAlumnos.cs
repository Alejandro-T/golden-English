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
    public partial class SeleccionAlumnos : Form
    {
        public SeleccionAlumnos()
        {
            InitializeComponent();
        }
        public void CargarAlumnoName(DataGridView dvg)
        {
            try
            {
                DataTable dtsAlu = new DataTable();
                string comprobacion = "select A.ID_ALUMNO,A.NOMBRE,A.PATERNO,A.MATERNO,G.DESCRIPCION AS SEXO ,A.TELEFONO,A.DIRECCION,A.FECHA_NACIMIENTO,A.sexo_id_sexo from alumnos A JOIN sexo G ON A.sexo_id_sexo=G.ID_sexo where A.NOMBRE like '" + Convert.ToString(this.textBox1.Text).ToLower() + "%'and A.PATERNO like'" + Convert.ToString(this.textBoxPaterno.Text).ToLower() + "%' and A.MATERNO like'" + Convert.ToString(this.textBoxMaterno.Text).ToLower() + "%' order by A.id_alumno";

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
        private void btncbuscar_Click(object sender, EventArgs e)
        {
            this.cargarAlumno(this.dataGridViewCargaAlumno);
        }
        private void DataGridViewCargaAlumno_CellContentClick_1(object sender, DataGridViewCellEventArgs d)
        {
            if (checkBox2.Checked == true)
            {
                if (d.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridViewCargaAlumno.Rows[d.RowIndex];
                    this.textBox1.Text = row.Cells["nombre"].Value.ToString();
                }
            }
            else
            {
                DataGridViewRow row = this.dataGridViewCargaAlumno.Rows[d.RowIndex];
                this.textBoxSidAlumno.Text = row.Cells["id_alumno"].Value.ToString();
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

        private void SeleccionAlumnos_Load(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.CargarAlumnoName(this.dataGridViewCargaAlumno);
        }

        private void textBoxPaterno_TextChanged(object sender, EventArgs e)
        {
            this.CargarAlumnoName(this.dataGridViewCargaAlumno);
        }

        private void textBoxMaterno_TextChanged(object sender, EventArgs e)
        {
            this.CargarAlumnoName(this.dataGridViewCargaAlumno);
        }
    }
}
