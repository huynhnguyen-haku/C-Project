using BusinessObject.Models;

namespace Service
{
    public interface IUserService
    {
        public void AddNewUser(User newUser);
        public void AddNewUser2(User newUser);
        public void UpdateUser(User newUser);
        public void DeleteUser(int userId);
        public List<User?> GetAllUser();
        public User GetUserById(int userId);
        public User? Login(string email, string password);
        
        public string CreateUser(string email, string password, string confirmPass, string name, string city, string country, DateTime? birthday, string role);
        public string UpdateUser(User oldUser, string email, string oldPassword, string password, string confirmPass, string name, string city, string country, DateTime? birthday);
        public List<User?> FindUser(int findCase, string value);
    }
}
