using System;

public class MeetingWithType : Meeting
{  
    private static string meetingtype;

    ArrayList available_types = new ArrayList() {
                "совещание", "поручение", "звонок", "день рождения"
                };

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

    new public DateTime? EndDate;
}
