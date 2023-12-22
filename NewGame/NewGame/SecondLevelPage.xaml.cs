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
public partial class SecondLevelPage : ContentPage
{
        private int targetNumber;
        private int attempts;

        public SecondLevelPage()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            targetNumber = -1;
            attempts = 0;

            ResultLabel.Text = "Загадайте четырехзначное число.";
            AttemptsLabel.Text = $"Количество попыток: {attempts}";
        }

        private void StartGameButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(NumberEntry.Text, out int userNumber))
            {
                if (IsValidNumber(userNumber))
                {
                    targetNumber = userNumber;

                    ResultLabel.Text = "Компьютер угадывает число...";
                    CheckButton.IsEnabled = false;
                    StartGameButton.IsEnabled = false;

                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        int computerGuess = GenerateComputerGuess();

                        attempts++;

                        if (computerGuess == targetNumber)
                        {
                            ResultLabel.Text = $"Компьютер угадал число {computerGuess}! Поздравляем!";
                            return false;
                        }
                        else
                        {
                            ResultLabel.Text = $"Попытка {attempts}: Компьютер предполагает число {computerGuess}.";
                            AttemptsLabel.Text = $"Количество попыток: {attempts}";
                            return true;
                        }
                    });
                }
                else
                {
                    ResultLabel.Text = "Пожалуйста, введите четырехзначное число с уникальными цифрами.";
                }
            }
            else
            {
                ResultLabel.Text = "Пожалуйста, введите четырехзначное число.";
            }
        }

        private bool IsValidNumber(int number)
        {
            string numberString = number.ToString();

            if (numberString.Length != 4)
            {
                return false;
            }

            return numberString.Distinct().Count() == numberString.Length;
        }

        private int GenerateComputerGuess()
        {
            int lowerBound = 1000;
            int upperBound = 9999;

            if (targetNumber >= 1000 && targetNumber <= 9999)
            {
                lowerBound = (targetNumber / 1000) * 1000;
                upperBound = lowerBound + 999;
            }

            Random random = new Random();
            int randomGuess = random.Next(lowerBound, upperBound + 1);

            return randomGuess;
        }

        private async void CheckButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(NumberEntry.Text, out int userNumber))
            {
                if (IsValidNumber(userNumber))
                {
                    attempts++;

                    if (userNumber == targetNumber)
                    {
                        ResultLabel.Text = $"Поздравляем! Вы угадали число {userNumber} за {attempts} попыток.";
                        image.Source = "png_file_1.png";
                        bool input = await DisplayAlert("Игра", "Может все таки хочешь прекратить?", "Дальше идем", "Все я устал ждать");
                        if (!input)
                        {
                            await Navigation.PushAsync(new ThreeLevelPage());
                        }
                        else
                        {
                            await Navigation.PushAsync(new MainPage());
                        }
                        return;
                    }

                    int bulls = CountBulls(userNumber);
                    int cows = CountCows(userNumber);

                    ResultLabel.Text = $"Попытка {attempts}: Быки: {bulls}, Коровы: {cows}.";
                    AttemptsLabel.Text = $"Количество попыток: {attempts}";
                }
                else
                {
                    ResultLabel.Text = "Пожалуйста, введите четырехзначное число с уникальными цифрами.";
                }
            }
            else
            {
                ResultLabel.Text = "Пожалуйста, введите четырехзначное число.";
            }
        }

        private int CountBulls(int number)
        {
            string targetString = targetNumber.ToString();
            string numberString = number.ToString();

            int bulls = 0;

            for (int i = 0; i < 4; i++)
            {
                if (targetString[i] == numberString[i])
                {
                    bulls++;
                }
            }

            return bulls;
        }

        private int CountCows(int number)
        {
            string targetString = targetNumber.ToString();
            string numberString = number.ToString();

            int cows = 0;

            for (int i = 0; i < 4; i++)
            {
                if (targetString.Contains(numberString[i]))
                {
                    cows++;
                }
            }

            return cows;
        }
    }
}