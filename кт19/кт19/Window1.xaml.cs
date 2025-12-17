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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace кт19
{
    public partial class Window1 : Window
    {

        private int counter;
        private string[] results;

        public Window1(int counter, string[] results)
        {
            InitializeComponent();
            this.counter = counter;
            this.results = results;
            ShowScore();
        }

        public void ShowScore()
        {
            result.Text = $"Поздравляю, вы набрали {counter} баллов";
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveDialog.Title = "Сохранить файл как";
            saveDialog.OverwritePrompt = true;

            if (saveDialog.ShowDialog() == true)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName, false))
                    {
                        writer.WriteLine("Результаты");
                        writer.WriteLine($"Правильных ответов: {counter}/12");
                        writer.WriteLine();

                        for (int i = 0; i < results.Length; i++)
                        {
                            writer.WriteLine($"{i + 1}. {results[i]}");
                        }
                    }
                    MessageBox.Show($"Файл сохранён: {saveDialog.FileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка записи: {ex.Message}");
                }
            }
        }
    }
}
