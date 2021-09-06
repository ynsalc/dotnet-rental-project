using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }
        public void Add(Company company)
        {
            _companyDal.Add(company);
        }

        public List<Company> GetAll()
        {
            return new List<Company>(_companyDal.GetAllWithInclude());
        }

        public Company GetByIdWithInclude(int id)
        {
            return _companyDal.GetByIdWithInclude(x => x.Id == id);
        }
    }
}
