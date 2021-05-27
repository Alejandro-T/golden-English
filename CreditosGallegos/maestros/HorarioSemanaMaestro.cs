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
    public partial class HorarioSemanaMaestro : Form
    {
        public HorarioSemanaMaestro()
        {
            InitializeComponent();
        }

        private void HorarioSemanaMaestro_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Today.ToString("d/M/yyyy");
            this.reportViewer1.RefreshReport();
        }
        private void CargarReporte()
        {
            List<rSemanaMaestro> Agregar = new List<rSemanaMaestro>();
            //Datos AcederDatos = new Conexionsql();
            foreach (DataRow Lista in Datos().Rows)
            {
                Agregar.Add(new rSemanaMaestro
                {
                    nombre = Lista[0].ToString(),
                    apellidoPat = Lista[1].ToString(),
                    apellidMat = Lista[2].ToString(),
                    fecha = Lista[3].ToString(),
                    hora = (Lista[4].ToString())

                });
            }
            ///Mostrar datos en el reporte
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GoldenE.reporte.ReporeSemanaMaestro1.rdlc";
            ReportDataSource rds1 = new ReportDataSource("DataSetHoraxSemana", Agregar);
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
            string query = "select U.NOMBRE,U.PATERNO,U.MATERNO,to_char(fecha,'day'), HORAINICIO ||' - '|| horafin from horarioMaestro JOIN USUARIOS U ON USUARIOSF_ID_USUARIO = U.ID_USUARIO where fecha between '"+ this.dateTimePicker1.Text + "' and  next_day(sysdate,'domingo') and USUARIOSF_ID_USUARIO = 63";
            OracleDataAdapter Comandosql = new OracleDataAdapter(query, Conexion.conectar());
            Comandosql.Fill(Retornar);
            Conexion.cerrar();
            return Retornar;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
