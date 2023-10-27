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
            taskListView.ItemsSource = tasks;
            TaskReminder taskReminder = new TaskReminder(tasks);
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            Task taskToEdit = null; // Здесь можно создать пустую задачу по умолчанию
            AddEditWindow addEditWindow = new AddEditWindow(taskToEdit);

            // Обработчик события TaskUpdated
            addEditWindow.TaskUpdated += updatedTask =>
            {
                if (taskToEdit == null)
                {
                    // Создаем новую задачу, только если taskToEdit пустой
                    tasks.Add(updatedTask);
                }
                else
                {
                    // Иначе обновляем существующую задачу
                    taskToEdit.Title = updatedTask.Title;
                    taskToEdit.Priority = updatedTask.Priority;
                    taskToEdit.DueDate = updatedTask.DueDate;
                    taskToEdit.ProgressCompleted = updatedTask.ProgressCompleted;
                }

                taskListView.Items.Refresh();
            };

            addEditWindow.ShowDialog();
        }
        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (taskListView.SelectedItem != null)
            {
                Task selectedTask = (Task)taskListView.SelectedItem;

                // Открываем окно редактирования задачи и передаем выбранную задачу
                EditWindow editWindow = new EditWindow(selectedTask);

                if (editWindow.ShowDialog() == true)
                {
                    // Обновляем выбранную задачу после редактирования
                    selectedTask.Title = editWindow.EditedTask.Title;
                    selectedTask.Priority = editWindow.EditedTask.Priority;
                    selectedTask.DueDate = editWindow.EditedTask.DueDate;
                    selectedTask.ProgressCompleted = editWindow.EditedTask.ProgressCompleted;
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
            if (taskListView.SelectedItem != null)
            {
                Task selectedTask = (Task)taskListView.SelectedItem;

                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту задачу?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    tasks.Remove(selectedTask);
                    taskListView.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите задачу для удаления");
            }
        }

    }
}
