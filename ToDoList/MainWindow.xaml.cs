using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Reflection;

namespace ToDoList
{
    public partial class MainWindow : MetroWindow
    {

        public ObservableCollection<TaskModel> ListBoxTasks { get; } = new ObservableCollection<TaskModel>();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this; // Set the DataContext to the current instance of MainWindow

            Populate();
            Console.WriteLine($"Number of tasks: {ListBoxTasks.Count}");

            Console.WriteLine("Press any key to exit...");
            Console.Read();

        }


        private void Populate()
        {
            AddTask("Task 1", DateTime.Now, true);
            AddTask("Task 2", DateTime.Now, false);
            AddTask("Task 3", DateTime.Now, false);
            listBoxTasks.ItemsSource = ListBoxTasks;

        }

        public void AddTask(string taskName, DateTime dueDate, bool isCompleted)
        {
            TaskModel task = new TaskModel(taskName, dueDate, null, isCompleted);
            ListBoxTasks.Add(task);
        }




        private void EditTask(TaskModel task)
        {
            EditTaskWindow editTaskWindow = new EditTaskWindow(this, task);
            editTaskWindow.ShowDialog();

            // Update the ListBoxTasks collection or perform any other necessary actions after editing the task
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button editButton && editButton.DataContext is TaskModel selectedTask)
            {
                EditTask(selectedTask);
            }
        }




        private void DeleteTask()
        {
            // Implementation of the DeleteTask method
        }




        private void filterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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




    }
}

