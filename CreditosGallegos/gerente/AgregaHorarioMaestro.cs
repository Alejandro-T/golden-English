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

namespace GoldenE.gerente
{
    public partial class AgregaHorarioMaestro : Form
    {
        public AgregaHorarioMaestro()
        {
            InitializeComponent();
        }

        private void textBoxKardexMaestro_Leave(object sender, EventArgs e)
        {
            try
            {
                string nocA = " select nombre from usuarios where ID_USUARIO ='" + this.textBoxKardexMaestro.Text + "' and TIPO_USUARIO_ID_TIPO_USUARIO = '"+3+"'";
                OracleCommand cpe = new OracleCommand(nocA, Conexion.conectar());
                OracleDataReader dre = cpe.ExecuteReader();
                string pacU = " select paterno from  usuarios where ID_USUARIO  ='" + this.textBoxKardexMaestro.Text + "' and TIPO_USUARIO_ID_TIPO_USUARIO = '" + 3 + "'";
                OracleCommand cpe2 = new OracleCommand(pacU, Conexion.conectar());
                OracleDataReader dre2 = cpe2.ExecuteReader();
                string macU = " select materno from usuarios ID_USUARIO  ='" + this.textBoxKardexMaestro.Text + "' and TIPO_USUARIO_ID_TIPO_USUARIO = '" + 3 + "'";
                OracleCommand cpe3 = new OracleCommand(pacU, Conexion.conectar());
                OracleDataReader dre3 = cpe3.ExecuteReader();
                if (dre.Read() && dre2.Read() && dre3.Read())
                {
                    string rn = "";
                    string rm = "";
                    string rp = "";
                    rn = Convert.ToString(cpe.ExecuteScalar());
                    rp = Convert.ToString(cpe2.ExecuteScalar());
                    rm = Convert.ToString(cpe3.ExecuteScalar());
                    textBoxNombre.Text = rn;
                    textBoxPaterno.Text = rp;
                    textBoxMaterno.Text = rm;
                }
                else
                {
                    MessageBox.Show("Maestro no encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxNombre.Clear();
                    textBoxPaterno.Clear();
                    textBoxMaterno.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand comandoinse = new OracleCommand("insertar_horariom", Ge.Conexion.conectar());
            comandoinse.CommandType = CommandType.StoredProcedure;
            string rfcU = " select RFC from usuarios where ID_USUARIO ='" + this.textBoxKardexMaestro.Text + "' and TIPO_USUARIO_ID_TIPO_USUARIO = '" + 3 + "'";
            try
            {
                OracleCommand cpe2 = new OracleCommand(rfcU, Conexion.conectar());
                OracleDataReader dre2 = cpe2.ExecuteReader();
                if (dre2.Read())
                {

                    string ru = "";
                    comandoinse.Parameters.Add("@FECHA", OracleDbType.Varchar2).Value = this.dateTimePicker1.Text;
                    // if (publicas.hora.ToString() == "null")
                    // {
                    //     MessageBox.Show("Agrega una hora", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // }
                    // else
                    // {
                    // comandoinse.Parameters.Add("@hora", OracleDbType.Varchar2).Value = publicas.hora.ToString();
                    if ((Convert.ToInt32(textBox1.Text) >= 7 && Convert.ToInt32(textBox1.Text) <= 21) && (Convert.ToInt32(textBox2.Text) >= 7 && Convert.ToInt32(textBox2.Text) <= 21))
                    {
                        comandoinse.Parameters.Add("@HORAINICIO", OracleDbType.Int32).Value = Convert.ToInt32(textBox1.Text);
                        comandoinse.Parameters.Add("@HORAFIN", OracleDbType.Int32).Value = Convert.ToInt32(textBox2.Text);
                        ru = Convert.ToString(cpe2.ExecuteScalar());
                        comandoinse.Parameters.Add("@USUARIOSF_RFC", OracleDbType.Varchar2).Value = ru;
                        comandoinse.Parameters.Add("@USUARIOSF_ID_USUARIO", OracleDbType.Int32).Value = Convert.ToInt32(textBoxKardexMaestro.Text);
                        comandoinse.ExecuteNonQuery();
                        MessageBox.Show("Horario Insertado ", "aviso", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Hora no Valida ", "aviso", MessageBoxButtons.OK);

                    }

                    //}
                }
                else
                {
                    MessageBox.Show("Horario no insertado ", "aviso", MessageBoxButtons.OK);

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

            private void AgregaHorarioMaestro_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Today.ToString("d/M/yyyy");
        }
        // publicas.hora = listBox1.SelectedItem.ToString();



    }
}
