using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlateReader.ViewModel
{
    public class FileDialogViewModel : ViewModelBase
    {
        private string _selectedPath;
        private string _defaultPath;

        public static RelayCommand OpenCommand { get; set; }
        public string SelectedPath
        {
            get { return _selectedPath; }
            set
            {
                _selectedPath = value;
                RaisePropertyChanged("SelectedPath");
                SendMessage();
            }
        }

        [PreferredConstructor]
        public FileDialogViewModel()
        {
            RegisterCommands();
        }

        public FileDialogViewModel(string defaultPath)
        {
            _defaultPath = defaultPath;
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            OpenCommand = new RelayCommand(ExecuteOpenFileDialog);
        }

        private void ExecuteOpenFileDialog()
        {
            var dialog = new OpenFileDialog { InitialDirectory = _defaultPath };
            if (dialog.ShowDialog() == true)// Open Win 32 file dialogbox
            {
                SelectedPath = dialog.FileName;
            }
        }

        /// <summary>
        /// ViewModel to ViewModel communication can be done by two patterns 1. Mediator and 2.EventAggrigator
        /// MVVMLight provides Messenger class it decreases coupling between viewmodels. Every viewmodel can communicate with another viewmodel without any association between them
        /// </summary>
        private void SendMessage()
        {
            MessengerInstance.Send<NotificationMessage>(new NotificationMessage(SelectedPath));
        }
    }
}
