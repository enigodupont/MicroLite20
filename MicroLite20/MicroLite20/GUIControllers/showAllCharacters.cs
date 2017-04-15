using MicroLite20.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MicroLite20.GUIControllers
{
	public partial class showAllCharacters : ContentPage
	{

        List<String> characters;

        public showAllCharacters ()
		{

            loadCharacterButtons();

           
        }

        private async void loadCharacter(Object sender, EventArgs args) {
            Button characterName = (Button) sender;
            await Navigation.PushAsync(new displayCharacter(await CharFileHandler.LoadCharacterFromFileSystem(characterName.Text)));
        }

        private async void loadCharacterButtons() {
           characters = await CharFileHandler.getAllCharacterFromFileSystem();
            StackLayout layout = new StackLayout();
            foreach (string character in characters) {
                Button button = new Button {
                    Text = character,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                button.Clicked += loadCharacter;
                layout.Children.Add(button);

            }
            Content = layout;
        }
    }
}
