using System;
using System.Windows;

namespace ToDoList
{
    public partial class CreateTaskWindow : Window
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

            mainWindow.AddTask(taskName, dueDate);

            Close();
        }
    }
}
