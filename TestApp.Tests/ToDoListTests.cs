using System;

using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }

    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        string title = "Complete assignment";
        DateTime dueDate = DateTime.Now.AddDays(7);

        // Act
        _toDoList.AddTask(title, dueDate);

        // Assert
        Assert.That(_toDoList.DisplayTasks(), Does.Contain(title));
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        // Arrange
        string title = "Complete assignment";
        DateTime dueDate = DateTime.Now.AddDays(7);
        _toDoList.AddTask(title, dueDate);

        // Act
        _toDoList.CompleteTask(title);

        // Assert
        Assert.That(_toDoList.DisplayTasks(), Does.Contain("[✓]"));
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // Arrange
        string nonExistentTitle = "Nonexistent task";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => _toDoList.CompleteTask(nonExistentTitle));
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        // Arrange and Act
        string result = this._toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Is.EqualTo("To-Do List:"));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // Arrange
        _toDoList.AddTask("Task 1", DateTime.Now.AddDays(5));
        _toDoList.AddTask("Task 2", DateTime.Now.AddDays(10));

        // Act
        string result = _toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Does.Contain("[ ] Task 1"));
        Assert.That(result, Does.Contain("[ ] Task 2"));
    }
}
