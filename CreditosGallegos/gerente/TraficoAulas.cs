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

namespace GoldenE.gerente
{
    public partial class TraficoAulas : Form
    {
        public TraficoAulas()
        {
            InitializeComponent();
        }

        private void TraficoAulas_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Today.ToString("d/M/yyyy");
            this.reportViewer1.RefreshReport();
        }
        private void CargarReporte()
        {
            List<rTrafico> Agregar = new List<rTrafico>();
            //Datos AcederDatos = new Conexionsql();
            foreach (DataRow Lista in Datos().Rows)
            {
                Agregar.Add(new rTrafico
                {
                    hora = Lista[0].ToString(),
                    total = Convert.ToInt32(Lista[1].ToString())

                });
            }
            ///Mostrar datos en el reporte
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GoldenE.reporte.RhoraAulas.rdlc";
            ReportDataSource rds1 = new ReportDataSource("DataSet1", Agregar);
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
            string query = "select hora,count(*) as total from horarios where fecha = '" + this.dateTimePicker1.Text + "' group by hora";
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
