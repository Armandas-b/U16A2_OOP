using System;
using System.Windows;
using System.Windows.Controls;

namespace ToDoList
{
    public partial class EditTaskWindow : Window
    {
        private MainWindow mainWindow;
        private ListBoxItem selectedTask;

        public EditTaskWindow(MainWindow mainWindow, ListBoxItem selectedTask)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.selectedTask = selectedTask;

            // Populate the necessary data from the selectedTask
            if (selectedTask.Content is CheckBox checkBox)
            { 
                // Example: Set the initial values of the controls
                string taskTitleF = checkBox.Content.ToString();

                int index = taskTitleF.IndexOf('(');
                if(index> 0)
                {
                      string taskTitleI = taskTitleF.Substring(0, index);
                      textBoxTitle.Text = taskTitleI;
                }
                DateTime dueDate = selectedTask.Content.ToString().Contains("Due") ? DateTime.Parse(taskTitleF.Substring(index + 5, 10)) : DateTime.Now;

                // Set the values of the controls in your XAML file
             
            }
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTask.Content is CheckBox checkBox)
            {
                // Retrieve the updated values from the controls
                string updatedTitle = textBoxTitle.Text;
                DateTime? updatedDueDate = datePickerDueDate.SelectedDate;

                // Update the task with the new values
                if (updatedDueDate.HasValue)
                {
                    string formattedDueDate = updatedDueDate.Value.ToString("yyyy-MM-dd");
                    checkBox.Content = $"{updatedTitle} (Due: {formattedDueDate})";
                }
                else
                {
                    checkBox.Content = updatedTitle;
                }

                // Save the changes to the task using the task data associated with the selectedTask

                // Close the window
                Close();
            }
        }
    }

}
