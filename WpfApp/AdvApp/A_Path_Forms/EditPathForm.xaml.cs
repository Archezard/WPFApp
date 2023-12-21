using System.Windows;

namespace AdvApp
{
    /* Редактирование данных рекламы */
    public partial class EditAdvertisementForm : Window
    {
        // Список реклам (получение переменных)
        public Advertisement UpdatedAdvertisement { get; set; }

        // Отображение исходных данных
        public EditAdvertisementForm(Advertisement advertisementToEdit)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            UpdatedAdvertisement = advertisementToEdit;
            PathIdTextBox.Text = advertisementToEdit.PathId.ToString();
            PathNameTextBox.Text = advertisementToEdit.PathName.ToString();
            LenPathTextBox.Text = advertisementToEdit.LenPath.ToString();
            PathDaysTextBox.Text = advertisementToEdit.PathDays.ToString();
            PathPayTextBox.Text = advertisementToEdit.PathPay.ToString();
        }

        // Сохранение новых данных в Advertisement
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PathIdTextBox.Text, out var pathId) &&
                !string.IsNullOrWhiteSpace(PathNameTextBox.Text) &&
                int.TryParse(LenPathTextBox.Text, out var lenPath) &&
                int.TryParse(PathDaysTextBox.Text, out var pathDays) &&
                int.TryParse(PathPayTextBox.Text, out var pathPay))
            {
                UpdatedAdvertisement.PathId = pathId;
                UpdatedAdvertisement.PathName = PathNameTextBox.Text;
                UpdatedAdvertisement.LenPath = lenPath;
                UpdatedAdvertisement.PathDays = pathDays;
                UpdatedAdvertisement.PathPay = pathPay;

                base.DialogResult = true;
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}