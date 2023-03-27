using MAUI_Assessment_One.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MAUI_Assessment_One.ViewModel.WelcomeViewModel
{
    public class WelcomeViewModel : INotifyPropertyChanged
    {
        private string _playerName;
        private WelcomeModel _welcomeModel;
        public event EventHandler StartGameEvent;
        public ICommand StartGameCommand { get; private set; }
        public string PlayerName { get { return _playerName; } set { _playerName = value; NotifyPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public WelcomeViewModel()
        {
            StartGameCommand = new Command(StartGame);
            _welcomeModel = new WelcomeModel();
        }

        private void StartGame(object obj)
        {
            _welcomeModel.PlayerName = PlayerName;
            StartGameEvent?.Invoke(this, new EventArgs());  
        }

        public void NotifyPropertyChanged([CallerMemberName]string propertyname="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
