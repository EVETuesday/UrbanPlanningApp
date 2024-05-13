using System;
using System.Collections.Generic;
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
using static UrbanPlanningApp.CH.Context;
using static UrbanPlanningApp.CH.ClassHelper;

namespace UrbanPlanningApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для DefaultArchitectWindow.xaml
    /// </summary>
    public partial class DefaultArchitectWindow : Window
    {
        public DefaultArchitectWindow()
        {
            InitializeComponent();
            tbHeaderUser.Text = $"{Posts.Where(i => i.IDPost == ActiveEmployee.IDPost).FirstOrDefault().PostTitle}: {ActiveEmployee.LastName} {ActiveEmployee.FirstName} {ActiveEmployee.Patronymic}";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ActiveEmployee = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnSeeEstate_Click(object sender, RoutedEventArgs e)
        {
            EstateObjectSeeWindow estateObjectSeeWindow = new EstateObjectSeeWindow();
            estateObjectSeeWindow.Show();
            Close();
        }
    }
}
