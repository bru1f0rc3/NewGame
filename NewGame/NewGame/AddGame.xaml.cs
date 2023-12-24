using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGame : ContentPage
    {



        public AddGame()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            label1.Text = "";
            Random random = new Random();
            string[] options = { "rock", "scissors", "paper" };
            string computerChoice = options[random.Next(options.Length)];

            string input = strings.Text.ToLower();

            if (input == computerChoice)
            {
                label1.Text += "Ничья...";
            }
            else if ((input == "rock" && computerChoice == "scissors") ||
                     (input == "scissors" && computerChoice == "paper") ||
                     (input == "paper" && computerChoice == "rock"))
            {
                label1.Text += $"Компьютер выбрал {computerChoice},\nВы выиграли";
            }
            else
            {
                label1.Text += $"Компьютер выбрал {computerChoice},\nКомпьютер выиграл";
            }


        }
    }
}