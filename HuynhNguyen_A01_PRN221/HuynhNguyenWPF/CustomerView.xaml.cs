using BusinessObject.Models;
using Service;
using Service.Implementation;
using System.Windows;
using System.Windows.Controls;


namespace HuynhNguyenWPF
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        private User _user;
        private List<Order> _orders = new();
        private List<OrderDetail> _orderDetails = new();
        private readonly IOrderService _orderService = new OrderService();
        private readonly IOrderDetailService _orderDetailService = new OrderDetailService();
        private readonly ICarService _carService = new CarService();
        private IUserService _userService = new UserService();
        private int _orderSelectIndex = -1;

        public CustomerView()
        {
            InitializeComponent();
        }

        public CustomerView(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void Awake(object sender, RoutedEventArgs e)
        {
            if (_user == null)
            {
                LogOut();
            }
            else
            {
                UserDisplayName.Text = _userService.GetUserById(_user.UserId).UserName;
                LoadDataOrder();
                UpdateOrderListView();
            }
        }

        private void LoadDataOrder()
        {
            try
            {
                _orders = _orderService.GetOrderByUser(_user.UserId);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        private void UpdateOrderListView()
        {
            OrderView.ItemsSource = _orders ?? throw new Exception("You do not have any order");
        }

        private void LoadDataOrderDetail(int id)
        {
            try
            {
                _orderDetails = _orderDetailService.GetOrderDetailById(id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        private void UpdateOrderDetailListView()
        {
            var viewModel = new List<OrderDetailViewModel>();
            foreach (OrderDetail detail in _orderDetails)
            {
                viewModel.Add(new OrderDetailViewModel(detail.OrderId, GetCarName(detail.CarId), detail.UnitPrice, detail.Quantity, detail.Discount));
            }

            OrderDetailView.ItemsSource = viewModel;
        }

        private string GetCarName(int id)
        {
            try
            {
                return _carService.GetCarName(id) ?? "";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
                return "";
            }
        }

        private void LogOut()
        {
            Login login = new Login();
            login.Show();
            _user = null;
            Close();
        }

        private void OnFinishUpdate(User? newUser)
        {
            if (newUser == null)
            {
                Show();
                return;
            }

            _user = newUser;
            UserDisplayName.Text = _userService.GetUserById(_user.UserId).UserName;
            LoadDataOrder();
            UpdateOrderListView();
        }

        private void OnClickUpdate(object sender, RoutedEventArgs e)
        {
            UserEditor userEditor = new UserEditor(_user, OnFinishUpdate);
            userEditor.Show();
            Hide();
        }

        private void OnClickLogOut(object sender, RoutedEventArgs e)
        {
            LogOut();
        }

        private void OnChangeSelectedOrder(object sender, SelectionChangedEventArgs e)
        {
            if (_orderSelectIndex != OrderView.SelectedIndex)
            {
                _orderSelectIndex = OrderView.SelectedIndex;
                LoadDataOrderDetail(_orders[_orderSelectIndex].OrderId);
                UpdateOrderDetailListView();
            }
        }
    }
    public class OrderDetailViewModel
    {
        public int OrderId { get; set; }
        public string CarName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public OrderDetailViewModel(int orderId, string carName, decimal unitPrice, int quantity, double discount)
        {
            OrderId = orderId;
            CarName = carName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
        }
    }

}
