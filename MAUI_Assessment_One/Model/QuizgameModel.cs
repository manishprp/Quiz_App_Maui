using MAUI_Assessment_One.Questions;

namespace MAUI_Assessment_One.Model
{
    public class QuizgameModel
    {
        private QuestionProvider _questionProvider;
        public bool MoveToResult { get; private set; }
        public double Progress { get; private set; }
        private int _attempt;
        public QuestionDataModel CurrentQuestion { get; private set; }
        public string Attempt { get;private set; }
        public string CurrentQuestionString { get; private set; }
        private int _currentQuestionNumber = 0;
        public int Points { get; private set; }
        public bool IsErrorVisible { get; private set; }
        public bool OptionA { get; set; }
        public double Percentage { get; private set; }
        public bool OptionB { get; set; }
        public bool OptionC { get; set; }
        private bool isCorrect = true;
        public bool OptionD { get; set; }
        public QuizgameModel()
        {
            _questionProvider = new QuestionProvider();
            _attempt = 3;
        }
        public void CheckAnswer()
        {
            if(OptionA)
            {
                if(CurrentQuestion.CorrectAnswer.Trim().ToLower()==CurrentQuestion.OptionA.Trim().ToLower())
                {
                    CorrectAnswer();
                   
                }
                else
                {
                    InCorrectAnswer();
                }
            }
            else if(OptionB) 
            {
                if (CurrentQuestion.CorrectAnswer.Trim().ToLower() == CurrentQuestion.OptionB.Trim().ToLower())
                {
                    CorrectAnswer();
                }
                else
                {
                    InCorrectAnswer();
                }
            }
            else if(OptionC) 
            {
                if (CurrentQuestion.CorrectAnswer.Trim().ToLower() == CurrentQuestion.OptionC.Trim().ToLower())
                {
                    CorrectAnswer();
                }
                else
                {
                    InCorrectAnswer();
                }
            }
            else 
            {
                if (CurrentQuestion.CorrectAnswer.Trim().ToLower() == CurrentQuestion.OptionD.Trim().ToLower())
                {
                    CorrectAnswer();
                }
                else
                {
                    InCorrectAnswer();
                }
            }
        }
        public void GetNextQuestion()
        {
            if (!isCorrect)
                return;
            if (_currentQuestionNumber == _questionProvider.GetTotalCount())
            {
                GetResults();
                return;
            }
            _currentQuestionNumber += 1;
            CurrentQuestion = _questionProvider.GetNextQuestions();
            Progress = (double)_currentQuestionNumber / _questionProvider.GetTotalCount();
            CurrentQuestionString = "Question " + _currentQuestionNumber.ToString() + "/"+_questionProvider.GetTotalCount().ToString();
        }

        private void GetResults()
        {
            var totalScore = _questionProvider.GetTotalCount()*10.0;
            Percentage = Points / totalScore * 100.0;
            MoveToResult = true;
        }

        private void InCorrectAnswer()
        {
            isCorrect = false;
            if (Points>=5)
                Points -= 5;
            else 
                Points = 0;
            _attempt = _attempt - 1;
            if (_attempt == 2)
            {
                IsErrorVisible = true;
                Attempt = "You have 2 more attempts";
            }
            if (_attempt == 1)
            {
                IsErrorVisible = true;
                Attempt = "This is your last attempt";
            }
            if (_attempt == 0)
            {
                GetResults();
            }
        }
        private void CorrectAnswer()
        {
            isCorrect = true;
            Points += 10;
        }
    }
}
