using System;
using System.Windows;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace AchieveNow.ProgramClasses
{
    public class ExcelContext : IDisposable
    {
        private Excel.Application _excel;
        private Excel.Workbook _workbook;
        private Excel.Worksheet _worksheet;
        private string _filePath;

        public ExcelContext()
        {
            _excel = new Excel.Application();
        }

        internal bool Open(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    _workbook = _excel.Workbooks.Open(filePath);
                }
                else
                {
                    _workbook = _excel.Workbooks.Add();
                    _filePath = filePath;
                }

                _worksheet = (Excel.Worksheet)_workbook.Worksheets.get_Item(1);

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        internal void Save()
        {
            if (!string.IsNullOrEmpty(_filePath))
            {
                _workbook.SaveAs(_filePath);
                _filePath = null;
            }
            else
            {
                _workbook.Save();
            }
        }

        internal bool Set(string column, int row, object data, int size = 12, bool isBold = false, bool isCenter = false, bool isRight = false, int columnWidth = 0)
        {
            try
            {
                _excel.ActiveCell.Cells[row, column].Font.Size = size;
                _excel.ActiveCell.Cells[row, column].Font.Bold = isBold;
                _excel.ActiveCell.Cells[row, column].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                if (isCenter)
                    _excel.ActiveCell.Cells[row, column].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                else if (isRight)
                    _excel.ActiveCell.Cells[row, column].HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                if (columnWidth > 0)
                {
                    ((Excel.Range)_worksheet.Cells[row, column]).EntireColumn.ColumnWidth = columnWidth;
                }

                ((Excel.Worksheet)_excel.ActiveSheet).Cells[row, column] = data;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }

            return false;
        }

        public void Dispose()
        {
            try
            {
                _workbook.Close();
                _excel.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
