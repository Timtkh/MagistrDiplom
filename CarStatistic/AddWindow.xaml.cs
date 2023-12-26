using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WfDbApp;

namespace CarStatistic
{
    public partial class AddWindow : Window
    {
        ApplicationContext db;

        public AddWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.Parent as FrameworkElement;
            var textBox1 = parent.FindName("textbox1") as TextBox;
            var textBox2 = parent.FindName("textbox2") as TextBox;
            var textBox3 = parent.FindName("textbox3") as TextBox;
            var textBox4 = parent.FindName("textbox4") as TextBox;
            var textBox5 = parent.FindName("textbox5") as TextBox;
            var textBox6 = parent.FindName("textbox6") as TextBox;

            var newCar = new Car
            {
                Company = textBox1.Text,
                Model = textBox2.Text,
                Count = int.Parse(textBox3.Text),
                Contry = textBox4.Text,
                Year = textBox5.Text,
                Money = int.Parse(textBox6.Text)
            };
            db.Cars.Add(newCar);
            db.SaveChanges();
            MessageBox.Show("Добавлено");
            db.Dispose();
            Close();
        }
    }
}