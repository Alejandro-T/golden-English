using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ge;
using Oracle.DataAccess.Client;
namespace GoldenE.alumnos
{
    public partial class InsertaAlumno : Form
    {
        public InsertaAlumno()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                comboBoxGenero.DataSource = ds.Tables[0];
                comboBoxGenero.DisplayMember = "descripcion";
                comboBoxGenero.ValueMember = "id_sexo";
            }
            else
            {
                MessageBox.Show("no hay generos existentes");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               //correccion
               

                OracleCommand comandoinse = new OracleCommand("insertar_alumno", Conexion.conectar());
                comandoinse.CommandType = CommandType.StoredProcedure;

                comandoinse.Parameters.Add("@RFC_ALUMNO", OracleDbType.Varchar2).Value = this.textBoxRfc.Text;
                comandoinse.Parameters.Add("@SEXO_ID_SEXO", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxGenero.SelectedValue);
                comandoinse.Parameters.Add("@nombre", OracleDbType.Varchar2).Value = this.textBoxName.Text;
                comandoinse.Parameters.Add("@paterno", OracleDbType.Varchar2).Value = this.textBoxPaterno.Text;
                comandoinse.Parameters.Add("@materno", OracleDbType.Varchar2).Value = this.textBoxMaterno.Text;
                comandoinse.Parameters.Add("@FECHA_NACIMIENTO", OracleDbType.Varchar2).Value = this.dateTimePicker1.Text;
                comandoinse.Parameters.Add("@direccion", OracleDbType.Varchar2).Value = this.textBoxDireccion.Text;
                comandoinse.Parameters.Add("@telefono", OracleDbType.Varchar2).Value = this.textBoxTelefono.Text;
               

                comandoinse.ExecuteNonQuery();
                this.actualizarKardex();
                MessageBox.Show("Alumno Insertado ", "aviso", MessageBoxButtons.OK);
                //Select para saber el numero actual.

                Limpiar();
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
        }
        public void Limpiar()
        {
            this.textBoxName.Clear();
            this.textBoxMaterno.Clear();
            this.textBoxPaterno.Clear();
            this.textBoxDireccion.Clear();
            this.textBoxTelefono.Clear();

        }
        private void InsertaAlumno_Load(object sender, EventArgs e)
        {
            SeleccionacomboGenero();
            this.actualizarKardex();
        }
        public void actualizarKardex()
        {
            string comp = "select * from(select id_alumno from alumnos order by id_alumno desc) where rownum =1";
            OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
            publicas.id_alumno = Convert.ToInt32(cpe.ExecuteScalar());
            publicas.id_alumno += 1;
            textBoxKardex.Text = publicas.id_alumno.ToString();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
