using CommunityToolkit.Maui.Converters;
using System.Text.RegularExpressions;

namespace MAUI_Assessment_One.Model
{
    public class RegisterModel
    {
        public string PlayerName { get; set; }
        private Regex _regex = new Regex("^[a-zA-Z]+$");
        public bool IsCorrect { get; private set; }
        public void Validate()
        {
            IsCorrect = _regex.IsMatch(PlayerName);
        }
    }
}
