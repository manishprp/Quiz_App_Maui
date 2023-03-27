using System.Windows.Input;

namespace MAUI_Assessment_One.Model
{
    public class ResultsModel
    {
        private int points;
        public double Percentage { get; set; }
        public string NameOfPlayer { get; set; }
        public string Review { get; set; }
        public string ImageSource { get; set; }
        public string PointsString { get; set; }
        public ResultsModel()
        {
            points = PlayerInfo.Points;
            NameOfPlayer = PlayerInfo.Name; 
            Percentage = PlayerInfo.Percentage;
            PointsString = "Your Points: " + points.ToString();
            SetUpData();
        }

        private void SetUpData()
        {
            if(Percentage == 100.0)
            {
                ImageSource = "gold";
                Review = "Excellent";
            }
            else if (Percentage>=76 && Percentage<=96)
            {
                ImageSource = "silver";
                Review = "Very Good!!!";
            }
            else if (Percentage >= 51 && Percentage <= 75)
            {
                ImageSource = "bronze";
                Review = "Good!!!";
            }
            else
            {
                ImageSource = "ribbon";
                Review = "Can do better...";
            }
        }
    }
}
