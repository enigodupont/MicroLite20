using Xamarin.Forms;

using MicroLite20.GUIControllers;
namespace MicroLite20 {
    public class App : Application{
        
        public App() {
            MainPage = new NavigationPage(new MainMenu());
        }
        
    }
}

