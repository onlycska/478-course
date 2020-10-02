using System;
using System.Reflection;

namespace ConsoleApp1
{
    /// <summary>
    /// Метод печатает имена всех read-write свойств полученного объекта и строковые представления значений свойств.
    /// </summary>
    public class MethodProperties1
    {
        /// <summary>
        /// Метод вывод имена свойств класса и их значения.
        /// </summary>
        public void PrintMethodProperties()
        {
            try
            {
                var describedClass = new MeetingWithType();
                describedClass.Type = MeetingWithType.MeetingType.call;
                Console.WriteLine("\n\n13. Вывод всех свойств объекта {0}\n", describedClass);
                Console.WriteLine("\nОписание свойств объекта {0}:", describedClass);
                Type classType = describedClass.GetType();
                PropertyInfo[] properties = classType.GetProperties();
                // Dictionary<string, object> dict = new Dictionary<string, object>();
                foreach (PropertyInfo prp in properties)
                {
                    if (prp.GetIndexParameters().Length == 0)
                        Console.WriteLine("   {0} ({1}): {2}", prp.Name,
                            prp.PropertyType.Name,
                            prp.GetValue(describedClass));
                    else
                        Console.WriteLine("   {0} ({1}): <Indexed>", prp.Name,
                            prp.PropertyType.Name);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("У объекта нет свойств", ex);
            }
        }
    }
}