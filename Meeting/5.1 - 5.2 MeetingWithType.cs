using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    /// <summary>
    /// Встреча с типом.
    /// </summary>
    public class MeetingWithType: Meeting.Meeting
    {   
        /// <summary>
        /// Тип встречи у текущего класса.
        /// </summary>
        [Obsolete("This property is obsolete. Use NewProperty instead.", false)]
        private static string meetingtype;
        
        /// <summary>
        /// Тип встречи у текущего класса.
        /// </summary>
        private MeetingType type; 
        
        public object GetMeetingName(MeetingType type)
        {
            return available_types.ElementAt((int)type);
        }
        
        public MeetingWithType() {
            MeetingType2 = "день рождения";
            StartDate = DateTime.Now; 
            EndDate = null; 
        }

        public override string ToString()
        {
            return base.ToString() + ": " + available_types.ElementAt((int)type);
        }
        
        public MeetingType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        /// <summary>
        /// Доступные типы встреч.
        /// </summary>
        readonly HashSet<string> available_types = new HashSet<string>{
            "совещание", "поручение", "звонок", "день рождения"
        };

        /// <summary>
        /// Установка типа встречи из списка доступных.
        /// </summary>
        
        public enum MeetingType
        {    
            council = 0,
            assignment = 1,
            call = 2,
            birthday = 3
        }

        /// <summary>
        /// Доп параметр для теста ObsoleteAttribute в задании 13S.
        /// </summary>
        [Obsolete("This property is obsolete. Use NewProperty instead.", false)]
        public string MeetingType2
        {
            get
            {
                return meetingtype;
            }
            set
            {
                if (available_types.Contains(value))
                {
                    meetingtype = value;
                }
                else
                {
                    Console.WriteLine("Левый тип какой-то");
                }
            }
        }

        new public DateTime? EndDate;

        new public DateTime StartDate;
    }

}