using DeliveryTestApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
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
            TbClock.Text = DateTime.Now.ToString("t");
            Time_Set();
        }
        private async void Time_Set()
        {
            while (true)
            {
                DateTime now = DateTime.Now;
                int millisecondsUntilNextSecond = 1000 - now.Millisecond;
                await Task.Delay(millisecondsUntilNextSecond);
                if (IsMaximize == false)
                {
                    TbClock.Text = DateTime.Now.ToString("t");
                }
                else
                {
                    TbClockMini.Text = DateTime.Now.ToString("F");
                }
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
                MainFrame.Content = new OrderListPage(LoaderControl);
            }
        }

        private void LogListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is LogListPage)
            {
                return;
            }
            else
            {
                MainFrame.Content = new LogListPage(LoaderControl);
            }
        }

        private void SelectionListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is SelectionListPage)
            {
                return;
            }
            else
            {
                MainFrame.Content = new SelectionListPage(LoaderControl);
            }
        }
        private void UpcomingOrderListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is UpcomingOrdersPage)
            {
                return;
            }
            else
            {
                MainFrame.Content = new UpcomingOrdersPage(LoaderControl);
            }
        }
        private void MaximizeBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.BeginAnimation(Window.LeftProperty, null);
            this.BeginAnimation(Window.TopProperty, null);

            if (IsMaximize == false)
            {
                TbClockMini.Visibility = Visibility.Visible;
                MenuBtnsSt.Visibility = Visibility.Visible;
                this.BeginAnimation(Window.TopProperty, new DoubleAnimation()
                {
                    To = (SystemParameters.PrimaryScreenHeight - 850) / 2,
                    Duration = TimeSpan.FromSeconds(0.2),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });

                this.BeginAnimation(Window.LeftProperty, new DoubleAnimation()
                {
                    To = (SystemParameters.PrimaryScreenWidth - 1400) / 2,
                    BeginTime = TimeSpan.FromSeconds(0.2),
                    Duration = TimeSpan.FromSeconds(0.2),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });

                MainAppRect.BeginAnimation(RectangleGeometry.RadiusXProperty, new DoubleAnimation()
                {
                    To = 15,
                    Duration = TimeSpan.FromSeconds(0.1),
                    BeginTime = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });
                MainAppRect.BeginAnimation(RectangleGeometry.RadiusYProperty, new DoubleAnimation()
                {
                    To = 15,
                    Duration = TimeSpan.FromSeconds(0.1),
                    BeginTime = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });
                InnerRectangle.BeginAnimation(Rectangle.RadiusXProperty, new DoubleAnimation()
                {
                    To = 15,
                    Duration = TimeSpan.FromSeconds(0.1),
                    BeginTime = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });
                InnerRectangle.BeginAnimation(Rectangle.RadiusYProperty, new DoubleAnimation()
                {
                    To = 15,
                    Duration = TimeSpan.FromSeconds(0.1),
                    BeginTime = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });

                MainAppRect.BeginAnimation(RectangleGeometry.RectProperty, new RectAnimation()
                {
                    To = new Rect(0, 0, 1400, 850),
                    Duration = TimeSpan.FromSeconds(0.6),
                    BeginTime = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });
                
                this.BeginAnimation(Window.WidthProperty, new DoubleAnimation()
                {
                    From = this.Width,
                    To = 1400,
                    Duration = TimeSpan.FromSeconds(0.6),
                    BeginTime = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });

                ToolBarSt.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation()
                {
                    To = 630,
                    Duration = TimeSpan.FromSeconds(0.6),
                    BeginTime = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });

                this.BeginAnimation(Window.HeightProperty, new DoubleAnimation()
                {
                    From = this.Height,
                    To = 850,
                    Duration = TimeSpan.FromSeconds(0.4),
                    BeginTime = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });

                CenterRectangle.BeginAnimation(OpacityProperty, new DoubleAnimation()
                {
                    To = 0.2,
                    Duration = TimeSpan.FromSeconds(0.4),
                    BeginTime = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });

                InnerRectangle.BeginAnimation(OpacityProperty, new DoubleAnimation()
                {
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.4),
                    BeginTime = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });

                InnerDifferentColorRectangle.BeginAnimation(OpacityProperty, new DoubleAnimation()
                {
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.4),
                    BeginTime = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });

                Head.Background.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation()
                {
                    To = Color.FromRgb(127, 173, 203),
                    Duration = TimeSpan.FromSeconds(0.4),
                    BeginTime = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });

                FooterGrid.Background.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation()
                {
                    To = Color.FromRgb(12, 22, 36),
                    Duration = TimeSpan.FromSeconds(0.4),
                    BeginTime = TimeSpan.FromSeconds(1),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                });

                IsMaximize = true;
            }
            else
            {
                Head.Background.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation()
                {
                    To = Color.FromRgb(18, 18, 18),
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });

                FooterGrid.Background.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation()
                {
                    To = Color.FromRgb(18, 18, 18),
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });

                CenterRectangle.BeginAnimation(OpacityProperty, new DoubleAnimation()
                {
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });

                InnerDifferentColorRectangle.BeginAnimation(OpacityProperty, new DoubleAnimation()
                {
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });

                TbClockMini.Visibility = Visibility.Collapsed;
                MenuBtnsSt.Visibility = Visibility.Collapsed;

                InnerRectangle.BeginAnimation(OpacityProperty, new DoubleAnimation()
                {
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });

                this.BeginAnimation(Window.HeightProperty, new DoubleAnimation()
                {
                    From = this.Height,
                    To = 300,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });
                this.BeginAnimation(Window.WidthProperty, new DoubleAnimation()
                {
                    From = this.Width,
                    To = 300,
                    Duration = TimeSpan.FromSeconds(0.4),
                    BeginTime = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });
                ToolBarSt.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation()
                {
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.4),
                    BeginTime = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });
                MainAppRect.BeginAnimation(RectangleGeometry.RectProperty, new RectAnimation()
                {
                    To = new Rect(0, 0, 300, 300),
                    Duration = TimeSpan.FromSeconds(0.6),
                    BeginTime = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });
                MainAppRect.BeginAnimation(RectangleGeometry.RadiusXProperty, new DoubleAnimation()
                {
                    To = 250,
                    Duration = TimeSpan.FromSeconds(0.1),
                    BeginTime = TimeSpan.FromSeconds(0.6),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });
                MainAppRect.BeginAnimation(RectangleGeometry.RadiusYProperty, new DoubleAnimation()
                {
                    To = 250,
                    Duration = TimeSpan.FromSeconds(0.1),
                    BeginTime = TimeSpan.FromSeconds(0.6),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });
                InnerRectangle.BeginAnimation(Rectangle.RadiusXProperty, new DoubleAnimation()
                {
                    To = 250,
                    Duration = TimeSpan.FromSeconds(0.1),
                    BeginTime = TimeSpan.FromSeconds(0.6),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });
                InnerRectangle.BeginAnimation(Rectangle.RadiusYProperty, new DoubleAnimation()
                {
                    To = 250,
                    Duration = TimeSpan.FromSeconds(0.1),
                    BeginTime = TimeSpan.FromSeconds(0.6),
                    EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
                });

                IsMaximize = false;
            }
        }

        private void MaximizeBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuBtnShadow.BeginAnimation(DropShadowEffect.OpacityProperty, new DoubleAnimation()
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
            });
        }

        private void MaximizeBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuBtnShadow.BeginAnimation(DropShadowEffect.OpacityProperty, new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0.1),
                EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut }
            });
        }

    }
}
