using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ModernDisegn.Core;

namespace ModernDisegn.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        /* commands */
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutdownWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand MinimizaWindowCommand { get; set; }

        public RelayCommand ShowProtectedView { get; set; }
        public RelayCommand ShowSettingsView { get; set; }
        
        
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ProtectionViewModel ProtectionVM { get; set; }
        public SettingViewModel SettingVM { get; set; }


        public MainViewModel()
        {
            ProtectionVM = new ProtectionViewModel();
            SettingVM = new SettingViewModel();
            CurrentView = ProtectionVM;

            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
         
            MoveWindowCommand = new RelayCommand(o=>{Application.Current.MainWindow.DragMove();});
            ShutdownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximizeWindowCommand = new RelayCommand(o =>
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                }
                else Application.Current.MainWindow.WindowState = WindowState.Maximized;
            });
            MinimizaWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.WindowState = WindowState.Minimized; });

            ShowProtectedView = new RelayCommand(o => { CurrentView = ProtectionVM; });
            ShowSettingsView = new RelayCommand(o => { CurrentView = SettingVM; });
        }
    }
}
