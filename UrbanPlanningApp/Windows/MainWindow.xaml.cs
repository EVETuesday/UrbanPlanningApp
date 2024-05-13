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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UrbanPlanningApp.DataBasesClasses;
using UrbanPlanningApp.Windows;
using static UrbanPlanningApp.CH.Context;
using static UrbanPlanningApp.CH.ClassHelper;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace UrbanPlanningApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = $@"{Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName}\UrbanPlanningApi\UrbanPlanningApi\bin\Debug\net8.0\UrbanPlanningApi.exe";
                processStartInfo.UseShellExecute = false;
                processStartInfo.EnvironmentVariables.Add("ASPNETCORE_ENVIRONMENT", "Development");
                try
                {
                    
                    Process.Start(processStartInfo);
                }
                catch
                {
                    processStartInfo.FileName = $@"{Directory.GetCurrentDirectory()}\UrbanPlanningApi.exe";
                    Process.Start(processStartInfo);
                }
                
                
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee = Employees.Where(i=>i.Login==tbLogin.Text && i.Password==tbPassword.Password).FirstOrDefault();
            if (employee!=null)
            {
                ActiveEmployee = employee;
                switch (employee.IDPost)
                {
                    case 1:
                        DefaultManagerWindow defaultManagerWindow = new DefaultManagerWindow();
                        defaultManagerWindow.Show();
                        Close();
                        break;
                    case 2:
                        DefaultEngineerWindow defaultEngineerWindow = new DefaultEngineerWindow();
                        defaultEngineerWindow.Show();
                        Close();
                        break;
                    case 3:
                        DefaultArchitectWindow defaultArchitectWindow = new DefaultArchitectWindow();
                        defaultArchitectWindow.Show();
                        Close();
                        break;
                }
            }
            else
            {
                return;
            }
        }
    }
}
