using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MicroLite20.GUIControllers
{
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
            CharRace.Text += myPlayerData.playerRace;
            CharSTR.Text += myPlayerData.STR.ToString();
            CharDEX.Text += myPlayerData.DEX.ToString();
            CharMIND.Text += myPlayerData.MIND.ToString();
            CharHP.Text += myPlayerData.HP.ToString();
        }
	}
}
