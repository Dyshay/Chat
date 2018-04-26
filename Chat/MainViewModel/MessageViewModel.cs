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
    public class MessageViewModel : ViewModelBase
    {
        private string _Login;
        public string Login
        {
            get
            {
                return _Login;
            }
            private set
            {
                _Login = value;
            }
        }
        private ICommand _SendCommand;
        
        public ICommand SendCommand
        {
            get { return _SendCommand = _SendCommand ?? new RelayCommand(ExecSend, CanExecSend); }
        }
        

        private ObservableCollection<string> _MessageView;

        public ObservableCollection<string> MessageView
        {
            get { return _MessageView = (_MessageView ?? new ObservableCollection<string>());}
        }
        private string _Text;

        public string Text
        {
            get { return _Text; }
            set { _Text = value; RaisePropertyChanged(); }
        }
        private bool CanExecSend()
        {
            if (!string.IsNullOrWhiteSpace(Text))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void ExecSend()
        {
            string Message = $"{Login} : {Text}";
            Mediator<string>.Instance.Send(Message);
            Text = null;
        }
        public MessageViewModel(string Login)
        {
            Mediator<string>.Instance.Register(NewMessageReceveid);
            this.Login = Login;
            MessageView.Add($"Bienvenue {Login} vous êtes connecté");
            Mediator<string>.Instance.Send($"{Login} est connecté");
        }

        private void NewMessageReceveid(string Message)
        {
            MessageView.Add(Message);
            //Mediator<string>.Instance.Send(Text);
        }
    }
}
