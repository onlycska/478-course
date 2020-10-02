using System;
using System.IO;

/*
Класс предполагается использовать для ведения логов в произвольных программах. 
Необходимо доработать класс под следующее условие: как только программа посчитает запись в лог законченной, 
необходимо освободить файл, чтобы другие программы могли начать его читать.
Продемонстрировать использование класса на примере.
*/

namespace ConsoleApp1
{
    /// <summary>
    /// Логгер - класс для ведения логов.
    /// </summary>
    public class Logger : IDisposable
    {
        /// <summary>
        /// Файл логов.
        /// </summary>
        private FileStream logFile;

        /// <summary>
        /// Писатель в лог.
        /// </summary>
        private StreamWriter logWriter;

    
        /// <summary>
        /// Создать объект.
        /// </summary>
        /// <param name="fileName">Имя файла логов.</param>
        public Logger(string fileName)
        {
            logFile = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            logWriter = new StreamWriter(logFile);
        }

        /// <summary>
        /// Запись в лог-файл
        /// </summary>
        /// <param name="data">Информация для записи в лог.</param>
        public void WriteString(string data)
        {
            logWriter.Write(data);
            logWriter.Flush(); 
        }
    
        /// <summary>
        /// Освобождены ли управляемые ресурсы
        /// </summary>
        private bool disposed;
        
        public bool Disposed {
            get 
            {
                return disposed;
            }
        }
        
    
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
                    // Освобождаем управляемые ресурсы.
                    logWriter?.Dispose();
                    logFile?.Dispose();
                }
                this.disposed = true;
            }
        }
    
    }
}