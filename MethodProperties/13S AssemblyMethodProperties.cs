using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    /// <summary>
    /// Метод печатает имена всех read-write свойств полученного объекта и строковые представления значений свойств.
    /// </summary>
    public class AssemblyMethodProperties
    {
        /// <summary>
        /// Метод печатает имена всех read-write свойств полученного объекта и строковые представления значений свойств.
        /// </summary>
        /// <param name="assemblyName">Имя сборки.</param>
        /// <param name="findClass">Название класса в сборке (без учёта регистра)</param>
        public void PrintMethodProperties(string assemblyName, string findClass)
        {
            Console.WriteLine("\n\n13. Вывод имён АКТУАЛЬНЫХ свойств класса и их значений\n");
            Assembly asm = Assembly.Load(assemblyName);

            Type describedClassType = asm.GetType(findClass, throwOnError: false, ignoreCase: true);

            if (describedClassType == null)
            {
                Console.WriteLine("\nНет указанного класса {0} в переданной сборке.", findClass);
            }
            else
            {
                //создание конструктора
                ConstructorInfo classConstructor = describedClassType.GetConstructor(Type.EmptyTypes);
                object[] parameters = new object[0];
                object constructor = classConstructor.Invoke(parameters);

                Console.WriteLine("\nОписание свойств объекта {0}:", describedClassType);

                // вывод значений свойств 
                // todo Гораздо проще здесь через linq получить сразу только не-obsolete свойства. См. validator.cs в DSS
                // +
                var properties = describedClassType.GetProperties().Where(x => 
                    x.GetCustomAttributes(typeof(ObsoleteAttribute), true).Any() == false);
                Dictionary<string, object> dict = new Dictionary<string, object>();
                foreach (PropertyInfo prp in properties)
                {
                    // вывод на экран всех актуальныъх атрибутов
                    if (prp.GetIndexParameters().Length == 0)
                        Console.WriteLine("   {0} ({1}): {2}", prp.Name,
                                          prp.PropertyType.Name,
                                          prp.GetValue(constructor));
                    else
                        Console.WriteLine("   {0} ({1}): <Indexed>", prp.Name,
                                          prp.PropertyType.Name);
                }
            }
        }
    }
}