using System;

namespace ConsoleApp1
{
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
        public Meeting.Meeting CreateMeeting(DateTime Start, DateTime End)
        {
            var meet = new Meeting.Meeting
            {
                StartDate = Start,
                EndDate = End
            };
            return meet;
        }
    }
}