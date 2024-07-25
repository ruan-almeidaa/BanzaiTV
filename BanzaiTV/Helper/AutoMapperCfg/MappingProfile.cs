using AutoMapper;
using BanzaiTV.Models;
using BanzaiTV.ViewModel;

namespace BanzaiTV.Helper.AutoMapperCfg
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
