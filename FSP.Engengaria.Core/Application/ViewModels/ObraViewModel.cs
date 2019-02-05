using FSP.Engengaria.Core.Application.Validation;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FSP.Engengaria.Core.Application.ViewModels
{
    public class ObraViewModel
    {
        [Key]
        [DisplayName("Código")]
        public int CodigoObra { get; set; }
        [DisplayName("Objeto")]
        [Required(ErrorMessage = "Informe a descrição do objeto.")]
        public string DescricaoObjeto { get; set; }

        [DisplayName("Obra")]
        [Required(ErrorMessage = "Informe o nome da obra.")]
        public string NomeObra { get; set; }

        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [DisplayName("Estado")]
        public string UF { get; set; }

        [DisplayName("CEP")]
        public string CEP { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Data Início")]
        public string DataInicio { get; set; }

        [DisplayName("Data Fim")]
        public string DataFim { get; set; }

        public ICollection<ItemServicoViewModel> ItensServicos { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public ObraViewModel()
        {
            ItensServicos = new List<ItemServicoViewModel>();
        }
    }
}
