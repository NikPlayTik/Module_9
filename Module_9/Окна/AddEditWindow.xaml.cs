using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Module_9
{
    public partial class AddEditWindow : Window
    {
        public Task newTask { get; set; }
        public event Action<Task> TaskUpdated;

        public AddEditWindow(Task taskToEdit)
        {
            InitializeComponent();

            if (taskToEdit == null)
            {
                newTask = new Task();
            }
            else
            {
                newTask = taskToEdit;
            }

            DataContext = newTask;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string Title = titleTextBox.Text;
            string Priority = priorityComboBox.Text;
            DateTime DueDate = dateDatePicker.SelectedDate ?? DateTime.MinValue;
            string ProgressCompleted = progressComboBox.Text;

            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Priority) || DueDate == DateTime.MinValue || string.IsNullOrWhiteSpace(ProgressCompleted))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
            else
            {
                newTask.Title = Title;
                newTask.Priority = Priority;
                newTask.DueDate = DueDate;
                newTask.ProgressCompleted = ProgressCompleted;

                // Вызываем событие TaskUpdated и передаем обновленную задачу
                TaskUpdated?.Invoke(newTask);

                DialogResult = true; // Устанавливаем DialogResult в true
            }
        }
    }
}
