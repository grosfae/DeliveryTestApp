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
    /// Логика взаимодействия для UpcomingOrdersPage.xaml
    /// </summary>
    public partial class UpcomingOrdersPage : Page
    {
        LoaderControl contextLoader;
        UpcomingOrdersPageViewModel contextViewModel;
        public UpcomingOrdersPage(LoaderControl loaderControl)
        {
            InitializeComponent();
            contextLoader = loaderControl;

            contextViewModel = new UpcomingOrdersPageViewModel();
            DataContext = contextViewModel;

            contextLoader.LoaderStart();
        }
        private void ResetSortBtn_Click(object sender, RoutedEventArgs e)
        {
            CbArea.SelectedItem = null;
        }

        private async void GenerateSelectionBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CbArea.SelectedItem == null)
            {
                MessageBox.Show("Перед сохранением данной выборки выберите район");
                return;
            }
            await Task.Run(() => SaveFilteredSelection());
        }
        private void SaveFilteredSelection()
        {
            try
            {
                var SelectionResult = new SelectionResult
                {
                    Name = $"Выборка ближайших заказов. Дата первой доставки: {contextViewModel.SelectedArea.FirstDeliveryTime}",
                    Area = contextViewModel.SelectedArea,
                    SelectionDateTime = DateTime.Now
                };
                App.DB.SelectionResult.Add(SelectionResult);
                foreach (var order in contextViewModel.OrderList)
                {
                    App.DB.SelectionResultOrder.Add(new SelectionResultOrder()
                    {
                        Order = order,
                        SelectionResult = SelectionResult
                    });
                }
                App.DB.DeliveryLog.Add(new DeliveryLog()
                {
                    LogDateTime = DateTime.Now,
                    Description = $"Сохранена выборка ближайших заказов в таблицу SelectionResult №{SelectionResult.Id} от {SelectionResult.SelectionDateTime}"
                });
                App.DB.SaveChanges();
                MessageBox.Show("Выборка успешно сохранена!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CbArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CbArea.SelectedItem != null)
            {
                TbAreaFirstDeliveryTime.Text = $"Время: {(CbArea.SelectedItem as Area).FirstDeliveryTime}";
                TbAreaFirstDeliveryTime.Visibility = Visibility.Visible;            
            }
            else
            {
                TbAreaFirstDeliveryTime.Visibility = Visibility.Collapsed;
            }
        }

        private void LvOrder_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (LvOrder.Visibility == Visibility.Visible)
            {
                contextLoader.LoaderStop();
            }
        }
    }
}
