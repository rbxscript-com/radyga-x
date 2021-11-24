using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Radyga
{
    /// <summary>
    /// Логика взаимодействия для Credits.xaml
    /// </summary>
    public partial class Start : Window //first start window
    {
        Storyboard StoryBoard = new Storyboard();

        //animations
        private IEasingFunction Smooth
        {
            get;
            set;
        }
        = new QuarticEase
        {
            EasingMode = EasingMode.EaseInOut
        };

        public void Fade(DependencyObject Object)
        {
            DoubleAnimation FadeIn = new DoubleAnimation()
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromMilliseconds(1500)),
            };
            Storyboard.SetTarget(FadeIn, Object);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath("Opacity", 1));
            StoryBoard.Children.Add(FadeIn);
            StoryBoard.Begin();
        }

        public void ObjectShift(DependencyObject Object, Thickness Get, Thickness Set)
        {
            ThicknessAnimation Animation = new ThicknessAnimation()
            {
                From = Get,
                To = Set,
                Duration = TimeSpan.FromMilliseconds(1000),
                EasingFunction = Smooth,
            };
            Storyboard.SetTarget(Animation, Object);
            Storyboard.SetTargetProperty(Animation, new PropertyPath(MarginProperty));
            StoryBoard.Children.Add(Animation);
            StoryBoard.Begin();
        }

        public Start()
        {
            InitializeComponent(); //init
            
            if(Properties.Settings.Default.StartAnimation == false) //if start animation is off just skip | если стартовая анимация выключена, то пропустить её.
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var date = DateTime.Now; //start site | запуск сайта раз в день
            int day = (int)date.DayOfWeek;
            if(Properties.Settings.Default.Day != day)
            {
                Process.Start("https://rbxscript.com/");
                Properties.Settings.Default.Day = day;
                Properties.Settings.Default.Save();
            }

            await Task.Delay(300);

            //анимации
            ObjectShift(logo, logo.Margin, new Thickness(168, 66, 0, 0));
            Fade(logo);
            await Task.Delay(3500);
            if(!Properties.Settings.Default.StartAnimation == false)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) //анимация скрытия окна
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.5));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
            ShowActivated = true;
        }
    }
}
