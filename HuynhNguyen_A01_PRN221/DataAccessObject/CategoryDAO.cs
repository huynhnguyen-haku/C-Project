using BusinessObject.Models;


namespace DataAccessObject
{
    public class CategoryDAO
    {
        private static CategoryDAO instance = null;
        private static object instanceLock = new object();  

        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }

        private readonly CarManagementContext _context = new CarManagementContext();
        public List<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }
    }
}
