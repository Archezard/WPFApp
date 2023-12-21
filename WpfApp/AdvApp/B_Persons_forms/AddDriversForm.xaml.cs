using System.Windows;
using System.Windows.Controls;

namespace AdvApp.Show_forms
{
    /* Окно c добавлением водителей */
    public partial class AddShowForm : Window
    {
        // Список водителей (получение переменных)
        public Drivers NewShow { get; private set; }

        public AddShowForm()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            NewShow = new Drivers();
        }

        // Добавление данных в Drivers
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SecondNameTextBox.Text) &&
                int.TryParse(DriveIdTextBox.Text, out var id) &&
                !string.IsNullOrWhiteSpace(ThirdNameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(FirstNameTextBox.Text) &&
                int.TryParse(ExperTextBox.Text, out var exper))
            {
                NewShow = new Drivers
                {
                    DriveId = id,
                    FirstName = FirstNameTextBox.Text,
                    SecondName = SecondNameTextBox.Text,
                    ThirdName = ThirdNameTextBox.Text,
                    Exper = exper
                };

                base.DialogResult = true;
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные и попробуйте снова.", "Некорректные данные", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        private void ShowIdTextBox_TextChanged(object sender, TextChangedEventArgs e) { }
    }
}