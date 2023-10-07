using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        ICarDal _carDal;
        public ProductManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.CarName.Length>2 && car.DailyPrice > 0)
            {
                Console.WriteLine("Car added.");
            }
            _carDal.Add(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p=>p.BrandId == id);  
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p=>p.ColorId == id);  

        }
    }
}
