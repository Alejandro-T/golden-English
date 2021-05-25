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
               
                comandoinse.Parameters.Add("@descripcion", OracleDbType.Varchar2).Value = this.textBoxNombreSalon.Text;
                
                string comp = " select id_salon from salones where descripcion =lower('" + this.textBoxNombreSalon.Text + "')";
                OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
                OracleDataReader dre = cpe.ExecuteReader();
                if (dre.Read())
                {
                    MessageBox.Show("Existe un salon con el mismo nombre ", "aviso", MessageBoxButtons.OK);
                }
                else
                {
                    comandoinse.ExecuteNonQuery();
                    MessageBox.Show("Salon insertado ", "aviso", MessageBoxButtons.OK);
                    limpiar();
                }
                    
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
            actualizarIdSalon();
        }

        public void actualizarIdSalon()
        {
            string comp = "select * from(select id_salon from salones order by id_salon desc) where rownum =1";
            OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
            publicas.id_salon = Convert.ToInt32(cpe.ExecuteScalar());
            publicas.id_salon += 1;
            textBoxSalonId.Text = publicas.id_salon.ToString();
        }

        private void InsertarSalones_Load(object sender, EventArgs e)
        {
            actualizarIdSalon();
        }
    }
}
