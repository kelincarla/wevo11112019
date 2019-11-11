using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public sealed class UsuarioSingleton
    {
        static UsuarioSingleton _instance;
        public static UsuarioSingleton Instance
        {
            get { return _instance ?? (_instance = new UsuarioSingleton()); }
        }

        private UsuarioSingleton() { Usuarios = new List<Usuario>(); }

        public List<Usuario> Usuarios { get; set; }

    }
}
