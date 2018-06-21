using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Hello_Xamarin_Forms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            var main = (MainPage)MainPage;
            main.SetupClient();
        }

        protected override void OnSleep()
        {
            // start the backgrounding workflow here.
        }

        protected override void OnResume()
        {
            // start the foregrounding workflow here.
        }
    }
}
