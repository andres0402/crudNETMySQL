using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETMySQL.Model
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string nombres { get; set; }

        public string apellidos { get; set; }
        public string username { get; set; }

        public string pass { get; set; }


    }
}
