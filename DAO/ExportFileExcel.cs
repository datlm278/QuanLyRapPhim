using QuanLyRapChieuPhim.UI.frmAdminUserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.DAO
{
    public class ExportFileExcel
    {
        public static void export_excel (DataGridView dataGrid, string file_name)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            Microsoft.Office.Interop.Excel.Sheets worksheets;
            Microsoft.Office.Interop.Excel.Workbooks workbooks;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbooks = excel.Workbooks;

                workbook = (excel.Workbooks.Add(Type.Missing));

                worksheets = workbook.Worksheets;
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)worksheets.get_Item(1);

                worksheet.Name = "doanh thu";

                Microsoft.Office.Interop.Excel.Range head = worksheet.get_Range("A1", "E2");
                head.MergeCells = true;
                head.Value2 = "BÁO CÁO DOANH THU";
                head.Font.Bold = true;
                head.Font.Name = "Times New Roman";
                head.Font.Size = "20";
                head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range c1 = worksheet.get_Range("A3", "A3");
                c1.Value2 = "Tên phim";
                c1.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range c2 = worksheet.get_Range("B3", "B3");
                c2.Value2 = "Ngày chiếu";
                c2.ColumnWidth = 25;

                Microsoft.Office.Interop.Excel.Range c3 = worksheet.get_Range("C3", "C3");
                c3.Value2 = "Giờ chiếu";
                c3.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range c4 = worksheet.get_Range("D3", "D3");
                c4.Value2 = "Số vé đã bán";
                c4.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range c5 = worksheet.get_Range("E3", "E3");
                c5.Value2 = "Tiền vé";
                c5.ColumnWidth = 20;

                int cellsum = 4 + dataGrid.Rows.Count;

                Microsoft.Office.Interop.Excel.Range sum = worksheet.get_Range($"A{cellsum}", $"A{cellsum}");
                sum.Value2 = "Tổng doanh thu:";
                sum.Font.Bold = true;
                sum.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range total = worksheet.get_Range($"E{cellsum}", $"E{cellsum}");
                total.Value2 = RevenueUC.doanhthu;
                total.Font.Bold = true;

                Microsoft.Office.Interop.Excel.Range rowHead = worksheet.get_Range("A3", "E3");
                rowHead.Font.Bold = true;

                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                rowHead.Interior.ColorIndex = 6;
                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                

                // export header
                for (int i = 0; i < dataGrid.ColumnCount; i++)
                {
                    worksheet.Cells[3, i + 1] = dataGrid.Columns[i].HeaderText;
                }

                // export content
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    for (int j = 0; j < dataGrid.ColumnCount; j++)
                    {
                        if (j == 1)
                        {
                            DateTime ngayChieu;
                            if(DateTime.TryParse(dataGrid.Rows[i].Cells[j].Value.ToString(), out ngayChieu))
                            {
                                worksheet.Cells[i + 4, j + 1] = ngayChieu.ToString("dd/MM/yyyy");
                            }
                        }
                        else
                        {
                            worksheet.Cells[i + 4, j + 1] = dataGrid.Rows[i].Cells[j].Value.ToString();
                        }                       
                    }
                }

                Microsoft.Office.Interop.Excel.Range col1 = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[4, 1];
                Microsoft.Office.Interop.Excel.Range col2 = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[4 + dataGrid.RowCount, dataGrid.ColumnCount];

                Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(col1, col2);
                worksheet.get_Range(col1, col2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                // save workbook
                workbook.SaveAs(file_name);
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Đã tạo file excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
    }
}
