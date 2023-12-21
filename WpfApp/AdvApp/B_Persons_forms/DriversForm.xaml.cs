using System.Windows;

namespace AdvApp.Show_forms
{
    /* Окно со списком передач */
    public partial class ShowForm : Window
    {
        // Список передач
        private List<Drivers> entities;

        public ShowForm()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            entities = XmlDataManager.LoadData<Drivers>("data/Drivers.xml");
            dataGrid.ItemsSource = entities;
        }

        // Открытие окна с добавлением и отправить данные в таблицу
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddShowForm addShowForm = new AddShowForm();

            if (addShowForm.ShowDialog() == true)
            {
                Drivers newShow = addShowForm.NewShow;

                if (newShow != null)
                {
                    entities.Add(newShow);
                    XmlDataManager.SaveData("data/Drivers.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
        }

        // Удаление выделенной строчки с данными
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Drivers selectedShow)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбраннного водителя?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    entities.Remove(selectedShow);
                    dataGrid.ItemsSource = null;

                    XmlDataManager.SaveData("data/Drivers.xml", entities);
                    dataGrid.ItemsSource = entities;
                }
            }
            else MessageBox.Show("Пожалуйста, выберите водителя для удаления.", "Водитель не выбран", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        // Открытие окна с редактированием и отправить новые данные в таблицу
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Drivers selected)
            {
                EditShowForm editForm = new EditShowForm(selected);

                if (editForm.ShowDialog() == true)
                {
                    int index = entities.IndexOf(selected);

                    entities[index] = editForm.UpdatedShow;
                    
                    XmlDataManager.SaveData("data/Drivers.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
        }

        // Поиск в таблице по введенному значению
        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            List<Drivers> filteredList = entities.Where((Drivers show) =>
            show.FirstName.ToLower().Contains(searchText) ||
            show.DriveId.ToString().Contains(searchText) ||
            show.SecondName.ToString().Contains(searchText) ||
            show.ThirdName.ToString().Contains(searchText)).ToList();

            dataGrid.ItemsSource = filteredList;
        }

        private void dataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}