using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public List<Car> GetAll()
        {
            return new List<Car>(_carDal.GetAll()); 
        }

        public List<Car> GetAllTopCars()
        {
            List<Car> cars = new List<Car>(_carDal.GetAllWithInclude());
            List<Car> topCars = new List<Car>();
            foreach (var item in cars)
            {
                Car car = new Car();
                car.Id = item.Id;
                car.CarName = item.CarName;
                int kilometer = calculateBase(item.Kilometer) * 25 / 100;
                car.Kilometer = item.Kilometer;
                decimal price = calculateBase(item.Price) * 35 / 100;
                car.Price = item.Price;
                decimal deposite = calculateBase(item.Deposite) * 15 / 100;
                car.Deposite = item.Deposite;
                int point = calculateBase(item.Point) * 10 / 100;
                car.Point = item.Point;
                car.SegmentId = item.SegmentId;
                car.CompanyId = item.CompanyId;
                decimal companyCount = item.Company.Cars.Count * 15 / 100;
                car.CompanyCount = companyCount;
                car.TotalAlgorithm = car.Kilometer - Decimal.ToInt32(car.Price) - Decimal.ToInt32(car.Deposite) + car.Point + Decimal.ToInt32((decimal)car.CompanyCount);
                topCars.Add(car);
            }
            return topCars.OrderByDescending(x => x.TotalAlgorithm).Take(5).ToList();
        }

        public List<Car> GetByCompanyId(int companyId)
        {
            return new List<Car>(_carDal.GetAll(c => c.CompanyId == companyId));
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

        //decimal base(mod) calculate
        public decimal calculateBase(decimal a)
        {
            int kalan;
            int b = Convert.ToInt32(a);
            string deger ="";
            while (b != 0)
            {
                kalan = b % 5;
                b = b / 5;

                deger = kalan.ToString() + deger;
            }
            return decimal.Parse(deger);
        }

        //integer base(mod) calculate
        public int calculateBase(int a)
        {
            int kalan;
            string deger = "";
            while (a != 0)
            {
                kalan = a % 5;
                a = a / 5;

                deger = kalan.ToString() + deger;
            }
            return int.Parse(deger);
        }
    }
}
