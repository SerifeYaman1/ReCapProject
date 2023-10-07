using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
        }

        private static void CarTest()
        {
            ProductManager productManager = new ProductManager(new EfCarDal());
            foreach (var car in productManager.GetCarDetails())
            {
                Console.WriteLine("{0}  {1}  {2}  {3}",car.CarName,car.BrandName,car.ColorName,car.DailyPrice);
            }
        }
    }
}