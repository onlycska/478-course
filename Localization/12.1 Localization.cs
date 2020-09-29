using System.Collections.Generic;
using System.Collections.Specialized;


namespace ConsoleApp1
{
    /// <summary>
    /// Словарь локализации
    /// </summary>
    public struct Localization
    {
        private static readonly StringDictionary russianValues = new StringDictionary()
        {
            { "E_CANT_CHANGE_PASSWORD_WITH_OS_AUTHENTIFICATION", "Нельзя изменять пароль при использовании Windows-аутентификации."},
            { "DEBUGGER_MAIN_FORM_TRACE_INTO_ACTION_CAPTION", "Шаг в" }
        };
        
        private static readonly StringDictionary englishValues = new StringDictionary()
        {
            { "E_CANT_CHANGE_PASSWORD_WITH_OS_AUTHENTIFICATION", "Cannot change password when using Windows-authentication."},
            { "DEBUGGER_MAIN_FORM_TRACE_INTO_ACTION_CAPTION", "Trace into" }
        };
        
        private static readonly Dictionary<string, StringDictionary> localeDict = new Dictionary<string, StringDictionary>()
        {
            { "ru", russianValues},
            { "en", englishValues }
        };
        
        /// <summary>
        /// Получить значение строки локализации.
        /// </summary>
        /// <param name="localeString">Имя строки.</param>
        /// <param name="language">Язык строки.</param>
        /// <returns>Строка локализации.</returns>
        public static string GetValue(string localeString, string language)
        {
            var value = localeDict[language][localeString];
            return value;
        }
    }
}