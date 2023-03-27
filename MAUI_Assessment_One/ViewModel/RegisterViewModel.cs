using CommunityToolkit.Maui.Alerts;
using MAUI_Assessment_One.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MAUI_Assessment_One.ViewModel.RegisterViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private RegisterModel _registerModel;
        private string _playerName;
        public event EventHandler<string> MoveToWelcomePageEvent;
        public string PlayerName { get { return _playerName; } set { _playerName = value; NotifyPropertyChanged(); } }
        public ICommand SubmitPlayerNameCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public RegisterViewModel()
        {
            _registerModel = new RegisterModel();
            SubmitPlayerNameCommand = new Command(SubmitPlayerName);
            PlayerName = string.Empty;
        }

        private async void SubmitPlayerName(object obj)
        {
            _registerModel.PlayerName = PlayerName;
            _registerModel.Validate();
            var result = _registerModel.IsCorrect;
            if(result)
            {
                MoveToWelcomePageEvent?.Invoke(this, PlayerName);
            }
            else
            {
                await Toast.Make( "Please enter name.",CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                PlayerName = string.Empty;
            }
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
