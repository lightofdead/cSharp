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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x <= 10; x++)
            {
                
                if (x == 10)
                {
                    myLabel.Text = "x must be 10";
                }
                else
                {
                    myLabel.Text = "x isn't 10";
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            myLabel.Text = "Я вас переиграл и сделал эт ов кнопке 2 хых";
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            while (count < 10)
            {
                count = count + 1;
            }
            for(int i=0;i<5; i++)
            {
                count = count - 1;
            }

            myLabel.Text = "The answer is " + count;
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {

            string name = "Qeuentlin";
            int x = 3;
            x *= 17;
            double d = Math.PI / 2;
            myLabel.Text = "name is" + name + "\nx is " + x + "\nd is " + d;
        }
    }
}
