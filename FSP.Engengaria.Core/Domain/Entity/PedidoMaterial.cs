using DomainValidation.Validation;
using FSP.Engengaria.Core.Domain.Validations.Servicos;
using System;
using System.Collections.Generic;

namespace FSP.Engengaria.Core.Domain.Entity
{
    public class PedidoMaterial
    {
        public int CodigoPedido{ get; set; }
        public DateTime DataPedido { get; set; }
        public string NomeSolicitante { get; set; }
        public string NomeAutorizador { get; set; }
        public decimal ValorPedido { get; set; }

        //public virtual ICollection<Itenizacao> Itenizacoes { get; set; }

        //public ValidationResult ValidationResult { get; set; }
        //public bool IsValid()
        //{
        //    ValidationResult = new ServicoEstaConsistenteValidation().Validate(this);
        //    return ValidationResult.IsValid;
        //}

        public PedidoMaterial()
        {
            //Itenizacoes = new List<Itenizacao>();
        }
    }
}
