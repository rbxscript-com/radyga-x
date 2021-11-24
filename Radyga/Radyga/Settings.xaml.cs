using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Radyga
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent(); //инитиализация

            //load settings | загружаем настройки
            if(Properties.Settings.Default.AutoInject == true)
            {
                autoinject.IsChecked = true;
            }
            if (Properties.Settings.Default.TopMost == true)
            {
                topmost.IsChecked = true;
            }
            if(Properties.Settings.Default.StartAnimation == false)
            {
                startanim.IsChecked = true;
            }
        }

        private void killrblx_Click(object sender, RoutedEventArgs e) // kill roblox | экстренное выключение процесса роблокса
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("RobloxPlayerBeta"))
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Already killed! Original error: {ex}", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void multipleRblx_Click(object sender, RoutedEventArgs e) // multiple roblox | мульти роблокс
        {
            new Mutex(true, "ROBLOX_singletonMutex");
        }

        private void topmost_Checked(object sender, RoutedEventArgs e) //topmost checked
        {
            Properties.Settings.Default.TopMost = true;
            Properties.Settings.Default.Save();
            MainWindow mw = new MainWindow();
            mw.Topmost = true;
        }

        private void autoattach_Checked(object sender, RoutedEventArgs e) //autoattach | автоинжект
        {
            Properties.Settings.Default.StartAnimation = false;
            Properties.Settings.Default.Save();
        }

        private void flyexec_Click(object sender, RoutedEventArgs e)  //fly | флай
        {
            Functions func = new Functions();
            func.Execute("loadstring(game: HttpGet'https://pastebin.com/raw/6KVugL85')()");
        }

        private void topmost_Unchecked(object sender, RoutedEventArgs e) // TopMost unchecked
        {
            Properties.Settings.Default.TopMost = false;
            Properties.Settings.Default.Save();
            MainWindow mw = new MainWindow();
            mw.Topmost = false;
        }

        private void startanim_Unchecked(object sender, RoutedEventArgs e) //startanim unchecked
        {
            Properties.Settings.Default.StartAnimation = true;
            Properties.Settings.Default.Save();
        }

        private void btoolsexec_Click(object sender, RoutedEventArgs e) //btools
        {
            Functions func = new Functions();
            func.Execute("local destroy = Instance.new(\"HopperBin\",game.Players.LocalPlayer.Backpack) destroy.BinType = \"Hammer\" local clone = Instance.new(\"HopperBin\",game.Players.LocalPlayer.Backpack) clone.BinType = \"Clone\" local grab = Instance.new(\"HopperBin\",game.Players.LocalPlayer.Backpack) grab.BinType = \"Grab\"");
        }
        
        private void speedexec_Click(object sender, RoutedEventArgs e) //speed | скорость
        {
            Functions func = new Functions();
            func.Execute("game:service'Players'.LocalPlayer.Character.Humanoid.WalkSpeed=100");
        }

        private void autoinject_Checked(object sender, RoutedEventArgs e) //autoinject checked | автоинжект чекнутый
        {
            Properties.Settings.Default.AutoInject = true;
            Properties.Settings.Default.Save();
        }
        
        private void autoinject_Unchecked(object sender, RoutedEventArgs e) //autoinject unchecked | автоинжект анчекнутый
        {
            Properties.Settings.Default.AutoInject = false;
            Properties.Settings.Default.Save();
        }

        private void dragPanel_MouseDown(object sender, MouseButtonEventArgs e) //drag move | перемещение окна драгом
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    DragMove();
            }
            catch { }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e) //exut | выход
        {
            Hide();
        }
    }
}
