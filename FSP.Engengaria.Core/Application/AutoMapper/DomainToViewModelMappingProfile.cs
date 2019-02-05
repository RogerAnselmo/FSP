using AutoMapper;
using FSP.Engengaria.Core.Application.ViewModels;
using FSP.Engengaria.Core.Domain.Entity;

namespace FSP.Engengaria.Core.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected void Configure()
        {
            CreateMap<Obra, ObraViewModel>();
            CreateMap<Servico, ServicoViewModel>();
            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Itenizacao, ItemServicoViewModel>();
        }
    }
}
