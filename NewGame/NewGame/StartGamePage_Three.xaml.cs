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
    public partial class StartGamePage_Three : ContentPage
    {
        public StartGamePage_Three()
        {
            InitializeComponent();
        }

        private async Task PlayGame()
        {
            Random random = new Random();
            int targetNumber = random.Next(1, 101);

            for (int i = 1; ; i++)
            {
                string input = await DisplayPromptAsync("Игра", $"Попытка {i}: Угадайте число от 1 до 100.", "OK", "Отмена");

                if (input == null) // Пользователь нажал отмену
                {
                    await DisplayAlert("Игра", "Игра отменена", "OK");
                    break;
                }

                if (Int32.TryParse(input, out int guess)) // Проверяем, что введен корректное число
                {
                    if (guess < targetNumber)
                    {
                        await DisplayAlert("Игра", "Загаданное число больше.", "OK");
                    }
                    else if (guess > targetNumber)
                    {
                        await DisplayAlert("Игра", "Загаданное число меньше.", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Поздравляем!", $"Вы угадали число {targetNumber} за {i} попыток", "УРА");
                        await Task.Delay(500);
                        await DisplayAlert("Игра", "Вы выиграли\n Перемещение в главное меню", "Ура");
                        await Navigation.PushAsync(new MainPage());
                        MyImage.Source = "png_file_1.png";
                        break;
                    }
                }
                else
                {
                    await DisplayAlert("Ошибка", "Пожалуйста, введите корректное число.", "OK");
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PlayGame();
        }
    }
}