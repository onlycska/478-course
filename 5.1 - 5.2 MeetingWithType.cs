using System;
using System.Collections;

/// <summary>
/// Встреча с типом.
/// </summary>
public class MeetingWithType : Meeting
{   
    /// <summary>
    /// Тип встречи у текущего класса.
    /// </summary>
    private static string meetingtype;

    public MeetingWithType() { 
        
        MeetingType = "день рождения";
        MeetingType2 = "день рождения";
        StartDate = DateTime.Now; 
        EndDate = null; 
    }
    
    
    /// <summary>
    /// Доступные типы встреч.
    /// </summary>
    readonly ArrayList available_types = new ArrayList() {
                "совещание", "поручение", "звонок", "день рождения"
                };

    /// <summary>
    /// Установка типа встречи из списка доступных.
    /// </summary>
    [ObsoleteAttribute("This property is obsolete. Use NewProperty instead.", false)]
    public string MeetingType
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

    /// <summary>
    /// Доп параметр для теста ObsoleteAttribute в задании 13S.
    /// </summary>
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
}
