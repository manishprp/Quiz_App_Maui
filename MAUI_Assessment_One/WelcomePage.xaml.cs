using MAUI_Assessment_One.ViewModel.WelcomeViewModel;

namespace MAUI_Assessment_One;

public partial class WelcomePage : ContentPage
{
	private WelcomeViewModel _welcomeViewModel;
	public WelcomePage(string PlayerName)
	{
		InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);
        _welcomeViewModel = (WelcomeViewModel)BindingContext;
        _welcomeViewModel.PlayerName = PlayerName;
        _welcomeViewModel.StartGameEvent += WelcomeViewModel_StartGameEvent;
    }

    private async void WelcomeViewModel_StartGameEvent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QuizgamePage());
    }
}