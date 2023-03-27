using MAUI_Assessment_One.ViewModel.ResultsViewModel;

namespace MAUI_Assessment_One;

public partial class ResultsPage : ContentPage
{
	private ResultsViewModel _resultsPageViewModel;
	public ResultsPage(double Percentage)
	{
		InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);
        _resultsPageViewModel = (ResultsViewModel)BindingContext;
        _resultsPageViewModel.RestartGame += ResultsPageViewModel_RestartGame;
   }

    private async void ResultsPageViewModel_RestartGame(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}