using AutoMapper;
using BanzaiTV.Models;
using BanzaiTV.ViewModel;

namespace BanzaiTV.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteModel, ClienteViewModel>();
            CreateMap<MensalidadeModel, MensalidadeViewModel>();
        }
    }
}
