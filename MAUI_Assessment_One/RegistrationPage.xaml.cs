using MAUI_Assessment_One.ViewModel.RegisterViewModel;

namespace MAUI_Assessment_One;

public partial class RegistrationPage : ContentPage
{
	private RegisterViewModel _registerViewModel;
	public RegistrationPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        _registerViewModel = (RegisterViewModel)BindingContext;
        _registerViewModel.MoveToWelcomePageEvent += RegisterViewModel_MoveToWelcomePageEvent;
    }

    private async void RegisterViewModel_MoveToWelcomePageEvent(object sender, string e)
    {
        await Navigation.PushAsync(new WelcomePage(e));
    }
}

