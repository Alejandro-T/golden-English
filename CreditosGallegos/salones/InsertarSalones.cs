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

namespace GoldenE.salones
{
    public partial class InsertarSalones : Form
    {
        public InsertarSalones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand comandoinse = new OracleCommand("insertar_salon", Conexion.conectar());
                comandoinse.CommandType = CommandType.StoredProcedure;
                comandoinse.Parameters.Add("@id_salon", OracleDbType.Int16).Value = Convert.ToInt16(this.textBoxSalon.Text);
                comandoinse.Parameters.Add("@descripcion", OracleDbType.Varchar2).Value = this.textBoxNombreSalon.Text;

                comandoinse.ExecuteNonQuery();
                MessageBox.Show("Salon insertado ", "aviso", MessageBoxButtons.OK);
                limpiar();
            }
            catch (OracleException ex)
            {
                ManejoErrores.erroresOracle(ex);
            }
            catch(System.FormatException exe)
            {
                ManejoErrores.erroresSystem(exe);
            }
        }
        public void limpiar()
        {
            this.textBoxNombreSalon.Clear();
            this.textBoxSalon.Clear();
        }
    }
}
