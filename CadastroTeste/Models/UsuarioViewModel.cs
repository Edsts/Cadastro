using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroTeste.Models
{
    public class UsuarioViewModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor insira um telefone válido")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "A senha deve conter entre 8 e 20 caracteres")]
        public string Senha { get; set; }
    }
}
