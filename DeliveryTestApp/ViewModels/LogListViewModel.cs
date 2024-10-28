using DeliveryTestApp.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTestApp.ViewModels
{
    public class LogListViewModel : ViewModelBase
    {
        public bool IsLoading { get; private set; }
        public ObservableCollection<DeliveryLog> LogList { get; private set; }
        public List<Area> AreaList { get; private set; }
        public Area selectedArea { get; set; }

        public Area SelectedArea
        {
            get
            {
                return selectedArea;
            }
            set
            {
                selectedArea = value;
                OnPropertyChanged("SelectionResultList");
            }
        }

        public LogListViewModel()
        {
            LogList = new ObservableCollection<DeliveryLog>();
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

            var Data = await Task.Run(() => App.DB.DeliveryLog.ToList());

            foreach (var item in Data)
            {
                LogList.Add(item);
            }

            IsLoading = true;
            OnPropertyChanged(nameof(IsLoading));

        }
    }
}
