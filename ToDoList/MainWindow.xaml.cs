using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Automation;


namespace ToDoList
{
    public partial class MainWindow : MetroWindow
    {

        public ObservableCollection<TaskModel> ListBoxTasks { get; } = new ObservableCollection<TaskModel>();

        public MainWindow()
        {
                InitializeComponent();

                string v =  Environment.GetEnvironmentVariable("ClickOnce_CurrentVersion");

                this.Title = $"TO-DO LIST {v}";


            DataContext = this; // Set the DataContext to the current instance of MainWindow

            Populate();
            Console.WriteLine($"Number of tasks: {ListBoxTasks.Count}");

            Console.WriteLine("Press any key to exit...");
            Console.Read();

        }


        private void Populate()
        {
            AddTask("Task 1", "Blah blah blah",DateTime.Now, true);
            AddTask("Task 2", "Blah blah blah", DateTime.Now, false);
            AddTask("Task 3", "Blah blah blah", DateTime.Now, false);
            listBoxTasks.ItemsSource = ListBoxTasks;

        }

        public void AddTask(string taskName, string taskDescription, DateTime dueDate, bool isCompleted)
        {
            TaskModel task = new TaskModel(taskName,taskDescription ,dueDate, null, isCompleted);
            ListBoxTasks.Add(task);
        }

        public void AddTask_Click(object sender, RoutedEventArgs e) {
        
            CreateTaskWindow createTaskWindow = new CreateTaskWindow(this);
            createTaskWindow.ShowDialog();
        }


        private void EditTask(TaskModel task)
        {
            EditTaskWindow editTaskWindow = new EditTaskWindow(this, task);
            editTaskWindow.ShowDialog();

            // Update the ListBoxTasks collection or perform any other necessary actions after editing the task
        }


        private void filterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filterComboBox.SelectedItem is ComboBoxItem selectedFilter)
            {
                switch (selectedFilter.Content.ToString())
                {
                    case "All Tasks":
                        // Show all tasks
                        foreach (var task in ListBoxTasks)
                        {
                            task.IsVisible = true;
                        }
                        break;

                    case "Completed Tasks":
                        // Show only completed tasks
                        foreach (var task in ListBoxTasks)
                        {
                            if (task.IsCompleted)
                            {
                                task.IsVisible = true;
                            }
                            else
                            {
                                task.IsVisible = false;
                            }
                        }
                        break;

                    case "Uncompleted Tasks":
                        // Show only uncompleted tasks
                        foreach (var task in ListBoxTasks)
                        {
                            if (!task.IsCompleted)
                            {
                                task.IsVisible = true;
                            }
                            else
                            {
                                task.IsVisible = false;
                            }
                        }
                        break;
                }
            }
        }


    }

}

