using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, Context>, ICompanyDal
    {
        public List<Company> GetAllWithInclude()
        {
            using (Context context = new Context())
            {
                return context.Companies.Include(x => x.Cars).ToList();
            }
        }

        public Company GetByIdWithInclude(Expression<Func<Company, bool>> filter)
        {
            using (Context context = new Context())
            {
                return context.Companies.Include(x => x.Cars).SingleOrDefault(filter);
            }
        }
    }
}
