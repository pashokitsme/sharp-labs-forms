using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int random_number;
        private int attempts;

        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            random_number = new Random().Next(0, 10);
            attempts = 3;

            resultLabel.Content = "";
            resultLabel1.Content = "";
            checkButton.IsEnabled = true;
            entryTextBox.Text = "";
        }

        private void CheckGuess()
        {
            int guess;
            if (int.TryParse(entryTextBox.Text, out guess))
            {
                if (guess == random_number)
                {
                    resultLabel.Content = "Поздравляем! Вы угадали число.";
                    checkButton.IsEnabled = false;
                }
                else
                {
                    attempts--;
                    if (attempts > 0)
                    {
                        resultLabel.Content = $"Неверно! У вас осталось {attempts} попыток.";
                    }
                    else
                    {
                        resultLabel.Content = "Извините, у вас закончились попытки.";
                        resultLabel1.Content = $"Правильное число было { random_number}.";
                        checkButton.IsEnabled = false;
                    }
                }
            }
            else
            {
                resultLabel.Content = "Пожалуйста, введите корректное число.";
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            CheckGuess();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void Endgame_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
