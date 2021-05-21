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

namespace GoldenE.maestros
{
    public partial class Calificaciones : Form
    {
        public Calificaciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //correcciones
            try
            {
                OracleCommand comandoinse = new OracleCommand("insertar_calificacion", Ge.Conexion.conectar());
                comandoinse.CommandType = CommandType.StoredProcedure;

                string rfcA = " select RFC_ALUMNO from alumnos where id_alumno ='" + this.textBoxKardexAlumno.Text + "'";
                OracleCommand cpe = new OracleCommand(rfcA, Conexion.conectar());
                OracleDataReader dre = cpe.ExecuteReader();
                string rfcU = " select RFC from usuarios where id_usuario ='" + Convert.ToInt16(publicas.id_t_user.ToString()) + "'";
                OracleCommand cpe2 = new OracleCommand(rfcU, Conexion.conectar());
                OracleDataReader dre2 = cpe2.ExecuteReader();
                if (dre.Read() && dre2.Read())
                {
                    string ra = "";
                    string ru = "";
                    ra = Convert.ToString(cpe.ExecuteScalar());
                    ru = Convert.ToString(cpe2.ExecuteScalar());
                    comandoinse.Parameters.Add("@RFC_ALUMNO_CALIF", OracleDbType.Varchar2).Value = ra;
                    comandoinse.Parameters.Add("@RFC_MAES_CALIF", OracleDbType.Varchar2).Value = ru;

                    comandoinse.Parameters.Add("@TIPO_CLASE_ID_CLASE", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxTipoDeLeccion.SelectedValue);
                    comandoinse.Parameters.Add("@LECCIONES_ID_LECCION", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxlecc.SelectedValue);
                    comandoinse.Parameters.Add("@ALUMNOS_ID_ALUMNO", OracleDbType.Int16).Value = textBoxKardexAlumno.Text;
                    comandoinse.Parameters.Add("@USUARIOS_ID_MAESTRO", OracleDbType.Int16).Value = Convert.ToInt16(publicas.id_t_user.ToString());
                    comandoinse.Parameters.Add("@CALIFICACION", OracleDbType.Int16).Value = Convert.ToInt16(textBoxCali.Text);

                    comandoinse.Parameters.Add("@FECHACALIF", OracleDbType.Varchar2).Value = this.dateTimePicker1.Text;
                 
                    comandoinse.ExecuteNonQuery();
                    MessageBox.Show("Calificacion Insertada ", "aviso", MessageBoxButtons.OK);
                    
                }
                else
                {
                    MessageBox.Show("Calificacion Insertada ", "aviso", MessageBoxButtons.OK);
                    
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

        private void textBoxKardexAlumno_Leave(object sender, EventArgs e)
        {
            try
            {
                string nocA = " select nombre from alumnos where id_alumno ='" + this.textBoxKardexAlumno.Text + "'";
                OracleCommand cpe = new OracleCommand(nocA, Conexion.conectar());
                OracleDataReader dre = cpe.ExecuteReader();
                string pacU = " select paterno from alumnos where id_alumno ='" + this.textBoxKardexAlumno.Text + "'";
                OracleCommand cpe2 = new OracleCommand(pacU, Conexion.conectar());
                OracleDataReader dre2 = cpe2.ExecuteReader();
                string macU = " select materno from alumnos where id_alumno ='" + this.textBoxKardexAlumno.Text + "'";
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
                    MessageBox.Show("Alumno no encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        
        private void Calificaciones_Load(object sender, EventArgs e)
        {
           
            CargaComboBox.SeleccionacomboTipoLeccion(comboBoxTipoDeLeccion);
           
            CargaComboBox.SeleccionacomboNivel(comboBoxNivel);
           
        }
        public void SeleccionacomboLecciones()
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string idnivel = "";
            idnivel = (comboBoxNivel.SelectedValue.ToString());
            string depto = "SELECT id_leccion,descripcion FROM lecciones where NIVELES_ID_NIVEL = '" + idnivel + "'";
            //MessageBox.Show(""+idnivel,"");
            OracleDataAdapter da = new OracleDataAdapter
                (depto, Ge.Conexion.conectar());
            OracleCommand cmd = new OracleCommand(depto, Ge.Conexion.conectar());

            OracleDataReader dr = cmd.ExecuteReader();
            da.Fill(ds);

            if (dr.Read())
            {
                comboBoxlecc.DataSource = ds.Tables[0];
                comboBoxlecc.DisplayMember = "descripcion";
                comboBoxlecc.ValueMember = "id_leccion";
            }
            else
            {
                MessageBox.Show("no hay lecciones existentes");
            }
        }

        int cont = 0;
        private void comboBoxNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cont > 1)
            {
                //string idnivel = "";
                //idnivel = (comboBoxNivel.SelectedValue.ToString());
                //MessageBox.Show("" + idnivel, "");
                SeleccionacomboLecciones();
            }
            else { cont++; }
            //SeleccionacomboLecciones();
        }
    }
}
