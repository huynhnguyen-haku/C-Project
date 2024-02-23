using BusinessObject.Models;
using Service.Implementation;
using Service;
using System.Windows;
using System.Windows.Controls;


namespace HuynhNguyenWPF
{

    public partial class ManagerView : Window
    {
        private User _user;
        private ShowName _currentShow;
        private IUserService _userService = new UserService();
        private List<User?> _listUsers = new();
        private ICarService _carService = new CarService();
        private List<Car?> _listCars = new();
        private List<Order> _listOrder = new();
        private List<OrderDetail> _listOrderDetails = new();
        private readonly IOrderService _orderService = new OrderService();
        private readonly IOrderDetailService _orderDetailService = new OrderDetailService();
        private int _indexSelect = -1;

        public ManagerView()
        {
            InitializeComponent();
        }

        private void Awake(object sender, RoutedEventArgs eventArgs)
        {
            ResetDisplay();
            CarBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
            _currentShow = ShowName.User;
            CarManagement.Visibility = Visibility.Visible;
            LoadAndShowAllCar();
            CarSearchType.SelectedIndex = -1;
            CarSearchType.Items.Clear();
            CarSearchType.Items.Add("By name");
            CarSearchType.Items.Add("By description");
            CarSearchType.SelectedIndex = 0;
        }


        private void OnClickOrder(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Order)
            {
                ResetDisplay();
                OrderBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                _currentShow = ShowName.Order;
                OrderManagement.Visibility = Visibility.Visible;
                LoadDataOrder();
                ShowOrder();
            }
        }

        private void OnClickCar(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Car)
            {
                ResetDisplay();
                CarBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                _currentShow = ShowName.Car;
                CarManagement.Visibility = Visibility.Visible;
                LoadAndShowAllCar();
                CarSearchType.SelectedIndex = -1;
                CarSearchType.Items.Clear();
                CarSearchType.Items.Add("By Name");
                CarSearchType.Items.Add("By Description");
                CarSearchType.SelectedIndex = 0;
            }
        }

        private void OnClickReport(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Report)
            {
                ResetDisplay();
                ReportBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                _currentShow = ShowName.Report;
                ReportManagement.Visibility = Visibility.Visible;
                LoadAndShowAllCar();
                ReportStart.SelectedDate = DateTime.Today;
                ReportEnd.SelectedDate = DateTime.Today;
            }
        }

        private void ResetDisplay()
        {
            OrderManagement.Visibility = Visibility.Collapsed;
            CarManagement.Visibility = Visibility.Collapsed;
            ReportManagement.Visibility = Visibility.Collapsed;
            _indexSelect = -1;
            switch (_currentShow)
            {
                case ShowName.Order:
                    OrderBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                    break;
                case ShowName.Car:
                    CarBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                    CarView.SelectedIndex = -1;
                    break;
                case ShowName.Report:
                    ReportBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                    break;
            }
        }

        private enum ShowName
        {
            User,
            Order,
            Car,
            Report
        }

        private void ClearOrderDetail()
        {
            OrderDetailView.ItemsSource = null;
        }

        private void ShowOrderDetail()
        {
            var viewModel = _listOrderDetails.Select(detail => new OrderDetailViewModel(detail.OrderId, GetCarName(detail.CarId), detail.UnitPrice, detail.Quantity, detail.Discount)).ToList();
            OrderDetailView.ItemsSource = viewModel;
        }

        private void ShowOrder()
        {
            OrderView.ItemsSource = _listOrder;
        }

        private void LoadDataOrder()
        {
            try
            {
                _listOrder = _orderService.GetAllOrders();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        private void LoadDataOrderDetail(int id)
        {
            if (id == -1)
            {
                _listOrderDetails = new List<OrderDetail>();
            }
            try
            {
                _listOrderDetails = _orderDetailService.GetOrderDetailByOrderId(id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        private void ShowOrderReportRaw()
        {
            ReportView.ItemsSource = _listOrder;
            TotalProfit.Text = _listOrder.Sum(p => p.Total).ToString();
        }

        private void ShowOrderRenameSort()
        {
            var sortedList = _listOrder.OrderByDescending(p => p.Total).ToList();
            ReportView.ItemsSource = sortedList;
        }

        private void LoadDataReport()
        {
            _listOrder = _orderService.GetDataInRange(ReportStart.SelectedDate.Value, ReportEnd.SelectedDate.Value, out var message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "ERROR");
            }
        }

        private void LoadAndShowAllCar()
        {
            try
            {
                _listCars = _carService.GetAllCar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
            CarView.ItemsSource = _listCars;
        }

        private string GetCarName(int id)
        {
            try
            {
                return _carService.GetCarName(id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
                return "";
            }
        }

        private void ShowAllCar()
        {
            try
            {
                CarView.ItemsSource = _listCars;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }


        private void OnClickSearchCar(object sender, RoutedEventArgs routedEventArgs)
        {
            try
            {
                _listCars = _carService.FindCar(CarSearchType.SelectedIndex, SearchValueCar.Text);
                ShowAllCar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR");
            }
        }

        private void OnClickShowAllCar(object sender, RoutedEventArgs e)
        {
            LoadAndShowAllCar();
        }

        private void OnClickDeleteCar(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure to delete " + _listCars[_indexSelect].CarName, "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _carService.DeleteCar(_listCars[_indexSelect].CarId);
                        MessageBox.Show("Delete successfully ", "Notification");
                        LoadAndShowAllCar();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Delete fail: " + exception.Message, "ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a car", "Warning");
            }
        }

        private void OnClickUpdateCar(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                CarEditor carEditor = new CarEditor(_listCars[_indexSelect], OnFinishEditCar);
                carEditor.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Please select a car", "Warning");
            }
        }

        private void OnClickAddNewCar(object sender, RoutedEventArgs e)
        {
            CarEditor carEditor = new CarEditor(null, OnFinishEditCar);
            carEditor.Show();
            Hide();
        }

        private void OnFinishEditCar()
        {
            Show();
            LoadAndShowAllCar();
            _indexSelect = -1;
            CarView.SelectedIndex = -1;
        }

        private void OnSelectionChangedCar(object sender, SelectionChangedEventArgs e)
        {
            _indexSelect = CarView.SelectedIndex;
        }

        private void OnChangeSelectedOrder(object sender, SelectionChangedEventArgs e)
        {
            if (_indexSelect != OrderView.SelectedIndex)
            {
                _indexSelect = OrderView.SelectedIndex;
                LoadDataOrderDetail(_listOrder[_indexSelect].OrderId);
                ShowOrderDetail();
            }
        }

        private void OnClickShowAllOrder(object sender, RoutedEventArgs e)
        {
            LoadDataOrder();
            ShowOrder();
        }

        private void OnClickDeleteOrder(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure to delete " + _listOrder[_indexSelect].OrderId, "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _orderService.DeleteOrder(_listOrder[_indexSelect].OrderId);
                        MessageBox.Show("Delete successfully ", "Notification");
                        LoadDataOrder();
                        ShowOrder();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Delete fail: " + exception.Message, "ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order", "Warning");
            }
        }

        private void OnClickUpdateOrder(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                OrderEditor orderEditor = new OrderEditor(_listOrder[_indexSelect], OnFinishEditOrder);
                orderEditor.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Please select an order", "Warning");
            }
        }

        private void OnClickAddNewOrder(object sender, RoutedEventArgs e)
        {
            OrderEditor orderEditor = new OrderEditor(OnFinishEditOrder);
            orderEditor.Show();
            Hide();
        }

        private void OnFinishEditOrder()
        {
            Show();
            LoadDataOrder();
            ShowOrder();
            _indexSelect = -1;
            OrderView.SelectedIndex = -1;
            ShowOrderDetail();
        }

        private void OnClickSearchReport(object sender, RoutedEventArgs e)
        {
            LoadDataReport();
            ShowOrderReportRaw();
        }

        private void OnClickSortReport(object sender, RoutedEventArgs e)
        {
            ShowOrderRenameSort();
        }

        private void OnClickLogout(object sender, RoutedEventArgs e)
        {
            LogOut();
        }

        private void LogOut()
        {
            Login login = new Login();
            login.Show();
            _user = null;
            Close();
        }
    }
}
