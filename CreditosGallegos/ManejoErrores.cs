using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenE
{
    class ManejoErrores
    {
        public static void erroresOracle(OracleException ex)
        {
            switch (ex.Number)
            {
                case 1:
                    MessageBox.Show("Id ya existe--Error-- " + ex.Number, "Violacion llave primaria", MessageBoxButtons.OK);
                    break;
                case 12899:
                    MessageBox.Show("Campo con demasiados caracteres--Error-- " + ex.Number, "Aviso", MessageBoxButtons.OK);
                    break;
                case 1722:
                    MessageBox.Show("Numero invalido(FormatException)--Error-- " + ex.Number, "Aviso", MessageBoxButtons.OK);
                    break;
                case 2292:
                    MessageBox.Show("No se puede eliminar el dato, porque existe una tabla hijo con ese dato", "Aviso", MessageBoxButtons.OK);
                    break;
                default:
                    MessageBox.Show("Formato invalido--Error--" + ex.Number, "Aviso", MessageBoxButtons.OK);
                    break;
            }
        }
        public static void erroresSystem(FormatException exe)
        {
            switch (exe.HResult)
            {
                default:
                    MessageBox.Show("Formato invalido --Error-- " + exe.Message, "Aviso", MessageBoxButtons.OK);
                    break;
            }
        }
    }
}
