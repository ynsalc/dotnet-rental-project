using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        Car GetById(int id);
        List<Car> GetByCompanyId(int companyId);
        List<Car> GetAll();
        List<Car> GetAllTopCars();
    }
}
