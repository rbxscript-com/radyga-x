using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using DLLManager;

namespace Radyga
{
    class Functions
    {
        public void Execute(string script)
        {
            ManagerEX exApi = new ManagerEX();
            ManagerKRNL krnlApi = new ManagerKRNL();
            ManagerWRD wrdApi = new ManagerWRD();
            ManagerELECTRON electronApi = new ManagerELECTRON();

            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            if (pname.Length == 0)
            {
                MessageBox.Show("Roblox isn't opened!", "DLL Manager");
            }
            else
            {
                if (Properties.Settings.Default.SelectedDLL == 0)
                {
                    if (exApi.isInjected())
                    {
                        exApi.ExecuteScript(script);
                    }
                    else
                    {
                        MessageBox.Show("Please inject!", "DLL Manager");
                    }
                }
                else if (Properties.Settings.Default.SelectedDLL == 1)
                {
                    if (wrdApi.isAPIAttached())
                    {
                        wrdApi.SendLuaScript(script);
                    }
                    else
                    {
                        MessageBox.Show("Please inject!", "DLL Manager");
                    }
                }
                else if (Properties.Settings.Default.SelectedDLL == 2)
                {
                    if (krnlApi.IsInjected())
                    {
                        krnlApi.Execute(script);
                    }
                    else
                    {
                        MessageBox.Show("Please inject!", "DLL Manager");
                    }
                }
                else if (Properties.Settings.Default.SelectedDLL == 3)
                {
                    if (ManagerELECTRON.NamedPipeExist())
                    {
                        electronApi.Execute(script);
                    }
                    else
                    {
                        MessageBox.Show("Please inject!", "DLL Manager");
                    }
                }
            }
        }

        public static void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }
    }
}
