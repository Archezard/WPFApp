using System.Windows;
using AdvApp.Customer_forms;
using AdvApp.Show_forms;
using AdvApp.User_forms;

/* Главное меню с кнопками */
namespace AdvApp
{
    public partial class MainMenu : Window
    {
        private MainWindow mainWindow;

        public MainMenu(string userName, MainWindow mainWindow)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.mainWindow = mainWindow;

            UserLabel.Content = "Пользователь: " + userName;

            if (userName.ToLower() != "администратор") addUserButton.Visibility = Visibility.Collapsed;
        }

        // Маршруты
        private void ShowsForm_Button(object sender, RoutedEventArgs e)
        {
            ShowForm form = new ShowForm();

            form.ShowDialog();
        }

        // Водители
        private void AdvertisementsForm_Button(object sender, RoutedEventArgs e)
        {
            AdvertisementForm advForm = new AdvertisementForm();

            advForm.ShowDialog();
        }

        // Активные Пути
        private void CustomersForm_Button(object sender, RoutedEventArgs e)
        {
            CustomerForm form = new CustomerForm();

            form.ShowDialog();
        }


        // Пользователи
        private void Users_Button(object sender, RoutedEventArgs e)
        {
            UserForm form = new UserForm();

            form.ShowDialog();
        }

        // Возврат к авторизации
        private void MainMenu_Closed(object sender, EventArgs e)
        {
            mainWindow.Show();
        }
    }
}