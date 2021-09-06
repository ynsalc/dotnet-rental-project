using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public List<Car> GetAllWithInclude()
        {
            using(Context context = new Context())
            {
                return context.Cars.Include(x => x.Company).Include(x => x.Segment).ToList();
            }
        }
    }
}
