using System.Windows;

namespace AdvApp.Show_forms
{
    /* Редактирование данных передачи */
    public partial class EditShowForm : Window
    {
        // Список передач (получение переменных)
        public Drivers UpdatedShow { get; private set; }

        // Отображение исходных данных
        public EditShowForm(Drivers showToEdit)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            UpdatedShow = showToEdit;
            DriveIdTextBox.Text = showToEdit.DriveId.ToString();
            FirstNameTextBox.Text = showToEdit.FirstName;
            SecondNameTextBox.Text = showToEdit.SecondName.ToString();
            ThirdNameTextBox.Text = showToEdit.ThirdName.ToString();
            ExperTextBox.Text = showToEdit.Exper.ToString();
        }

        // Сохранение новых данных в Show
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ThirdNameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(SecondNameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(FirstNameTextBox.Text) &&
                int.TryParse(DriveIdTextBox.Text, out var driveId) &&
                int.TryParse(ExperTextBox.Text, out var exper))
            {
                UpdatedShow.FirstName = FirstNameTextBox.Text;
                UpdatedShow.SecondName = SecondNameTextBox.Text;
                UpdatedShow.ThirdName = ThirdNameTextBox.Text;
                UpdatedShow.DriveId = driveId;
                UpdatedShow.Exper = exper;

                base.DialogResult = true;
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}