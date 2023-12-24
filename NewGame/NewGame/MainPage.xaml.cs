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

        private async void StartGame_Clicked(object sender, EventArgs e)
        {
            bool accept = await DisplayAlert("Игра", "Здесь вы будете отгадывать число комьпютера", "OK", "НЕТ");
            await Task.Delay(1500);
            if (accept == true)
            {
                await Navigation.PushAsync(new StartGamePage());
            }
            else
            {
                await Navigation.PushAsync(new MainPage());
            }
        }

        private async void StartGameSecond_Clicked(object sender, EventArgs e)
        {
            bool accept = await DisplayAlert("Игра", "Здесь вы будете загадывать число, а компьютер отгадывать", "OK", "НЕТ");
            await Task.Delay(1500);
            if (accept == true)
            {
                await Navigation.PushAsync(new StartGamePage_Second());
            }
            else
            {
                await Navigation.PushAsync(new MainPage());
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
                await Navigation.PushAsync(new AddGame());
        }
    }
}
