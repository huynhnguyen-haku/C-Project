using BusinessObject.Models;
using Service;
using Service.Implementation;
using System.Windows;

namespace HuynhNguyenWPF
{
    /// <summary>
    /// Interaction logic for CarEditor.xaml
    /// </summary>
    public partial class CarEditor : Window
    {
        private readonly Action _onFinish;
        private readonly Car _updateCar;
        private readonly bool _isUpdate;
        private readonly ICarService _carService = new CarService();
        private readonly ICategoryService _categoryService = new CategoryService();

        private List<Category> _categories = new();

        public CarEditor()
        {
            InitializeComponent();
        }

        public CarEditor(Car? updateCar, Action onFinishUpdate)
        {
            InitializeComponent();
            _onFinish = onFinishUpdate;

            if (updateCar != null)
            {
                _updateCar = updateCar;
                ShowOldInformation();
                _isUpdate = true;
            }
            else
            {
                _isUpdate = false;
            }
        }

        private void Awake(object sender, RoutedEventArgs e)
        {
            InitCategoryComboBox();
            if (_isUpdate)
            {
                CarName.Text = _updateCar.CarName;
                CarDes.Text = _updateCar.Description;
                CarPrice.Text = _updateCar.UnitPrice.ToString();
                CarUnitsInStock.Text = _updateCar.UnitsInStock.ToString();
                var index = -1;
                foreach (var cate in _categories)
                {
                    index++;
                    if (cate.CategoryId == _updateCar.CategoryId)
                    {
                        Category.SelectedIndex = index;
                        break;
                    }
                }
            }
        }

        private void InitCategoryComboBox()
        {
            _categories = _categoryService.GetAllCategory();
            List<string> displayString = new();
            foreach (var category in _categories)
            {
                displayString.Add(category.CategoryName);
            }

            Category.ItemsSource = displayString;
        }

        private int GetCategoryId()
        {
            return Category.SelectedIndex == -1 ? -1 : _categories[Category.SelectedIndex].CategoryId;
        }

        private void ShowOldInformation()
        {
        }

        private void OnClickSubmit(object sender, RoutedEventArgs e)
        {
            if (_isUpdate)
            {
                UpdateCar();
            }
            else
            {
                CreateCar();
            }
        }

        private void UpdateCar()
        {
            try
            {
                var message = _carService.UpdateCar(_updateCar, GetCategoryId(), CarName.Text,
                    CarDes.Text, CarPrice.Text, CarUnitsInStock.Text);
                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message, "ERROR");
                    return;
                }

                MessageBox.Show("Update successfully");
                _onFinish?.Invoke();
                Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        private void CreateCar()
        {
            try
            {
                var message = _carService.CreateCar(GetCategoryId(), CarName.Text,
                    CarDes.Text, CarPrice.Text, CarUnitsInStock.Text);
                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message, "ERROR");
                    return;
                }

                MessageBox.Show("Create successfully");
                _onFinish?.Invoke();
                Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        private void CarEditor_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _onFinish?.Invoke();
        }
    }
}
