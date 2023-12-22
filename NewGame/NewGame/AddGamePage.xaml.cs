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
public partial class AddGamePage : ContentPage
{
public AddGamePage ()
{
InitializeComponent ();
}

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            int col = Grid.GetColumn(this.elf0);
            int row = Grid.GetRow(this.elf0);
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    col--;
                    break;
                case SwipeDirection.Right:
                    col++;
                    break;
                case SwipeDirection.Up:
                    row--;
                    break;
                case SwipeDirection.Down:
                    row++;
                    break;
            }
            Grid.SetColumn(this.elf0, col);
            Grid.SetRow(this.elf0, row);
        }

        private void SwipeGestureRecognizer_Swiped1(object sender, SwipedEventArgs e)
        {
            int col = Grid.GetColumn(this.elf1);
            int row = Grid.GetRow(this.elf1);
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    col--;
                    break;
                case SwipeDirection.Right:
                    col++;
                    break;
                case SwipeDirection.Up:
                    row--;
                    break;
                case SwipeDirection.Down:
                    row++;
                    break;
            }
            Grid.SetColumn(this.elf1, col);
            Grid.SetRow(this.elf1, row);
        }

        private void SwipeGestureRecognizer_Swiped8(object sender, SwipedEventArgs e)
        {
            int col = Grid.GetColumn(this.elf8);
            int row = Grid.GetRow(this.elf8);
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    col--;
                    break;
                case SwipeDirection.Right:
                    col++;
                    break;
                case SwipeDirection.Up:
                    row--;
                    break;
                case SwipeDirection.Down:
                    row++;
                    break;
            }
            Grid.SetColumn(this.elf8, col);
            Grid.SetRow(this.elf8, row);
        }

        private void SwipeGestureRecognizer_Swiped7(object sender, SwipedEventArgs e)
        {
            int col = Grid.GetColumn(this.elf7);
            int row = Grid.GetRow(this.elf7);
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    col--;
                    break;
                case SwipeDirection.Right:
                    col++;
                    break;
                case SwipeDirection.Up:
                    row--;
                    break;
                case SwipeDirection.Down:
                    row++;
                    break;
            }
            Grid.SetColumn(this.elf7, col);
            Grid.SetRow(this.elf7, row);
        }

        private void SwipeGestureRecognizer_Swiped6(object sender, SwipedEventArgs e)
        {
            int col = Grid.GetColumn(this.elf6);
            int row = Grid.GetRow(this.elf6);
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    col--;
                    break;
                case SwipeDirection.Right:
                    col++;
                    break;
                case SwipeDirection.Up:
                    row--;
                    break;
                case SwipeDirection.Down:
                    row++;
                    break;
            }
            Grid.SetColumn(this.elf6, col);
            Grid.SetRow(this.elf6, row);
        }

        private void SwipeGestureRecognizer_Swiped5(object sender, SwipedEventArgs e)
        {
            int col = Grid.GetColumn(this.elf5);
            int row = Grid.GetRow(this.elf5);
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    col--;
                    break;
                case SwipeDirection.Right:
                    col++;
                    break;
                case SwipeDirection.Up:
                    row--;
                    break;
                case SwipeDirection.Down:
                    row++;
                    break;
            }
            Grid.SetColumn(this.elf5, col);
            Grid.SetRow(this.elf5, row);
        }

        private void SwipeGestureRecognizer_Swiped4(object sender, SwipedEventArgs e)
        {
            int col = Grid.GetColumn(this.elf4);
            int row = Grid.GetRow(this.elf4);
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    col--;
                    break;
                case SwipeDirection.Right:
                    col++;
                    break;
                case SwipeDirection.Up:
                    row--;
                    break;
                case SwipeDirection.Down:
                    row++;
                    break;
            }
            Grid.SetColumn(this.elf4, col);
            Grid.SetRow(this.elf4, row);
        }

        private void SwipeGestureRecognizer_Swiped3(object sender, SwipedEventArgs e)
        {
            int col = Grid.GetColumn(this.elf3);
            int row = Grid.GetRow(this.elf3);
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    col--;
                    break;
                case SwipeDirection.Right:
                    col++;
                    break;
                case SwipeDirection.Up:
                    row--;
                    break;
                case SwipeDirection.Down:
                    row++;
                    break;
            }
            Grid.SetColumn(this.elf3, col);
            Grid.SetRow(this.elf3, row);
        }

        private void SwipeGestureRecognizer_Swiped2(object sender, SwipedEventArgs e)
        {
            int col = Grid.GetColumn(this.elf2);
            int row = Grid.GetRow(this.elf2);
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    col--;
                    break;
                case SwipeDirection.Right:
                    col++;
                    break;
                case SwipeDirection.Up:
                    row--;
                    break;
                case SwipeDirection.Down:
                    row++;
                    break;
            }
            Grid.SetColumn(this.elf2, col);
            Grid.SetRow(this.elf2, row);
        }
    }
}