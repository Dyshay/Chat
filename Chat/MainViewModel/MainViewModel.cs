using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Patterns.MVVM.Commands;
using ToolBox.Patterns.MVVM.ViewModels;

namespace Chat.MainViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ICommand _ConnexionCommand;

        private string _Login;

        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> _ID;

        public ObservableCollection<string> ID
        {
            get { return _ID = (_ID ?? new ObservableCollection<string>()); }
        }

        public ICommand ConnexionCommand
        {
            get { return _ConnexionCommand = _ConnexionCommand ?? new RelayCommand(ExecConnexion, CanExecuteConnexion); }
        }

        private bool CanExecuteConnexion()
        {
            if (!string.IsNullOrWhiteSpace(Login))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ExecConnexion()
        {
            ChatWindow cw = new ChatWindow();
            cw.DataContext = new MessageViewModel(Login);
            cw.Title = Login;
            cw.Show();
        }
    }
}
