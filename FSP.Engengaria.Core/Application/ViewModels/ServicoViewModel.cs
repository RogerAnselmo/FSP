using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FSP.Engengaria.Core.Application.ViewModels
{
    public class ServicoViewModel
    {
        [Key]
        [DisplayName("Código")]
        public int CodigoServico { get; set; }
        [DisplayName("Descrição")]
        public string DescricaoServico { get; set; }
        [DisplayName("Percentual")]
        public decimal Percentual { get; set; }
        [DisplayName("Valor")]
        public decimal Valor { get; set; }

        public ICollection<ItemServicoViewModel> Itenizacoes { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public ServicoViewModel()
        {
            Itenizacoes = new List<ItemServicoViewModel>();
        }
    }
}
