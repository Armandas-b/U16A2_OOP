using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace ToDoList
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Populate();
        }

        private void Populate()
        {
            AddTask("Task 1", DateTime.Now);
            AddTask("Task 2", DateTime.Now);
            AddTask("Task 3", DateTime.Now);
            AddTask("Task 4", DateTime.Now);
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var createTaskWindow = new CreateTaskWindow(this);
            createTaskWindow.ShowDialog();
        }

        public void AddTask(string taskName, DateTime dueDate)
        {
            CheckBox checkBox = new CheckBox
            {
                Content = $"{taskName} (Due: {dueDate.ToString("yyyy-MM-dd")})"
            };

            ListBoxItem newTaskItem = new ListBoxItem
            {
                Content = checkBox
            };

            listBoxTasks.Items.Add(newTaskItem);
        }


        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxTasks.SelectedItem is ListBoxItem selectedTask)
            {
                if (selectedTask.Content is CheckBox checkBox && listBoxTasks.Items.Contains(selectedTask))
                {
                    listBoxTasks.Items.Remove(selectedTask);
                }
            }
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            if (filterComboBox.SelectedItem is ComboBoxItem selectedFilter)
            {
                ListBoxItem listBoxItem = null; // Declare listBoxItem outside the switch statement

                switch (selectedFilter.Content.ToString())
                {
                    case "All Tasks":
                        // Show all tasks
                        foreach (var item in listBoxTasks.Items)
                        {
                            listBoxItem = item as ListBoxItem;
                            if (listBoxItem != null)
                            {
                                listBoxItem.Visibility = Visibility.Visible;
                            }
                        }
                        break;

                    case "Completed Tasks":
                        // Show only completed tasks
                        foreach (var item in listBoxTasks.Items)
                        {
                            listBoxItem = item as ListBoxItem;
                            if (listBoxItem != null && listBoxItem.Content is CheckBox checkBox && checkBox.IsChecked == true)
                            {
                                listBoxItem.Visibility = Visibility.Visible;
                            }
                            else if (listBoxItem != null)
                            {
                                listBoxItem.Visibility = Visibility.Collapsed;
                            }
                        }
                        break;

                    case "Uncompleted Tasks":
                        // Show only uncompleted tasks
                        foreach (var item in listBoxTasks.Items)
                        {
                            listBoxItem = item as ListBoxItem;
                            if (listBoxItem != null && listBoxItem.Content is CheckBox checkBox && checkBox.IsChecked != true)
                            {
                                listBoxItem.Visibility = Visibility.Visible;
                            }
                            else if (listBoxItem != null)
                            {
                                listBoxItem.Visibility = Visibility.Collapsed;
                            }
                        }
                        break;
                }

            }
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxTasks.SelectedItem is ListBoxItem selectedTask)
            {
                if (selectedTask.Content is CheckBox checkBox && listBoxTasks.Items.Contains(selectedTask))
                {
                    var editTaskWindow = new EditTaskWindow(this, selectedTask);
                    editTaskWindow.ShowDialog();
                }
            }
        }
    }
}

