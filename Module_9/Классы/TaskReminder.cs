using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace Module_9
{
    public class TaskReminder
    {
        private ObservableCollection<Task> tasks;
        private DispatcherTimer timer;

        public TaskReminder(ObservableCollection<Task> tasks)
        {
            this.tasks = tasks;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1); // Таймер с интервалом в 1 минуту
            timer.Tick += CheckTaskDeadlines;
            timer.Start();
        }

        private void CheckTaskDeadlines(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            foreach (Task task in tasks)
            {
                TimeSpan timeRemaining = task.DueDate - now;

                if (timeRemaining.TotalMinutes > 0 && timeRemaining.TotalMinutes <= 1440) // Менее 24 часов (1 день)
                {
                    // Показываем уведомление о задаче
                    MessageBox.Show($"Срок выполнения задачи \"{task.Title}\" через {timeRemaining.TotalHours} часов.", "Приближающийся срок задачи", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
