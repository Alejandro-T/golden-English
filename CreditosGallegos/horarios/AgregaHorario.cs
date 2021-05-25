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

namespace GoldenE.horarios
{
    public partial class AgregaHorario : Form
    {
        public AgregaHorario()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void limpiar()
        {
            textBoxKardexAlumno.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //correcciones
            try
            {
                OracleCommand comandoinse = new OracleCommand("insertar_horario", Ge.Conexion.conectar());
                comandoinse.CommandType = CommandType.StoredProcedure;

                string rfcA = " select RFC_ALUMNO from alumnos where id_alumno ='" + this.textBoxKardexAlumno.Text + "'";
                OracleCommand cpe = new OracleCommand(rfcA, Conexion.conectar());
                OracleDataReader dre = cpe.ExecuteReader();
                string rfcU = " select RFC from usuarios where id_usuario ='" + Convert.ToInt16(comboBoxMaestros.SelectedValue) + "'";
                OracleCommand cpe2 = new OracleCommand(rfcU, Conexion.conectar());
                OracleDataReader dre2 = cpe2.ExecuteReader();
                if (dre.Read() && dre2.Read())
                {
                    string ra = "";
                    string ru = "";
                    ra = Convert.ToString(cpe.ExecuteScalar());
                    ru = Convert.ToString(cpe2.ExecuteScalar());
                    comandoinse.Parameters.Add("@TIPO_CLASE_ID_CLASE", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxTipoDeLeccion.SelectedValue);
                    comandoinse.Parameters.Add("@LECCIONES_ID_LECCION", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxlecc.SelectedValue);
                    comandoinse.Parameters.Add("@USUARIOS_ID_MAESTRO", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxMaestros.SelectedValue);
                    comandoinse.Parameters.Add("@ALUMNOS_ID_ALUMNO", OracleDbType.Int16).Value = textBoxKardexAlumno.Text;
                    comandoinse.Parameters.Add("@SALONES_ID_SALON", OracleDbType.Int16).Value = Convert.ToInt16(comboBoxSalon.SelectedValue);
                    comandoinse.Parameters.Add("@RFC_ALUMNO_HORARIO", OracleDbType.Varchar2).Value = ra;
                    comandoinse.Parameters.Add("@RFC_MAES_HORARIO", OracleDbType.Varchar2).Value = ru;
                    comandoinse.Parameters.Add("@FECHA", OracleDbType.Varchar2).Value = this.dateTimePicker1.Text;

                    if (publicas.hora.ToString() == "null")
                    {
                        MessageBox.Show("Agrega una hora", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else { 
                        comandoinse.Parameters.Add("@hora", OracleDbType.Varchar2).Value = publicas.hora.ToString();
                        comandoinse.ExecuteNonQuery();
                        MessageBox.Show("Horario Insertado ", "aviso", MessageBoxButtons.OK);
                        limpiar();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Horario NO Insertado ", "aviso", MessageBoxButtons.OK);
                    limpiar();
                }

            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Agrega una hora", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            publicas.hora = listBox1.SelectedItem.ToString();
            //MessageBox.Show("" + hora, "");
        }
        
        public void SeleccionacomboSalones()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string depto = "SELECT id_salon,descripcion FROM salones";
            OracleDataAdapter da = new OracleDataAdapter
                (depto, Ge.Conexion.conectar());
            OracleCommand cmd = new OracleCommand(depto, Ge.Conexion.conectar());

            OracleDataReader dr = cmd.ExecuteReader();
            da.Fill(ds);

            if (dr.Read())
            {
                comboBoxSalon.DataSource = ds.Tables[0];
                comboBoxSalon.DisplayMember = "descripcion";
                comboBoxSalon.ValueMember = "id_salon";
            }
            else
            {
                MessageBox.Show("no hay salones existentes");
            }
        }


        
        public void SeleccionacomboLecciones()
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string idnivel = "";
            idnivel = (comboBoxNivel.SelectedValue.ToString());
            string depto = "SELECT id_leccion,descripcion FROM lecciones where NIVELES_ID_NIVEL = '" + idnivel+ "'";
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

        public void SeleccionacomboMaestros()
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            
            string depto = "SELECT id_usuario,nombre FROM usuarios where TIPO_USUARIO_ID_TIPO_USUARIO = '" + 3 + "'";
           
            OracleDataAdapter da = new OracleDataAdapter
                (depto, Ge.Conexion.conectar());
            OracleCommand cmd = new OracleCommand(depto, Ge.Conexion.conectar());

            OracleDataReader dr = cmd.ExecuteReader();
            da.Fill(ds);

            if (dr.Read())
            {
                comboBoxMaestros.DataSource = ds.Tables[0];
                comboBoxMaestros.DisplayMember = "nombre";
                comboBoxMaestros.ValueMember = "ID_USUARIO";
            }
            else
            {
                MessageBox.Show("no hay maestros existentes");
            }
        }

        private void AgregaHorario_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Today.ToString("d/M/yyyy");
            CargaComboBox.SeleccionacomboTipoLeccion(comboBoxTipoDeLeccion);
            SeleccionacomboSalones();
            CargaComboBox.SeleccionacomboNivel(comboBoxNivel);
            SeleccionacomboMaestros();
        }
        int cont = 0;
        private void comboBoxNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            if(cont>1)
            {
                //string idnivel = "";
                //idnivel = (comboBoxNivel.SelectedValue.ToString());
                //MessageBox.Show("" + idnivel, "");
                SeleccionacomboLecciones();
            }
            else { cont++; }
            //SeleccionacomboLecciones();
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
                    MessageBox.Show("Alumno no encontrado","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
    }
}
