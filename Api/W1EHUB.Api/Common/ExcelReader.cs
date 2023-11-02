using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace W1EHUB.Api.Common
{
    public class ExcelReader
    {
        public static Dictionary<string, object> ReadExcelFile(string filePath, List<Dictionary<int, string>> sheetTemplates)
        {
            var jsonData = new Dictionary<string, object>();

            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(file);

                // Loop on Sheets
                for (int sheetIndex = 0; sheetIndex < workbook.NumberOfSheets; sheetIndex++)
                {
                    // If Template not found
                    if (sheetTemplates.Count < sheetIndex + 1) break;
                    
                    ISheet sheet = workbook.GetSheetAt(sheetIndex);
                    var template = sheetTemplates[sheetIndex];
                    
                    var sheetJsonData = new List<Dictionary<string, string>>();
                    // Loop on Rows
                    for (int row = 1; row <= sheet.LastRowNum; row++)
                    {
                        IRow rowData = sheet.GetRow(row);
                        if(rowData == null ) continue;

                        var rowJsonData = new Dictionary<string, string>();
                        for (int cellndex = 0; cellndex < rowData.Cells.Count(); cellndex++)
                        {
                            var cell = rowData.GetCell(cellndex);
                            if (cell is not null && template.ContainsKey(cellndex))
                            {
                                switch (cell.CellType)
                                {
                                    case CellType.Numeric:
                                        rowJsonData[template[cellndex]] = cell.NumericCellValue.ToString();
                                        break;
                                    case CellType.String:
                                        rowJsonData[template[cellndex]] = cell.StringCellValue;
                                        break;
                                    default:
                                        rowJsonData[template[cellndex]] = string.Empty;
                                        break;
                                }

                            }
                        }

                        sheetJsonData.Add(rowJsonData);
                    }
                    jsonData[sheet.SheetName] = sheetJsonData;
                }

            }

            return jsonData;
        }
    }
}
