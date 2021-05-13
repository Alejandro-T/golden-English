using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ge
{
    class publicas
    {
        public static int _id_t_user;
        public static int _id_alumno;
        public static int _id_usuario;
        public static int _id_nivel;
        public static string _nombre;
        public static int _id_leccion;
        public static int _id_salon;
        public publicas()
        {
            id_alumno = 0;
            id_usuario = 0;
            id_t_user = 0;
            id_nivel = 0;
            nombre = "";
            id_leccion = 0;
            id_salon = 0;
        }
        
        public static int id_t_user
        {
            get => _id_t_user;
            set => _id_t_user = value;
        }
        public static int id_alumno
        {
            get => _id_alumno;
            set => _id_alumno = value;
        }
        public static int id_usuario
        {
            get => _id_usuario;
            set => _id_usuario = value;
        }
        public static int id_nivel
        {
            get => _id_nivel;
            set => _id_nivel = value;
        }

        public static string nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public static int id_leccion
        {
            get => _id_leccion;
            set => _id_leccion = value;
        }

        public static int id_salon
        {
            get => _id_salon;
            set => _id_salon = value;
        }

    }
}
