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

namespace UrbanPlanningApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для LittleAddPhotoWindow.xaml
    /// </summary>
    public partial class LittleAddPhotoWindow : Window
    {
        public LittleAddPhotoWindow()
        {
            InitializeComponent();
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                imgPhoto.Source = new BitmapImage(new Uri(tbUri.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
