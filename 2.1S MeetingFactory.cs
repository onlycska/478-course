using System;

/// <summary>
/// Фабрика создания встреч.
/// </summary>
public class MeetingFactory
{
    /// <summary>
    /// Создание встречи.
    /// </summary>
    /// <param name="Start">Начало встречи.</param>
    /// <param name="End">Конец встречи.</param>
    /// <returns>Экземпляр встречи.</returns>
	public MeetingWithType CreateMeeting(DateTime Start, DateTime? End)
    {
        MeetingWithType meet = new MeetingWithType
        {
            StartDate = Start,
            EndDate = End
        };
        return meet;
    }
}
