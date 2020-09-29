using System;

namespace ConsoleApp1
{
    /// <summary>
    /// интерфейс, позволяющий устанавливать и считывать дату-время напоминания о событии.
    /// </summary>
    public interface IRemind
    {
        /// <summary>
        /// Напоминание о событии
        /// </summary>
        DateTime Reminder { get; set; }
    }
}