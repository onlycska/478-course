using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

/// <summary>
/// Сортировка записей лог-файла по убыванию
/// </summary>
public class FileByDescendingStrings
{
    /// <summary>
    /// Запускает процесс фильтрации и сортировка.
    /// </summary>
    /// <param name="path">Путь до лог-файла.</param>
    /// <param name="startDate">Фильтрация по дате "от"</param>
    /// <param name="endDate">Фильтрация по дате "до"</param>
    public static void Process(string path, DateTime startDate, DateTime endDate)
    {
        Console.WriteLine("\n\n18. Сортировка записей в убывающем порядке с помощью Linq\n");
        FileByStrings file = new FileByStrings();
        List<string> fileByStrings = file.ParseFile(path);
        

        var infos = new List<SimpleInfo>();
        foreach (string line in fileByStrings)
        {
            var lineArr = line.Split('\t');

            if (DateTime.TryParseExact(lineArr[0], "yyyy-MM-ddThh:mm:ss.fffK", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue)) ;
            {
                SimpleInfo correctString = new SimpleInfo(dateValue, lineArr[5]);
                infos.Add(correctString);
            }
        }

        var query = from item in infos
                    where item.Date > startDate && item.Date < endDate
                    orderby item.Date descending
                    select item;

        foreach(SimpleInfo item in query)
        {
            Console.WriteLine("\n" + item.ToString());
        }
    }
}


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
