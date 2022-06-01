using System;
using System.Windows;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;

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
            string date = DateTime.UtcNow.ToString("dd-MM-yyyy");

            try
            {
                if (File.Exists(filePath))
                {
                    _workbook = _excel.Workbooks.Open(filePath);

                    if (_workbook.Worksheets.OfType<Excel.Worksheet>().FirstOrDefault(ws => ws.Name == date) != null)
                    {
                        Excel.Worksheet _oldWorksheet = _workbook.Sheets[date];
                        _worksheet = (Excel.Worksheet)_excel.Worksheets.Add(Type.Missing, _excel.Worksheets[_excel.Worksheets.Count], 1, Excel.XlSheetType.xlWorksheet);
                        _oldWorksheet.Delete();
                        //MessageBox.Show("Старый лист удалён, создан новый: " + date);
                    }
                    else
                    {
                        _worksheet = (Excel.Worksheet)_excel.Worksheets.Add(Type.Missing, _excel.Worksheets[_excel.Worksheets.Count], 1, Excel.XlSheetType.xlWorksheet);
                        //MessageBox.Show("Создан новый лист: " + date);
                    }
                }
                else
                {
                    _workbook = _excel.Workbooks.Add();
                    _worksheet = (Excel.Worksheet)_workbook.Worksheets.get_Item(1);
                    _filePath = filePath;
                }

                _worksheet.Name = date;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        internal void Merge(int fromRowNum, int fromColumnNum, int ToRowNum, int ToColumnNum)
        {
            _worksheet.Range[_worksheet.Cells[fromRowNum, fromColumnNum], _worksheet.Cells[ToRowNum, ToColumnNum]].Merge();
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
