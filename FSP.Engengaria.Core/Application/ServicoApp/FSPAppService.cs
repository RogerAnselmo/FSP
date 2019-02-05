using FSP.Engengaria.Core.Application.Adapter;
using FSP.Engengaria.Core.Application.Interface;
using FSP.Engengaria.Core.Application.ViewModels;
using FSP.Engengaria.Core.Domain.Interface.Repository;

namespace FSP.Engengaria.Core.Application.ServicoApp
{
    public class FSPAppService : IFSPAppService
    {
        private readonly IObraRepository _obraRepository;
        public void Dispose() { }

        public FSPAppService(IObraRepository obraRepository)
        {
            _obraRepository = obraRepository;
        }

        public void RegistrarObra(ObraViewModel obraViewModel)
        {
            var obra = ObraAdapter.DeObraViewModelParaObra(obraViewModel);
            _obraRepository.Adicionar(obra);
        }
    }
}
