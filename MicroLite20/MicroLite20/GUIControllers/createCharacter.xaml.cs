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
            AddToSTR.Clicked += setStatRoll;
            AddToDEX.Clicked += setStatRoll;
            AddToMIND.Clicked += setStatRoll;
            displayCharPage.Clicked += displayCharacter;
        }

        private void rollStats(Object sender, EventArgs args) {

            rollResult.Text = getStatRoll().ToString();
            rollButton.IsEnabled = false;
            StatButtons.IsVisible = true;
        }

        private void setStatRoll(Object sender, EventArgs args) {
            Button caller = (Button)sender;
            caller.Text = rollResult.Text;
            caller.IsEnabled = false;
            rollResult.Text = "";
            rollButton.IsEnabled = true;
            enableDisplay();
        }

        private int getStatRoll() {

            int[] statRolls = { DiceRoller.rollD6(), DiceRoller.rollD6() , DiceRoller.rollD6() , DiceRoller.rollD6() };

            int least = statRolls[0];
            int total = 0;

            for(int i = 0; i < statRolls.Length; i++) {
                if(statRolls[i] < least) {
                    least = statRolls[i];
                }
                total += statRolls[i];
            }

            return total - least;

        }

        private async void displayCharacter(Object sender, EventArgs args) {
            await Navigation.PushAsync(new displayCharacter(new CharacterData(int.Parse(AddToSTR.Text), int.Parse(AddToDEX.Text), int.Parse(AddToMIND.Text), Class.Items[Class.SelectedIndex], Race.Items[Race.SelectedIndex], CharacterName.Text)));
        }

        private void enableDisplay() {
            if(CharacterName.Text != "" && raceChanged && classChanged
                && !AddToSTR.IsEnabled && !AddToDEX.IsEnabled && !AddToMIND.IsEnabled) {
                displayCharPage.IsVisible = true;
            }else {
                displayCharPage.IsVisible = false;
            }
        }

        private void enableRollStats() {
            if(CharacterName.Text != "" && raceChanged && classChanged) {
                rollButton.IsVisible = true;
            }else {
                rollButton.IsVisible = false;
            }
        }

        private void nameChanged(Object sender, EventArgs args) {
            enableRollStats();
            enableDisplay();
        }

        private void confirmClassChange(Object sender, EventArgs args) {
            classChanged = true;
            enableRollStats();
            enableDisplay();
        }

        private void confirmRaceChange(Object sender, EventArgs args) {
            raceChanged = true;
            enableRollStats();
            enableDisplay();
        }

    }
}
