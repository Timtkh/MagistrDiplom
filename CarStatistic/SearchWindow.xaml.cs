using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WfDbApp;

namespace CarStatistic
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        ApplicationContext db;

        public SearchWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();

            var operations = new string[]
            {
                "-",
                "<",
                ">",
                "="
            };

            var columns = new string[]
            {
                "-",
                "Марка",
                "Модель",
                "Количество",
                "Год",
                "Страна",
                "Цена"
            };

            operationComboBox1.ItemsSource = operations;
            operationComboBox1.SelectedIndex = 0;

            columnComboBox1.ItemsSource = columns;
            columnComboBox1.SelectedIndex = 0;

            operationComboBox2.ItemsSource = operations;
            operationComboBox2.SelectedIndex = 0;

            columnComboBox2.ItemsSource = columns;
            columnComboBox2.SelectedIndex = 0;

            operationComboBox3.ItemsSource = operations;
            operationComboBox3.SelectedIndex = 0;

            columnComboBox3.ItemsSource = columns;
            columnComboBox3.SelectedIndex = 0;

            operationComboBox4.ItemsSource = operations;
            operationComboBox4.SelectedIndex = 0;

            columnComboBox4.ItemsSource = columns;
            columnComboBox4.SelectedIndex = 0;

            operationComboBox5.ItemsSource = operations;
            operationComboBox5.SelectedIndex = 0;

            columnComboBox5.ItemsSource = columns;
            columnComboBox5.SelectedIndex = 0;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.Parent as FrameworkElement;
            var textBox1 = parent.FindName("textbox1") as TextBox;
            var textBox2 = parent.FindName("textbox2") as TextBox;
            var textBox3 = parent.FindName("textbox3") as TextBox;
            var textBox4 = parent.FindName("textbox4") as TextBox;
            var textBox5 = parent.FindName("textbox5") as TextBox;

            var sampleList = db.Cars.ToList();

            if (!textBox1.Text.IsNullOrEmpty())
            {
                sampleList = GetRecordsWithCondition(sampleList, columnComboBox1.Text, operationComboBox1.Text, textBox1.Text);
            }
            if (!textBox2.Text.IsNullOrEmpty())
            {
                sampleList = GetRecordsWithCondition(sampleList, columnComboBox2.Text, operationComboBox2.Text, textBox2.Text);
            }
            if (!textBox3.Text.IsNullOrEmpty())
            {
                sampleList = GetRecordsWithCondition(sampleList, columnComboBox3.Text, operationComboBox3.Text, textBox3.Text);
            }
            if (!textBox4.Text.IsNullOrEmpty())
            {
                sampleList = GetRecordsWithCondition(sampleList, columnComboBox4.Text, operationComboBox4.Text, textBox4.Text);
            }
            if (!textBox5.Text.IsNullOrEmpty())
            {
                sampleList = GetRecordsWithCondition(sampleList, columnComboBox5.Text, operationComboBox5.Text, textBox5.Text);
            }

            var searchResultWindow = new SearchResultWindow(sampleList);
            searchResultWindow.Show();
            Close();
        }

        private List<Car> GetRecordsWithCondition(List<Car> cars, string column, string operation, string conditionValue)
        {
            switch (column)
            {
                case "Марка":
                    return cars.Where(c => c.Company == conditionValue).ToList();
                case "Модель":
                    return cars.Where(c => c.Model == conditionValue).ToList();
                case "Количество":
                    switch (operation)
                    {
                        case ">":
                            return cars.Where(c => c.Count > int.Parse(conditionValue)).ToList();
                        case "<":
                            return cars.Where(c => c.Count < int.Parse(conditionValue)).ToList();
                        case "=":
                            return cars.Where(c => c.Count == int.Parse(conditionValue)).ToList();
                        default:
                            return null;
                    }
                case "Год":
                    switch (operation)
                    {
                        case ">":
                            return cars.Where(c => int.Parse(c.Year) > int.Parse(conditionValue)).ToList();
                        case "<":
                            return cars.Where(c => int.Parse(c.Year) < int.Parse(conditionValue)).ToList();
                        case "=":
                            return cars.Where(c => int.Parse(c.Year) == int.Parse(conditionValue)).ToList();
                        default:
                            return null;
                    }
                case "Страна":
                    return cars.Where(c => c.Count == int.Parse(conditionValue)).ToList();
                case "Цена":
                    switch (operation)
                    {
                        case ">":
                            return cars.Where(c => c.Money > int.Parse(conditionValue)).ToList();
                        case "<":
                            return cars.Where(c => c.Money < int.Parse(conditionValue)).ToList();
                        case "=":
                            return cars.Where(c => c.Money == int.Parse(conditionValue)).ToList();
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }
    }
}