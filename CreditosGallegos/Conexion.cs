using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ge
{
    class Conexion
    {
        public static OracleConnection conectar()
        {
            OracleConnection cn =
               new OracleConnection("DATA SOURCE = xe; PASSWORD=patito; USER ID = golden");


            //cn.ConnectionString = "USER ID = golden; PASSWORD=O^wJaX!dsG!9; DATA SOURCE = db202105251128_high";
            //cn =
            //   new OracleConnection("TNS_ADMIN=C:\\Users\\90474\\Oracle\\network\\admin\\DB202105251128;USER ID=GOLDEN;WALLET_LOCATION=C:\\Users\\90474\\Oracle\network\admin\\DB202105251128;DATA SOURCE=db202105251128_high");
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
