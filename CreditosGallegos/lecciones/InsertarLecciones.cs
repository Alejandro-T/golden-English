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

                comandoinse.Parameters.Add("@NIVELES_ID_NIVEL", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxNiveles.SelectedValue);
                comandoinse.Parameters.Add("@descripcion", OracleDbType.Varchar2).Value = this.textBoxNombreLeccion.Text;

                string comp = " select id_leccion from lecciones where descripcion =lower('" + this.textBoxNombreLeccion.Text + "')and  NIVELES_ID_NIVEL ='"+ Convert.ToInt16(comboBoxNiveles.SelectedValue) + "'";
                OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
                OracleDataReader dre = cpe.ExecuteReader();
                if (dre.Read())
                {
                    MessageBox.Show("Existe una leccion con el mismo nombre ", "aviso", MessageBoxButtons.OK);
                }
                else
                {   
                    comandoinse.ExecuteNonQuery();
                    MessageBox.Show("Leccion Insertada ", "aviso", MessageBoxButtons.OK);
                    //Select para saber el numero actual.
                    limpiar();
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

        private void InsertarLecciones_Load(object sender, EventArgs e)
        {
            SeleccionacomboNivles();
            actualizarIdLeccion();
        }

        public void limpiar()
        {
            this.textBoxNombreLeccion.Clear();
            actualizarIdLeccion();
        }

        public void actualizarIdLeccion()
        {
            string comp = "select * from(select id_leccion from lecciones order by id_leccion desc) where rownum =1";
            OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
            publicas.id_leccion = Convert.ToInt32(cpe.ExecuteScalar());
            publicas.id_leccion += 1;
            textBoxLeccionId.Text = publicas.id_leccion.ToString();
        }
    }
}
