using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    /// <summary>
    /// Парсинг файла и возвращение его в виде списка строк, упакованных в Generic-коллекцию.
    /// </summary>
    public class FileByStrings
    {
        /// <summary>
        /// Парсинг файла.
        /// </summary>
        /// <param name="path">Путь до файла.</param>
        /// <returns>Generic-коллекция строк файла.</returns>
        public List<string> ParseFile(string path)
        {
            try
            {
                string[] fileStrings = File.ReadAllLines(path);
                List<string> parsedFile = new List<string>();
                foreach (string line in fileStrings)
                {
                    parsedFile.Add(line);
                }

                return parsedFile;
            }
            catch (FileNotFoundException e)
            {
                string output = String.Format("Ошибка: {0}\nПо пути {1} файл не был найден", e, path);
                throw new FileNotFoundException(output);
            }
        }
    }
}