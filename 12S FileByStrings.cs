using System;
using System.Collections.Generic;
using System.IO;

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
        if (File.Exists(path))
        {
            string[] fileStrings = File.ReadAllLines(path);
            List<string> parsedFile = new List<string>();
            foreach(string line in fileStrings)
            {
                parsedFile.Add(line);
            }
            return parsedFile;
        }
        else
        {
            throw new FileNotFoundException("File doesn't exist");
        }
    }
}

