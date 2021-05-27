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
    public partial class CalifAuto : Form
    {
        public CalifAuto()
        {
            InitializeComponent();
        }
        public void SeleccionacomboLecciones()
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            
            string depto = "SELECT id_leccion,descripcion FROM lecciones";
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
        public void cargarAlumno(DataGridView dvg)
        {
            try
            {
                DataTable dtalumnos = new DataTable();
                string comprobacion = "Select ALUMNOS_ID_ALUMNO,FECHA,RFC_ALUMNO_HORARIO,USUARIOS_ID_MAESTRO,RFC_MAES_HORARIO,TIPO_CLASE_ID_CLASE,LECCIONES_ID_LECCION from HORARIOS where  hora ='" + comboBoxHora.SelectedValue + "' and fecha = '"+ DateTime.Today.ToString("d/M/yyyy") + "'";
                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {

                    da.Fill(dtalumnos);
                    dvg.DataSource = dtalumnos;
                }
                else
                {
                    dataGridView1.DataSource = "";
                    MessageBox.Show("El Alumno no existe", "aviso", MessageBoxButtons.OK);
                }
            }


            catch (Oracle.DataAccess.Client.OracleException)
            {
                dataGridView1.DataSource = "";
                MessageBox.Show("Formato invalido", "Aviso", MessageBoxButtons.OK);
            }
        }
        public void cargarHora()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            //DateTime.Today.ToString("d/M/yyyy")

            string depto = "SELECT hora FROM horarios where fecha = '"+ DateTime.Today.ToString("d/M/yyyy") + "' and USUARIOS_ID_MAESTRO = '"+publicas.id_usr.ToString()+"'group by hora";
            //MessageBox.Show(""+idnivel,"");
            OracleDataAdapter da = new OracleDataAdapter
                (depto, Ge.Conexion.conectar());
            OracleCommand cmd = new OracleCommand(depto, Ge.Conexion.conectar());

            OracleDataReader dr = cmd.ExecuteReader();
            da.Fill(ds);

            if (dr.Read())
            {
                comboBoxHora.DataSource = ds.Tables[0];
                comboBoxHora.DisplayMember = "hora";
                comboBoxHora.ValueMember = "hora";
            }
            else
            {
                MessageBox.Show("no hay horas disponibles");
            }
        }
        string hora = "";
        private void CalifAuto_Load(object sender, EventArgs e)
        {
            
            CargaComboBox.SeleccionacomboTipoLeccion(comboBoxTipoDeLeccion);
            SeleccionacomboLecciones();
            MessageBox.Show(DateTime.Today.ToString("d/M/yyyy"));
            cargarHora();
            
        }
        
        

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                this.textBoxKardexAlumno.Text = row.Cells["ALUMNOS_ID_ALUMNO"].Value.ToString();
                this.comboBoxTipoDeLeccion.SelectedValue= row.Cells["TIPO_CLASE_ID_CLASE"].Value.ToString();
                this.comboBoxlecc.SelectedValue = row.Cells["LECCIONES_ID_LECCION"].Value.ToString();
                this.dateTimePicker1.Text = row.Cells["FECHA"].Value.ToString();
                /*this.textBoxAmaterno.Text = row.Cells["materno"].Value.ToString();
                this.dateTimePicker1.Text = row.Cells["FECHA_NACIMIENTO"].Value.ToString();

                this.textBoxAtelefono.Text = row.Cells["telefono"].Value.ToString();
                this.textBoxAdireccion.Text = row.Cells["direccion"].Value.ToString();
                this.comboBoxGeneros.SelectedValue = row.Cells["SEXO_ID_SEXO"].Value.ToString();*/
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //correcciones
            try
            {
                OracleCommand comandoinse = new OracleCommand("insertar_calificacion", Ge.Conexion.conectar());
                comandoinse.CommandType = CommandType.StoredProcedure;

                OracleCommand comandoinseR = new OracleCommand("insertar_review", Ge.Conexion.conectar());
                comandoinseR.CommandType = CommandType.StoredProcedure;


                string rfcA = " select RFC_ALUMNO from alumnos where id_alumno ='" + this.textBoxKardexAlumno.Text + "'";
                OracleCommand cpe = new OracleCommand(rfcA, Conexion.conectar());
                OracleDataReader dre = cpe.ExecuteReader();
                string rfcU = " select RFC from usuarios where id_usuario ='" + Convert.ToInt16(publicas.id_usr.ToString()) + "'";
                OracleCommand cpe2 = new OracleCommand(rfcU, Conexion.conectar());
                OracleDataReader dre2 = cpe2.ExecuteReader();
                if (dre.Read() && dre2.Read())
                {
                    if (Convert.ToInt16(textBoxCali.Text) >= 0 && Convert.ToInt16(textBoxCali.Text) <= 5)
                    {
                        MessageBox.Show("Usuario Reprobado", "Aviso", MessageBoxButtons.OK);

                        comandoinseR.Parameters.Add("@C_LECCIONES_ID_LECCION", OracleDbType.Int32).Value = Convert.ToInt32(comboBoxlecc.SelectedValue);
                        comandoinseR.Parameters.Add("@C_TIPO_CLASE_ID_CLASE", OracleDbType.Int32).Value = Convert.ToInt32(comboBoxTipoDeLeccion.SelectedValue);
                        comandoinseR.Parameters.Add("@C_ALUMNOS_ID_ALUMNO", OracleDbType.Int32).Value = textBoxKardexAlumno.Text;
                        
                        comandoinseR.Parameters.Add("@C_ID_CALIFICACION", OracleDbType.Int32).Value = Convert.ToInt32(textBoxCali.Text);
                        comandoinseR.Parameters.Add("@FECHA", OracleDbType.Varchar2).Value = this.dateTimePicker1.Text;

                        comandoinseR.ExecuteNonQuery();
                        MessageBox.Show("Review Insertado ", "aviso", MessageBoxButtons.OK);
                    }
                    else
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
                        comandoinse.Parameters.Add("@USUARIOS_ID_MAESTRO", OracleDbType.Int16).Value = Convert.ToInt16(publicas.id_usr.ToString());
                        if (Convert.ToInt32(textBoxCali.Text) >= 0 && Convert.ToInt32(textBoxCali.Text) <= 10) {
                            comandoinse.Parameters.Add("@CALIFICACION", OracleDbType.Int16).Value = Convert.ToInt16(textBoxCali.Text);

                            comandoinse.Parameters.Add("@FECHACALIF", OracleDbType.Varchar2).Value = this.dateTimePicker1.Text;

                            comandoinse.ExecuteNonQuery();
                            MessageBox.Show("Calificacion Insertada ", "aviso", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Ingresa una calificacion entre 0 y 10 ", "aviso", MessageBoxButtons.OK);
                        }
                        
                    }
                    

                }
                else
                {
                    MessageBox.Show("Calificacion NO Insertada ", "aviso", MessageBoxButtons.OK);

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
        int cont = 0;
        private void comboBoxHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cont > 1)
            {
                //string idnivel = "";
                //idnivel = (comboBoxNivel.SelectedValue.ToString());
                //MessageBox.Show("" + idnivel, "");
                cargarAlumno(dataGridView1);
            }
            else { cont++; }
            //SeleccionacomboLecciones();
            
        }
    }
}
