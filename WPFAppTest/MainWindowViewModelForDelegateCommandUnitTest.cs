using Microsoft.VisualStudio.TestTools.UnitTesting;
using  WpfApp.ViewModels;
using WpfApp.Services;
using WpfApp.Models;
using System.ComponentModel;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Shouldly;

namespace WPFAppTest
{
    public class FakeTodoService : ITodoItemService
    {
        private const string filePath = @"C:\Prj\TestProjekte\WPFLearning\WpfApp\Test\TODOs.json";
        public BindingList<TODOItem> ReadToDoItems()
        {
            var toDoItems = new BindingList<TODOItem>();

            var jsonOutput = JsonConvert.DeserializeObject<BindingList<TODOItem>>(File.ReadAllText(filePath));

            toDoItems = jsonOutput;

            return toDoItems;

        }


        public void WriteToDoItems(BindingList<TODOItem> todoItems)
        {
            var jsonInput = JsonConvert.SerializeObject(todoItems, Formatting.Indented);

            File.WriteAllText(filePath, jsonInput);
        }
    }

    [TestClass]
    public class MainWindowViewModelForDelegateCommandUnitTest
    {
        [TestMethod]
        public void NewTODOButton_Click_EmptyNewTodoItemName_AddButtonCantBeExecuted()
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
        public void NewTODOButton_Click_NewTodoItemNameNotEmpty_AddButtonCanBeExucted()
        {
            // Arrange
            var viewModel = CreateSut();
            viewModel.NewToDoName = "ToDo10";
            //Act
            var canExecute = viewModel.AddNewToDoCommand.CanExecute(viewModel.NewToDoName);
            // Assert
            canExecute.ShouldBeTrue();
        }

        private MainWindowViewModelForDelegateCommand CreateSut()
        {
            return new MainWindowViewModelForDelegateCommand(new FakeTodoService());
        }
    }
}
