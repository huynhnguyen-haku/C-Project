using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject
{
    public class CarDAO
    {
        private static CarDAO instance = null;
        private static object instanceLock = new object();

        public static CarDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDAO();
                    }
                    return instance;
                }
            }
        }

        private readonly CarManagementContext _context = new CarManagementContext();

        public List<Car?> GetAllCar()
        {
            return _context.Cars
                .Include(c => c.Category)
                .Where(o => o.CarStatus == 1)
                .ToList();
        }

        public void AddCar(Car car)
        {
            var maxId = _context.Cars.Max(c => c.CarId);
            car.CarId = maxId + 1;

            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public Car GetCarById(int ?id)
        {
            var listTmp = _context.Cars.Where(c => c.CarId == id).ToList();
            if (listTmp.Count == 0)
            {
                return null;
            }
            else
            {
                return listTmp[0];
            }
        }

        public void DeleteCar(int id)
        {
            var car = _context.Cars.Where(c => c.CarId == id).ToList()[0];
            var isCarInOrder = _context.OrderDetails.Where(c => c.CarId == id).ToList().Count > 0;
            if (isCarInOrder) // if car is in order, just update status
            {
                car.CarStatus = 0;
                car.Category = null;

                _context.Cars.Update(car);
                _context.SaveChanges();
            }
            else // if car is not in order, delete it
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }

        public List<Car?> GetCarByName(string name)
        {
            return _context.Cars.Where(c => c.CarName.ToUpper().Contains(name.ToUpper())).ToList();
        }

        public List<Car?> GetCarDescription(string description)
        {
            return _context.Cars.Where(c => c.Description.ToUpper().Contains(description.ToUpper())).ToList();
        }

        public void UpdateCar(Car car)
        {
            var existingCar = _context.Cars.Find(car.CarId);
            if (existingCar != null)
            {
                car.Category = null;
                _context.Entry(existingCar).State = EntityState.Detached;
                _context.Cars.Update(car);
                _context.SaveChanges();
            }
        }

        public string GetCarName(int id)
        {
            return _context.Cars.Where(c => c.CarId == id).ToList()[0].CarName;
        }
    }
}
