using System.Collections.Generic;
using System.Windows;
using WfDbApp;

namespace CarStatistic
{
    /// <summary>
    /// Interaction logic for SearchResultWindow.xaml
    /// </summary>
    public partial class SearchResultWindow : Window
    {
        public SearchResultWindow(List<Car> cars)
        {
            InitializeComponent();
            carsGrid.ItemsSource = cars;
        }

        private SearchResultWindow() { }
    }
}