using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WfDbApp;

namespace CarStatistic
{
    /// <summary>
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        ApplicationContext db;
        public DeleteWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.Parent as FrameworkElement;
            var textBox1 = parent.FindName("textbox1") as TextBox;
            var textBox2 = parent.FindName("textbox2") as TextBox;

            var deletedAccount = db.Cars
                    .Where(с => с.Company == textBox1.Text)
                    .FirstOrDefault(с => с.Model == textBox2.Text);

            if (deletedAccount != null)
            {
                db.Cars.Remove(deletedAccount);
                db.SaveChanges();
                MessageBox.Show("Удалено");
                db.Dispose();
                Close();
            }
            else
            {
                MessageBox.Show("Такой записи не существует");
            }
        }
    }
}