namespace MAUI_Assessment_One.Model
{
    public class WelcomeModel
    {
        private string _playerName;
        public string PlayerName { get { return _playerName; } set { _playerName = value; PlayerInfo.Name = _playerName; } }
    }
}
