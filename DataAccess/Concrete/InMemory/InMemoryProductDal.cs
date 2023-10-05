using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal 
    {
        List<Car> _car; // global değişken - veritabanı
        public InMemoryProductDal()
        {
            //Oracle, Sql Server, Postgres, MongoDb'den geliyormuş gibi liste oluşturduk.
            _car = new List<Car> {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=1000, Description="Mercedes M02 Car", ModelYear="2000"},
                new Car{Id=2, BrandId=1, ColorId=1, DailyPrice=5000, Description="Mercedes M03 Car", ModelYear="2023"},
                new Car{Id=3, BrandId=2, ColorId=1, DailyPrice=10000, Description="Porsche Car", ModelYear="2023"},
                new Car{Id=4, BrandId=3, ColorId=2, DailyPrice=1000, Description="BMW B001 Car", ModelYear="2010"},
                new Car{Id=5, BrandId=3, ColorId=2, DailyPrice=500, Description="BMW B002 Car", ModelYear="2000"}
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);  
        }

        public void Delete(Car car)
        {
           Car carToDelete=carToDelete= _car.FirstOrDefault(c=>c.Id==car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(c=>c.Id== id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = carToUpdate = _car.FirstOrDefault(c=>c.Id==car.Id);
            carToUpdate.DailyPrice= car.DailyPrice; 
            carToUpdate.Description=car.Description;    
            carToUpdate.ModelYear=car.ModelYear;
            carToUpdate.BrandId=car.BrandId;
            carToUpdate.ColorId=car.ColorId;
            
        }
    }
}
