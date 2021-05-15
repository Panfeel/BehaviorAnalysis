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
using System.Diagnostics;
using System.IO;

namespace MyAppOnWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            inputText.Focus();
        }

        Stopwatch sw = new Stopwatch();
        string answer = "";
        int count = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void InputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.L)
            {
                sw.Start();
            }

            if (e.Key == Key.Enter)
            {
                if (answer == "доверительный")
                {
                    sw.Stop();
                    inputText.Clear();
                    TimeSpan st1 = sw.Elapsed;
                    sw.Reset();

                    using (FileStream fstream = new FileStream(@"F:\result90.txt", FileMode.Append, FileAccess.Write))
                    {
                        // преобразуем строку в байты
                        byte[] input = Encoding.Default.GetBytes(st1.ToString() + "\n");
                        // запись массива байтов в файл
                        fstream.Write(input, 0, input.Length);

                    }
                    outputText.Content = "Верно";
                    rect.Fill = Brushes.DodgerBlue;
                    el4.Fill = Brushes.DodgerBlue;

                    count++;
                    res.Content = count.ToString();
                }
                else
                {
                    sw.Stop();
                    inputText.Clear();
                    TimeSpan st2 = sw.Elapsed;
                    sw.Reset();
                    outputText.Content = "Ошибка!";
                    rect.Fill = Brushes.Red;
                    el4.Fill = Brushes.Red;

                }
            }
        }

        private void InputText_TextChanged(object sender, TextChangedEventArgs e)
        {
            answer = inputText.Text;
        }
    }
}
