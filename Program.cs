using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            // тест создания совещаний - задание 2.1
            Console.WriteLine("\n\n2.1 - создание совещаний с длительностью\n");
            Meeting meeting = new Meeting
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            Console.WriteLine(meeting.MeetingDuration());

            // задания 2.2 - 2.4 создание интерфейса IRemind и его наследника - встречу с напоминанием
            Console.WriteLine("\n\n2.2-2.4 - создание интерфейса IRemind и его наследника - встречу с напоминанием\n");
            MeetingWithRemind meet = new MeetingWithRemind
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            ((IRemind)meet).Reminder = DateTime.Now;
            var duration = meet.MeetingDuration();
            Console.WriteLine(value: duration);
            while (true)
            {
                if (meet.TimerSetted == true)
                {
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }

            // самостоятельная работа 2 - реализация класса встреч через MeetingFactory
            Console.WriteLine("\n\n2S - реализация класса встреч через MeetingFactory\n");
            MeetingFactory factoryMeeting = new MeetingFactory();
            _ = factoryMeeting.CreateMeeting(DateTime.Now, null);

            // задание 5.1-5.2 добавлены тип встречи и пустая дата окончания встречи
            Console.WriteLine("\n\n5.1 - добавлены тип встречи и пустая дата окончания встречи\n");
            MeetingWithType meetingwithtype = new MeetingWithType
            {
                MeetingType = "совещание"
            };
            meetingwithtype.EndDate = null;
            Console.WriteLine(meetingwithtype.MeetingType);
            meetingwithtype.MeetingType = "fol";


            // самостоятельная работа 5.1 - вывод на экран доступных прав
            Console.WriteLine("\n\n5.1 - вывод на экран доступных прав\n");
            AccessRights accessRights = AccessRights.Ratify;
            Rights check = new Rights();
            check.PrintAccessRights(accessRights);

            // самостоятельная работа 5.2: 
            // форматирование дат https://metanit.com/sharp/tutorial/19.2.php 
            // форматирование чисел https://metanit.com/sharp/tutorial/7.5.php

            // задание 7.1 - 7.2 реализация Equals и ==
            Console.WriteLine("\n\n7.1 - 7.2 реализация Equals и ==\n");
            Console.WriteLine(new StringValue("AAA").Equals(new StringValue("AAA")));
            Console.WriteLine(new StringValue("AAA") == (new StringValue("AAA")));
            Console.WriteLine(new StringValue("AAA") != (new StringValue("AAA")));

            // самостоятельная 7 - сортировка комплексных чисел
            Console.WriteLine("\n\n7. Сортировка двух комплексных чисел.\n");
            List<Complex> TwoComplexes = new List<Complex>() { new Complex() { Re = 3, Im = 5 }, new Complex() { Re = 2, Im = 2}};
            TwoComplexes.Sort();
            Console.WriteLine(TwoComplexes[1].Re);

            // практическая 8 - подсчёт количества записей в логах
            Console.WriteLine("\n\n8. Подсчёт количества строк в логах за промежуток.\n");
            string path = @"C:\Users\andriyanov_oe\source\repos\Meeting\ConsoleApp1\filebeat.log";
            string startDate = "2020-08-23T10:47:24.654+0400";
            string endDate = "2020-08-23T10:49:24.646+0400";
            DateTime.TryParseExact(startDate, "yyyy-MM-ddThh:mm:ss.fffK", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime start);
            DateTime.TryParseExact(endDate, "yyyy-MM-ddThh:mm:ss.fffK", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime end);
            LogRecordsCount recordsCount = new LogRecordsCount();
            int records = recordsCount.RecordsCount(path, start, end);
            Console.WriteLine("Количество строк с {0} по {1}: {2}", start, end, records);

            // самостоятельная 8 - чтобы класс красиво переводился в строку, нужно переопределять метод ToString 
            ToStringTest test = new ToStringTest();
            Console.WriteLine("\n\n8. Переопределение метода ToString\n");
            Console.WriteLine(test.ToString());

            // самостоятельная 11 - разработать функцию, которая будет находить максимум из трех значений любого, но строго одинакового типа.
            Comparing<int> comparer = new Comparing<int>();
            List<int> theBiggest = new List<int>();
            theBiggest.Add(1);
            theBiggest.Add(7);
            theBiggest.Add(6);
            Console.WriteLine("\n\n11. Поиск максимума с помощью {0}\n", comparer);
            Console.WriteLine("Поиск максимума из {0}. Максимум: {1}", theBiggest, comparer.FindMaximum(theBiggest));

            // практика 12.1 - Описать структуру хранения данных локализации без создания своих типов.
            var locale = new Localization();
            Console.WriteLine("\n\n12. Описать структуру хранения данных локализации без создания своих типов (строки локализации).\n");
            Console.WriteLine(locale.GetValue("E_CANT_CHANGE_PASSWORD_WITH_OS_AUTHENTIFICATION", "en"));

            // практика 13 - выводить имена всех read-write свойств полученного объекта и строковые представления значений свойств.
            MethodProperties methodProperties = new MethodProperties();
            methodProperties.PrintMethodProperties(meetingwithtype);

            // самостоятельная 13 - вывод имен всех свойств кроме Obsolete с помощью конструктора класса
            AssemblyMethodProperties assemblyMethodProperties = new AssemblyMethodProperties();
            var currentAssembly = Assembly.GetExecutingAssembly();
            string currentAssemblyName = currentAssembly.FullName;
            string findedClass = "meetingwithtype";
            assemblyMethodProperties.PrintMethodProperties(currentAssemblyName, findedClass);

            // самостоятельная 14 - чтение XML
            ReadXMLfromFile.ReadXml(@"C:\Users\andriyanov_oe\source\repos\Meeting\ConsoleApp1\14XML.xml");

            // практика 17 - раннее связывание в Excel
            var excelCreation = new ExcelEarlyBinding();
            excelCreation.CreateExcel(@"C:\EarlyBinding.xls");

            // практика 17 - позднее связывание в excel
            // var lateExcelCreation = new ExcelLateBinding();
            // lateExcelCreation.CreateExcel(@"C:\lateBinding.xls");

            // самостоятельная 18 - работа с лог-файлом. фильтрация и сортировка его записей с помощью Linq
            FileByDescendingStrings.Process(@"C:\Users\andriyanov_oe\source\repos\Meeting\ConsoleApp1\filebeat.log", start, end);
        }
    }


    /// <summary>
    /// Тип прав.
    /// </summary>
    [Flags, Serializable]
    public enum AccessRights : byte
    {
        /// <summary>
        /// Просмотр.
        /// </summary>
        View = 1,

        /// <summary>
        /// Выполнение.
        /// </summary>
        Run = 2,

        /// <summary>
        /// Добавление.
        /// </summary>
        Add = 4,

        /// <summary>
        /// Изменение.
        /// </summary>
        Edit = 8,

        /// <summary>
        /// Утверждение.
        /// </summary>
        Ratify = 16,

        /// <summary>
        /// Удаление.
        /// </summary>
        Delete = 32,

        /// <summary>
        /// Нет доступа.
        /// </summary>
        /// <remarks>
        /// Этот флаг имеет максимальный приоритет.
        /// Если он установлен, остальные флаги игнорируются 
        /// </remarks>
        AccessDenied = 64
    }

}

