using System;
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
            string taskName = txtTaskName.Text;
            DateTime dueDate = dpDueDate.SelectedDate ?? DateTime.Now;
            bool isCompleted = false;

            mainWindow.AddTask(taskName, dueDate, isCompleted );

            Close();
        }
    }
}
