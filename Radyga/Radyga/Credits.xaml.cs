using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Radyga
{
    /// <summary>
    /// Логика взаимодействия для Credits.xaml
    /// </summary>
    public partial class Credits : Window
    {
        Storyboard StoryBoard = new Storyboard();

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

        public Credits()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(300);
            ObjectShift(qufteamImgg, qufteamImgg.Margin, new Thickness(306, 19, 0, 0));
            ObjectShift(qufLbl, qufLbl.Margin, new Thickness(356, 128, 0, 0));
            ObjectShift(rbxsriptsImg, rbxsriptsImg.Margin, new Thickness(37, 9, 0, 0));
            ObjectShift(rbxscriptslbl, rbxscriptslbl.Margin, new Thickness(46, 128, 0, 0));

            Fade(qufteamImgg);
            Fade(qufLbl);
            Fade(rbxsriptsImg);
            Fade(rbxscriptslbl);
            await Task.Delay(3500);
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
