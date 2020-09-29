using System;

namespace ConsoleApp1
{
    /// <summary>
    /// Класс для оформления записей лог-файлов в консольную строку.
    /// </summary>
    public class SimpleInfo
    {
        public DateTime Date { get; private set; }

        public string String { get; private set; }

        public SimpleInfo(DateTime date, string sstring)
        {
            this.Date = date;
            this.String = sstring;
        }

        public override string ToString()
        {
            return Date.ToString() + "  " + String;
        }

    }
}