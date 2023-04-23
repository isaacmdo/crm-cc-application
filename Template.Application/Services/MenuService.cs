using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Application.ViewModels.Modules;
using Template.Domain.Entities.Usr;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMapper mapper;
        private readonly IModuleRepository moduleRepository;
        private readonly IModuleItemRepository moduleItemRepository;
        private readonly IModuleMenuRepository moduleMenuRepository;

        public MenuService(IModuleRepository moduleRepository, IModuleItemRepository moduleItemRepository, IModuleMenuRepository moduleMenuRepository, IMapper mapper)
        {
            this.moduleRepository = moduleRepository;
            this.moduleItemRepository = moduleItemRepository;
            this.moduleMenuRepository = moduleMenuRepository;
            this.mapper = mapper;
        }

        public List<MenuViewModel> GetMenuByProfile(int profileId)
        {
            IQueryable<Module> _modules = moduleRepository.GetByProfileId(profileId);
            IQueryable<ModuleItem> _modulesItems = moduleItemRepository.GetByProfileId(profileId);
            IQueryable<ModuleMenu> _modulesMenus = moduleMenuRepository.GetByProfileId(profileId);

            var modules = _modules.ToList();
            var moduleItems = _modulesItems.ToList();
            var modulesMenus = _modulesMenus.ToList();

            List<MenuViewModel> menu = new List<MenuViewModel>();

            foreach (var module in modules)
            {
                List<ModuleItemViewModel> items = new List<ModuleItemViewModel>();
                foreach (var moduleItem in moduleItems)
                {
                    List<ModuleMenuViewModel> menus = new List<ModuleMenuViewModel>();
                    foreach (var moduleMenu in modulesMenus)
                    {

                        if (moduleMenu.ModuleItemId == moduleItem.Id)
                        {
                            menus.Add(new ModuleMenuViewModel
                            {
                                Name = moduleMenu.Name,
                                Icon = moduleMenu.Icon,
                                URL = moduleMenu.URL,
                                Sequence = moduleItem.Sequence,
                                Id = moduleMenu.Id
                            });
                        }
                    }

                    if (module.Id == moduleItem.ModuleId)
                    {
                        items.Add(new ModuleItemViewModel
                        {
                            Name = moduleItem.Name,
                            Icon = moduleItem.Icon,
                            Sequence = moduleItem.Sequence,
                            Id = moduleItem.Id,
                            ModuleMenu = menus
                        });
                    }
                }
                menu.Add(new MenuViewModel
                {
                    Id = module.Id,
                    Icon = module.Icon,
                    Name = module.Name,
                    Sequence = module.Sequence,
                    ModuleItem = items
                });
            }

            return menu;
        }
    }
}
