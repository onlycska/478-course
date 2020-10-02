using System;

namespace ConsoleApp1
{
    /// <summary>
    /// Встреча с напоминанием.
    /// </summary>
    public class MeetingWithRemind : Meeting.Meeting, IRemind
    {
        public delegate void RemindTimer(string msg);
        public event RemindTimer TimerHandler;

        private static System.Timers.Timer aTimer;

        public MeetingWithRemind(DateTime remindDate)
        {
            SetTimer();
            this.RemindDate = remindDate;
        }

        /// <summary>
        /// Установка таймера
        /// </summary>
        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(900);
            aTimer.Elapsed += ATimer_Elapsed;
            this.TimerHandler += Message;
            this.TimerHandler += AnotherMessage;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        /// <summary>
        /// Напоминание о наступлении события.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ATimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now < remindDate) return;
            Console.WriteLine("\n\n2.2-2.4 - создание интерфейса IRemind и его наследника - встречу с напоминанием\n");
            TimerHandler?.Invoke("Событие наступило");
            aTimer.AutoReset = false;
            aTimer.Enabled = false;
        }

        /// <summary>
        /// Напоминание о наступлении события
        /// </summary>
        /// <param name="message">Сообщение для вывода пользователю.</param>
        static void AnotherMessage(string message)
        {
            Console.WriteLine("Another Message: " + message);
            
        }

        /// <summary>
        /// Сообщение для вывода пользователю.
        /// </summary>
        /// <param name="msg">Текст сообщения.</param>
        static void Message(string msg)
        {
            Console.WriteLine(msg);
        }

        private static DateTime remindDate;

        public DateTime RemindDate
        {
            get
            {
                return remindDate;
            }

            set
            {
                remindDate = value;
            }
        }

    }
}