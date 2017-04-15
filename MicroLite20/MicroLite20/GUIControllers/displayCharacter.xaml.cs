using MicroLite20.Utility;
using System;
using Xamarin.Forms;

namespace MicroLite20.GUIControllers {
    public partial class displayCharacter : ContentPage
	{

        CharacterData myPlayerData;

        public displayCharacter() {
            InitializeComponent();
        }

		public displayCharacter (CharacterData toShow)
		{
			InitializeComponent ();

            myPlayerData = toShow;

            CharName.Text += myPlayerData.characterName;
            CharRace.Text += myPlayerData.charRace;
            charClass.Text += myPlayerData.characterClassString;

            CharLevel.Text += myPlayerData.myLevel.ToString();
            CharExp.Text += myPlayerData.exp.ToString();

            CharHP.Text += myPlayerData.HP.ToString();
            CharSTR.Text += myPlayerData.STR.ToString();
            CharSTRMOD.Text += myPlayerData.STRMOD.ToString();
            CharDEX.Text += myPlayerData.DEX.ToString();
            CharDEXMOD.Text += myPlayerData.DEXMOD.ToString();
            CharMIND.Text += myPlayerData.MIND.ToString();
            CharMINDMOD.Text += myPlayerData.MINDMOD.ToString();

            ReturnButton.Clicked += returnToMainMenu;
            deleteButton.Clicked += deleteCharacter;
            saveButton.Clicked += saveCharacter;
            addEXP.Clicked += applyEXP;
            increaseSTR.Clicked += modifySTR;
            increaseDEX.Clicked += modifyDEX;
            increaseMIND.Clicked += modifyMIND;
        }

        private async void returnToMainMenu(Object sender, EventArgs args) {
            await Navigation.PopToRootAsync(true);
        }

        public void applyEXP(Object sender, EventArgs args) {
            int toApply;
            if(int.TryParse(expToAdd.Text, out toApply)) {
                int oldLevel = myPlayerData.myLevel;
                myPlayerData.applyEXP(toApply);

                if(myPlayerData.attributePoints > 0) {
                    //Prompt to increase a stat by one
                    increaseSTR.IsVisible = true;
                    increaseDEX.IsVisible = true;
                    increaseMIND.IsVisible = true;
                }

                CharHP.Text = "HP: " +  myPlayerData.HP.ToString();
                CharExp.Text = "Exp: " + myPlayerData.exp.ToString();
                CharLevel.Text = "Level: " + myPlayerData.myLevel.ToString();

            }
        }

        public void modifySTR(Object sender, EventArgs args) {
            myPlayerData.STR++;
            CharSTR.Text = "STR: " + myPlayerData.STR.ToString();
            CharSTRMOD.Text = "STR MOD: " + myPlayerData.STRMOD.ToString();
            --myPlayerData.attributePoints;
            if(myPlayerData.attributePoints == 0) {
                increaseSTR.IsVisible = false;
                increaseDEX.IsVisible = false;
                increaseMIND.IsVisible = false;
            }
        }

        public void modifyDEX(Object sender, EventArgs args) {
            myPlayerData.DEX++;
            CharDEX.Text = "DEX: " + myPlayerData.DEX.ToString();
            CharDEXMOD.Text = "DEX MOD: " + myPlayerData.DEXMOD.ToString();
            --myPlayerData.attributePoints;
            if (myPlayerData.attributePoints == 0) {
                increaseSTR.IsVisible = false;
                increaseDEX.IsVisible = false;
                increaseMIND.IsVisible = false;
            }
        }

        public void modifyMIND(Object sender, EventArgs args) {
            myPlayerData.MIND++;
            CharMIND.Text = "MIND: " + myPlayerData.MIND.ToString();
            CharMINDMOD.Text = "MIND MOD: " + myPlayerData.MINDMOD.ToString();
            --myPlayerData.attributePoints;
            if (myPlayerData.attributePoints == 0) {
                increaseSTR.IsVisible = false;
                increaseDEX.IsVisible = false;
                increaseMIND.IsVisible = false;
            }
        }

        public async void saveCharacter(Object sender, EventArgs args) {
            CharFileHandler.SaveCharacterToFileSystem(myPlayerData);
            await DisplayAlert("Save Status", "Save Succeded", "Understood");
        }

        public async void deleteCharacter(Object sender, EventArgs args) {
            CharFileHandler.DeleteCharacterFromFileSystem(myPlayerData);
            await DisplayAlert("Delete Status", "Delete Succeded", "Understood");
        }
    }


}
