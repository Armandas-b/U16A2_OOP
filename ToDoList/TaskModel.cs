using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoList;

public class TaskModel : ObservableObject
{
    private string taskName;
    private DateTime dueDate;
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; set; }
    private bool isCompleted;
    public TaskModel AssociatedTask { get; } // Add AssociatedTask property

    public string TaskName
    {
        get { return taskName; }
        set { SetProperty(ref taskName, value); }
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

    public TaskModel(string taskName, DateTime dueDate, TaskModel associatedTask, bool isCompleted)
    {
        TaskName = taskName;
        DueDate = dueDate;
        AssociatedTask = associatedTask; // Assign the associated task to the property
        EditCommand = new RelayCommand(EditTask); // Use EditTask method directly as the command
        IsCompleted = isCompleted;
    }

    public override string ToString()
    {
        return $"{TaskName} (Due: {DueDate:yyyy-MM-dd})";
    }

    private void EditTask()
    {
        EditTaskWindow editTaskWindow = new EditTaskWindow((MainWindow)App.Current.MainWindow, this);
        editTaskWindow.ShowDialog();
    }

    private void DeleteTask()
    {
        // Implementation of the DeleteTask method
    }
}
