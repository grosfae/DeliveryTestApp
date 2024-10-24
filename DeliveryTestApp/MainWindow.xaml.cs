using DeliveryTestApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace DeliveryTestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsMaximize = false;
        public MainWindow()
        {
            InitializeComponent();
            Head.MouseLeftButtonDown += new MouseButtonEventHandler(Window_MouseDown);
            Time_Set();
            //MainFrame.Navigate(new InfoPage());
        }
        private async void Time_Set()
        {
            while (true)
            {
                TbClock.Text = DateTime.Now.ToString("t");
                DateTime now = DateTime.Now;
                int millisecondsUntilNextSecond = 1000 - now.Millisecond;              
                await Task.Delay(millisecondsUntilNextSecond);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.XButton1 || e.ChangedButton == MouseButton.XButton2)
            {
                e.Handled = true;
            }
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OrderListBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MainFrame.Content is OrderListPage)
            {
                return;
            }
            else
            {
                MainFrame.Content = new OrderListPage();
            }
        }

        private void LogListBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectionListBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MaximizeBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsMaximize == false)
            {
                MainAppRect.BeginAnimation(RectangleGeometry.RectProperty, new RectAnimation()
                {
                    To = new Rect(0, 0, 1400, 850),
                    Duration = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });
                var widthAnimation = new DoubleAnimation
                {
                    From = this.Width,
                    To = 1400,
                    Duration = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                };

                // Анимация высоты окна
                var heightAnimation = new DoubleAnimation
                {
                    From = this.Height,
                    To = 850,
                    Duration = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                };

                // Объединение анимаций в последовательность
                var storyboard = new Storyboard();
                storyboard.Children.Add(widthAnimation);
                storyboard.Children.Add(heightAnimation);

                // Устанавливаем цели для анимаций
                Storyboard.SetTarget(widthAnimation, this);
                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath("Width"));


                Storyboard.SetTarget(heightAnimation, this);
                Storyboard.SetTargetProperty(heightAnimation, new PropertyPath("Height"));

                // Запуск анимации
                storyboard.Begin();
                IsMaximize = true;
            }
            else
            {
                MainAppRect.BeginAnimation(RectangleGeometry.RectProperty, new RectAnimation()
                {
                    To = new Rect(0, 0, 300, 300),
                    Duration = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });
                var widthAnimation = new DoubleAnimation
                {
                    From = this.Width,
                    To = 300,
                    Duration = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                };

                // Анимация высоты окна
                var heightAnimation = new DoubleAnimation
                {
                    From = this.Height,
                    To = 300,
                    Duration = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                };

                // Объединение анимаций в последовательность
                var storyboard = new Storyboard();
                storyboard.Children.Add(widthAnimation);
                storyboard.Children.Add(heightAnimation);

                // Устанавливаем цели для анимаций
                Storyboard.SetTarget(widthAnimation, this);
                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath("Width"));

                Storyboard.SetTarget(heightAnimation, this);
                Storyboard.SetTargetProperty(heightAnimation, new PropertyPath("Height"));

                // Запуск анимации
                storyboard.Begin();
                IsMaximize = false;
            }
        }
    }
}
