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

namespace GoldenE.niveles
{
    public partial class InsertarNivel : Form
    {
        public InsertarNivel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                

                OracleCommand comandoinse = new OracleCommand("insertar_nivel", Conexion.conectar());
                comandoinse.CommandType = CommandType.StoredProcedure;
                comandoinse.Parameters.Add("@descripcion", OracleDbType.Varchar2).Value = this.textBoxNombreNivel.Text;
                string comp = " select id_nivel from niveles where descripcion =lower('" + this.textBoxNombreNivel.Text + "')";
                OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
                OracleDataReader dre = cpe.ExecuteReader();
                if (dre.Read())
                {
                    MessageBox.Show("Existe un nivel con el mismo nombre ", "aviso", MessageBoxButtons.OK);
                }
                else
                {
                    comandoinse.ExecuteNonQuery();
                    MessageBox.Show("nivel insertado ", "aviso", MessageBoxButtons.OK);
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

        private void InsertarNivel_Load(object sender, EventArgs e)
        {
            this.actualizarNivel();
        }

        public void limpiar()
        {
            this.textBoxNombreNivel.Clear();
            actualizarNivel();
        }

        public void actualizarNivel()
        {
            string comp = "select * from(select id_nivel from niveles order by id_nivel desc) where rownum =1";
            OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
            publicas.id_nivel = Convert.ToInt32(cpe.ExecuteScalar());
            publicas.id_nivel += 1;
            textBoxNivel.Text = publicas.id_nivel.ToString();
        }
    }
}
