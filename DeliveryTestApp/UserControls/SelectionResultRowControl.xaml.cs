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

namespace DeliveryTestApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SelectionResultRowControl.xaml
    /// </summary>
    public partial class SelectionResultRowControl : UserControl
    {
        public bool IsExpanded = false;

        public SelectionResultRowControl()
        {
            InitializeComponent();
        }
        private void ExpandBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsExpanded == false)
            {
                StResult.Visibility = Visibility.Visible;
                IsExpanded = true;
                ArrowUp.Visibility = Visibility.Visible;
                Arrow.Visibility = Visibility.Collapsed;
                return;
            }
            if (IsExpanded == true)
            {
                StResult.Visibility = Visibility.Collapsed;
                IsExpanded = false;
                ArrowUp.Visibility = Visibility.Collapsed;
                Arrow.Visibility = Visibility.Visible;
                return;
            }
        }
    }
}
