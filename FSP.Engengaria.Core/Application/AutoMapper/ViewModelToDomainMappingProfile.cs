using AutoMapper;
using FSP.Engengaria.Core.Application.ViewModels;
using FSP.Engengaria.Core.Domain.Entity;

namespace FSP.Engengaria.Core.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected void Configure()
        {
            CreateMap<ObraViewModel, Obra>();
            CreateMap<ServicoViewModel, Servico>();
            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<ItemServicoViewModel, Itenizacao>();
        }
    }
}
