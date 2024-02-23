using Service;
using Service.Implementation;
using System.Windows;


namespace HuynhNguyenWPF
{

    public partial class Login : Window
    {
        private IUserService _userService = new UserService();
        public Login()
        {
            InitializeComponent();
        }

        private void OnClickLogin(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = _userService.Login(txt_Email.Text, txt_Password.Password);
                if (user != null)
                {
                    string greeting;
                    if (user.Role == "Admin")
                    {
                        greeting = "Hello admin";
                        AdminView adminView = new AdminView();
                        adminView.Show();
                        this.Close();
                    }
                    else if (user.Role == "Manager")
                    {
                        greeting = "Hello manager";
                        ManagerView managerView = new ManagerView();
                        managerView.Show();
                        this.Close();
                    }
                    else
                    {
                        greeting = "Hello customer";
                        CustomerView customerview = new CustomerView(user);
                        customerview.Show();
                        this.Close();
                    }
                    MessageBox.Show(greeting);
                }
                else
                {
                    MessageBox.Show("Login fail");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void OnClickRegister(object sender, RoutedEventArgs e)
        {
            UserEditor userEditor = new UserEditor();
            userEditor.Show();
            this.Close();
        }

    }
}