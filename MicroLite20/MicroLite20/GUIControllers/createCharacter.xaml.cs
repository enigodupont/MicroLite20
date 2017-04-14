using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MicroLite20.GUIControllers
{
	public partial class createCharacter : ContentPage
	{

        private bool raceChanged = false;
        private bool classChanged = false;

		public createCharacter ()
		{
			InitializeComponent ();

            CharacterName.TextChanged += nameChanged;

            Class.SelectedIndexChanged += confirmClassChange;

            Race.SelectedIndexChanged += confirmRaceChange;

            rollButton.Clicked += rollStats;
        }

        private async void rollStats(Object sender, EventArgs args) {
            int STR = Utility.DiceRoller.rollD6();
            int DEX = Utility.DiceRoller.rollD6();
            int MIND = Utility.DiceRoller.rollD6();

            await DisplayAlert("Roll Results", "Your Rolled\nSTR: " + STR + "\nDEX: " + DEX + "\nMIND: " + MIND, "Understood");

            await Navigation.PushAsync(new displayCharacter(new CharacterData(STR, DEX, MIND, Class.Items[Class.SelectedIndex], CharacterName.Text)));
        }

        private void enableRollStats() {
            if(CharacterName.Text != "" && raceChanged && classChanged) {
                rollButton.IsEnabled = true;
            }else {
                rollButton.IsEnabled = false;
            }
        }

        private void nameChanged(Object sender, EventArgs args) {
            enableRollStats();
        }

        private void confirmClassChange(Object sender, EventArgs args) {
            classChanged = true;
            enableRollStats();
        }

        private void confirmRaceChange(Object sender, EventArgs args) {
            raceChanged = true;
            enableRollStats();
        }

    }
}
