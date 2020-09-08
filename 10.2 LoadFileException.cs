using System;

/// <summary>
/// Исключение ошибки деления на ноль.
/// </summary>
public class LoadFileException : Exception
{
    /// <summary>
    /// Создать экземпляр класса.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="innerException">Вложенное искючение.</param>
    public LoadFileException(string message,
      Exception innerException) : base(message, innerException) { }
}

