using Microsoft.Extensions.DependencyInjection;
using System;
using Template.Application.Interfaces;
using Template.Application.Services;
using Template.CrossCutting.Auth.Interfaces;
using Template.CrossCutting.Auth.Services;
using Template.CrossCutting.Notification.Interfaces;
using Template.CrossCutting.Notification.Services;
using Template.Data.Repositories;
using Template.Domain.Entities.Sales;
using Template.Domain.Interfaces;

namespace Template.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();

            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IInventoryTypeService, InventoryTypeService>();
            services.AddScoped<IOpportunityTypeService, OpportunityTypeService>();
            services.AddScoped<IConceptService, ConceptService>();
            services.AddScoped<IBusinessUnitService, BusinessUnitService>();
            services.AddScoped<ICompanyService, CompanyService>();

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IModuleItemRepository, ModuleItemRepository>();
            services.AddScoped<IModuleMenuRepository, ModuleMenuRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IInventoryTypeRepository, InventoryTypeRepository>();
            services.AddScoped<IConceptRepository, ConceptRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IBusinessUnitRepository, BusinessUnitRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductSubCategoryRepository, ProductSubCategoryRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
            services.AddScoped<IOpportunityRepository, OpportunityRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAnnotationRepository, AnnotationRepository>();
            services.AddScoped<IOpportunityTypeRepository, OpportunityTypeRepository>();
            services.AddScoped<IStageRepository, StageRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();

            #endregion
        }
    }
}
