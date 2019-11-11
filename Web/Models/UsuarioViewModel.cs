using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UsuarioViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(200, ErrorMessage = "Tamanho máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
               
        public long Cpf { get; set; }
        
        [Required(ErrorMessage = "E-mail é obrigatório")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "E-mail está num formato inválido")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        
        public long Telefone { get; set; }

        [Required(ErrorMessage = "Sexo é obrigatório")]
        [MaxLength(1, ErrorMessage = "Tamanho máximo 1 caracter, utilize 'F' ou 'M'")]
        public string Sexo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
    }
}