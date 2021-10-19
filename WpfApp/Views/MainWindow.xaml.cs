using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public MainWindow()
        {
            InitializeComponent();
            ITodoItemService _todoItemService = new TodoItemService();

            //DataContext = new MainWindowViewModel();
            DataContext = new MainWindowViewModelForDelegateCommand(_todoItemService);
         


        }

    
    }
}
