using System;

namespace ConsoleApp1
{
    /// <summary>
    /// Встреча с напоминанием.
    /// </summary>
    public class MeetingWithRemind : Meeting.Meeting, IRemind
    {  
       
        DateTime IRemind.Reminder { get; set; }

        public delegate void RemindTimer(string msg);
        public event RemindTimer TimerHandler;

        private static System.Timers.Timer aTimer;

        public bool TimerSetted { get; set; }

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
            this.TimerSetted = true;
        }

        /// <summary>
        /// Напоминание о наступлении события.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ATimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now >= startdate)
            {
                TimerHandler("Событие наступило");
            }
        }

        /// <summary>
        /// Напоминание о наступлении события
        /// </summary>
        /// <param name="message">Сообщение для вывода пользователю.</param>
        private void AnotherMessage(string message)
        {
            Console.WriteLine("Another Message: " + message);
            this.TimerSetted = false;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        /// <summary>
        /// Сообщение для вывода пользователю.
        /// </summary>
        /// <param name="msg">Текст сообщения.</param>
        public void Message(string msg)
        {
            Console.WriteLine(msg);
        }

        private static DateTime startdate;

        new public DateTime StartDate
        {
            get
            {
                return startdate;
            }

            set
            {
                startdate = value;
                SetTimer();
            }
        }

        new public DateTime EndDate;

    }
}