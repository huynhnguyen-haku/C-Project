using BusinessObject.Models;
using Repository;
using Repository.Implementation;

namespace Service.Implementation
{
    public class CarService : ICarService
    {
        private readonly ICarRepo carRepo = null;
        public CarService()
        {
            carRepo = new CarRepo();
        }

        public void AddNewCar(Car newCar) => carRepo.CreateCar(newCar);
        

        public string CreateCar(int categoryId, string carName, string description, string unitPrice, string unitInStock)
            => carRepo.CreateCar(categoryId, carName, description, unitPrice, unitInStock);
        

        public void DeleteCar(int carId) => carRepo.DeleteCar(carId);

        public List<Car?> FindCar(int findCase, string value) => carRepo.FindCar(findCase, value);

        public List<Car> GetAllCar() => carRepo.GetAllCar();

        public Car GetCarById(int carId) => carRepo.GetCarById(carId);

        public string GetCarName(int id) => carRepo.GetCarName(id);

        public void UpdateCar(Car newCar) => carRepo.UpdateCar(newCar);

        public string UpdateCar(Car oldCar, int categoryId, string carName, string description, string unitPrice, string unitInStock)
        => carRepo.UpdateCar(oldCar, categoryId, carName, description, unitPrice, unitInStock);
    }
}
