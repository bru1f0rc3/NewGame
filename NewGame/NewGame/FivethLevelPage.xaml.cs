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
public partial class FivethLevelPage : ContentPage
{
        private Random rand = new Random();
        private int[] computerGuess = new int[4];
        private int[] availableDigits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private int coincidence;
        private int partlycoincidence;

        public FivethLevelPage()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            GenerateComputerGuess();
            label2.Text = "";
            label3.Text = "";
            textBox1.IsEnabled = true;
        }

        private void GenerateComputerGuess()
        {
            for (int i = 0; i < 4; i++)
            {
                int randomIndex = rand.Next(0, availableDigits.Length);
                computerGuess[i] = availableDigits[randomIndex];
                availableDigits = availableDigits.Where((val, index) => index != randomIndex).ToArray();
            }
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox1.Text.Length > 4)
            {
                textBox1.Text = e.OldTextValue;
            }
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 4)
            {
                await DisplayAlert("Ошибка", "Введенное число должно быть четырехзначным", "OK");
            }
            else
            {
                CompareNumbers();
                ShowResult();
            }
            textBox1.Text = "";
            if (coincidence == 4)
            {
                await DisplayAlert("Игра", "Пользователь угадал число!", "OK");
                await Task.Delay(1500);
                image.Source = "png_file_1.png";
                await Task.Delay(5000);
                await DisplayAlert("Игра", "Поздравляю, вы угадали число! еще раз!!!", "OK");
                await Task.Delay(1500);
                await DisplayAlert("Игра", "Наслаждайтесь закрашенными коровками", "OK");
                await Task.Delay(5000);
                await Navigation.PushAsync(new MainPage());
            }
        }

        private void ShowResult()
        {
            label2.Text += textBox1.Text + " полностью совпало " + coincidence + " совпало " + partlycoincidence + "\n";
        }

        private void CompareNumbers()
        {
            coincidence = 0;
            partlycoincidence = 0;
            char[] userGuessChars = textBox1.Text.ToCharArray();
            int[] userGuess = Array.ConvertAll(userGuessChars, c => (int)Char.GetNumericValue(c));

            for (int i = 0; i < 4; i++)
            {
                if (computerGuess.Contains(userGuess[i]))
                {
                    if (computerGuess[i] == userGuess[i])
                    {
                        coincidence++;
                    }
                    else
                    {
                        partlycoincidence++;
                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            answer.Text += $"Ответ: {string.Join("", computerGuess)}";
        }

    }
}