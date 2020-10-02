extern alias MethodProperties2;
extern alias MethodProperties1;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using First = MethodProperties1::ConsoleApp1.MethodProperties1;
using Second = MethodProperties2::ConsoleApp1.MethodProperties1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            // todo ко всему:
            // 1. по возможности использовать var
            // +
            // 2. каждое задание лучше сделать в отдельном проекте внутри одного solution-а
            // +
            // 3. хардкодить абсолютные пути не стоит. Лучше сделать файлы ресурсами и в свойствах указывать Copy to output directiry = Copy always (сделал для xml и log)
            // +
            //
            
            // тест создания совещаний - задание 2.1
            Console.WriteLine("\n\n2.1 - создание совещаний с длительностью\n");
            var meeting = new Meeting.Meeting
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            Console.WriteLine(meeting.MeetingDuration());

            // задания 2.2 - 2.4 создание интерфейса IRemind и его наследника - встречу с напоминанием
            Console.WriteLine("\n\n2.2-2.4 - создание интерфейса IRemind и его наследника - встречу с напоминанием\n");
            var meet = new MeetingWithRemind
            {
                RemindDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            ((IRemind)meet).RemindDate = DateTime.Now;
            var duration = meet.MeetingDuration();
            Console.WriteLine(value: duration);
            while (true)
            {
                // todo лишнее сравнение с true.
                // +
                if (meet.TimerSetted)
                {
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }

            // самостоятельная работа 2 - реализация класса встреч через MeetingFactory
            Console.WriteLine("\n\n2S - реализация класса встреч через MeetingFactory\n");
            var factoryMeeting = new MeetingFactory();
            _ = factoryMeeting.CreateMeeting(DateTime.Now, DateTime.Now);

            // задание 5.1-5.2 добавлены тип встречи и пустая дата окончания встречи
            Console.WriteLine("\n\n5.1 - добавлены тип встречи и пустая дата окончания встречи\n");
            // todo MeetingType должен быть enum-ом
            // +
            var meetingwithtype = new MeetingWithType();
            meetingwithtype.Type = MeetingWithType.MeetingType.council;
            Console.WriteLine(meetingwithtype);


            // самостоятельная работа 5.1 - вывод на экран доступных прав
            Console.WriteLine("\n\n5.1 - вывод на экран доступных прав\n");
            var accessRights = AccessRights.Ratify;
            var check = new Rights();
            check.PrintAccessRights(accessRights);

            // самостоятельная работа 5.2: 
            // форматирование дат https://metanit.com/sharp/tutorial/19.2.php 
            // форматирование чисел https://metanit.com/sharp/tutorial/7.5.php

            // todo 6-ое задание не нашёл
            // +
            // я его не доделал было, видимо не разобрался как делать. сейчас доделал
            Console.WriteLine("\n\n6S - запись в файл и освобождение ресурсов\n");
            var logWriter = new Logger(@"./6sHello.txt");
            logWriter.WriteString("Hello world!");
            Console.WriteLine("Работа с логом прекращена: {0}", logWriter.Disposed);
            logWriter.Dispose();
            Console.WriteLine("Работа с логом прекращена: {0}", logWriter.Disposed);

            // задание 7.1 - 7.2 реализация Equals и ==
            Console.WriteLine("\n\n7.1 - 7.2 реализация Equals и ==\n");
            Console.WriteLine(new StringValue("AAA").Equals(new StringValue("AAA")));
            Console.WriteLine(new StringValue("AAA") == (new StringValue("AAA")));
            Console.WriteLine(new StringValue("AAA") != (new StringValue("AAA")));

            // самостоятельная 7 - сортировка комплексных чисел
            // todo Abs должно быть свойством или pure-методом возвращающим длину (без сайд эффектов).
            // +
            // Abs теперь свойство
            // todo Сейчас можно обратиться к публичному полю abs и там будет 0 до вызова метода Abs.
            // +
            // сделал поле приватным
            Console.WriteLine("\n\n7. Сортировка двух комплексных чисел.\n");
            var TwoComplexes = new List<Complex>() { new Complex() { Re = 3, Im = 5 }, new Complex() { Re = 2, Im = 2}};
            TwoComplexes.Sort();
            Console.WriteLine(TwoComplexes[1].Re);

            // практическая 8 - подсчёт количества записей в логах
            Console.WriteLine("\n\n8. Подсчёт количества строк в логах за промежуток.\n");
            string path = @"./filebeat.log";
            string startDate = "2020-08-23T10:47:24.654+0400";
            string endDate = "2020-08-23T10:49:24.646+0400";
            DateTime.TryParseExact(startDate, "yyyy-MM-ddThh:mm:ss.fffK", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime start);
            DateTime.TryParseExact(endDate, "yyyy-MM-ddThh:mm:ss.fffK", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime end);
            var recordsCount = new LogRecordsCount();
            var records = recordsCount.RecordsCount(path, start, end);
            Console.WriteLine("Количество строк с {0} по {1}: {2}", start, end, records);

            // самостоятельная 8 - чтобы класс красиво переводился в строку, нужно переопределять метод ToString 
            // todo Надо реализовать свой ToString в этом задании. Можно взять существующий класс и для него реализовать (meeting, например).
            // +
            Console.WriteLine("\n\n8S. Метод ToString для класса MeetingWithType.\n");
            Console.WriteLine(meetingwithtype.ToString());

            // todo нет 9-го и 10-го заданий.
            // +
            // они выполнены, просто не вызываются, т.к. там нужны спец файлы, которые я не стал делать.
            // можешь просто глянуть LoadGZippedText и LoadFileException. если шо, могу сделать работу с реальным файлом

            // самостоятельная 11 - разработать функцию, которая будет находить максимум из трех значений любого, но строго одинакового типа.
            var comparer = new Comparing<int>();
            var theBiggest = new List<int>();
            theBiggest.Add(1);
            theBiggest.Add(7);
            theBiggest.Add(6);
            Console.WriteLine("\n\n11. Поиск максимума с помощью {0}\n", comparer);
            Console.WriteLine("Поиск максимума из {0}. Максимум: {1}", theBiggest, comparer.FindMaximum(theBiggest));

            // практика 12.1 - Описать структуру хранения данных локализации без создания своих типов.
            // todo Инициализацию локазлизации лучше делать Lazy
            // Т.е. сделать какое-то свойство, которое будет заполняться при первом обращении, а при повторном будет использоваться вместо повторной инициализации.
            // + 
            // сделал static поля со словарями и static метод GetValue
            Console.WriteLine("\n\n12. Описать структуру хранения данных локализации без создания своих типов (строки локализации).\n");
            Console.WriteLine(Localization.GetValue("E_CANT_CHANGE_PASSWORD_WITH_OS_AUTHENTIFICATION", "en"));

            // практика 13 - выводить имена всех read-write свойств полученного объекта и строковые представления значений свойств.
            // todo внутри класса.
            // + 
            var methodProperties = new MethodProperties();
            methodProperties.PrintMethodProperties(meetingwithtype);
            methodProperties.PrintMethodProperties(null);

            // самостоятельная 13 - вывод имен всех свойств кроме Obsolete с помощью конструктора класса
            // todo Лучше использование и инициализацию держать рядом (т.е. 127 строчку перенести перед 131) + см. замечания в классе AssemblyMethodProperties
            // +
            var assemblyMethodProperties = new AssemblyMethodProperties();
            var currentAssemblyName = Assembly.GetExecutingAssembly().FullName;
            string findedClass = "MeetingWithType";
            assemblyMethodProperties.PrintMethodProperties(currentAssemblyName, findedClass);

            // самостоятельная 14 - чтение XML
            ReadXMLfromFile.ReadXml(@"./14XML.xml");

            // todo В 15-ом задании надо собрать две версии одной библиотеки.
            // Например, код для 13-го задания (классы встреч) вынести в отдельный проект и дважды собрать в виде dll с разными начальными значениями.
            // И потом загрузить их через reflection в разные домены приложений и вывести значения.
            // +
            Console.WriteLine("\n\n15. Собрать две версии одной библиотеки.\n");
            var first = new First();
            first.PrintMethodProperties();

            var second = new Second();
            second.PrintMethodProperties();

            // практика 17 - раннее связывание в Excel
            var excelCreation = new ExcelEarlyBinding();
            excelCreation.CreateExcel(@"C:\EarlyBinding.xlsx");

            // todo в 17.1 надо сделать всё то же самое, но oXl создать через Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            // +

            // практика 17 - позднее связывание в excel
            var lateExcelCreation = new ExcelLateBinding();
            lateExcelCreation.CreateExcel();

            // самостоятельная 18 - работа с лог-файлом. фильтрация и сортировка его записей с помощью Linq
            FileByDescendingStrings.Process(@"./filebeat.log", start, end);
        }
    }
}

