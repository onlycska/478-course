using System;
using System.IO;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleApp1
{
    /// <summary>
    /// Создание таблицы умножения в Эксель через раннее связывание.
    /// </summary>
    public class ExcelEarlyBinding
    {
        /// <summary>
        /// Создание Excel с таблицей умножения.
        /// </summary>
        /// <param name="path">Путь, куда сохранить Excel-файл.</param>
        public void CreateExcel(string path)
        {
            Console.WriteLine("\n\n17. Формирование таблицы умножения в Excel. Путь до файла: {0}\n", path);
            if (!File.Exists(path))
            {
                var oXL = new Excel.Application();
                oXL.Visible = true;
                //Get a new workbook.
                var oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                var oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                for (int first_digit = 1; first_digit < 11; first_digit++)
                {
                    for (int second_digit = 1; second_digit < 11; second_digit++)
                    {
                        // вычисление текущего ряда
                        int row = 10 * (first_digit - 1) + second_digit;

                        // результат умножения
                        int result = first_digit * second_digit;

                        oSheet.Cells[row, 1] = first_digit.ToString();
                        oSheet.Cells[row, 2] = "x";
                        oSheet.Cells[row, 3] = second_digit.ToString();
                        oSheet.Cells[row, 4] = "=";
                        oSheet.Cells[row, 5] = result.ToString();
                    }
                }
                oXL.Windows[1].Close(true, path, Missing.Value);
                oXL.Quit();
            }
        }
    }
}