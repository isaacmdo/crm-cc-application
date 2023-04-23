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
using Template.Domain.Entities.Usr;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class ConceptService : IConceptService
    {
        private readonly IMapper mapper;
        private readonly IConceptRepository repository;

        public ConceptService(IConceptRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public bool Update(Concept inventoryType)
        {

            try
            {
                Concept _inventoryType = this.GetById(inventoryType.Id);

                _inventoryType.Name = inventoryType.Name;

                this.repository.UpdateType(_inventoryType);

                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public bool Create(ConceptRequestCreateViewModel inventoryType)
        {

            try
            {
                Concept _inventoryType = mapper.Map<Concept>(inventoryType);

                this.repository.CreateType(_inventoryType);

                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public List<Concept> Get()
        {
            IQueryable<Concept> _modules = repository.Get();

            return _modules.ToList();
        }

        public Concept GetById(int id)
        {
            Concept _concept = repository.GetById(id);
            if (_concept == null)
                throw new ApiException("Concept not found", HttpStatusCode.NotFound);

            return _concept;
        }

        public bool Deactivate(int conceptId)
        {
            Concept _concept = GetById(conceptId);
            _concept.IsActive = false;
            repository.UpdateType(_concept);
            return true;
        }

        public bool Activate(int conceptId)
        {
            Concept _concept = GetById(conceptId);
            _concept.IsActive = true;
            repository.UpdateType(_concept);
            return true;
        }
    
    }
}
