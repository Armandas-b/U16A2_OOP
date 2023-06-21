using System;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;

namespace ToDoList
{
    public partial class CreateTaskWindow : MetroWindow
    {
        private MainWindow mainWindow;

        public CreateTaskWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtTaskName.Text) || txtTaskName.Text.Length > 50)
            {
                MessageBox.Show("Please enter a valid task name", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dpDueDate.SelectedDate.HasValue && dpDueDate.SelectedDate.Value < DateTime.Today)
            {
                MessageBox.Show("Please select a future or today as a due date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTaskDescription.Text))
            {
                MessageBox.Show("Please enter a valid task description", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string taskName = txtTaskName.Text;
            string taskDescription = txtTaskDescription.Text;
            DateTime dueDate = dpDueDate.SelectedDate ?? DateTime.Now;
            bool isCompleted = false;

            mainWindow.AddTask(taskName, taskDescription, dueDate, isCompleted );

            Close();
        }
    }
}
