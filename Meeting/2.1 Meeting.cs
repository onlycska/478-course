﻿using System;

namespace ConsoleApp1
{    
    // просто тест неймспейса внутри неймспейса
    namespace Meeting
    {
        /// <summary>
        /// Организация встречи.
        /// </summary>
        public class Meeting
        {
            /// <summary>
            /// Расчёт длительности митинга исходя из значений свойств (конец и начало встречи).
            /// </summary>
            /// <returns>Длительность митинга.</returns>
            public TimeSpan MeetingDuration()
            {
                return this.EndDate - this.StartDate;
            }

            public DateTime StartDate;

            public DateTime EndDate;
        }
    }
}