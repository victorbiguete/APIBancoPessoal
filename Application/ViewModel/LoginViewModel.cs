using System.ComponentModel.DataAnnotations;

namespace APIBanco.Application.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O Login não pode ser vazio")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A Senha não pode ser vazia")]
        public string Password { get; set; }
    }
}
