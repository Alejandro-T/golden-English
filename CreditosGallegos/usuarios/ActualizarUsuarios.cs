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
    public partial class ActualizarUsuarios : Form
    {
        public ActualizarUsuarios()
        {
            InitializeComponent();
        }

        private void btncActu_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand act = new OracleCommand("ACTUALIZAUSUARIOS", Conexion.conectar());
                act.CommandType = System.Data.CommandType.StoredProcedure;
                string password = Helper.EncodePassword(string.Concat(textBoxSidUsuario.Text, this.textBoxAcontraseña.Text));

                act.Parameters.Add("id_usuario_in", OracleDbType.Int16).Value = textBoxSidUsuario.Text;
                act.Parameters.Add("usuario_id_genero", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxGeneros.SelectedValue);
                if(this.radioButtonGerente.Checked == true)
                {
                    act.Parameters.Add("usuario_id_tipo_usuario", OracleDbType.Int16).Value = 1;
                }
                if (this.radioButtonRecepcionista.Checked == true)
                {
                    act.Parameters.Add("usuario_id_tipo_usuario", OracleDbType.Int16).Value = 2;
                }
                if (this.radioButtonMaestro.Checked == true)
                {
                    act.Parameters.Add("usuario_id_tipo_usuario", OracleDbType.Int16).Value = 3;
                }

                act.Parameters.Add("nombrein", OracleDbType.Varchar2).Value = textBoxAnombre.Text;
                act.Parameters.Add("paternoin", OracleDbType.Varchar2).Value = textBoxApaterno.Text;
                act.Parameters.Add("maternoin", OracleDbType.Varchar2).Value = textBoxAmaterno.Text;

                act.Parameters.Add("usuario_fecha_na", OracleDbType.Varchar2).Value = dateTimePicker1.Text;
                act.Parameters.Add("usuario_telefono", OracleDbType.Varchar2).Value = textBoxAtelefono.Text;
                act.Parameters.Add("usuario_direccion", OracleDbType.Varchar2).Value = textBoxAdireccion.Text;
                act.Parameters.Add("usuario_contrasena", OracleDbType.Varchar2).Value = password;


                //
                string comprobacion2 =
                    "SELECT ID_USUARIO from usuarios where ID_USUARIO='" + textBoxSidUsuario.Text + "'";
                OracleCommand cp2 = new OracleCommand(comprobacion2, Conexion.conectar());
                OracleDataReader dr2 = cp2.ExecuteReader();
                if (dr2.Read())
                {
                    act.ExecuteNonQuery();
                    MessageBox.Show("Dato actualizado con exito", "exito", MessageBoxButtons.OK);
                    this.cargarUsuario(this.dataGridViewCargaUsuario);
                    this.Limpiar();
                }
                else
                {
                    MessageBox.Show("El usuario no existe", "aviso", MessageBoxButtons.OK);
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
        public void SeleccionacomboGenero()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string depto = "SELECT id_sexo,descripcion FROM sexo";
            OracleDataAdapter da = new OracleDataAdapter
                (depto, Ge.Conexion.conectar());
            OracleCommand cmd = new OracleCommand(depto, Ge.Conexion.conectar());

            OracleDataReader dr = cmd.ExecuteReader();
            da.Fill(ds);

            if (dr.Read())
            {
                comboBoxGeneros.DataSource = ds.Tables[0];
                comboBoxGeneros.DisplayMember = "descripcion";
                comboBoxGeneros.ValueMember = "id_sexo";
            }
            else
            {
                MessageBox.Show("no hay generos existentes");
            }
        }
        private void dataGridViewCargaAlumno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewCargaUsuario.Rows[e.RowIndex];;
                this.textBoxAnombre.Text = row.Cells["nombre"].Value.ToString();
                this.textBoxApaterno.Text = row.Cells["paterno"].Value.ToString();
                this.textBoxAmaterno.Text = row.Cells["materno"].Value.ToString();
                this.dateTimePicker1.Text = row.Cells["FECHA_NACIMIENTO"].Value.ToString();

                this.textBoxAtelefono.Text = row.Cells["telefono"].Value.ToString();
                this.textBoxAdireccion.Text = row.Cells["direccion"].Value.ToString();
                this.comboBoxGeneros.SelectedValue = row.Cells["SEXO_ID_SEXO"].Value.ToString();
                if(int.Parse(row.Cells["TIPO_USUARIO_ID_TIPO_USUARIO"].Value.ToString()) == 1)
                {
                    this.radioButtonGerente.Checked = true;
                }else if (int.Parse(row.Cells["TIPO_USUARIO_ID_TIPO_USUARIO"].Value.ToString()) == 2)
                {
                    this.radioButtonRecepcionista.Checked = true;
                }else if (int.Parse(row.Cells["TIPO_USUARIO_ID_TIPO_USUARIO"].Value.ToString()) == 3)
                {
                    this.radioButtonMaestro.Checked = true;
                }
                this.textBoxAcontraseña.Text = row.Cells["contrasena"].Value.ToString();
            }
        }
        public void CargarUsuarioName(DataGridView dvg)
        {
            try
            {
                DataTable dtsAlu = new DataTable();
                string comprobacion = "select U.ID_USUARIO,U.NOMBRE,U.PATERNO,U.MATERNO,G.DESCRIPCION AS SEXO ,U.TELEFONO,U.DIRECCION,U.FECHA_NACIMIENTO,U.sexo_id_sexo,U.tipo_usuario_id_tipo_usuario,U.contrasena from usuarios U JOIN sexo G ON U.sexo_id_sexo=G.ID_sexo where U.NOMBRE like '" + Convert.ToString(this.textBoxBnombre.Text).ToLower() + "%'and U.PATERNO like'" + Convert.ToString(this.textBoxBPaterno.Text).ToLower() + "%' and U.MATERNO like'" + Convert.ToString(this.textBoxBMaterno.Text).ToLower() + "%' order by U.id_usuario";

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
                    dataGridViewCargaUsuario.DataSource = "";
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
        public void cargarUsuario(DataGridView dvg)
        {
            try
            {
                DataTable dtalumnos = new DataTable();
                string comprobacion = "Select A.ID_USUARIO,A.NOMBRE,A.PATERNO,A.MATERNO,G.DESCRIPCION AS SEXO ,A.TELEFONO,A.DIRECCION,A.FECHA_NACIMIENTO,A.sexo_id_sexo,A.tipo_usuario_id_tipo_usuario,A.contrasena from usuarios A JOIN sexo G ON A.sexo_id_sexo=G.id_sexo  where A.ID_USUARIO='" + this.textBoxSidUsuario.Text + "'";
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
                    dataGridViewCargaUsuario.DataSource = "";
                    MessageBox.Show("El usuario no existe", "aviso", MessageBoxButtons.OK);
                }
            }


            catch (Oracle.DataAccess.Client.OracleException)
            {
                dataGridViewCargaUsuario.DataSource = "";
                MessageBox.Show("Formato invalido", "Aviso", MessageBoxButtons.OK);
            }
        }
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.cargarUsuario(this.dataGridViewCargaUsuario);
            SeleccionacomboGenero();
        }

        private void ActualizarUsuarios_Load(object sender, EventArgs e)
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
            this.textBoxSidUsuario.Clear();
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
            this.CargarUsuarioName(this.dataGridViewCargaUsuario);
        }

        private void textBoxBPaterno_TextChanged(object sender, EventArgs e)
        {
            this.CargarUsuarioName(this.dataGridViewCargaUsuario);
        }

        private void textBoxBMaterno_TextChanged(object sender, EventArgs e)
        {
            this.CargarUsuarioName(this.dataGridViewCargaUsuario);
        }
    }
    
}
