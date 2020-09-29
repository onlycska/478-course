using System;

namespace ConsoleApp1
{
    /// <summary>
    /// Класс работы с правами доступа.
    /// </summary>
    public class Rights
    {
        /// <summary>
        /// Вывод в консоль все доступные действия с текущими правами.
        /// </summary>
        /// <param name="accessRights">Текущие права доступа.</param>
        public void PrintAccessRights(AccessRights accessRights)
        {
            foreach (AccessRights value in Enum.GetValues(typeof(AccessRights)))
            {
                if (value <= accessRights)
                {
                    Console.WriteLine("{0,3}     {1}", (int)value, (value));
                }
                else { break; }
            }
        }

    }
    
    /// <summary>
    /// Тип прав.
    /// </summary>
    [Flags, Serializable]
    public enum AccessRights : byte
    {
        /// <summary>
        /// Просмотр.
        /// </summary>
        View = 1,

        /// <summary>
        /// Выполнение.
        /// </summary>
        Run = 2,

        /// <summary>
        /// Добавление.
        /// </summary>
        Add = 4,

        /// <summary>
        /// Изменение.
        /// </summary>
        Edit = 8,

        /// <summary>
        /// Утверждение.
        /// </summary>
        Ratify = 16,

        /// <summary>
        /// Удаление.
        /// </summary>
        Delete = 32,

        /// <summary>
        /// Нет доступа.
        /// </summary>
        /// <remarks>
        /// Этот флаг имеет максимальный приоритет.
        /// Если он установлен, остальные флаги игнорируются 
        /// </remarks>
        AccessDenied = 64
    }
}