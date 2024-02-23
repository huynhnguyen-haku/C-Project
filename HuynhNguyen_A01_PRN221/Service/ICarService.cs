using BusinessObject.Models;

namespace Service
{
    public interface ICarService
    {
        public void AddNewCar(Car newCar);
        public void UpdateCar(Car newCar);
        public void DeleteCar(int carId);
        public List<Car> GetAllCar();
        public Car GetCarById(int carId);
        public string GetCarName(int id);
        public string CreateCar(int categoryId, string carName, string description, string unitPrice, string unitInStock);
        public string UpdateCar(Car oldCar, int categoryId, string carName, string description, string unitPrice, string unitInStock);
        public List<Car?> FindCar(int findCase, string value);
    }
}
