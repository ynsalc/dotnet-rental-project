using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        void Add(Company company);
        List<Company> GetAll();
        Company GetByIdWithInclude(int id);
    }
}
