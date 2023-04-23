using Template.Application.Services;
using Template.Application.ViewModels.Environments;
using Template.Application.ViewModels.Modules;
using Template.Application.ViewModels.Products;
using Template.Application.ViewModels.Profiles;
using Template.Application.ViewModels.Users;
using Template.CrossCutting.Auth.ViewModels;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Person;
using Template.Domain.Entities.Production;
using Template.Domain.Entities.Sales;
using Template.Domain.Entities.Usr;
using Profile = AutoMapper.Profile;
using ProfileUser = Template.Domain.Entities.Usr.Profile;

namespace Template.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup() 
        {

            #region "ViewModel To Domain"

            CreateMap<UserRequestCreateAccountViewModel, Users>()
                .ForMember(x => x.Password, y => y.MapFrom(m => UtilsService.EncryptPassword(m.Password)));

            CreateMap<InventoryTypeRequestCreateViewModel, InventoryType>();
            CreateMap<OpportunityTypeRequestCreateViewModel, OpportunityType>();
            CreateMap<ConceptRequestCreateViewModel, Concept>();
            CreateMap<BusinessUnitRequestCreateViewModel, BusinessUnit>();

            #endregion

            #region "Domain to ViewModel"

            CreateMap<Users, ContextUserViewModel>()
                .ForMember(x => x.Profile, m => m.MapFrom(map => map.ProfileId));
            CreateMap<Users, UserViewModel>();
            CreateMap<Users, UserResponseListViewModel>();
            CreateMap<Users, UserResponseAuthenticateViewModel>()
                .ForMember(x => x.Profile, m => m.MapFrom(map => map.ProfileId));
            CreateMap<ProfileUser, ProfileViewModel>();
            CreateMap<Module, ModuleViewModel>();
            CreateMap<Product, ProductViewModel>();

            #endregion
        }
    }
}
