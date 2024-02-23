using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace DataAccessObject
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static object instanceLock = new object();

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }

        readonly CarManagementContext _context = new CarManagementContext();

        public List<User?> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public void AddUser(User user)
        {
            var maxId = _context.Users.Max(c => c.UserId);
            user.UserId = maxId + 1;

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool AddUser2(User user)
        {
            using (StreamReader r = new StreamReader("appsettings.json"))
            {
                string json = r.ReadToEnd();
                IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
                string name = config["account:defaultAccount:Email"];

                if (user.Email.ToUpper().Equals(name.ToUpper()))
                {
                    return false; // not valid email
                }
            }

            var maxId = _context.Users.Max(c => c.UserId);
            user.UserId = maxId + 1;

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Where(c => c.UserId == id).ToList()[0];
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            var tmp = _context.Users.Where(c => c.UserId == id).ToList();
            if (tmp.Count > 0)
            {
                return tmp[0];
            }
            return null;
        }

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.UserId);
            if (existingUser != null)
            {
                _context.Entry(existingUser).State = EntityState.Detached;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public List<User?> GetUserByEmail(string email)
        {
            return _context.Users.Where(c => c.Email.ToUpper().Contains(email.ToUpper())).ToList();
        }

        public List<User?> GetUserByName(string name)
        {
            return _context.Users.Where(c => c.UserName.ToUpper().Contains(name.ToUpper())).ToList();
        }
    }
}
