using BusinessObject.Models;
using Service;
using Service.Implementation;
using System.Windows;
using System.Windows.Controls;


namespace HuynhNguyenWPF
{
    public partial class OrderEditor : Window
    {
        private readonly bool _isUpdate;
        private Order? _updateOrder;
        private List<Car> _listCar = new();
        private List<User?> _listUser = new();
        private List<OrderDetail> _listOrderDetail = new();

        private IUserService _userService = new UserService();
        private ICarService _carService = new CarService();
        private IOrderService _orderService = new OrderService();
        private IOrderDetailService _orderDetailService = new OrderDetailService();

        private Action _onFinish;

        public OrderEditor()
        {
            _updateOrder = null;
            _isUpdate = false;
            InitializeComponent();
        }

        public OrderEditor(Action onFinish)
        {
            InitializeComponent();
            _onFinish = onFinish;
            _updateOrder = null;
            _isUpdate = false;
        }

        public OrderEditor(Order updateOrder, Action onFinish)
        {
            InitializeComponent();
            _updateOrder = updateOrder;
            _onFinish = onFinish;
            _isUpdate = true;
        }

        private void ShowAllCar()
        {
            CarView.ItemsSource = _listCar;
        }

        private void ShowAllUser()
        {
            UserName.Items.Add("None");
            foreach (var user in _listUser)
            {
                UserName.Items.Add(user.UserName);
            }
        }


        private void ShowAllOrderDetail()
        {
            OrderDetailView.ItemsSource = null;
            OrderDetailView.ItemsSource = _listOrderDetail;
            decimal totalPrice = 0;
            foreach (var orderDetail in _listOrderDetail)
            {
                totalPrice += (orderDetail.UnitPrice * decimal.Parse(orderDetail.Quantity.ToString()));
            }

            TotalPrice.Text = totalPrice.ToString();
        }

        // Controller

        private void LoadCar()
        {
            _listCar = _carService.GetAllCar();
        }

        private void LoadUser()
        {
            _listUser = _userService.GetAllUser();
        }

        private void LoadOderDetails()
        {
            _listOrderDetail = _orderDetailService.GetOrderDetailByOrderId(_updateOrder.OrderId);
        }

        private void OnUnload(object sender, RoutedEventArgs e)
        {
            _onFinish.Invoke();
        }

        // Event
        private void Awake(object sender, RoutedEventArgs e)
        {
            LoadUser();
            LoadCar();
            ShowAllUser();
            ShowAllCar();
            ShipDate.DisplayDateStart = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0));
            if (_isUpdate)
            {
                LoadOderDetails();
                ShowAllOrderDetail();
                ShipDate.SelectedDate = _updateOrder.ShippedDate;
                if (_updateOrder.UserId != null)
                {
                    var index = -1;

                    foreach (var user in _listUser)
                    {
                        if (user.UserId == _updateOrder.UserId)
                        {
                            index++;
                            break;
                        }


                    }

                    UserName.SelectedIndex = index + 1;
                }
            }
            InitCheckBox();
        }

        private void InitCheckBox()
        {
            if (ShipDate.SelectedDate == null || ShipDate.SelectedDate > DateTime.Now)
            {
                IsShipped.IsChecked = false;
            }
            else
            {
                if (_updateOrder.OrderStatus.ToUpper().Contains("DONE"))
                {
                    IsShipped.IsChecked = true;
                }
            }
        }

        private void CreateOrder()
        {
            if (_listOrderDetail.Count == 0)
            {
                MessageBox.Show("List order detail cannot null", "ERROR");
                return;
            }

            int? userId = UserName.SelectedIndex > 0
                ? _listUser[UserName.SelectedIndex - 1].UserId
                : null;


            var orderId = _orderService.AddOrder(userId, ShipDate.SelectedDate, TotalPrice.Text, "Shipping",
                out var message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "ERROR");
                return;
            }

            foreach (var orderDetail in _listOrderDetail)
            {
                orderDetail.OrderId = orderId;
            }

            try
            {
                _orderDetailService.AddOrderDetail(_listOrderDetail);
            }
            catch (Exception exception)
            {
                _orderService.DeleteOrder(orderId);
                MessageBox.Show(exception.Message, "ERROR");
                return;
            }

            MessageBox.Show("Create successfully");
            Close();
        }

        private void UpdateOrder()
        {
            if (_listOrderDetail.Count == 0)
            {
                MessageBox.Show("List order detail cannot null", "ERROR");
                return;
            }

            int? customerId = UserName.SelectedIndex > 0
                ? _listUser[UserName.SelectedIndex - 1].UserId
                : null;

            var orderId = _orderService.UpdateOrder(_updateOrder, customerId, ShipDate.SelectedDate, TotalPrice.Text,
                IsShipped.IsChecked == true ? "Done" : "Shipping",
                out var message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "ERROR");
                return;
            }

            foreach (var orderDetail in _listOrderDetail)
            {
                orderDetail.OrderId = orderId;
            }

            try
            {

                _orderDetailService.UpdateOrderDetail(_listOrderDetail);
            }
            catch (Exception exception)
            {
                _orderService.DeleteOrder(orderId);
                MessageBox.Show(exception.Message, "ERROR");
                return;
            }

            MessageBox.Show("Update successfully");
            Close();
        }

        private void OnClickSubmit(object sender, RoutedEventArgs e)
        {
            if (_isUpdate)
            {
                UpdateOrder();
            }
            else
            {
                CreateOrder();
            }
        }

        private void OnChangeSelectedCar(object sender, SelectionChangedEventArgs e)
        {
        }

        private void OnClickCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnClickRemove(object sender, RoutedEventArgs e)
        {
            if (CarView.SelectedIndex != -1)
            {
                foreach (var orderDetail in _listOrderDetail)
                {
                    if (orderDetail.CarId == _listCar[CarView.SelectedIndex].CarId)
                    {
                        orderDetail.Quantity--;
                        break;
                    }
                }
            }

            OrderDetail removeItem = null;
            foreach (var orderDetail in _listOrderDetail)
            {
                if (orderDetail.Quantity <= 0)
                {
                    removeItem = orderDetail;
                }
            }

            if (removeItem != null)
            {
                _listOrderDetail.Remove(removeItem);
            }


            ShowAllOrderDetail();
        }

        private void OnClickAdd(object sender, RoutedEventArgs e)
        {
            if (CarView.SelectedIndex != -1)
            {
                foreach (var orderDetail in _listOrderDetail)
                {
                    if (orderDetail.CarId == _listCar[CarView.SelectedIndex].CarId)
                    {
                        orderDetail.Quantity++;
                        ShowAllOrderDetail();
                        return;
                    }
                }

                _listOrderDetail.Add(new OrderDetail()
                {
                    Discount = 0,
                    CarId = _listCar[CarView.SelectedIndex].CarId,
                    OrderId = -1,
                    UnitPrice = _listCar[CarView.SelectedIndex].UnitPrice,
                    Quantity = 1
                });
            }

            ShowAllOrderDetail();
        }

        private void OnClickRemoveAll(object sender, RoutedEventArgs e)
        {
            _listOrderDetail = new List<OrderDetail>();
            ShowAllOrderDetail();
        }

        private void OnClickRemoveOne(object sender, RoutedEventArgs e)
        {
        }

        private void OnChangeSelectedDetails(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
