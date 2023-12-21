using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartGamePage_Second : ContentPage
    {
        private int[] secretNumber;
        private int[] currentGuess;
        private int guessAttempts;

        private const int NumberLength = 4;

        public StartGamePage_Second()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            secretNumber = GenerateSecretNumber();
            currentGuess = GenerateInitialGuess();
            guessAttempts = 0;

            label2.Text = "";
            label3.Text = "";
        }

        private int[] GenerateSecretNumber()
        {
            int[] number = new int[NumberLength];
            Random rand = new Random();

            for (int i = 0; i < NumberLength; i++)
            {
                number[i] = rand.Next(0, 10);
            }

            return number;
        }

        private int[] GenerateInitialGuess()
        {
            int[] guess = new int[NumberLength];

            for (int i = 0; i < NumberLength; i++)
            {
                guess[i] = 0;
            }

            return guess;
        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {
            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < NumberLength; i++)
            {
                if (currentGuess[i] == secretNumber[i])
                {
                    bulls++;
                }
                else if (secretNumber.Contains(currentGuess[i]))
                {
                    cows++;
                }
            }

            guessAttempts++;

            label2.Text = $"Ход {guessAttempts}: {string.Join("", currentGuess)}";
            label3.Text = $"Быки: {bulls}, Коровы: {cows}";

            if (bulls == NumberLength)
            {
                label2.Text += "\nПоздравляем! Компьютер угадал число.";
                button1.IsEnabled = false;
                await Task.Delay(2500);
                await DisplayAlert("Игра", "Увы компьютер угадал ваше число", "Жалко");
                await Task.Delay(2500);
                await DisplayAlert("Игра", "Вы переместитесь в главное меню через 5 секунд", "OK");
                await Task.Delay(5000);
            }
            else
            {
                currentGuess = GenerateNextGuess();
            }
        }

        private int[] GenerateNextGuess()
        {
            int[] nextGuess = new int[NumberLength];
            Random rand = new Random();

            for (int i = 0; i < NumberLength; i++)
            {
                nextGuess[i] = rand.Next(0, 10);
            }

            return nextGuess;
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            NewGame();
            button1.IsEnabled = true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool checking = await DisplayAlert("Игра", "Вы точно хотите выйти?", "Да", "Нет");
            await Task.Delay(1500);
            if (checking == true)
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Игра", "Ошибочно нажал тогда ладно", "OK");
            }
        }
    }
}