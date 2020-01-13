using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Supermarket.Domain.Dtos.Users
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "Id é um campo obrigatório para a edição do cadastro.")]
        public Guid Id { get; set; }    

        [Required(ErrorMessage = "Nome é um campo obrigatório para a edição do cadastro.")]
        [StringLength(60, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório para a edição do cadastro.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public String Email { get; set; }

        public String Password { get; set; }
    }
}
