using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace TestFramework
{
    static class DataFromExcelFile
    {
        private static Excel.Application excelApp = new Excel.Application();
        private static Excel._Worksheet workSheet = new Excel.Worksheet();

        public static List<JournalModel> GetDataFromExcelFile()
        {
            List<JournalModel> outputData = new List<JournalModel>();
            NavigationModel navModel;
            JournalModel jourModel;

            var workBook = excelApp.Workbooks.Open(TestData.ExcelFilePath);

            for (int journalCount = 1; journalCount <= workBook.Sheets.Count; journalCount++)
            {
                workSheet = workBook.Sheets[journalCount];
                jourModel.JournalCode = workSheet.Name;
                List<NavigationModel> nav = new List<NavigationModel>();
                
                for (int col = 1; col <= 5; col++)
                {
                    string category = GetValue(2, col);
                    bool flag = false;
                    for (int row = 3; row < 26; row++)
                    {
                        if (category == "")
                        {
                            break;
                        }
                        if (GetValue(row, col) != "")
                        {
                            navModel.Item = GetValue(row, col);
                            navModel.Category = category;
                            nav.Add(navModel);
                            flag = true;
                        }
                        else
                        {
                            if (!flag)
                            {
                                navModel.Item = null;
                                navModel.Category = category;
                                nav.Add(navModel);
                                break;
                            }
                        }
                    }
                }
                jourModel.Navigation = nav;
                outputData.Add(jourModel);
            }

            CloseExcelApp();

            return outputData;
        }

        private static void GetWorkSheets()
        {
            excelApp.Visible = false;

            var workBook = excelApp.Workbooks.Open(TestData.ExcelFilePath);
            var workSheets = workBook.Worksheets;
        }

        private static void CloseExcelApp()
        {
            excelApp.Quit();
            excelApp = null;
        }

        private static string GetValue(int row, int col)
        {
            string cellValue = "";
            Excel.Range cell = (Excel.Range)workSheet.Cells[row, col];
            if (cell.Value != null)
            {
                cellValue = Convert.ToString(cell.Value);
            }
            return cellValue;
        }
    }
}
