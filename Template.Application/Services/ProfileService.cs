using AutoMapper;
using System.Collections.Generic;
using Template.Application.Interfaces;
using Template.Application.ViewModels.Profiles;
using Template.Domain.Entities.Usr;
using Template.Domain.Interfaces;
using Profile = Template.Domain.Entities.Usr.Profile;

namespace Template.Application.Services
{
    public class ProfileService: IProfileService
    {

        private readonly IMapper mapper;

        private readonly IProfileRepository repository;

        public ProfileService(IMapper mapper, IProfileRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;

        }

        public List<ProfileViewModel> Get()
        {
            return mapper.Map<List<ProfileViewModel>>(repository.Get());
        }

        public ProfileViewModel GetById(int profileId)
        {
            Profile _user = repository.GetById(profileId);

            return mapper.Map<ProfileViewModel>(_user);
         
        }
    }
}
