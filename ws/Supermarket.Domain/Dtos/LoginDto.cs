﻿using System.ComponentModel.DataAnnotations;

namespace Supermarket.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é um campo obrigatório para o Login.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Senha é um campo obrigatório para o Login.")]
        [StringLength(100, ErrorMessage = "Senha deve ter no máximo {1} caracteres.")]
        public string Password { get; set; }
    }
}
