using System;
using System.Windows;
using MathLab_6.core;

namespace MathLab_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Разкоммить, для проверки работы
            TextBoxView.Text = "e ^ x + 1 / x";
        }

        // При нажатии на кнопку, округляет с точностью в 16 знаков
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                String text = TextBoxView.Text;
                Func func = new Func(text, 16);
                GoldenRatioMinimizer goldenRatioMinimizer = new GoldenRatioMinimizer();
                string result = goldenRatioMinimizer.Minimize(func, 0.1, 1, 0.0001).ToString();
                MessageBox.Show(result);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                throw;
            }
        }

        // Выводит вспомогательную инфу
        private void ButtonHelper_OnClick(object sender, RoutedEventArgs e)
        {
            String textHelper = 
                "аргумент - x" +
                "модуль - abs(...)\n" +
                "квадратный корень - sqrt(...)\n" +
                "возведение в степень - ^\n" +
                "экспонента - e";
            MessageBox.Show(textHelper);
        }
    }
}