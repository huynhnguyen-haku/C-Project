using BusinessObject.Models;

namespace Repository
{
    public interface ICarRepo
    {
        public List<Car> GetAllCar();
        public string GetCarName(int id);
        public Car GetCarById(int? id);
        public void DeleteCar(int id);
        public string UpdateCar(Car oldCar, int categoryId, string carName, string description,
            string unitPrice, string unitInStock);

        public void UpdateCar(Car newCar);
        public string CreateCar(int categoryId, string carName, string description,
                       string unitPrice, string unitInStock);
        public void CreateCar(Car newCar);
        public List<Car?> FindCar(int findCase, string value);
    }
}
