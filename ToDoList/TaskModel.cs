using System;
using System.Windows.Input;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoList;
using System.Windows.Navigation;

public class TaskModel : ObservableObject
{
    private string taskName;
    private string taskDescription;
    private DateTime dueDate;
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; set; }
    private bool isCompleted;
    private bool isVisible;
    public TaskModel AssociatedTask { get; } // Add AssociatedTask property

    public string TaskName
    {
        get { return taskName; }
        set { SetProperty(ref taskName, value); }
    }

    public string TaskDescription
    {
        get { return taskDescription; }
        set { SetProperty(ref taskDescription, value); }
    }
    public DateTime DueDate
    {
        get { return dueDate; }
        set { SetProperty(ref dueDate, value); }
    }

    public bool IsCompleted
    {
        get { return isCompleted; }
        set { SetProperty(ref isCompleted, value); }
    }

    public bool IsVisible
    {
        get { return isVisible; }
        set { SetProperty(ref isVisible, value); }
    }

    public TaskModel(string taskName, string taskDescription, DateTime dueDate, TaskModel associatedTask, bool isCompleted)
    {
        TaskName = taskName;
        TaskDescription = taskDescription;
        DueDate = dueDate;
        AssociatedTask = associatedTask; // Assign the associated task to the property
        EditCommand = new RelayCommand(EditTask); // Use EditTask method directly as the command
        DeleteCommand = new RelayCommand(DeleteTask); 
        IsCompleted = isCompleted;
        IsVisible = true;
    }

    public override string ToString()
    {
        return $"{TaskName} {taskDescription} (Due: {DueDate:yyyy-MM-dd})";
    }

    private void EditTask()
    {
        EditTaskWindow editTaskWindow = new EditTaskWindow((MainWindow)App.Current.MainWindow, this);
        editTaskWindow.ShowDialog();
    }

    private void DeleteTask()
    {
        if(Application.Current.MainWindow is MainWindow mainWindow)
        {
            mainWindow.ListBoxTasks.Remove(this);
        }
    }
}
