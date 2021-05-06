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

namespace GoldenE.lecciones
{
    public partial class InsertarLecciones : Form
    {
        public InsertarLecciones()
        {
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //correcciones

                OracleCommand comandoinse = new OracleCommand("insertar_leccion", Conexion.conectar());
                comandoinse.CommandType = CommandType.StoredProcedure;

                comandoinse.Parameters.Add("@id_leccion", OracleDbType.Int16).Value =  Convert.ToInt16(this.textBoxLeccionId.Text);
                comandoinse.Parameters.Add("@NIVELES_ID_NIVEL", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxNiveles.SelectedValue);
                comandoinse.Parameters.Add("@descripcion", OracleDbType.Varchar2).Value = this.textBoxNombreLeccion.Text;


                comandoinse.ExecuteNonQuery();               
                MessageBox.Show("Leccion Insertada ", "aviso", MessageBoxButtons.OK);
                //Select para saber el numero actual.

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

        private void InsertarLecciones_Load(object sender, EventArgs e)
        {
            SeleccionacomboNivles();
        }
    }
}
