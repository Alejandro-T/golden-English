using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenE.reporte
{
    class rHoraDiaMaestro
    {
        //Propiedades
        public string nombre { get; set; }
        public string apellidoPat { get; set; }
        public string apellidMat { get; set; }
        public int Kardex { get; set; }
        public string lecciones_id_leccion { get; set; }
        public string tipolecciones_id_leccion { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string nombreA { get; set; }
        public string apellidoPatA { get; set; }
        public string apellidoMatA { get; set; }
        //Asignar el constructor por
        //defecto para que no genere error
        //de argumentos
        public rHoraDiaMaestro()
        {

        }
        //Constructor que recibe parámetro de la misma clase
        public rHoraDiaMaestro(rHoraDiaMaestro Add)
        {
            nombre = Add.nombre;
            apellidoPat = Add.apellidoPat;
            apellidMat = Add.apellidMat;
            Kardex = Add.Kardex;
            lecciones_id_leccion = Add.lecciones_id_leccion;
            tipolecciones_id_leccion = Add.tipolecciones_id_leccion;
            fecha = Add.fecha;
            hora = Add.hora;
            nombreA = Add.nombre;
            apellidoPatA = Add.apellidoPat;
            apellidoMatA = Add.apellidMat;
        }
    }
}
