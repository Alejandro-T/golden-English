using GoldenE;
using GoldenE.alumnos;
using GoldenE.Catalogo_Horario;
using GoldenE.horarios;
using GoldenE.lecciones;
using GoldenE.maestros;
using GoldenE.niveles;
using GoldenE.salones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ge
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Calificaciones());
        }
    }
}
