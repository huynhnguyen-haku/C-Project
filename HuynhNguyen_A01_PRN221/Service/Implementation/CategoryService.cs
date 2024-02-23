using BusinessObject.Models;
using Repository;
using Repository.Implementation;

namespace Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo categoryRepo = null;

        public CategoryService()
        {
            categoryRepo = new CategoryRepo();
        }

        public List<Category> GetAllCategory() => categoryRepo.GetAllCategory();
    }

}

