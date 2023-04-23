using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.ViewModels.Environments;
using Template.Domain.Entities.Person;

namespace Template.Application.Interfaces
{
    public interface ICompanyService
    {
        List<Company> Get();
        Company GetById(int id);
        //bool Update(Company company);
        //bool Create(Company company);
        //bool Activate(int companyId);
        //bool Deactivate(int companyId);
    }
}
