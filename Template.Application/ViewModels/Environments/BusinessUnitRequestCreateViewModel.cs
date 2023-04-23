using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.ViewModels.Environments
{
    public class BusinessUnitRequestCreateViewModel
    {
        [Required]
        public int CompanyId { get; set; }
    }
}
