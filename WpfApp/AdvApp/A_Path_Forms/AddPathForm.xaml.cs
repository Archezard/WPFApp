using System.Windows;

namespace AdvApp
{
    /* Окно c добавлением рекламы */
    public partial class AddAdvertisementForm : Window
    {
        // Список реклам (получение переменных)
        public Advertisement NewAdvertisement { get; private set; }

        public AddAdvertisementForm()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        // Добавление данных в Advertisement
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PathIdTextBox.Text, out var pathId) &&
                !string.IsNullOrWhiteSpace(PathNameTextBox.Text) &&
                int.TryParse(LenPathTextBox.Text, out var lenPath) &&
                int.TryParse(PathDaysTextBox.Text, out var pathDays) &&
                int.TryParse(PathPayTextBox.Text, out var pathPay))
            {
                NewAdvertisement = new Advertisement
                {
                    PathId = pathId,
                    PathName = PathNameTextBox.Text,
                    LenPath = lenPath,
                    PathDays = pathDays,
                    PathPay = pathPay
                };

                base.DialogResult = true;
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}