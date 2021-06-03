using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenE.reporte
{
    class rAvance
    {
        //Propiedades
        public string nombre { get; set; }
        public string apellidoPat { get; set; }
        public string apellidMat { get; set; }
        public string calificacion { get; set; }
        public string lecciones_id_leccion { get; set; }
        public string fecha { get; set; }
        public string nombreM { get; set; }
        public string apellidoPatM { get; set; }
        public string apellidoMatM { get; set; }
        //Asignar el constructor por
        //defecto para que no genere error
        //de argumentos
        public rAvance()
        {
        }
        //Constructor que recibe parámetro de la misma clase
        public rAvance(rAvance Add)
        {
            nombre = Add.nombre;
            apellidoPat = Add.apellidoPat;
            apellidMat = Add.apellidMat;
            calificacion = Add.calificacion;
            lecciones_id_leccion = Add.lecciones_id_leccion;
            fecha = Add.fecha;
            nombreM = Add.nombreM;
            apellidoPatM = Add.apellidoPatM;
            apellidoMatM = Add.apellidoMatM;
        }
    }
}
