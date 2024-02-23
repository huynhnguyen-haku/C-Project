using BusinessObject.Models;
using DataAccessObject;
using System.Text.RegularExpressions;

namespace Repository.Implementation
{
    public class UserRepo : IUserRepo
    {
        public void AddNewUser(User newUser)
        {
            UserDAO.Instance.AddUser(newUser);
        }

        public void AddNewUser2(User newUser)
        {
            UserDAO.Instance.AddUser2(newUser);
        }

        public string CreateUser(string email, string password, string confirmPass, string name, string city, string country, DateTime? birthday, string role)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPass) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(country))
            {
                return "Please fill in all fields";
            }

            if (!IsValidEmail(email))
            {
                return "Email not valid, must contain '@'";
            }

            if (email.Length > 30)
            {
                return "Email too long, below 30 characters";
            }

            if (email.Contains(" "))
            {
                return "Email contains special characters";
            }

            if (!IsValidEmailTail(email))
            {
                return "Email tail not valid or email contains special characters";
            }

            if (name.Length > 30)
            {
                return "Name too long, below 30 characters";
            }

            if (city.Length > 30)
            {
                return "City too long, below 30 characters";
            }

            if (country.Length > 30)
            {
                return "Country too long, below 30 characters";
            }

            if (!password.Equals(confirmPass))
            {
                return "Password does not match";
            }

            if (password.Length < 8)
            {
                return "Password is too short, at least 8 characters";
            }

            if (!HasDigit(password))
            {
                return "Password must have at least one digit";
            }

            if (!HasLetter(password))
            {
                return "Password must have at least one letter";
            }

            UserDAO.Instance.AddUser(new User()
            {
                Birthday = birthday,
                City = city,
                Country = country,
                UserName = name,
                Email = email,
                Password = password,
                Role = role
            });

            return "";
        }

        public void DeleteUser(int userId)
        {
            UserDAO.Instance.DeleteUser(userId);
        }

        public List<User?> FindUser(int findCase, string value)
        {
            switch (findCase)
            {
                case 0:
                    {
                        return UserDAO.Instance.GetUserByName(value);
                    }
                case 1:
                    {
                        return UserDAO.Instance.GetUserByEmail(value);
                    }
                case 2:
                    {
                        var newList = new List<User?>();
                        var user = UserDAO.Instance.GetUserById(int.Parse(value));
                        if (user != null)
                        {
                            newList.Add(user);
                        }

                        return newList;
                    }
            }

            return null;
        }

        public List<User?> GetAllUser()
        {
            return UserDAO.Instance.GetAllUser();
        }

        public User GetUserById(int userId)
        {
            return UserDAO.Instance.GetUserById(userId);
        }

        public User? Login(string email, string password)
        {
            var userList = UserDAO.Instance.GetAllUser();
            foreach (var user in userList)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        public void UpdateUser(User newUser)
        {
            UserDAO.Instance.UpdateUser(newUser);
        }

        public string UpdateUser(User oldUser, string email, string oldPassword, string password, string confirmPass, string name, string city, string country, DateTime? birthday)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(city) || string.IsNullOrEmpty(country))
            {
                return "Please fill all required information!";
            }

            if (!oldUser.Email.Equals(email))
            {
                if (!IsValidEmail(email))
                {
                    return "Email not valid, must contain '@'";
                }

                if (email.Length > 30)
                {
                    return "Email too long, below 30 characters";
                }

                if (email.Contains(" "))
                {
                    return "Email contains special characters";
                }

                if (!IsValidEmailTail(email))
                {
                    return "Email tail not valid or email contains special characters";
                }
            }

            if (name.Length > 30)
            {
                return "Name too long, below 30 characters";
            }

            if (city.Length > 30)
            {
                return "City too long, below 30 characters";
            }

            if (country.Length > 30)
            {
                return "Country too long, below 30 characters";
            }

            var isEditPass = !string.IsNullOrEmpty(oldPassword) || !string.IsNullOrEmpty(password) || !string.IsNullOrEmpty(confirmPass);
            if (isEditPass)
            {
                if (!oldUser.Password.Equals(oldPassword))
                {
                    return "Old password is not correct";
                }

                if (!password.Equals(confirmPass))
                {
                    return "Password does not match";
                }

                if (password.Length < 8)
                {
                    return "Password is too short, at least 8 characters";
                }

                if (!HasDigit(password))
                {
                    return "Password must have at least one digit";
                }

                if (!HasLetter(password))
                {
                    return "Password must have at least one letter";
                }
            }

            oldUser.Email = email;
            oldUser.UserName = name;
            oldUser.Password = isEditPass ? password : oldUser.Password;
            oldUser.City = city;
            oldUser.Country = country;
            oldUser.Birthday = birthday;

            UserDAO.Instance.UpdateUser(oldUser);
            return "";
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains("@");
        }

        private bool IsValidEmailTail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private bool HasDigit(string password)
        {
            return Regex.IsMatch(password, @"\d");
        }

        private bool HasLetter(string password)
        {
            return Regex.IsMatch(password, @"[a-zA-Z]");
        }
    }
}
