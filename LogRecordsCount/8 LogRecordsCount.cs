using System;
using System.Globalization;
using System.IO;

namespace ConsoleApp1
{
    /// <summary>
    /// Подсчёт количества записей в лог-файле за период.
    /// </summary>
    public class LogRecordsCount
    {
        /// <summary>
        /// Посчитать количество записей в лог-файле.
        /// </summary>
        /// <param name="path">Путь до лог-файла.</param>
        /// <param name="startDate">От какой даты считать записи в лог-файле.</param>
        /// <param name="endDate">До какой даты считать записи в лог-файле.</param>
        /// <returns>Количество записей за период.</returns>
        public int RecordsCount(string path, DateTime startDate, DateTime endDate)
        {
            // бросаем исключение, если передан неверный порядок дат
            if (startDate > endDate)
            {
                throw new Exception("start date is bigger than end date");
            }
    
            if (File.Exists(path))
            {
                int recordsCount = 0;
                string[] fileStrings = File.ReadAllLines(path);
                foreach (string line in fileStrings)
                {
                    var lineArr = line.Split('\t');
                    if (DateTime.TryParseExact(lineArr[0], "yyyy-MM-ddThh:mm:ss.fffK", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue)) ;
                    {
                        Console.WriteLine(dateValue);
                        if (dateValue >= startDate && dateValue <= endDate)
                        {
                            recordsCount++;
                        }
                        else if (dateValue < startDate)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return recordsCount;
            }
            else
            {
                throw new FileNotFoundException("File doesn't exist");
            }
        }
    }

}