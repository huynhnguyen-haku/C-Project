using BusinessObject.Models;
using Service;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HuynhNguyenWPF
{

    public partial class UserEditor : Window
    {
        private readonly User _updateUser;
        private readonly Action<User> _onFinish;
        private bool _isUpdate;
        private readonly IUserService _userService = new UserService();

        public UserEditor()
        {
            InitializeComponent();
        }

        public UserEditor(User? user, Action<User> onFinish)
        {
            InitializeComponent();
            _onFinish = onFinish;
            _updateUser = user;
        }

        private void Awake(object sender, RoutedEventArgs e)
        {
            if (_updateUser != null)
            {
                Title.Text = "Customer Update";
                _isUpdate = true;
                InitUpdateView();
            }
            else
            {
                InitCreateView();
                Title.Text = "Customer Creator";
            }
        }

        private void InitCreateView()
        {
            OldPassword.Visibility = Visibility.Collapsed;
            OldPasswordText.Visibility = Visibility.Collapsed;
            CreateSms1.Visibility = Visibility.Visible;
            CreateSms2.Visibility = Visibility.Visible;
            CreateSms3.Visibility = Visibility.Visible;
            UpdateSms1.Visibility = Visibility.Collapsed;
            UpdateSms2.Visibility = Visibility.Collapsed;
            UpdateSms3.Visibility = Visibility.Collapsed;
        }

        private void InitUpdateView()
        {
            OldPassword.Visibility = Visibility.Visible;
            OldPasswordText.Visibility = Visibility.Visible;
            CreateSms1.Visibility = Visibility.Collapsed;
            CreateSms2.Visibility = Visibility.Collapsed;
            CreateSms3.Visibility = Visibility.Collapsed;
            UpdateSms1.Visibility = Visibility.Visible;
            UpdateSms2.Visibility = Visibility.Visible;
            UpdateSms3.Visibility = Visibility.Visible;

            Email.Text = _updateUser.Email;
            Name.Text = _updateUser.UserName;
            City.Text = _updateUser.City;
            Country.Text = _updateUser.Country;
        }

        private void UpdateUser()
        {
            try
            {
                DateTime? birthday = BirthDay.SelectedDate;
                if (birthday == null)
                {
                    ShowErrorMessage("Please select a valid birthday");
                    return;
                }
                var message = _userService.UpdateUser(_updateUser, Email.Text, OldPassword.Password, Password.Password, ConfirmPassword.Password,
                    Name.Text, City.Text, Country.Text, birthday.Value);
                if (!string.IsNullOrEmpty(message))
                {
                    ShowErrorMessage(message);
                    return;
                }

                ShowSuccessMessage("Update successfully");
                _onFinish?.Invoke(_userService.GetUserById(_updateUser.UserId));
                Close();
            }
            catch (Exception e)
            {
                ShowErrorMessage(e.Message);
            }
        }

        private void CreateUser()
        {
            try
            {
                DateTime? birthday = BirthDay.SelectedDate;
                if (birthday == null)
                {
                    ShowErrorMessage("Please select a valid birthday");
                    return;
                }

                var message = _userService.CreateUser(Email.Text, Password.Password, ConfirmPassword.Password,
                    Name.Text, City.Text, Country.Text, birthday.Value, "Customer");
                if (!string.IsNullOrEmpty(message))
                {
                    ShowErrorMessage(message);
                    return;
                }

                ShowSuccessMessage("Create successfully");
                _onFinish?.Invoke(null);
                this.Close();
            }
            catch (Exception e)
            {
                ShowErrorMessage(e.Message);
            }
        }

        private void UserEditor_OnClosing(object sender, CancelEventArgs e)
        {
                _onFinish?.Invoke(null);
        }

        private void OnClickSubmit(object sender, RoutedEventArgs e)
        {
            if (_isUpdate)
            {
                UpdateUser();
            }
            else
            {
                CreateUser();
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "ERROR");
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
