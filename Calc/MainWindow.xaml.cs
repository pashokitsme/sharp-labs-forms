using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Калькулятор 42";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string content = button.Content.ToString();
            UpdateLabel(content);
        }

        private void UpdateLabel(string content)
        {
            resultLabel.Content += content;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearLabel();
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateResult();
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteLastCharacter();
        }

        private void ClearLabel()
        {
            resultLabel.Content = string.Empty;
        }

        private void CalculateResult()
        {
            try
            {
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(resultLabel.Content.ToString(), "");
                resultLabel.Content = result.ToString();
            }
            catch (Exception ex)
            {
                resultLabel.Content = "Ошибка";
            }
        }

        private void DeleteLastCharacter()
        {
            if (!string.IsNullOrEmpty(resultLabel.Content.ToString()))
            {
                resultLabel.Content = resultLabel.Content.ToString().Remove(resultLabel.Content.ToString().Length - 1);
            }
        }
        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentContent = resultLabel.Content.ToString();

                if (double.TryParse(currentContent, out var currentValue))
                {
                    var percentageValue = currentValue / 100;

                    resultLabel.Content = percentageValue.ToString();
                }
                else
                {
                    resultLabel.Content = "Ошибка";
                }
            }
            catch (Exception ex)
            {
                resultLabel.Content = "Ошибка";
            }
        }
    }
}
