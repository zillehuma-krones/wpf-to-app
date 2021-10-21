using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;
using WpfApp.ViewModels;

namespace WPFAppTest
{
    [TestClass]
    class ToDoItemViewModelUnitTest
    {
        [TestMethod]
        public void SetIsDone_IsDoneIsTrue_WriteToDoItemsExecuted()
        {
            //Arrange
            var fakeTodoService = new FakeTodoService();            
            var viewModel = this.CreateSut(fakeTodoService);

            //Act

            viewModel.IsDone = true;

            //Assert
            //fakeTodoService
        }
        private ToDoItemViewModel CreateSut(FakeTodoService fakeTodoService = null)
        {
            if(fakeTodoService ==null)
            {
                fakeTodoService = new FakeTodoService();
            }

            var todoitem = new TODOItem();
            var alltodos = new BindingList<ToDoItemViewModel>();


            return new ToDoItemViewModel(todoitem, fakeTodoService, alltodos);
        }
    }
}
