using DeliveryTestApp.Components;
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
    /// Логика взаимодействия для SelectionListPage.xaml
    /// </summary>
    public partial class SelectionListPage : Page
    {
        LoaderControl contextLoader;
        SelectionListPageViewModel contextViewModel;
        public SelectionListPage(LoaderControl loaderControl)
        {
            InitializeComponent();
            contextLoader = loaderControl;

            contextViewModel = new SelectionListPageViewModel();
            DataContext = contextViewModel;
            contextLoader.LoaderStart();
        }

        private void ResetSortBtn_Click(object sender, RoutedEventArgs e)
        {
            CbArea.SelectedItem = null;
        }

        private void LvSelection_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (LvSelection.Visibility == Visibility.Visible)
            {
                contextLoader.LoaderStop();
            }
        }
    }
}
