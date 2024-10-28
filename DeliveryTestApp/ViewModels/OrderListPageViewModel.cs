using DeliveryTestApp.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DeliveryTestApp.ViewModels
{
    public class OrderListPageViewModel : ViewModelBase
    {
        public bool IsLoading { get; private set; }
        public ObservableCollection<Order> Order { get; private set; }
        public List<Area> AreaList { get; private set; }
        public int? selectedSortIndex { get; set; }
        public Area selectedArea { get; set; }
        public DateTime? dateTimeStart { get; set; }
        public DateTime? dateTimeEnd { get; set; }
        public int? SelectedSortIndex
        {
            get
            {
                return selectedSortIndex;
            }
            set
            {
                selectedSortIndex = value;
                OnPropertyChanged("OrderList");
            }
        }
        public Area SelectedArea
        {
            get
            {
                return selectedArea;
            }
            set
            {
                selectedArea = value;
                OnPropertyChanged("OrderList");
            }
        }
        public DateTime? DateTimeStart
        {
            get
            {
                return dateTimeStart;
            }
            set
            {
                dateTimeStart = value;
                OnPropertyChanged("OrderList");
            }
        }
        public DateTime? DateTimeEnd
        {
            get
            {
                return dateTimeEnd;
            }
            set
            {
                dateTimeEnd = value;
                OnPropertyChanged("OrderList");
            }
        }

        public OrderListPageViewModel()
        {
            Order = new ObservableCollection<Order>();
            AreaList = new List<Area>();
            LoadDataAsync();
        }
        private async void LoadDataAsync()
        {
            IsLoading = false;
            OnPropertyChanged(nameof(IsLoading));

            var Areas = await Task.Run(() => App.DB.Area.ToList());

            foreach (var item in Areas)
            {
                AreaList.Add(item);
            }

            var Data = await Task.Run(() => App.DB.Order.ToList());

            foreach (var item in Data)
            {
                Order.Add(item);
            }

            IsLoading = true;
            OnPropertyChanged(nameof(IsLoading));
        }
        public IEnumerable<Order> OrderList
        {
            get
            {
                IEnumerable<Order> filteredOrders = Order;
                if(SelectedArea != null)
                {
                    filteredOrders = filteredOrders.Where(x => x.Area == SelectedArea);
                }
                if (DateTimeStart != null)
                {
                    filteredOrders = filteredOrders.Where(x => x.DeliveryDateTime >= DateTimeStart);
                }
                if (dateTimeEnd != null)
                {
                    filteredOrders = filteredOrders.Where(x => x.DeliveryDateTime <= dateTimeEnd);
                }
                if (selectedSortIndex == 0)
                {
                    filteredOrders = filteredOrders.OrderBy(x => x.Id);
                }
                if (selectedSortIndex == 1)
                {
                    filteredOrders = filteredOrders.OrderBy(x => x.Area.Name);
                }
                if (selectedSortIndex == 2)
                {
                    filteredOrders = filteredOrders.OrderBy(x => x.DeliveryDateTime);
                }
                if (selectedSortIndex == 3)
                {
                    filteredOrders = filteredOrders.OrderByDescending(x => x.DeliveryDateTime);
                }
                return filteredOrders;
            }
            set
            {

            }
        }
    }
}
