using System.ComponentModel.DataAnnotations;

namespace Supermarket.Domain.Dtos.Products
{
    public class ProductDtoCreate
    {
        [Required(ErrorMessage = "Descrição é um campo obrigatório para o cadastro.")]
        [StringLength(100, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }
    }
}
