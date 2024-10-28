using DeliveryTestApp.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTestApp.ViewModels
{
    public class UpcomingOrdersPageViewModel : ViewModelBase
    {
        public bool IsLoading { get; private set; }
        public ObservableCollection<Order> Order { get; private set; }
        public List<Area> AreaList { get; private set; }
        public Area selectedArea { get; set; }
        public DateTime? firstDeliveryDateOrder{ get; set; }

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
        public DateTime? FirstDeliveryDateOrder
        {
            get
            {
                return firstDeliveryDateOrder;
            }
            set
            {
                firstDeliveryDateOrder = value;
            }
        }
       
        public UpcomingOrdersPageViewModel()
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
                if (SelectedArea != null)
                {
                    filteredOrders = filteredOrders.Where(x => x.Area == SelectedArea);
                    if (SelectedArea.Order.Count() > 0)
                    {
                        filteredOrders = filteredOrders.Where(x => x.DeliveryDateTime >= SelectedArea.FirstDeliveryTime && x.DeliveryDateTime < SelectedArea.FirstDeliveryTime.AddMinutes(30));
                    }
                }
                return filteredOrders;
            }
            set
            {

            }
        }
    }
}
