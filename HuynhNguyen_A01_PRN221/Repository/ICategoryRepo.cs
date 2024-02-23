using BusinessObject.Models;

namespace Repository
{
    public interface ICategoryRepo
    {
        public List<Category> GetAllCategory();
    }
}
