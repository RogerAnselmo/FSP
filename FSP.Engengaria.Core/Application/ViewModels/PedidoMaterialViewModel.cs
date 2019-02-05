using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FSP.Engengaria.Core.Application.ViewModels
{
    public class PedidoMaterialViewModel
    {
        [Key]
        [DisplayName("Nº Pedido")]
        public int CodigoPedido { get; set; }

        [DisplayName("Data Pedido")]
        public DateTime DataPedido { get; set; }
        [DisplayName("Solicitado por")]
        public string NomeSolicitante { get; set; }

        [DisplayName("Autorizado por")]
        public string NomeAutorizador { get; set; }

        [DisplayName("Toral")]
        public decimal ValorPedido { get; set; }

        //Dados do Detalhe do Pedido

        [DisplayName("Obra")]
        public int CodigoObra { get; set; }

        [DisplayName("Serviço")]
        public int CodigoServico { get; set; }

        [DisplayName("Descrição do Item")]
        public int CodigoItenizacao { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Descricao")]
        public string DescricaoItem { get; set; }

        [DisplayName("Fornecedor")]
        public int CodigoFornecedor { get; set; }

        [DisplayName("Qtd")]
        public int Quantidade { get; set; }

        [DisplayName("Valor Total")]
        public decimal ValorTotal { get; set; }

        //public ObraViewModel Obra { get; set; }
        //public ServicoViewModel Servico { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
