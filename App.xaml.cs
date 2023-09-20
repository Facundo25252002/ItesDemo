using ItesDemo.Views;

namespace ItesDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new LoginPage();
	}
}
