using System.Windows;
using System.Windows.Markup;

namespace AdvApp
{
    /* Окно со списком реклам */
    public partial class AdvertisementForm : Window, IComponentConnector
    {
        // Список реклам
        private List<Advertisement> advertisements;

        public AdvertisementForm()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            advertisements = XmlDataManager.LoadData<Advertisement>("data/Path.xml");
            AdvertisementsDataGrid.ItemsSource = advertisements;
        }

        // Открытие окна с добавлением и отправить данные в таблицу
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddAdvertisementForm addForm = new AddAdvertisementForm();

            if (addForm.ShowDialog() == true)
            {
                Advertisement newAd = addForm.NewAdvertisement;

                advertisements.Add(newAd);
                
                XmlDataManager.SaveData("data/Path.xml", advertisements);
                AdvertisementsDataGrid.Items.Refresh();
            }
        }

        // Удаление выделенной строчки с данными
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdvertisementsDataGrid.SelectedItem is Advertisement selectedAd)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбранный маршрут?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    advertisements.Remove(selectedAd);
                    AdvertisementsDataGrid.ItemsSource = null;
                    XmlDataManager.SaveData("data/Path.xml", advertisements);
                    AdvertisementsDataGrid.ItemsSource = advertisements;
                }
            }
            else MessageBox.Show("Пожалуйста, выберите маршрут для удаления.", "Объявление не выбрано", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        // Открытие окна с редактированием и отправить новые данные в таблицу
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdvertisementsDataGrid.SelectedItem is Advertisement selectedAd)
            {
                EditAdvertisementForm editForm = new EditAdvertisementForm(selectedAd);

                if (editForm.ShowDialog() == true)
                {
                    int index = advertisements.IndexOf(selectedAd);

                    advertisements[index] = editForm.UpdatedAdvertisement;

                    XmlDataManager.SaveData("data/Path.xml", advertisements);
                    AdvertisementsDataGrid.Items.Refresh();
                }
            }
        }

        // Поиск в таблице по введенному значению
        private void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            List<Advertisement> filteredList = advertisements.Where((Advertisement advertisement) =>
            advertisement.PathId.ToString().Contains(searchText) ||
            advertisement.PathName.ToString().Contains(searchText) ||
            advertisement.LenPath.ToString().Contains(searchText) ||
            advertisement.PathDays.ToString().Contains(searchText) ||
            advertisement.PathPay.ToString().Contains(searchText)).ToList();

            AdvertisementsDataGrid.ItemsSource = filteredList;
        }
    }
}