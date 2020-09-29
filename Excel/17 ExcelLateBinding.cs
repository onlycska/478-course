using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    /// <summary>
    /// Создание таблицы умножения в Эксель через раннее связывание.
    /// </summary>
    public class ExcelLateBinding
    {
        /// <summary>
        /// Создание Excel с таблицей умножения в папке "Документы".
        /// </summary>
        public void CreateExcel()
        {
            Console.WriteLine("\n\n17. Формирование таблицы умножения в Excel. Файл сохранится в папке 'Документы'");
            Type type = Type.GetTypeFromProgID("Excel.Application");
            dynamic excel = Activator.CreateInstance(type);
            var workbooks = excel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, excel, null);
            var workbook = workbooks.GetType().InvokeMember(
                "Add", BindingFlags.InvokeMethod, null, workbooks, null);
            var oWorksheets = workbook.GetType().InvokeMember(
                "Worksheets", BindingFlags.GetProperty, null, workbook, null);
            var args = new object[1];
            args[0] = 1;
            object oSheet = oWorksheets.GetType().InvokeMember(
                "Item", BindingFlags.GetProperty, null, oWorksheets, args);
            var range = oSheet.GetType().InvokeMember(
                "Range", BindingFlags.GetProperty, null, oSheet, new object[] {"A1"});

            try
            {
                for (int first_digit = 1; first_digit < 11; first_digit++)
                {
                    for (int second_digit = 1; second_digit < 11; second_digit++)
                    {
                        // вычисление текущего ряда
                        int row = 10 * (first_digit - 1) + second_digit;

                        // результат умножения
                        int result = first_digit * second_digit;
                        
                        // заполнение ячеек.
                        range = oSheet.GetType().InvokeMember(
                            "Range", BindingFlags.GetProperty, null, oSheet, new object[] {"A" + row});
                        range.GetType().InvokeMember(
                            "Value", BindingFlags.SetProperty, null, range, new object[] {(first_digit).ToString()});

                        range = oSheet.GetType().InvokeMember(
                            "Range", BindingFlags.GetProperty, null, oSheet, new object[] {"B" + row});
                        range.GetType().InvokeMember(
                            "Value", BindingFlags.SetProperty, null, range, new object[] {("x")});

                        range = oSheet.GetType().InvokeMember(
                            "Range", BindingFlags.GetProperty, null, oSheet, new object[] {"C" + row});
                        range.GetType().InvokeMember(
                            "Value", BindingFlags.SetProperty, null, range, new object[] {(second_digit).ToString()});

                        range = oSheet.GetType().InvokeMember(
                            "Range", BindingFlags.GetProperty, null, oSheet, new object[] {"D" + row});
                        range.GetType().InvokeMember(
                            "Value", BindingFlags.SetProperty, null, range, new object[] {"="});

                        range = oSheet.GetType().InvokeMember(
                            "Range", BindingFlags.GetProperty, null, oSheet, new object[] {"E" + row});
                        range.GetType().InvokeMember(
                            "Value", BindingFlags.SetProperty, null, range, new object[] {(result).ToString()});

                    }
                }
                //сохраняется в папке документы
                workbook.GetType().InvokeMember("Save", BindingFlags.InvokeMethod, null, workbook, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // Закрытие всех COM-объектов Excel, чтобы процесс Excel.exe мог закрыться.
                while (Marshal.ReleaseComObject(workbook) > 0) { }
                workbook = null;
                while (Marshal.ReleaseComObject(oSheet) > 0) { }
                oSheet = null;
                while (Marshal.ReleaseComObject(oWorksheets) > 0) { }
                oWorksheets = null;
                while (Marshal.ReleaseComObject(workbooks) > 0) { }
                workbooks = null;
                while (Marshal.ReleaseComObject(range) > 0) { }
                range = null;
                GC_();
                
                // Закрытие Excel.exe
                excel.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod, null, excel, null);
                while (Marshal.ReleaseComObject(excel) > 0) { }
                excel = null;
                GC_();
            }
        }
        public static void GC_()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}