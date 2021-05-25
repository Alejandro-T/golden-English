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

namespace GoldenE.Catalogo_Horario
{
    public partial class InsertarCatalogo : Form
    {
        public InsertarCatalogo()
        {
            InitializeComponent();
        }
        public void limpiar()
        {
            this.textBoxNombrecatalogo.Clear();
            actualizarIdCatalogo();
        }

        public void actualizarIdCatalogo()
        {
            string comp = "select * from(select id_clase from tipo_clase order by id_clase desc) where rownum =1";
            OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
            publicas.id_catalogo = Convert.ToInt32(cpe.ExecuteScalar());
            publicas.id_catalogo += 1;
            textBoxIdCatalogo.Text = publicas.id_catalogo.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand comandoinse = new OracleCommand("insertar_catalogo", Conexion.conectar());
                comandoinse.CommandType = CommandType.StoredProcedure;

                comandoinse.Parameters.Add("@descripcion", OracleDbType.Varchar2).Value = this.textBoxNombrecatalogo.Text;

                string comp = " select id_clase from tipo_clase where descripcion =lower('" + this.textBoxNombrecatalogo.Text + "')";
                OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
                OracleDataReader dre = cpe.ExecuteReader();
                if (dre.Read())
                {
                    MessageBox.Show("Existe un tipo de clase con el mismo nombre ", "aviso", MessageBoxButtons.OK);
                }
                else
                {
                    comandoinse.ExecuteNonQuery();
                    MessageBox.Show("Clase insertada ", "aviso", MessageBoxButtons.OK);
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

        private void InsertarCatalogo_Load(object sender, EventArgs e)
        {
            actualizarIdCatalogo();
        }
    }
}
