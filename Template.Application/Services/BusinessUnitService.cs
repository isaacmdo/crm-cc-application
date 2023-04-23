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
using Template.Domain.Entities.Person;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class BusinessUnitService : IBusinessUnitService
    {
        private readonly IMapper mapper;
        private readonly IBusinessUnitRepository repository;
        private readonly ICompanyService companyService;

        public BusinessUnitService(IBusinessUnitRepository repository, IMapper mapper, ICompanyService companyService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.companyService = companyService;
        }

        public bool Update(BusinessUnit businessUnit)
        {

            try
            {
                BusinessUnit _businessUnit = this.GetById(businessUnit.Id);

                _businessUnit.Id = businessUnit.Id;

                this.repository.UpdateType(_businessUnit);

                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public bool CreateBusinessUnit(BusinessUnitRequestCreateViewModel companyId)
        {

            try
            {
                BusinessUnit _businessUnit = mapper.Map<BusinessUnit>(companyId);

                this.repository.Create(_businessUnit);

                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public List<BusinessUnit> Get()
        {
            List<BusinessUnit> _businessUnits = repository.Get().ToList();
            
            return _businessUnits.ToList();
        }

        public BusinessUnit GetById(int id)
        {
            BusinessUnit inventoryType = repository.GetById(id);

            return inventoryType;
        }

        public bool Deactivate(int businessUnitId)
        {
            BusinessUnit _businessUnitId = GetById(businessUnitId);
            _businessUnitId.IsActive = false;
            repository.UpdateType(_businessUnitId);
            return true;
        }


        public bool Activate(int businessUnitId)
        {
            BusinessUnit _businessUnitId = GetById(businessUnitId);
            _businessUnitId.IsActive = true;
            repository.UpdateType(_businessUnitId);
            return true;
        }
    }
}
