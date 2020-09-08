using System;
using System.IO;

/// <summary>
/// Логгер - класс для ведения логов.
/// </summary>
class Logger : IDisposable
{
    /// <summary>
    /// Файл логов.
    /// </summary>
    private readonly FileStream logFile;

    /// <summary>
    /// Писатель в лог.
    /// </summary>
    private readonly StreamWriter logWriter;

    /// <summary>
    /// Создать объект.
    /// </summary>
    /// <param name="fileName">Имя файла логов.</param>
    public Logger(string fileName)
    {
        logFile = new FileStream(fileName, FileMode.Append);
        logWriter = new StreamWriter(logFile);
    }

    /// <summary>
    /// Запись в лог-файл
    /// </summary>
    /// <param name="data">Информация для записи в лог.</param>
    public void WriteString(string data)
    {
        logWriter.WriteLine(data);
    }

    /// <summary>
    /// Освобождены ли управляемые ресурсы
    /// </summary>
    private bool disposed;

    /// <summary>
    /// Освободить ресурсы объекта.
    /// </summary>
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Осводобить ресурсы объекта.
    /// </summary>
    /// <param name="disposing">Признак, необходимо ли чистить управляемые ресурсы.</param>
    private void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                // Освобождаем управляемые ресурсы (присваиваем в null).
            }
            this.disposed = true;
        }
    }

}
