using FSP.Engengaria.Core.Application.ViewModels;
using FSP.Engengaria.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FSP.Engengaria.Core.Application.Adapter
{
    public static class ObraAdapter
    {
        public static Obra DeObraViewModelParaObra(ObraViewModel obraViewModel)
        {
            var obra = new Obra
            {
                CodigoObra = obraViewModel.CodigoObra,
                DescricaoObjeto = obraViewModel.DescricaoObjeto,
                NomeObra = obraViewModel.NomeObra,
                Endereco = obraViewModel.Endereco,
                Bairro = obraViewModel.Bairro,
                Cidade = obraViewModel.Cidade,
                UF = obraViewModel.UF,
                CEP = obraViewModel.CEP,
                Status = obraViewModel.Status,
                DataInicio = Convert.ToDateTime(obraViewModel.DataInicio),
                DataFim = Convert.ToDateTime(obraViewModel.DataFim),
            };
            return obra;
        }

        public static ObraViewModel DeObraParaObraViewModel(Obra obra)
        {
            var obraViewModel = new ObraViewModel
            {
                CodigoObra = obra.CodigoObra,
                DescricaoObjeto = obra.DescricaoObjeto,
                NomeObra = obra.NomeObra,
                Endereco = obra.Endereco,
                Bairro = obra.Bairro,
                Cidade = obra.Cidade,
                UF = obra.UF,
                CEP = obra.CEP,
                Status = obra.Status,
                DataInicio = obra.DataInicio.ToString("dd/MM/yyyy"),
                DataFim = obra.DataFim.ToString("dd/MM/yyyy"),
            };
            return obraViewModel;
        }
        public static IEnumerable<ObraViewModel> DeObrasParaObrasViewModels(IQueryable<Obra> obras)
        {
            var obrasViewModel = new List<ObraViewModel>();

            foreach (var obra in obras)
            {
                var obraViewModel = new ObraViewModel
                {
                    CodigoObra = obra.CodigoObra,
                    DescricaoObjeto = obra.DescricaoObjeto,
                    NomeObra = obra.NomeObra,
                    Endereco = obra.Endereco,
                    Bairro = obra.Bairro,
                    Cidade = obra.Cidade,
                    UF = obra.UF,
                    CEP = obra.CEP,
                    Status = obra.Status,
                    DataInicio = obra.DataInicio.ToString("dd/MM/yyyy"),
                    DataFim = obra.DataFim.ToString("dd/MM/yyyy"),

                };
                obrasViewModel.Add(obraViewModel);
            }

            return obrasViewModel;
        }
    }
}
