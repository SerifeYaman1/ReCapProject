using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (var ctx = new MyDatabaseContext())
            {
                var result = from ca in ctx.Cars
                             join b in ctx.Brands
                             on ca.BrandId equals b.BrandId
                             join co in ctx.Colors
                             on ca.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarName = ca.CarName,
                                 BrandName=b.BrandName,
                                 ColorName=co.ColorName,
                                 DailyPrice=ca.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
