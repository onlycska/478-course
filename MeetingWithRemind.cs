using System;

/// <summary>
/// интерфейс, позволяющий устанавливать и считывать дату-время напоминания о событии. задание 2.2
/// </summary>
interface IRemind
{
    /// <summary>
    /// Напоминание о событии
    /// </summary>
    public DateTime Reminder { get; set; }
}


public class MeetingWithRemind : Meeting, IRemind
{
    DateTime IRemind.Reminder { get; set; }

    public delegate void RemindTimer(string msg);
    public event RemindTimer TimerHandler;

    private static System.Timers.Timer aTimer;

    private void SetTimer()
    {
        aTimer = new System.Timers.Timer(6000);
        aTimer.Elapsed += ATimer_Elapsed;
        this.TimerHandler += Message;
        this.TimerHandler += AnotherMessage;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
        this.TimerSetted = true;
    }

    private void ATimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (DateTime.Now >= startdate)
        {
            TimerHandler("Событие наступило");
            aTimer.Enabled = false;
            aTimer.AutoReset = false;
            this.TimerSetted = false;
        }
    }

    private void AnotherMessage(string message)
    {
        Console.WriteLine("Another Message: " + message);
    }

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
