using BusinessObject.Models;
using DataAccessObject;


namespace Repository.Implementation
{
    public class CategoryRepo : ICategoryRepo
    {
        public List<Category> GetAllCategory()
        {
            return CategoryDAO.Instance.GetAllCategory();
        }
    }
}
