using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FSP.Engengaria.Core.Application.ViewModels
{
    public class ItemServicoViewModel
    {
        [Key]
        [DisplayName("Código")]
        public int CodigoItemServico { get; set; }

        [DisplayName("Obra")]
        public int CodigoObra { get; set; }

        [DisplayName("Serviço")]
        public int CodigoServico { get; set; }

        [DisplayName("Item")]
        [Required(ErrorMessage = "Informe o número do Item.")]
        public string NumeroItem { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Informe a descrição do item.")]
        public string DescricaoItem { get; set; }

        [DisplayName("Unidade")]
        [Required(ErrorMessage = "Informe a descrição da unidade.")]
        public string DescricaoUnidade { get; set; }

        [DisplayName("Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        [DisplayName("Número Ordem")]
        public int NumeroOrdem { get; set; }

        public ObraViewModel Obra { get; set; }
        public ServicoViewModel Servico { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
