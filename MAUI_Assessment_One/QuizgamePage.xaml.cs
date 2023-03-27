using MAUI_Assessment_One.ViewModel.QuizgameViewModel;

namespace MAUI_Assessment_One;

public partial class QuizgamePage : ContentPage
{
	private QuizgameViewModel _quizGameViewModel;
	public QuizgamePage()
	{
		InitializeComponent();
        NavigationPage.SetHasBackButton(this,false);
        _quizGameViewModel = (QuizgameViewModel)BindingContext;
        _quizGameViewModel.NavigateToResultsEvent += QuizGameViewModel_NavigateToResultsEvent;
    }
    protected override bool OnBackButtonPressed()
    {
        return true;
        //return base.OnBackButtonPressed();
    }
    private async void QuizGameViewModel_NavigateToResultsEvent(object sender, double e)
    {
        await Navigation.PushAsync(new ResultsPage(e));
        
    }
}