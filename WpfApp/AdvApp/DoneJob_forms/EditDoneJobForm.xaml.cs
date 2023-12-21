using System.Windows;

namespace AdvApp.Customer_forms
{
    /* Редактирование данных заказчиков */
    public partial class EditCustomerForm : Window
    {
        // Список реклам (получение переменных)
        public DoneJob UpdatedCustomer { get; private set; }

        // Отображение исходных данных
        public EditCustomerForm(DoneJob customerToEdit)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            UpdatedCustomer = customerToEdit;
            PathIdTextBox.Text = customerToEdit.PathId.ToString();
            DriveId1TextBox.Text = customerToEdit.DriveId1.ToString();
            DriveId2TextBox.Text = customerToEdit.DriveId2.ToString();
            StartPathTextBox.Text = customerToEdit.StartPath;
            EndPathTextBox.Text = customerToEdit.EndPath;
            PayTextBox.Text = customerToEdit.Pay.ToString();
            UpPayTextBox.Text = customerToEdit.UpPay.ToString();
        }

        // Сохранение новых данных в Customer
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PathIdTextBox.Text, out int pathId) &&
             int.TryParse(DriveId1TextBox.Text, out int driveId1) &&
             int.TryParse(DriveId2TextBox.Text, out int driveId2) &&
             !string.IsNullOrWhiteSpace(StartPathTextBox.Text) &&
             !string.IsNullOrWhiteSpace(EndPathTextBox.Text) &&
             int.TryParse(PayTextBox.Text, out int pay) &&
            int.TryParse(UpPayTextBox.Text, out int upPay))
            {
                UpdatedCustomer.PathId = pathId;
                UpdatedCustomer.DriveId1 = driveId1;
                UpdatedCustomer.DriveId2 = driveId2;
                UpdatedCustomer.StartPath = StartPathTextBox.Text;
                UpdatedCustomer.EndPath = EndPathTextBox.Text;
                UpdatedCustomer.Pay = pay;
                UpdatedCustomer.UpPay = upPay;

                base.DialogResult = true;
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}