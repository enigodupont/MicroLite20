using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Microlite20.GUIControllers {
    public partial class MainMenu : ContentPage {
        
        public MainMenu() {
            InitializeComponent();

            addCharButton.Clicked += openCreateCharacter;
        }

        public void openCreateCharacter(Object sender, EventArgs args) {
            Navigation.PushAsync(new createCharacter());
        }
    }
}
