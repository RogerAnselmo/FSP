using System.Collections.Generic;

namespace FSP.Engengaria.Core.Application.ViewModels
{
    public class StatusObraViewModel
    {
        public string Descricao { get; set; }

        public static ICollection<StatusObraViewModel> ObterStatusObra()
        {
            return new List<StatusObraViewModel>
            {
                new StatusObraViewModel {Descricao ="Iniciada"},
                new StatusObraViewModel {Descricao = "Contratada" },
                new StatusObraViewModel {Descricao = "Concluída" },
                new StatusObraViewModel {Descricao = "Entrega/Com Pendência" },
                new StatusObraViewModel {Descricao = "Entrega/Sem Pendência" },
                new StatusObraViewModel {Descricao = "Com Pendência" },
                new StatusObraViewModel {Descricao = "Cancelada" },
            };
        }
    }
}