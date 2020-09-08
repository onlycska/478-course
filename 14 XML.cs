using System;
using System.Xml;

/// <summary>
/// Обработка XML файлов и вывод их текста в консоль приложения.
/// </summary>
class ReadXMLfromFile
{
    /// <summary>
    /// Метод принимает файл и выводит его в консоль с сохранением XML формата.
    /// </summary>
    /// <param name="fileName">Полный путь до XML файла.</param>
    public static void ReadXml(string fileName)
    {
        XmlTextReader reader = new XmlTextReader(fileName);
        Console.WriteLine("\n\n14. Чтение XML из файла {0}:\n", fileName);

        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                // шапка XML с её содержимым
                case XmlNodeType.XmlDeclaration:
                    Console.Write("<?" + reader.Name);
                    while (reader.MoveToNextAttribute()) // Чтение атрибутов.
                        Console.Write(" " + reader.Name + "=" + reader.Value + "'");
                    Console.WriteLine("?>");
                    break;

                // элемент XML с его содержимым
                case XmlNodeType.Element: // Узел является элементом.
                    Console.Write("<" + reader.Name);
                    while (reader.MoveToNextAttribute()) // Чтение атрибутов.
                        Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                    Console.WriteLine(">");
                    break;

                // текст в XML
                case XmlNodeType.Text: // Вывести текст в каждом элементе.
                    Console.WriteLine(reader.Value);
                    Console.WriteLine("Text");
                    break;

                // конец элемента в XML
                case XmlNodeType.EndElement: // Вывести конец элемента.
                    Console.Write("</" + reader.Name);
                    Console.WriteLine(">");
                    break;
            }
        }
    }
}
