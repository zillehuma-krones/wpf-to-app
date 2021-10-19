using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp.ViewModels;
using WpfApp.Services;
using WpfApp.Models;
using System.ComponentModel;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Shouldly;
using System;
using Moq;

namespace WPFAppTest
{
    public class FakeTodoService : ITodoItemService
    {

        public BindingList<TODOItem> ReadToDoItems()
        {
            return new BindingList<TODOItem>();

        }


        public void WriteToDoItems(BindingList<TODOItem> todoItems)
        {

        }
    }

    [TestClass]
    public class MainWindowViewModelUnitTest
    {
        [TestMethod]
        public void AddNewTodo_NewTodoItemNameIsEmpty_AddButtonCannotBeExecuted()
        {
            //Arrange
            var viewModel = this.CreateSut();
            viewModel.NewToDoName = string.Empty;

            //Act

            var canExecute = viewModel.AddNewToDoCommand.CanExecute(viewModel.NewToDoName);

            //Assert
            canExecute.ShouldBeFalse();

        }
        [TestMethod]
        public void AddNewTodo_NewTodoItemNameIsNotEmpty_AddButtonCanBeExecuted()
        {
            // Arrange
            var viewModel = CreateSut();
            viewModel.NewToDoName = "ToDo10";
            //Act
            var canExecute = viewModel.AddNewToDoCommand.CanExecute(viewModel.NewToDoName);

            // Assert
            canExecute.ShouldBeTrue();
        }

        [TestMethod]
        public void AddNewTodo_NewTodoItemNameIsWhitespace_AddButtonCannotBeExecuted()
        {
            //Arrange
            var viewModel = this.CreateSut();
            viewModel.NewToDoName = " ";

            //Act

            var canExecute = viewModel.AddNewToDoCommand.CanExecute(viewModel.NewToDoName);

            //Assert
            canExecute.ShouldBeFalse();

        }
        [TestMethod]
        public void ExecuteAddNewTodo_TodoNameNotEmpty_TodoItemIsAddedToList()
        {
            // Arrange
            var viewModel = CreateSut();
            viewModel.NewToDoName = "TODO50";

            // Act
            viewModel.AddNewToDoCommand.Execute(viewModel.NewToDoName);

            // Assert
            viewModel.ToDoItems.Single().Name.ShouldBe("TODO50");
        }

        private MainWindowViewModel CreateSut(DateTime fakeNow = default(DateTime))
        {
            var dateTimeServiceMock = new Mock<IDateTimeService>();
            var dateTimeService = dateTimeServiceMock.Object;

            dateTimeServiceMock.Setup(service => service.Now()).Returns(fakeNow);


            return new MainWindowViewModel(new FakeTodoService(), dateTimeService);
        }
    }
}
