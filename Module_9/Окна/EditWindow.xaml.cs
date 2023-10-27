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
    public partial class EditWindow : Window
    {
        public Task EditedTask { get; set; }

        public EditWindow(Task taskToEdit)
        {
            InitializeComponent();
            if (taskToEdit == null)
            {
                EditedTask = new Task();
            }
            else
            {
                EditedTask = taskToEdit;
                titleTextBox.Text = taskToEdit.Title;
                priorityComboBox.Text = taskToEdit.Priority;
                dateDatePicker.SelectedDate = taskToEdit.DueDate;
                progressComboBox.Text = taskToEdit.ProgressCompleted;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем свойства задачи данными из текстовых полей
            EditedTask.Title = titleTextBox.Text;
            EditedTask.Priority = priorityComboBox.Text;
            EditedTask.DueDate = dateDatePicker.SelectedDate ?? DateTime.MinValue;
            EditedTask.ProgressCompleted = progressComboBox.Text;

            DialogResult = true; // Устанавливаем DialogResult в true
            Close(); // Закрываем окно
        }
    }
}
