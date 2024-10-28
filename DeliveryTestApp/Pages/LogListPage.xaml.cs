using DeliveryTestApp.UserControls;
using DeliveryTestApp.ViewModels;
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

namespace DeliveryTestApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для LogListPage.xaml
    /// </summary>
    public partial class LogListPage : Page
    {
        LoaderControl contextLoader;
        LogListViewModel contextViewModel;

        public LogListPage(LoaderControl loaderControl)
        {
            InitializeComponent();
            contextLoader = loaderControl;

            contextViewModel = new LogListViewModel();
            DataContext = contextViewModel;
            contextLoader.LoaderStart();
        }

        private void LvLog_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (LvLog.Visibility == Visibility.Visible)
            {
                contextLoader.LoaderStop();
            }
        }
    }
}
