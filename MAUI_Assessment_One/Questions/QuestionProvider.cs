namespace MAUI_Assessment_One.Questions
{
    public class QuestionProvider
    {
        private List<QuestionDataModel> _questionDataModels;
        private int _questionIndex = 0;
        public QuestionProvider()
        {
            _questionDataModels = new List<QuestionDataModel>();
            FillQuestions();
        }
        private void FillQuestions()
        {
            _questionDataModels.Add(new QuestionDataModel { Question = "What is the capital of India?", OptionA = "Delhi", OptionB = "Mumbai", OptionC = "Kolkata", OptionD = "Chennai", CorrectAnswer = "Delhi"});
            _questionDataModels.Add(new QuestionDataModel { Question = "On which continent is the sahara desert located?", OptionA = "Asia", OptionB = "South America", OptionC = "Africa", OptionD = "Europe", CorrectAnswer = "Africa"});
            _questionDataModels.Add(new QuestionDataModel { Question = "Which country is the largest producer of coffee in the world?", OptionA = "Brazil", OptionB = "Colombia", OptionC = "Ethiopia", OptionD = "Vietnam", CorrectAnswer = "Brazil" });
            _questionDataModels.Add(new QuestionDataModel { Question = "Who is the author of the book \"To Kill a Mockingbird\"?", OptionA = "Harper Lee", OptionB = "John Steinbeck", OptionC = "Ernest Hemingway", OptionD = "F. Scott Fitzgerald", CorrectAnswer = "Harper Lee" });
            _questionDataModels.Add(new QuestionDataModel { Question = "Which animal is known as the \"Ship of the Desert\"?", OptionA = "Camel", OptionB = "Elephant", OptionC = "Horse", OptionD = "Zebra", CorrectAnswer = "Camel"});
        }
        public int GetTotalCount()
        {
            return _questionDataModels.Count;
        }
        public QuestionDataModel GetNextQuestions()
        {
            if(_questionIndex<_questionDataModels.Count)
            {
                return _questionDataModels[_questionIndex++];
            }
            else
            { 
                return null; 
            }
        }
    }
}
