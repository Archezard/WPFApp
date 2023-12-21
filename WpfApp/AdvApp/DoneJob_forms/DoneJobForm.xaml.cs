using System.Windows;
using System.Windows.Controls;

namespace AdvApp.Customer_forms
{
    /* Окно со списком заказчиков */
    public partial class CustomerForm : Window
    {
        // Список заказчиков
        private List<DoneJob> entities;

        public CustomerForm()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            entities = XmlDataManager.LoadData<DoneJob>("data/DoneJob.xml");
            dataGrid.ItemsSource = entities;
        }

        // Открытие окна с добавлением и отправить данные в таблицу
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerForm addAgentForm = new AddCustomerForm();

            if (addAgentForm.ShowDialog() == true)
            {
                DoneJob newAgent = addAgentForm.NewCustomer;

                if (newAgent != null)
                {
                    entities.Add(newAgent);
                    XmlDataManager.SaveData("data/DoneJob.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
        }

        // Удаление выделенной строчки с данными
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is DoneJob selectedAd)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбранный маршрут?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    entities.Remove(selectedAd);
                    dataGrid.ItemsSource = null;
                    XmlDataManager.SaveData("data/DoneJob.xml", entities);
                    dataGrid.ItemsSource = entities;
                }
            }
            else MessageBox.Show("Пожалуйста, выберите маршрут для удаления.", "Маршрут не выбран", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        // Открытие окна с редактированием и отправить новые данные в таблицу
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is DoneJob selected)
            {
                EditCustomerForm editForm = new EditCustomerForm(selected);

                if (editForm.ShowDialog() == true)
                {
                    int index = entities.IndexOf(selected);

                    entities[index] = editForm.UpdatedCustomer;
                    dataGrid.Items.Refresh();
                    XmlDataManager.SaveData("data/DoneJob.xml", entities);
                }
            }
        }

        // Поиск в таблице по введенному значению
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            List<DoneJob> filteredList = entities.Where((DoneJob customer) =>
            customer.PathId.ToString().Contains(searchText) ||
            customer.DriveId1.ToString().Contains(searchText) ||
            (customer.DriveId2 != null && customer.DriveId2.ToString().Contains(searchText)) ||
            (customer.StartPath != null && customer.StartPath.Contains(searchText)) ||
            (customer.EndPath != null && customer.EndPath.ToLower().Contains(searchText))).ToList();

            dataGrid.ItemsSource = filteredList;
        }
    }
}