using BusinessObject.Models;
using DataAccessObject;


namespace Repository.Implementation
{
    public class CarRepo : ICarRepo
    {
        public string CreateCar(int categoryId, string carName, string description, string unitPrice, string unitInStock)
        {
            if (string.IsNullOrEmpty(carName) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(unitPrice) || string.IsNullOrEmpty(unitInStock))
                return "Please fill all required information!";

            if (categoryId == -1)
                return "Please choose category!";

            if (carName.Length > 30)
                return "Name too long, below 30 characters";

            if (description.Length > 200)
                return "Description too long, below 200 characters";

            decimal unitPriceTmp;
            int unitsInStockTmp;
            if (!decimal.TryParse(unitPrice, out unitPriceTmp) || !int.TryParse(unitInStock, out unitsInStockTmp))
                return "Unit price or unit in stock not valid";

            var updateCar = new Car
            {
                CategoryId = categoryId,
                CarName = carName,
                Description = description,
                UnitsInStock = unitsInStockTmp,
                UnitPrice = unitPriceTmp,
                CarStatus = 1
            };

            CarDAO.Instance.AddCar(updateCar);
            return "";
        }

        public void CreateCar(Car newCar)
        {
            newCar.CarStatus = 1;
            CarDAO.Instance.AddCar(newCar);
        }

        public void DeleteCar(int id)
        {
            CarDAO.Instance.DeleteCar(id);
        }

        public List<Car?> FindCar(int findCase, string value)
        {
            switch (findCase)
            {
                case 0:
                    return CarDAO.Instance.GetCarByName(value);
                case 1:
                    return CarDAO.Instance.GetCarDescription(value);
            }
            return null;
        }

        public List<Car> GetAllCar()
        {
            return CarDAO.Instance.GetAllCar();
        }

        public Car GetCarById(int? id)
        {
            return CarDAO.Instance.GetCarById(id);
        }

        public string GetCarName(int id)
        {
            return CarDAO.Instance.GetCarName(id);
        }

        public string UpdateCar(Car oldCar, int categoryId, string carName, string description, string unitPrice, string unitInStock)
        {
            if (string.IsNullOrEmpty(carName) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(unitPrice) || string.IsNullOrEmpty(unitInStock))
                return "Please fill all required information!";

            if (categoryId == -1)
                return "Please choose category!";

            if (carName.Length > 30)
                return "Name too long, below 30 characters";

            if (description.Length > 200)
                return "Description too long, below 200 characters";

            decimal unitPriceTmp;
            int unitsInStockTmp;
            if (!decimal.TryParse(unitPrice, out unitPriceTmp) || !int.TryParse(unitInStock, out unitsInStockTmp))
                return "Unit price or unit in stock not valid";

            var updateCar = oldCar;
            updateCar.CategoryId = categoryId;
            updateCar.CarName = carName;
            updateCar.Description = description;
            updateCar.UnitsInStock = unitsInStockTmp;
            updateCar.UnitPrice = unitPriceTmp;

            CarDAO.Instance.UpdateCar(updateCar);
            return "";
        }

        public void UpdateCar(Car newCar)
        {
            CarDAO.Instance.UpdateCar(newCar);
        }
    }
}
