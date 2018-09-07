using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ClassLibrary1.com.traveledge.common
{
    class ExcelLib
    {

        public static string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        public static string actualPath = path.Substring(0, path.LastIndexOf("bin"));
        public static string projectPath = new Uri(actualPath).LocalPath;
        public static string workbookPath = projectPath + "\\TestData\\TestData.xlsx";
        Excel.Application excelApp;
        Excel.Workbook excelWorkbook;
        Excel.Sheets excelSheets;
        Excel.Worksheet excelWorksheet;
        Excel.Range xlRange;

      /// <summary>
      /// Fetching the excel sheet data
      /// </summary>
      /// <param name="sheetName"></param>
      /// <param name="cellAddress"></param>
      /// <returns></returns>

        public  String getExcelData(String sheetName, String cellAddress)
        {

            excelApp = new Excel.Application();
            excelWorkbook = excelApp.Workbooks.Open(workbookPath);

            excelSheets = excelWorkbook.Sheets;

            excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(sheetName);
            xlRange = excelWorksheet.UsedRange;

            //going for map
            //Excel.Range usedRange = excelWorksheet.UsedRange;
            //Excel.Range lastCell = usedRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            //int lastRowNum = lastCell.Row;
            //for(int r=1;r<= lastRowNum; r++)
            //{
            //    for (int c = 1; c <= 2; c++)
            //    {
            //        Excel.Range cell = usedRange.Cells[r, c];//as Excel.Range;
            //        string s=cell.Value.ToString();
            //        //Excel.Range dataBinder1 = (Excel.Range)excelWorksheet.Cells[r, c];
            //       // string myData1 = dataBinder1.Value.ToString();

                   
            //    }
            //}


            //


            Excel.Range dataBinder = (Excel.Range)excelWorksheet.get_Range(cellAddress, cellAddress);

           // Excel.Range dataBinder1 = (Excel.Range)excelWorksheet.Cells[lastCell.Row + 1, 3]; //row // column

            string myData = dataBinder.Value.ToString();
            excelWorkbook.Close();

            excelApp.Quit();

            return myData;

        }




    }
}
