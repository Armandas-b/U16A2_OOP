using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace ToDoList
{
    public partial class EditTaskWindow : MetroWindow
    {
        private MainWindow mainWindow;
        private TaskModel selectedTask;

        public EditTaskWindow(MainWindow mainWindow, TaskModel selectedTask)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.selectedTask = selectedTask;

            // Populate the necessary data from the selectedTask
            textBoxTitle.Text = selectedTask.TaskName;
            datePickerDueDate.SelectedDate = selectedTask.DueDate;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Please enter a task title.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate the due date input
            if (datePickerDueDate.SelectedDate.HasValue && datePickerDueDate.SelectedDate.Value < DateTime.Today)
            {
                MessageBox.Show("Please select a future due date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Retrieve the updated values from the controls
            string updatedTitle = textBoxTitle.Text;
            DateTime? updatedDueDate = datePickerDueDate.SelectedDate;

            // Update the task with the new values
            selectedTask.TaskName = updatedTitle;
            selectedTask.DueDate = updatedDueDate ?? DateTime.Now;

            // Save the changes to the task using the task data associated with the selectedTask

            // Close the window
            Close();
        }
    }
}
