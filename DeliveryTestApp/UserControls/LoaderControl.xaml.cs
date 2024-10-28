using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DeliveryTestApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для LoaderControl.xaml
    /// </summary>
    public partial class LoaderControl : UserControl
    {
        public LoaderControl()
        {
            InitializeComponent();
        }

        public void LoaderStart()
        {
            this.Visibility = Visibility.Visible;
            this.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
            });
            LoaderImage.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation()
            {
                From = 0,
                To = 360,
                BeginTime = TimeSpan.FromSeconds(0.2),
                Duration = TimeSpan.FromSeconds(0.8),
                DecelerationRatio = 0.3,
                RepeatBehavior = RepeatBehavior.Forever,
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
            });;
        }
        public void LoaderStop()
        {
            this.BeginAnimation(OpacityProperty, new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
            this.Visibility = Visibility.Collapsed;
            LoaderImage.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
        }
    }
}
