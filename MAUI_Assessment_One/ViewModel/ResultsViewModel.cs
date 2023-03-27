using MAUI_Assessment_One.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MAUI_Assessment_One.ViewModel.ResultsViewModel
{
    public class ResultsViewModel : INotifyPropertyChanged
    {
        private string _review;
        private ResultsModel _resultsModel;
        public event EventHandler RestartGame;
        public string Review { get { return _review; } set { _review = value; NotifyPropertyChanged(); } }
        private string _imageSource;
        public string ImageSource { get { return _imageSource; } set { _imageSource = value; NotifyPropertyChanged(); } }
        private string _points;

        public string Points { get { return _points; } set { _points = value; NotifyPropertyChanged(); } }
        private string _nameOfPlayer;
        public string NameOfPlayer { get { return _nameOfPlayer; } set { _nameOfPlayer = value; NotifyPropertyChanged(); } }
        public ICommand ReplayCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ResultsViewModel()
        {
            ReplayCommand = new Command(ReplayButton);
            _resultsModel = new ResultsModel();
            Review = _resultsModel.Review;
            NameOfPlayer = _resultsModel.NameOfPlayer;
            Points = _resultsModel.PointsString;
            ImageSource = _resultsModel.ImageSource;
        }

        private void ReplayButton(object obj)
        {
            RestartGame?.Invoke(this, EventArgs.Empty);
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
