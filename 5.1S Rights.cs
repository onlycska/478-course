using System;
using ConsoleApp1;

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
				Console.WriteLine("{0,3}     {1}", (int)value, ((AccessRights)value));
			}
			else { break; }
		}
	}

}
