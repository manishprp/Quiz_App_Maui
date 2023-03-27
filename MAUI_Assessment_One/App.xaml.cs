namespace MAUI_Assessment_One;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage =new NavigationPage( new RegistrationPage());
	}
}
