using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Module_9
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> tasks = new ObservableCollection<Task>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            Task taskToEdit = null; // Здесь можно создать пустую задачу по умолчанию
            AddEditWindow addEditWindow = new AddEditWindow(taskToEdit);
            addEditWindow.ShowDialog();

            if (addEditWindow.DialogResult == true)
            {
                // Если результат окна равен true (значит, пользователь нажал "Сохранить" в окне)
                if (taskToEdit == null)
                {
                    // Создаем новую задачу, только если taskToEdit пустой
                    tasks.Add(addEditWindow.newTask);
                }
                else
                {
                    // Иначе обновляем существующую задачу
                    taskToEdit.Title = addEditWindow.newTask.Title;
                    taskToEdit.Priority = addEditWindow.newTask.Priority;
                    taskToEdit.DueDate = addEditWindow.newTask.DueDate;
                    taskToEdit.ProgressCompleted = addEditWindow.newTask.ProgressCompleted;
                }

                taskListView.Items.Refresh();
            }
        }
        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (taskListView.SelectedItem != null)
            { 
                Task selectedTask = (Task)taskListView.SelectedItem;

                // Открываем окно редактирования задачи и передаем выбранную задачу
                AddEditWindow editWindow = new AddEditWindow(selectedTask);
                if (editWindow.ShowDialog() == true)
                {
                    // Обновляем выбранную задачу после редактирования
                    selectedTask.Title = editWindow.newTask.Title;
                    selectedTask.Priority = editWindow.newTask.Priority;
                    selectedTask.DueDate = editWindow.newTask.DueDate;
                    selectedTask.ProgressCompleted = editWindow.newTask.ProgressCompleted;
                }
                taskListView.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите задачу для редактирования");
            }
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
