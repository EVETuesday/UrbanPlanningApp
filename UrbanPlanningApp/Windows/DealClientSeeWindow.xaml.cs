using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UrbanPlanningApp.DataBasesClasses;
using static UrbanPlanningApp.CH.ClassHelper;
using static UrbanPlanningApp.CH.Context;

namespace UrbanPlanningApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для DealClientSeeWindow.xaml
    /// </summary>
    public partial class DealClientSeeWindow : Window
    {
        ObservableCollection<Client> clients;
        public DealClientSeeWindow()
        {
            InitializeComponent();
            GetData();
            clients = new ObservableCollection<Client>(Clients);
            SetLv();
        }
        void SetLv()
        {
            LvEstateList.ItemsSource = clients;
        }
        void SetLv(string searchWord)
        {
            if (string.IsNullOrEmpty(searchWord))
            {
                clients = Clients;
            }
            else
            {
                clients = new ObservableCollection<Client>(clients.Where(i => i.FullName.ToLower().Contains(tbSearch.Text)|| i.CompanyTitle.ToLower().Contains(tbSearch.Text)|| i.PasportNumber.ToString().Contains(tbSearch.Text) || i.PasportSeries.ToString().Contains(tbSearch.Text)));
            }
            SetLv();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            if (LvEstateList.SelectedItem == null)
            {
                MessageBox.Show("Выберете клиента");
                return;
            }
            DealSelectedClient = LvEstateList.SelectedItem as Client;
            DealWindow dealWindow = new DealWindow();
            dealWindow.Show();
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DealEstateObjectSeeWindow dealEstateObjectSeeWindow = new DealEstateObjectSeeWindow();
            dealEstateObjectSeeWindow.Show();
            Close();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetLv(tbSearch.Text);
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (cmbSort.SelectedIndex)
                {
                    case 0:
                        clients = new ObservableCollection<Client>(clients.OrderBy(i => i.IDClient));
                        break;
                    case 1:
                        clients = new ObservableCollection<Client>(clients.OrderBy(i => i.FullName));
                        break;
                    case 2:
                        clients = new ObservableCollection<Client>(clients.OrderBy(i => i.Phone));
                        break;
                    case 3:
                        clients = new ObservableCollection<Client>(clients.OrderBy(i => i.PasportNumber));
                        break;
                    case 4:
                        clients = new ObservableCollection<Client>(clients.OrderBy(i => i.IsLegalEntity));
                        break;
                }
                SetLv();
            }
            catch
            {
                return;
            }
        }
    }
}
