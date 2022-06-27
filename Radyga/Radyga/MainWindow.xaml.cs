using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.Win32;
using DLLManager;

namespace Radyga
{
    public partial class MainWindow : Window
    {
        private int time = 0;

        //DLL
        ManagerEX exApi = new ManagerEX();
        ManagerKRNL krnlApi = new ManagerKRNL();
        ManagerWRD wrdApi = new ManagerWRD();
        ManagerELECTRON electronApi = new ManagerELECTRON();

        //Animations | Анимации
        Storyboard StoryBoard = new Storyboard();

        //For translator | Для переводчика
        CultureInfo ci = CultureInfo.InstalledUICulture;

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

        //Initialization
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Start();

            DispatcherTimer autoinjectTimer = new DispatcherTimer();
            autoinjectTimer.Tick += new EventHandler(autoinjectTimer_Tick);
            autoinjectTimer.Interval = new TimeSpan(0, 1, 0);
            autoinjectTimer.Start();

            if (Properties.Settings.Default.TopMost == true)
            { Topmost = true; }
            else
            { Topmost = false; }


            dllCombo.SelectedIndex = Properties.Settings.Default.SelectedDLL;



            TextEditor.TextArea.TextView.ElementGenerators.Add(new TruncateLongLines());
            TextEditor.SyntaxHighlighting = HighlightingLoader.Load(new XmlTextReader(File.OpenRead(@".\bin\lua.xshd")), HighlightingManager.Instance);
            scriptbox1.Items.Clear();
            Functions.PopulateListBox(scriptbox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(scriptbox1, "./Scripts", "*.lua");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time = time +1;
        }

        private async void autoinjectTimer_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AutoInject == true)
            {
                bool flagg = !exApi.isInjected() && !wrdApi.isAPIAttached() && !krnlApi.IsInjected() && !ManagerELECTRON.NamedPipeExist();
                if (flagg)
                {
                    bool flag = Process.GetProcessesByName("RobloxPlayerBeta").Length >= 1;
                    if(flag)
                    {
                        await Task.Delay(4000);
                        Inject();
                    }
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(300);
            welcomeLbl.Content = welcomeLbl.Content + Environment.UserName + "!";
            welcomeLbl.Visibility = Visibility.Visible;
            ObjectShift(welcomeLbl, welcomeLbl.Margin, new Thickness(177, 0, 0, 0));
            Fade(welcomeLbl);
        }

        private async void minBtn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(300);
            WindowState = WindowState.Minimized;
        }

        private async void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(300);
            Environment.Exit(0);
        }

        private void credits_Click(object sender, RoutedEventArgs e)
        {
            Credits credits = new Credits();
            credits.ShowDialog();
        }

        private bool InjectMethod(string dllName) //Injector select method | Метод, определяющий через какой инжектор будет происходить инжект
        {
            try
            {
                if(Properties.Settings.Default.PuppyMilk == true)
                {
                    //через паппимилк
                    var inj = new ProcessStartInfo(@".\Bin\PuppyMilkV3.exe");
                    inj.CreateNoWindow = true;
                    inj.Arguments = "\"" + Environment.CurrentDirectory + @"\DLLs\" + dllName + "\"";
                    Process.Start(inj).WaitForExit();
                    return true;
                }
                else
                {
                    Injector injector = new Injector();
                    injector.Inject(dllName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool GetDLLStatus(int dllNumber)
        {
            WebClient webClient = new WebClient();
            string statuses = webClient.DownloadString("https://pastebin.com/raw/FAyByi2d");

            if(dllNumber == 0)
            {
                if(statuses.Split(',')[0] == "false")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if(dllNumber == 1)
            {
                if (statuses.Split(',')[1] == "false")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if(dllNumber == 2)
            {
                if (statuses.Split(',')[2] == "false")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if(dllNumber == 3)
            {
                if (statuses.Split(',')[3] == "false")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void Inject() //Inject method | Сам метод инжекта
        {
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta"); //Check is Roblox opened | Проверить наличие окна роблокса
            if (pname.Length == 0)
            {
                if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                {
                    MessageBox.Show("Роблокс не открыт!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Roblox isn't opened!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else //Checking dll & injecting || Проверяем какая DLL и инжектим
            {
                if (Properties.Settings.Default.SelectedDLL == 0)
                {
                    if(!GetDLLStatus(0))
                    {
                        if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                        {
                            MessageBox.Show("Данная DLL сейчас временно не работает.\nПопробуйте позже", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            MessageBox.Show("DLL is temporarily not working now!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        if (!exApi.isInjected())
                        {
                            if (!exApi.CheckDllUpdateEX() && File.Exists(@".\DLLs\EasyExploitsDLL.dll"))
                            {
                                if (!InjectMethod("EasyExploitsDLL.dll"))
                                {
                                    if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                                    {
                                        MessageBox.Show("Неизвестная ошибка", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Unknown error", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                     exApi.DownloadEX();
                                    if (!InjectMethod("EasyExploitsDLL.dll"))
                                    {
                                        if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                                        {
                                            MessageBox.Show("Неизвестная ошибка", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Unknown error", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                }
                                catch
                                {
                                    if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                                    {
                                        MessageBox.Show("Не получилось скачать последнюю версию DLL.", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cant download the lastest version!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                            {
                                MessageBox.Show("DLL уже инжектнута (подключена)!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                MessageBox.Show("DLL already injected!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
                else if (Properties.Settings.Default.SelectedDLL == 1)
                {
                    if (!GetDLLStatus(1))
                    {
                        if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                        {
                            MessageBox.Show("Данная DLL сейчас временно не работает.\nПопробуйте позже", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            MessageBox.Show("DLL is temporarily not working now!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        if (!wrdApi.isAPIAttached())
                        {
                            if (wrdApi.IsUpdated())
                            {
                                if (wrdApi.DownloadLatestVersion())
                                {
                                    if (!InjectMethod("exploit-main.dll"))
                                    {
                                        if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                                        {
                                            MessageBox.Show("Неизвестная ошибка", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Unknown error", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                                    {
                                        MessageBox.Show("Не получилось скачать последнюю версию DLL.", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cant download the lastest version!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                            }
                            else
                            {
                                if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                                {
                                    MessageBox.Show("Данная DLL сейчас временно не работает.\nПопробуйте позже", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                else
                                {
                                    MessageBox.Show("DLL is temporarily not working now!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                        else
                        {
                            if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                            {
                                MessageBox.Show("DLL уже инжектнута (подключена)!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                MessageBox.Show("DLL already injected!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
                else if (Properties.Settings.Default.SelectedDLL == 2)
                {
                    if (!GetDLLStatus(2))
                    {
                        if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                        {
                            MessageBox.Show("Данная DLL сейчас временно не работает.\nПопробуйте позже", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            MessageBox.Show("DLL is temporarily not working now!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        if (!krnlApi.IsInjected())
                        {
                            if (krnlApi.Initialize())
                            {
                                if (!InjectMethod("Krnl.dll"))
                                {
                                    if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                                    {
                                        MessageBox.Show("Неизвестная ошибка", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Unknown error", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                            }
                            else
                            {
                                if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                                {
                                    MessageBox.Show("Не получилось скачать последнюю версию DLL.", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Cant download the lastest version!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                        else
                        {
                            if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                            {
                                MessageBox.Show("DLL уже инжектнута (подключена)!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                MessageBox.Show("DLL already injected!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
                else if (Properties.Settings.Default.SelectedDLL == 3)
                {
                    if (!GetDLLStatus(4))
                    {
                        if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                        {
                            MessageBox.Show("Данная DLL сейчас временно не работает.\nПопробуйте позже", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            MessageBox.Show("DLL is temporarily not working now!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        if (!ManagerELECTRON.NamedPipeExist())
                        {
                            if (electronApi.Updates())
                            {
                                if (!InjectMethod("ElectronDLL.dll"))
                                {
                                    if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                                    {
                                        MessageBox.Show("Неизвестная ошибка", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Unknown error", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                            }
                            else
                            {
                                if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                                {
                                    MessageBox.Show("Не получилось скачать последнюю версию DLL.", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Cant download the lastest version!", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (ci.Name == "ru_RU") //Translated error | Переведенная ошибка
                    {
                        MessageBox.Show("Неизвестная ошибка. Попробуйте снова выбрать какую-нибудь DLL", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("Unknown error. Try reselect DLL", "Radyga", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void inject_Click(object sender, RoutedEventArgs e)
        {
            Inject();
        }

        private void savefileBtn_Click(object sender, RoutedEventArgs e)
        {
            var SaveDialog = new SaveFileDialog
            {
                Title = "Radyga",
                Filter = "Script Files (*.lua, *.txt)|*.lua;*.txt|All Files (*.*)|*.*",
                FileName = ""
            };

            SaveDialog.FileOk += (o, args) =>
            {
                File.WriteAllText(SaveDialog.FileName, TextEditor.Text);
            };

            SaveDialog.ShowDialog();
        }

        private void opnfileBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextEditor == null)
            {
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false,
                DefaultExt = ".lua",
                Title = "Radyga",
                Filter = "Scripts (*.lua; .txt)|.lua;*.txt"
            };
            bool? flag = openFileDialog.ShowDialog();
            bool flag2 = true;
            if (flag.GetValueOrDefault() == flag2 & flag != null)
            {
                TextEditor.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void execBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(TextEditor.Text))
            {
                Functions func = new Functions();
                func.Execute(TextEditor.Text);
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            TextEditor.Clear();
        }

        private void scriptbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextEditor.Text = File.ReadAllText($"./scripts/{scriptbox1.SelectedItem}");
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings stn = new Settings();
            stn.ShowDialog();
        }

        bool dllComboLoaded = false;
        private void dllCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dllComboLoaded == true)
            {
                Properties.Settings.Default.SelectedDLL = dllCombo.SelectedIndex;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }

        private void dragPanel_MouseDown(object sender, MouseButtonEventArgs e) //Перемещение окна
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    DragMove();
            }
            catch { }
        }

        private void dllCombo_Loaded(object sender, RoutedEventArgs e)
        {
            dllComboLoaded = true;
        }
    }
}
