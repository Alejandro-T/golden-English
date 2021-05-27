//using Oracle.DataAccess.Client;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenE
{
    class CargaComboBox
    {
        public static void SeleccionacomboTipoLeccion(ComboBox c)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string depto = "SELECT id_clase,descripcion FROM tipo_clase";
            OracleDataAdapter da = new OracleDataAdapter
                (depto, Ge.Conexion.conectar());
            OracleCommand cmd = new OracleCommand(depto, Ge.Conexion.conectar());

            OracleDataReader dr = cmd.ExecuteReader();
            da.Fill(ds);

            if (dr.Read())
            {
                c.DataSource = ds.Tables[0];
                c.DisplayMember = "descripcion";
                c.ValueMember = "id_clase";
            }
            else
            {
                MessageBox.Show("no hay tipo de clases existentes");
            }
        }
        public static void SeleccionacomboNivel(ComboBox c)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string depto = "SELECT id_nivel,descripcion FROM niveles";
            OracleDataAdapter da = new OracleDataAdapter
                (depto, Ge.Conexion.conectar());
            OracleCommand cmd = new OracleCommand(depto, Ge.Conexion.conectar());

            OracleDataReader dr = cmd.ExecuteReader();
            da.Fill(ds);

            if (dr.Read())
            {
                c.DataSource = ds.Tables[0];
                c.DisplayMember = "descripcion";
                c.ValueMember = "id_nivel";
            }
            else
            {
                MessageBox.Show("no hay niveles existentes");
            }
        }

        public static void comboGenero(ComboBox c)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string depto = "SELECT id_sexo,descripcion FROM sexo";
            OracleDataAdapter da = new OracleDataAdapter
                (depto, Ge.Conexion.conectar());
            OracleCommand cmd = new OracleCommand(depto, Ge.Conexion.conectar());

            OracleDataReader dr = cmd.ExecuteReader();
            da.Fill(ds);

            if (dr.Read())
            {
                c.DataSource = ds.Tables[0];
                c.DisplayMember = "descripcion";
                c.ValueMember = "id_sexo";
            }
            else
            {
                MessageBox.Show("no hay generos existentes");
            }
        }
    }
}
