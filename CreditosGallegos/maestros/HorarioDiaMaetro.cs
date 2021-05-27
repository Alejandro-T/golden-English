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
    public partial class HorarioDiaMaetro : Form
    {
        public HorarioDiaMaetro()
        {
            InitializeComponent();
        }
        public DataTable Datos()
        {
            // Fragmento de código para
            //Para conexión al SQLSERVER
            DataTable Retornar = new DataTable();
            string dia = "";
            dia = DateTime.Today.ToString("d/M/yyyy");
            //Se ejecuta el procedimiento almacenado
            string query = "select U.NOMBRE,U.PATERNO,U.MATERNO,H.HORA,L.DESCRIPCION,H.ALUMNOS_ID_ALUMNO,T.DESCRIPCION FROM usuarios U JOIN HORARIOS H ON U.ID_USUARIO = H.USUARIOS_ID_MAESTRO JOIN LECCIONES L ON H.LECCIONES_ID_LECCION = L.ID_LECCION JOIN TIPO_CLASE T ON H.TIPO_CLASE_ID_CLASE = T.ID_CLASE WHERE H.USUARIOS_ID_MAESTRO = '" + publicas.id_usr.ToString() + "'and H.fecha = '" + dia + "'";
            OracleDataAdapter Comandosql = new OracleDataAdapter(query, Conexion.conectar());
            Comandosql.Fill(Retornar);
            Conexion.cerrar();
            return Retornar;
        }
        private void CargarReporte()
        {
            List<rHoraDiaMaestro> Agregar = new List<rHoraDiaMaestro>();
            //Datos AcederDatos = new Conexionsql();
            foreach (DataRow Lista in Datos().Rows)
            {
                Agregar.Add(new rHoraDiaMaestro
                {
                    nombre = Lista[0].ToString(),
                    apellidoPat = Lista[1].ToString(),
                    apellidMat = Lista[2].ToString(),
                    hora = Lista[3].ToString(),
                    lecciones_id_leccion = Lista[4].ToString(),
                    
                    Kardex = Convert.ToInt16(Lista[5].ToString()),
                    tipolecciones_id_leccion = (Lista[6].ToString())



                });
            }
            ///Mostrar datos en el reporte
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "GoldenE.reporte.HorasDiaMaestro.rdlc";
            ReportDataSource rds1 = new ReportDataSource("DataSetHoraDiaMaestro", Agregar);
            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(rds1);
            this.reportViewer2.RefreshReport();
            //DataSetHoraDiaMaestro
        }
        private void HorarioDiaMaetro_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
