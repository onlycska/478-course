using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    /// <summary>
    /// Комплексное число.
    /// </summary>
    public class Complex: IComparer<Complex>, IComparable
    {
       
	    public double Re, Im;
        private double abs;

        public Complex() { Re = 0; Im = 0;  }

        /// <summary>
        /// Получить длину вектора комплексного числа.
        /// </summary>
        /// <returns>Длина вектора.</returns>
	    public double Abs
        {
            get
            {
                abs = Math.Sqrt(Math.Pow(this.Re, 2) + Math.Pow(this.Im, 2));
                return abs;
            }
        }

        /// <summary>
        /// Сравнение длин векторов двух комплексных чисел.
        /// </summary>
        /// <param name="obj">Комплексное число, с которым идёт сравнение.</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj is Complex p)
                return this.abs.CompareTo(p.abs);
            throw new Exception("Невозможно сравнить два объекта");
        }

        /// <summary>
        /// Сортировка двух комплексных чисел в в порядке убывания.
        /// </summary>
        /// <param name="Complexes">Generic-коллекция из двух комплексных чисел.</param>
        /// <returns>Отсортированная Generic-коллекция.</returns>
        public List<Complex> Sort(List<Complex> Complexes)
        {
            var first = Complexes[0];
            var second = Complexes[1];
            var result = new List<Complex>();
            if (first.Abs >= second.Abs)
            {
                result.Add(first);
                result.Add(second);
            }
            else
            {
                result.Add(second);
                result.Add(first);
            }
            return result;
        }

        /// <summary>
        /// Реализация интерфейса сравнения IComparer.
        /// </summary>
        /// <param name="a">Первое комплексное число.</param>
        /// <param name="b">Второе комплексное число.</param>
        /// <returns>1, если первое число больше. -1, если второе число больше. 0, если числа равны.</returns>
        int IComparer<Complex>.Compare(Complex a, Complex b)
        {
            if (a.abs > b.abs)
                return 1;
            if (a.abs < b.abs)
                return -1;
            return 0;
        }
    }
}