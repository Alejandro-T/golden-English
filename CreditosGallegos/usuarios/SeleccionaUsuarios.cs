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

namespace GoldenE.usuarios
{
    public partial class SeleccionaUsuarios : Form
    {
        public SeleccionaUsuarios()
        {
            InitializeComponent();
        }

        private void btncbuscar_Click(object sender, EventArgs e)
        {
            this.cargarUser(this.dataGridViewCargaUsuarios);
        }

        private void SeleccionaUsuarios_Load(object sender, EventArgs e)
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
        public void cargarUser(DataGridView dvg)
        {
            try
            {
                DataTable dtuser = new DataTable();
                string comprobacion = "Select U.ID_usuario,U.NOMBRE,U.PATERNO,U.MATERNO,G.DESCRIPCION AS SEXO ,U.TELEFONO,U.DIRECCION,U.FECHA_NACIMIENTO,U.sexo_id_sexo from usuarios U JOIN sexo G ON U.sexo_id_sexo=G.ID_sexo  where U.ID_usuario='" + this.textBoxSidUsuario.Text + "'";
                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {

                    da.Fill(dtuser);
                    dvg.DataSource = dtuser;
                }
                else
                {
                    dataGridViewCargaUsuarios.DataSource = "";
                    MessageBox.Show("El Usuario no existe", "aviso", MessageBoxButtons.OK);
                }
            }


            catch (Oracle.DataAccess.Client.OracleException)
            {
                dataGridViewCargaUsuarios.DataSource = "";
                MessageBox.Show("Formato invalido", "Aviso", MessageBoxButtons.OK);
            }
        }
        private void dataGridViewCargaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridViewCargaUsuarios.Rows[e.RowIndex];
                    this.textBox1.Text = row.Cells["nombre"].Value.ToString();
                }
            }
            else
            {
                DataGridViewRow row = this.dataGridViewCargaUsuarios.Rows[e.RowIndex];
                this.textBoxSidUsuario.Text = row.Cells["id_usuario"].Value.ToString();
            }
        }
        public void CargarUserName(DataGridView dvg)
        {
            try
            {
                DataTable dtsAlu = new DataTable();
                string comprobacion = "select U.ID_USUARIO,U.NOMBRE,U.PATERNO,U.MATERNO,G.DESCRIPCION AS SEXO ,U.TELEFONO,U.DIRECCION,U.FECHA_NACIMIENTO,U.sexo_id_sexo from usuarios U JOIN sexo G ON U.sexo_id_sexo=G.ID_sexo where U.NOMBRE like '" + Convert.ToString(this.textBox1.Text).ToLower() + "%'and U.PATERNO like'" + Convert.ToString(this.textBoxPaterno.Text).ToLower() + "%' and U.MATERNO like'" + Convert.ToString(this.textBoxMaterno.Text).ToLower() + "%' order by U.id_usuario";

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
                    dataGridViewCargaUsuarios.DataSource = "";
                    MessageBox.Show("El usuario no existe", "aviso", MessageBoxButtons.OK);
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.CargarUserName(this.dataGridViewCargaUsuarios);
        }
    }
}
