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

namespace кт19
{
    public partial class MainWindow : Window
    {
        public int counter;
        public MainWindow()
        {
            InitializeComponent();

        }

        public void answer(object sender, EventArgs e)
        {
            gettotalscore();
        }

        public void ComboBox_SelectionChanged(object sender, EventArgs e)
        {
            gettotalscore();
        }

        public void gettotalscore()
        {
            counter = 0;
            if (correct1?.IsChecked == true) counter++;
            if (correct2?.IsChecked == true && correct22?.IsChecked == true) counter++;
            if (correct3?.IsChecked == true) counter++;
            if (correct4?.IsChecked == true) counter++;
            if (correct5?.IsChecked == true) counter++;
            if (correct6?.IsChecked == true && correct62?.IsChecked == true) counter++;
            if (correct7?.IsChecked == true) counter++;
            if (correct8?.IsChecked == true) counter++;
            if (q9.SelectedItem is ComboBoxItem selectedItem9 &&
            selectedItem9.Name == "correct9") counter++;
            if (q10.SelectedItem is ComboBoxItem selectedItem10 &&
            selectedItem10.Name == "correct10") counter++;
            if (q11.SelectedItem is ComboBoxItem selectedItem11 &&
            selectedItem11.Name == "correct11") counter++;
            if (q12.SelectedItem is ComboBoxItem selectedItem12 &&
            selectedItem12.Name == "correct12") counter++;

        }

        public string[] GetResults()
        {
            string[] correctAnswers = {
            "10",                                    
            "Картошка, Огурец",                    
            "Альберт Эйнштейн",                         
            "Румынский",                         
            "Амазонка",                         
            "Вена, Прага",                         
            "1917",                         
            "46",                        
            "Сатурн",                               
            "Кит",                                  
            "Золото",                              
            "Стеша"                                 
            };

            string[] results = new string[12];


            bool[] questionCorrectness = {
            correct1?.IsChecked == true,
            correct2?.IsChecked == true && correct22?.IsChecked == true,
            correct3?.IsChecked == true,
            correct4?.IsChecked == true,
            correct5?.IsChecked == true,
            correct6?.IsChecked == true && correct62?.IsChecked == true,
            correct7?.IsChecked == true,
            correct8?.IsChecked == true
            };

            for (int i = 0; i < 8; i++)
            {
                results[i] = questionCorrectness[i]
                    ? "Верно"
                    : $"Неверно, правильный ответ: {correctAnswers[i]}";
            }

            ComboBox[] comboBoxes = { q9, q10, q11, q12 };

            for (int i = 0; i < comboBoxes.Length; i++)
            {
                int questionIndex = 8 + i;

                if (comboBoxes[i].SelectedItem is ComboBoxItem selectedItem)
                {
                    bool isCorrect = selectedItem.Name == $"correct{questionIndex + 1}";
                    string userAnswer = selectedItem.Content.ToString();

                    results[questionIndex] = isCorrect
                        ? "Верно"
                        : $"Неверно, правильный ответ: {correctAnswers[questionIndex]} (ваш ответ: {userAnswer})";
                }
                else
                {
                    results[questionIndex] = $"Неверно, правильный ответ: {correctAnswers[questionIndex]} (ответ не выбран)";
                }
            }

            return results;
        }



        public void endquiz_clk(object sender, EventArgs e)
        {
            string[] results = GetResults();
            Window1 endwindow = new Window1(counter, results);
            this.Hide();
            endwindow.Show();
        }
    }

}
