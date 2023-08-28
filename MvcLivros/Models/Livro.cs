using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using MvcLivros.Resources;

namespace MvcLivros.Models
{
    public class Livro
    {
        public int Id { get; set; }


        [Display(Name = "Título")] //Alias para Coluna
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))] //A propriedade deve ter um valor. Mas não impede que esse valor seja um " "
        [StringLength(60, MinimumLength = 3, ErrorMessageResourceName = "MinimumLength", ErrorMessageResourceType = typeof(Messages))] //MinimumLength = A propriedade deve ter um valor. Mas não impede que esse valor seja um " 
        [RegularExpression(@"^[^\s].*", ErrorMessageResourceName = "RegularExpression", ErrorMessageResourceType = typeof(Messages))]//é usado para limitar quais caracteres podem ser inseridos.  
        public string? Titulo { get; set; }


        //public string? IdVolumeGoogleBook { get; set; }



        [Display(Name = "Lançado em")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        [DataType(DataType.Date)] //Especifica o tipo de dados (Data) e, portanto, as informações de hora armazenadas no campo não são exibidas.
        public DateTime DataLancamento { get; set; }


        [Display(Name = "Gênero")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "MinimumLength", ErrorMessageResourceType = typeof(Messages))]
        [RegularExpression(@"^[A-Z]+[A-zÀ-ú '´]*$", ErrorMessageResourceName = "RegularExpression", ErrorMessageResourceType = typeof(Messages))] 
        public string? Genero { get; set; }


        [Display(Name = "Preço")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        [Range(1, 100, ErrorMessageResourceName = "Range", ErrorMessageResourceType = typeof(Messages))] //restringe um valor a um intervalo especificado.
        [Column(TypeName = "decimal(18, 2)")]//Para que o Entity Framework Core possa mapear corretamente o Preço para a moeda no banco de dados.
        public decimal Preco { get; set; }

    }
}