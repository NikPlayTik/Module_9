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
    public partial class AddWindow : Window
    {
        public Task newTask { get; set; }

        public AddWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string Title = titleTextBox.Text;
            string Priority = priorityTextBox.Text;
            DateTime DueDate = dateDatePicker.DisplayDate;
            string ProgressCompleted = progressTextBox.Text;

            // Проверяем, что введены обязательные значения
            if (string.IsNullOrWhiteSpace(Title) || DueDate == DateTime.MinValue)
            {
                MessageBox.Show("Пожалуйста, заполните обязательные поля: Название и Сроки выполнения");
            }
            else
            {
                // Создаем новую задачу только если обязательные поля заполнены
                newTask = new Task
                {
                    Title = Title,
                    Priority = Priority,
                    DueDate = DueDate,
                    ProgressCompleted = ProgressCompleted
                };

                // Закрыть окно
                Close();
            }
        }
    }
}
