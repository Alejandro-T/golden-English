using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenE.reporte
{
    class rTrafico
    {
        public string hora { get; set; }
        public int total { get; set; }
        
        //Asignar el constructor por
        //defecto para que no genere error
        //de argumentos
        public rTrafico()
        {

        }
        //Constructor que recibe parámetro de la misma clase
        public rTrafico(rTrafico Add)
        {
            total = Add.total;   
            hora = Add.hora;
        }
    }
}
