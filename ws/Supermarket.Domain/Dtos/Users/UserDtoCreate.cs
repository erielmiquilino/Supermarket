using System.ComponentModel.DataAnnotations;

namespace Supermarket.Domain.Dtos.Users
{
    public class UserDtoCreate
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório para o cadastro.")]
        [StringLength(60, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório para o cadastro.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
