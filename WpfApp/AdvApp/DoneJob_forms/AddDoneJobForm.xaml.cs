using System.Windows;

namespace AdvApp.Customer_forms
{
    /* Окно c добавлением заказчиков */
    public partial class AddCustomerForm : Window
    {
        // Список заказчиков (получение переменных)
        public DoneJob NewCustomer { get; private set; }

        public AddCustomerForm()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            NewCustomer = new DoneJob();
        }

        // Добавление данных в Customer
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            bool PathId = int.TryParse(PathIdTextBox.Text, out int pathId);
            bool DriveId1 = int.TryParse(DriveId1TextBox.Text, out int driveId1);
            bool DriveId2 = int.TryParse(DriveId2TextBox.Text, out int driveId2);
            bool StartPath = !string.IsNullOrWhiteSpace(StartPathTextBox.Text);
            bool EndPath = !string.IsNullOrWhiteSpace(EndPathTextBox.Text);
            bool Pay = int.TryParse(PayTextBox.Text, out int pay);
            bool UpPay = int.TryParse(UpPayTextBox.Text, out int upPay);

            if (PathId && DriveId1 && DriveId2 && StartPath && EndPath && Pay && UpPay)
            {
                NewCustomer = new DoneJob
                {
                    PathId = pathId,
                    DriveId1 = driveId1,
                    DriveId2 = driveId2,
                    StartPath = StartPathTextBox.Text,
                    EndPath = EndPathTextBox.Text,
                    Pay = pay,
                    UpPay = upPay

                };

                base.DialogResult = true;
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные и попробуйте снова.", "Некорректные данные", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}