using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.ViewModels.Products;
using Template.Application.ViewModels.Profiles;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class ProductService
    {
        private readonly IMapper mapper;

        private readonly IProductRepository repository;

        public ProductService(IMapper mapper, IProductRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;

        }

        public List<ProductViewModel> Get()
        {
            return mapper.Map<List<ProductViewModel>>(repository.Get());
        }


    }
}
