using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenE.reporte
{
    class rSemanaMaestro
    {
        public string nombre { get; set; }
        public string apellidoPat { get; set; }
        public string apellidMat { get; set; }
        public int Kardex { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        //Asignar el constructor por
        //defecto para que no genere error
        //de argumentos
        public rSemanaMaestro()
        {

        }
        //Constructor que recibe parámetro de la misma clase
        public rSemanaMaestro(rSemanaMaestro Add)
        {
            nombre = Add.nombre;
            apellidoPat = Add.apellidoPat;
            apellidMat = Add.apellidMat;
            Kardex = Add.Kardex;
            fecha = Add.fecha;
            hora = Add.hora;
        }
    }
}
