using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Domain.Entities.Person;
using Template.Domain.Entities.Sales;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository repository;

        public CompanyService(IMapper mapper, ICompanyRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public List<Company> Get()
        {
            IQueryable<Company> _modules = repository.Get();

            return _modules.ToList();
        }

        public Company GetById(int id)
        {
            Company _company = repository.GetById(id);

            return _company;
        }
    }
}
