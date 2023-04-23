using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Application.ViewModels.Environments;
using Template.CrossCutting.ExceptionHandler.Extensions;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Sales;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class OpportunityTypeService : IOpportunityTypeService
    {
        private readonly IMapper mapper;
        private readonly IOpportunityTypeRepository repository;

        public OpportunityTypeService(IOpportunityTypeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public bool Update(OpportunityType inventoryType)
        {

            try
            {
                OpportunityType _inventoryType = this.GetById(inventoryType.Id);

                _inventoryType.Name = inventoryType.Name;

                this.repository.UpdateType(_inventoryType);

                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public bool Create(OpportunityTypeRequestCreateViewModel inventoryType)
        {

            try
            {
                OpportunityType _inventoryType = mapper.Map<OpportunityType>(inventoryType);

                this.repository.CreateType(_inventoryType);

                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public List<OpportunityType> Get()
        {
            IQueryable<OpportunityType> _modules = repository.Get();

            return _modules.ToList();
        }

        public OpportunityType GetById(int id)
        {
            OpportunityType opportunityType = repository.GetById(id);
            if (opportunityType == null)
                throw new ApiException("OpportunityType not found", HttpStatusCode.NotFound);

            return opportunityType;
        }

        public bool Deactivate(int opportunityTypeId)
        {
            OpportunityType _opportunityTypeId = GetById(opportunityTypeId);
            _opportunityTypeId.IsActive = false;
            repository.UpdateType(_opportunityTypeId);
            return true;
        }


        public bool Activate(int opportunityTypeId)
        {
            OpportunityType _opportunityTypeId = GetById(opportunityTypeId);
            _opportunityTypeId.IsActive = true;
            repository.UpdateType(_opportunityTypeId);
            return true;
        }
    }
}
