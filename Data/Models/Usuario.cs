using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public string Email { get; set; }
        public long Telefone { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}
