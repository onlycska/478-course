﻿using System;
using System.Collections.Generic;

/// <summary>
/// Поиск максимального значения из трёх объектов.
/// </summary>
/// <typeparam name="T">Объекты IComparable</typeparam>
public class Comparing<T>
    where T : IComparable<T>
{
	public T FindMaximum(List<T> list)
    {
        if (list[0].CompareTo(list[1]) > 0 && list[0].CompareTo(list[2]) > 0)
        {
            return list[0];
        }
        else if (list[1].CompareTo(list[2]) > 0 && list[1].CompareTo(list[0]) > 0)
        {
            return list[1];
        }    
        else
        {
            return list[2];
        }
    }
}
