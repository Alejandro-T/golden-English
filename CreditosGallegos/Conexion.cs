using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
namespace Ge
{
    class Conexion
    {
        public static OracleConnection conectar()
        {
            
            OracleConnection cn =
                new OracleConnection("DATA SOURCE = xe; PASSWORD=patito; USER ID = golden");
            cn.Open();
            return cn;
        }
        public static OracleConnection cerrar()
        {
            OracleConnection cn = new OracleConnection("DATA SOURCE = xe; PASSWORD=patito; USER ID = golden");
            cn.Dispose();
            return cn;
        }
    }
}
