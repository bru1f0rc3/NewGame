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
public partial class ThreeLevelPage : ContentPage
{
        private int targetNumber;
        private int attempts;
        private List<int[]> possibleNumbers = new List<int[]>();
        private List<int> guessedNumbers = new List<int>();

        public ThreeLevelPage()
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

        private async void StartGameButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(NumberEntry.Text, out int userNumber))
            {
                if (IsValidNumber(userNumber))
                {
                    targetNumber = userNumber;

                    ResultLabel.Text = "Компьютер угадывает число...";
                    StartGameButton.IsEnabled = false;

                    await Task.Run(async () =>
                    {
                        Random random = new Random();
                        while (true)
                        {
                            int computerGuess = GenerateComputerGuess(random);

                            attempts++;

                            if (computerGuess == targetNumber)
                            {
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    ResultLabel.Text = $"Компьютер угадал число {computerGuess}! Поздравляем!";
                                });
                                await Task.Delay(2000);
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    image.Source = "png_file_1.png";
                                });
                                await Task.Delay(2500);
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    Navigation.PushAsync(new MainPage());
                                });
                                break;
                            }
                            else
                            {
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    ResultLabel.Text = $"Попытка {attempts}: Компьютер предполагает число {computerGuess}.";
                                    AttemptsLabel.Text = $"Количество попыток: {attempts}";
                                });
                            }

                            await Task.Delay(1000);
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

        private int GenerateComputerGuess(Random random)
        {
            int guess = 0;

            if (possibleNumbers.Count > 0)
            {
                int index = random.Next(possibleNumbers.Count);
                int[] numberArray = possibleNumbers[index];
                guess = numberArray[0] * 1000 + numberArray[1] * 100 + numberArray[2] * 10 + numberArray[3];
                possibleNumbers.RemoveAt(index);
                guessedNumbers.Add(guess);
            }
            else
            {
                do
                {
                    int offset = random.Next(100);
                    guess = targetNumber - 50 + offset;
                } while (guessedNumbers.Contains(guess) || guess < 1000 || guess > 9999);
                guessedNumbers.Add(guess);
            }

            return guess;
        }

        private async void PausePlayGame(object sender, EventArgs e)
        {
            bool accept = await DisplayAlert("Система", "Вы точно хотите остановиться?", "Да", "Нет");

            if (accept == true)
            {
                await Navigation.PushAsync(new ThreeLevelPage());
            }
            else
            {
                await DisplayAlert("Система", "Вы ошибочно?", "Да");
            }
        }
    }
}