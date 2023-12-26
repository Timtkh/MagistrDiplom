using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WfDbApp;

namespace CarStatistic
{
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.Cars.Load();
            carsGrid.ItemsSource = db.Cars.Local.ToBindingList();
            this.Closing += ShowCars_Closing;
        }

        private void ShowCars_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddWindow();
            addWindow.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var deleteWindow = new DeleteWindow();
            deleteWindow.Show();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            db.Cars.Load();
            carsGrid.ItemsSource = db.Cars.Local.ToBindingList();
            carsGrid.UpdateLayout();
        }
        
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchWindow = new SearchWindow();
            searchWindow.Show();
        }
    }
}