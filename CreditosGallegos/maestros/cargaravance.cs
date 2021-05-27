using Ge;
using GoldenE.reporte;
using Microsoft.Reporting.WinForms;
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
    public partial class cargaravance : Form
    {
        public cargaravance()
        {
            InitializeComponent();
        }

        private void cargaravance_Load(object sender, EventArgs e)
        {
            
            
        }
        private void CargarReporte()
        {
            List<rAvance> Agregar = new List<rAvance>();
            //Datos AcederDatos = new Conexionsql();
            foreach (DataRow Lista in Datos().Rows)
            {
                Agregar.Add(new rAvance
                {
                    nombre = Lista[0].ToString(),
                    apellidoPat = Lista[1].ToString(),
                    apellidMat = Lista[2].ToString(),
                    calificacion = Lista[3].ToString(),
                    lecciones_id_leccion = Lista[4].ToString(),
                    fecha = Lista[5].ToString()

                });
            }
            ///Mostrar datos en el reporte
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GoldenE.reporte.AvanceReticular.rdlc";
            ReportDataSource rds1 = new ReportDataSource("DataSet2", Agregar);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.RefreshReport();
            //DataSetHoraDiaMaestro
        }

        public DataTable Datos()
        {
            // Fragmento de código para
            //Para conexión al SQLSERVER
            DataTable Retornar = new DataTable();

            //Se ejecuta el procedimiento almacenado
            string query = "select A.NOMBRE,A.PATERNO,A.MATERNO,C.CALIFICACION,L.DESCRIPCION,C.FECHACALIF FROM calificaciones C JOIN ALUMNOS A ON C.ALUMNOS_ID_ALUMNO = A.ID_ALUMNO JOIN LECCIONES L ON C.LECCIONES_ID_LECCION = L.ID_LECCION where c.ALUMNOS_ID_ALUMNO = '"+textBoxKardexAlumno.Text+"'";
            OracleDataAdapter Comandosql = new OracleDataAdapter(query, Conexion.conectar());
            Comandosql.Fill(Retornar);
            Conexion.cerrar();
            return Retornar;
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
                    CargarReporte();
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
    }
}
