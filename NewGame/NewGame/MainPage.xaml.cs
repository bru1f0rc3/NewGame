using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewGame
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonExit_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void StartGame_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StartGamePage());
        }
    }
}
