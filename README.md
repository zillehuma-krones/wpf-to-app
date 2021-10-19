### WPF TODO App
A Windows Presentation Foundation(WPF) Application that is based on *Model-View-ViewModel (MVVM)* architecture. It allows the user to maintain and work with a list of ToDos. Salient features include:

- Maintainence of ToDos in a .json file
- Adding/deleting ToDos through GUI

The solution comprises of the following Projects

| Project | Contents |
|-------|------|
| WpfApp | - **Model**: TODOItem <br> - **Views**: MainWindow <br> - **ViewModels**: MainWindowViewModel, ToDoItemViewModel <br> - **Services**: IDateTimeService, DateTimeService, ITodoItemService, TodoItemService <br> - **Commands**: AddNewTodoCommand, DeleteTodoCommand, DelegateCommand|
| WpfAppTest | - **ViewModels**: MainWindowViewModelUnitTest, ToDoItemViewModelUNitTest |
