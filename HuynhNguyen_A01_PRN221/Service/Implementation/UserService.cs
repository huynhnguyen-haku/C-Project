using BusinessObject.Models;
using Repository;
using Repository.Implementation;

namespace Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo = null;
        public UserService()
        {
            userRepo = new UserRepo();
        }

        public void AddNewUser(User newUser) => userRepo.AddNewUser(newUser);

        public void AddNewUser2(User newUser) => userRepo.AddNewUser2(newUser);

        public string CreateUser(string email, string password, string confirmPass, string name, string city, string country, DateTime? birthday, string role)
        => userRepo.CreateUser(email, password, confirmPass, name, city, country, birthday, role);

        public void DeleteUser(int userId) => userRepo.DeleteUser(userId);

        public List<User?> FindUser(int findCase, string value) => userRepo.FindUser(findCase, value);

        public List<User?> GetAllUser() => userRepo.GetAllUser();

        public User GetUserById(int userId) => userRepo.GetUserById(userId);

        public User? Login(string email, string password) => userRepo.Login(email, password);

        public void UpdateUser(User newUser) => userRepo.UpdateUser(newUser);

        public string UpdateUser(User oldUser, string email, string oldPassword, string password, string confirmPass, string name, string city, string country, DateTime? birthday)
        => userRepo.UpdateUser(oldUser, email, oldPassword, password, confirmPass, name, city, country, birthday);
    }
}
