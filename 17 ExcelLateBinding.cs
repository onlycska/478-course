using Westwind.Utilities;
using System;
using System.Reflection;

public class ExcelLateBinding
{
	public void CreateExcel(string path)
	{
        /*object[,] values = new object[,];
        
        */
        dynamic excelApp = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
        var visible = ReflectionUtils.GetPropertyCom(excelApp, "Visible");
        visible = true;
        // excelApp.Visible = true;
        // excelApp.Workbooks.Add();
        var workBooks = ReflectionUtils.GetPropertyCom(excelApp, "Workbooks");
        // workBooks.Add();
        var workSheet = ReflectionUtils.GetPropertyCom(excelApp, "ActiveSheet"); //excelApp.ActiveSheet;
        for (int first_digit = 1; first_digit < 11; first_digit++)
        {
            for (int second_digit = 1; second_digit < 11; second_digit++)
            {
                // вычисление текущего ряда
                int row = 10 * (first_digit - 1) + second_digit;

                // результат умножения
                int result = first_digit * second_digit;

                workSheet.Cells[row, "A"] = first_digit.ToString();
                workSheet.Cells[row, "B"] = "x";
                workSheet.Cells[row, 3] = second_digit.ToString();
                workSheet.Cells[row, 4] = "=";
                workSheet.Cells[row, 5] = result.ToString();
            }
        }
/*        }
        catch (Exception ex)
        {
            {
                Console.WriteLine("Excel reported the following Error:");
                Console.WriteLine(ex.Message);
            }
        }
        finally
        {
            // Release the com object
            var windows = ReflectionUtils.GetPropertyCom(excelApp, "Windows");
            // windows.Close(true, path, Missing.Value);
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }*/
    }

        /*var oXL = new Excel.Application();
        oXL.Visible = true;
        //Get a new workbook.
        var oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
        var oSheet = (Excel._Worksheet)oWB.ActiveSheet;

        

        //Add table headers going cell by cell.


        //oWB.Saved = true;
        //oXL.Workbooks.Close();
        oXL.Windows[1].Close(true, path, Missing.Value);
        oXL.Quit();*/
    
}
