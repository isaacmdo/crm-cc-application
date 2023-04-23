using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.ViewModels.Products;

namespace Template.Application.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> Get();
    }
}
