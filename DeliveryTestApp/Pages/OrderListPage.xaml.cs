﻿using DeliveryTestApp.Components;
using DeliveryTestApp.UserControls;
using DeliveryTestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        LoaderControl contextLoader;
        OrderListPageViewModel contextViewModel;
        public OrderListPage(LoaderControl loaderControl)
        {
            InitializeComponent();
            contextLoader = loaderControl;

            contextViewModel = new OrderListPageViewModel();
            DataContext = contextViewModel;
            contextLoader.LoaderStart();
        }

        private void ResetSortBtn_Click(object sender, RoutedEventArgs e)
        {
            CbSort.SelectedIndex = 0;
            CbArea.SelectedItem = null;
            DtDateStart.SelectedDate = null;
            DtDateEnd.SelectedDate = null;
        }

        private async void GenerateSelectionBtn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => SaveFilteredSelection());
        }
        private void SaveFilteredSelection()
        {
            try
            {
                string SelectionName = string.Empty;
                if (contextViewModel.DateTimeStart != null && contextViewModel.DateTimeEnd != null)
                {
                    SelectionName = $"Выборка заказов {contextViewModel.DateTimeStart} - {contextViewModel.DateTimeEnd}";
                }
                else
                {
                    SelectionName = $"Выборка заказов";
                }
                var SelectionResult = new SelectionResult
                {
                    Name = SelectionName,
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
                    Description = $"Сохранена выборка заказов в таблицу SelectionResult №{SelectionResult.Id} от {SelectionResult.SelectionDateTime}"
                });
                App.DB.SaveChanges();
                MessageBox.Show("Выборка успешно сохранена!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LvOrder_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(LvOrder.Visibility == Visibility.Visible)
            {
                contextLoader.LoaderStop();
            }
        }
    }
}
