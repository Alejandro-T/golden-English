using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace Ge
{
    class Conexion
    {
        public static OracleConnection conectar()
        {
            OracleConnection cn =
                new OracleConnection();
            cn.ConnectionString = "USER ID = golden; PASSWORD=O^wJaX!dsG!9; DATA SOURCE = db202105251128_high";
            //OracleConnection cn =
            //    new OracleConnection("DATA SOURCE = xe; PASSWORD=patito; USER ID = golden");
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
