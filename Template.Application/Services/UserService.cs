﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using Template.Application.Interfaces;
using Template.Application.ViewModels.Profiles;
using Template.Application.ViewModels.Users;
using Template.CrossCutting.Auth.Interfaces;
using Template.CrossCutting.Auth.ViewModels;
using Template.CrossCutting.ExceptionHandler.Extensions;
using Template.CrossCutting.Notification.Interfaces;
using Template.CrossCutting.Notification.ViewModels;
using Template.Domain.Entities.Usr;
using Template.Domain.Interfaces;
using Profile = Template.Domain.Entities.Usr.Profile;

namespace Template.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;
        private readonly ITokenService tokenService;
        private readonly IUserRepository repository;
        private readonly IProfileRepository profileRepository;

        public UserService(IMapper mapper, ITokenService tokenService, IEmailSender emailSender,
            IUserRepository repository, IProfileRepository profileRepository)
        {
            this.mapper = mapper;
            this.tokenService = tokenService;
            this.emailSender = emailSender;
            this.repository = repository;
            this.profileRepository = profileRepository;

        }

        public void ActivateByEmail(string email, string code)
        {
            Users _user = repository.GetByEmailAndCode(email, code);
            if (_user == null)
                throw new ApiException("Email/Code not found", HttpStatusCode.NotFound);

            _user.IsAuthorised = true;
            _user.Code = string.Empty;
            repository.Update(_user);
        }

        public bool ActivateUser(int userId)
        {
            Users _user = GetByIdPrivate(userId);
            _user.IsAuthorised = true;

            repository.Update(_user);
            return true;
        }

        public UserResponseAuthenticateViewModel Authenticate(UserRequestAuthenticateViewModel user)
        {
            Users _user = repository.GetByEmailAndPassword(user.Email, UtilsService.EncryptPassword(user.Password));
            if (_user == null)
                throw new ApiException("Email/Password not found", HttpStatusCode.NotFound);

            if (!_user.IsAuthorised)
                throw new ApiException("Sua conta não esta ativada ainda.", HttpStatusCode.NotFound);

            string token = tokenService.GenerateToken(mapper.Map<ContextUserViewModel>(_user));

            UserResponseAuthenticateViewModel _userResponse = mapper.Map<UserResponseAuthenticateViewModel>(_user);
            _userResponse.Token = token;

            return _userResponse;
        }

        public bool ChangePassword(UserRequestChangePasswordViewModel user)
        {
            ValidationService.ValidEmail(user.Email);
            ValidationService.ValidPassword(user.Password, user.PasswordConfirm);

            Users _user = repository.GetByEmailAndCode(user.Email, user.Code);
            if (_user == null)
                throw new ApiException("Email/Code not found", HttpStatusCode.NotFound);

            _user.Code = string.Empty;
            _user.Password = UtilsService.EncryptPassword(user.Password);
            repository.Update(_user);

            emailSender.SendEmailAsync(new EmailViewModel(new string[] { _user.Email }, "Mudança de senha - Template", "PASSWORD-CHANGED"), new string[] { _user.Name });

            return true;
        }

        public bool DeactivateUser(int userId)
        {
            Users _user = GetByIdPrivate(userId);
            _user.IsAuthorised = false;
            repository.Update(_user);
            return true;
        }

        public bool ForgotPassword(string email)
        {
            ValidationService.ValidEmail(email);
            Users _user = repository.GetByEmail(email);
            if (_user == null)
                throw new ApiException("Email not found", HttpStatusCode.NotFound);

            _user.Code = UtilsService.GenerateCode(8);

            repository.Update(_user);

            emailSender.SendEmailAsync(new EmailViewModel(new string[] { _user.Email }, "Mudança de senha - Template", "FORGOT-PASSWORD"), new string[] { _user.Name, _user.Code });

            return true;
        }

        public UserViewModel GetById(int userId)
        {
            Users _user = GetByIdPrivate(userId);

            return mapper.Map<UserViewModel>(_user);
        }

        public bool Post(UserRequestCreateAccountViewModel user, string host)
        {
            ValidationService.ValidEmail(user.Email);
            ValidationService.ValidPassword(user.Password, user.PasswordConfirm);

            if (repository.GetByEmail(user.Email) != null)
                throw new ApiException("Email not found", HttpStatusCode.Conflict);

            Profile _profile = profileRepository.GetDefault();
            if (_profile == null)
                throw new ApiException("Your account can't be registered because there is no default profile.", HttpStatusCode.Unused);

            try
            {
                Users _user = mapper.Map<Users>(user);
                _user.ProfileId = _profile.Id;
                _user.Code = UtilsService.GenerateCode(8);

                repository.Create(_user);

                string _generateUrlEmail = UtilsService.GenerateURL(_user.Code, _user.Email, host);

                emailSender.SendEmailAsync(new EmailViewModel(new string[] { _user.Email }, "Account Created - Template", "ACCOUNT-CREATED"), new string[] { _user.Name, _generateUrlEmail });

                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public List<UserViewModel> Get()
        {
            return mapper.Map<List<UserViewModel>>(repository.Get());
        }

        public bool Put(UserUpdateAccount user)
        {
            Users _user = GetByIdPrivate(user.Id);
            _user.Name = user.Name;

            repository.Update(_user);
            return true;
        }

        public bool UpdateAccess(UserUpdateAccess user)
        {
            Users _user = GetByIdPrivate(user.Id);
            Profile _profile = profileRepository.GetById(user.ProfileId);
            _user.Profile = _profile;
            _user.Name = user.Name;
            _user.ProfileId = user.ProfileId;
            _user.Email = user.Email;

            repository.Update(_user);
            return true;
        }



        private Users GetByIdPrivate(int userId)
        {
            Users _user = repository.GetById(userId);
            if (_user == null)
                throw new ApiException("User not found", HttpStatusCode.NotFound);

            return _user;
        }
    }
}
