using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Diagnostico
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IconCard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedCard)
            {
                string programName = string.Empty;

                switch (clickedCard.Name)
                {
                    case "CpuZCard":
                        programName = "Cpu-Z.exe";
                        break;
                    case "MemoryCleanerCard":
                        programName = "WinMemoryCleaner.exe";
                        break;
                    case "CrystalDiskCard":
                        programName = "CrystalDisk.exe";
                        break;
                    case "WinDirStatCard":
                        programName = "WinSatDir.exe";
                        break;
                    case "GeekUninstallCard":
                        programName = "Geek Unistaller.exe";
                        break;
                    case "HwinfoCard":
                        programName = "HWiNFO.exe";
                        break;
                    default:
                        return;
                }

                string dataFolderPath = "data";
                string executablePath = Path.Combine(Directory.GetCurrentDirectory(), dataFolderPath, programName);

                LaunchProgram(executablePath);
            }
        }

        private void LaunchProgram(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    Process.Start(path);
                }
            }
            catch (Exception)
            {
                // Silence all exceptions
            }
        }
    }
}