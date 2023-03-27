using MAUI_Assessment_One.Model;
using MAUI_Assessment_One.Questions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MAUI_Assessment_One.ViewModel.QuizgameViewModel
{
    public class QuizgameViewModel : INotifyPropertyChanged
    {
        private string _currentQuestion;
        public double Percentage { get; set; }
        private bool _moveToResult;
        public bool MovetoResults { get { return _moveToResult; } set { _moveToResult = value; if (_moveToResult) { MoveToResultScreen(); } } }
        public event EventHandler<double> NavigateToResultsEvent;
        public string CurrentQuestion{ get { return _currentQuestion; } set { _currentQuestion = value; NotifyPropertyChanged();} }
        private int _points;
        public int Points { get { return _points; } set { _points = value; NotifyPropertyChanged(); } }
        private QuestionDataModel _currentQuestionDataModel;
        public QuestionDataModel CurrentQuestionDataModel { get { return _currentQuestionDataModel; } set { _currentQuestionDataModel = value; NotifyPropertyChanged(); } }
        private string _attempts;
        public string Attempts { get { return _attempts; } set { _attempts = value; NotifyPropertyChanged(); } }
        public ICommand SubmitAnswerCommand { get; private set; }
        private QuizgameModel _quizgameModel;

        public event PropertyChangedEventHandler PropertyChanged;
        private double _progress;
        public double Progress { get { return _progress; } set { _progress = value; NotifyPropertyChanged(); } }
        public bool OptionA { get; set; } = true;
        public bool OptionB { get; set; }
        public bool OptionC { get; set; }
        public bool OptionD { get; set; }
        private bool _isErrorVisible;
        public bool IsErrorVisible { get { return _isErrorVisible; } set { _isErrorVisible = value; NotifyPropertyChanged(); } }
        public QuizgameViewModel()
        {
            SubmitAnswerCommand = new Command(SubmitAnswer);
            _quizgameModel = new QuizgameModel();
            GetNextQuestion();
        }

        private void GetNextQuestion()
        {
            _quizgameModel.GetNextQuestion();
            CurrentQuestionDataModel = _quizgameModel.CurrentQuestion;
            Progress = _quizgameModel.Progress;
            CurrentQuestion = _quizgameModel.CurrentQuestionString;
            MovetoResults = _quizgameModel.MoveToResult;
            
        }

        private void MoveToResultScreen()
        {
            Percentage = _quizgameModel.Percentage;
            PlayerInfo.Points = Points;
            PlayerInfo.Percentage = Percentage;
            NavigateToResultsEvent?.Invoke(this, Percentage);
        }
       
        private void SubmitAnswer(object obj)
        {
            PassData();
            _quizgameModel.CheckAnswer();
            GetData();
            GetNextQuestion();
        }

        private void GetData()
        {
            Attempts = _quizgameModel.Attempt;
            Points = _quizgameModel.Points;
            IsErrorVisible = _quizgameModel.IsErrorVisible;
            MovetoResults = _quizgameModel.MoveToResult;
        }

        private void PassData()
        {
            _quizgameModel.OptionA = OptionA;
            _quizgameModel.OptionB = OptionB;
            _quizgameModel.OptionC = OptionC;
            _quizgameModel.OptionD = OptionD;
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyname ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));  
        }
    }
}
