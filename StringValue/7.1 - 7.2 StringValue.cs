namespace ConsoleApp1
{
    /// <summary>
    /// Класс для проверки эквивалентности строк.
    /// </summary>
    public class StringValue
    {
        public string Value { get; private set; }

        public StringValue(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Сравнение двух строк объектов StringValue
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            StringValue person = (StringValue)obj;
            return (this.Value == person.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(StringValue c1, StringValue c2)
        {
            return c1.Value == c2.Value;
        }

        public static bool operator !=(StringValue c1, StringValue c2)
        {
            return c1.Value != c2.Value;
        }
    }
}