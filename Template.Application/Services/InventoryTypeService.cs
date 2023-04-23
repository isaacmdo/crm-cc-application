using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Application.ViewModels.Environments;
using Template.Application.ViewModels.Modules;
using Template.Application.ViewModels.Users;
using Template.CrossCutting.ExceptionHandler.Extensions;
using Template.CrossCutting.Notification.Services;
using Template.CrossCutting.Notification.ViewModels;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Sales;
using Template.Domain.Entities.Usr;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class InventoryTypeService : IInventoryTypeService
    {
        private readonly IMapper mapper;
        private readonly IInventoryTypeRepository repository;

        public InventoryTypeService(IInventoryTypeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public bool Update(InventoryType inventoryType)
        {
          
            try
            {
                InventoryType _inventoryType = this.GetById(inventoryType.Id);

                _inventoryType.Name = inventoryType.Name;

                this.repository.UpdateType(_inventoryType);

                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public bool Create(InventoryTypeRequestCreateViewModel inventoryType)
        {

            try
            {
                InventoryType _inventoryType = mapper.Map<InventoryType>(inventoryType);

                this.repository.CreateType(_inventoryType);

                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public List<InventoryType> Get()
        {
            IQueryable<InventoryType> _modules = repository.Get();

            return _modules.ToList();
        }

        public InventoryType GetById(int id)
        {
            InventoryType inventoryType = repository.GetById(id);
            if (inventoryType == null)
                throw new ApiException("InventoryType not found", HttpStatusCode.NotFound);

            return inventoryType;
        }

        public bool Deactivate(int inventoryTypeId)
        {
            InventoryType _inventoryTypeId = GetById(inventoryTypeId);
            _inventoryTypeId.IsActive = false;
            repository.UpdateType(_inventoryTypeId);
            return true;
        }


        public bool Activate(int inventoryTypeId)
        {
            InventoryType _inventoryTypeId = GetById(inventoryTypeId);
            _inventoryTypeId.IsActive = true;
            repository.UpdateType(_inventoryTypeId);
            return true;
        }
    }
}
