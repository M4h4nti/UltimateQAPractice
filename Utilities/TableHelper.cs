using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    public static class TableHelper
    {
        static List<TableDataCollection> _tableDataCollection = new List<TableDataCollection>();

        public static void ReadTable(IWebElement table)
        {
            var columns = table.FindElements(By.TagName("th"));
            var rows = table.FindElements(By.TagName("tr"));
            int rowIndex = 0;
            foreach (var row in rows)
            {
                var columnIndex = 0;
                var columnData = table.FindElements(By.TagName("td"));
                foreach (var columnValue in columnData)
                {
                    _tableDataCollection.Add(new TableDataCollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[columnIndex].Text != " " ?
                            columns[columnIndex].Text : columnIndex.ToString(),
                        ColumnValue = columnValue.Text
                    });
                    columnIndex++;
                }
                rowIndex++;
            }
        }

        public static string ReadCell(string ColumnName,int RowNumber)
        {
            return (from e in _tableDataCollection
                    where e.ColumnName == ColumnName && e.RowNumber == RowNumber
                    select e.ColumnValue).SingleOrDefault();
        }
    }

    public class TableDataCollection
    {
        public int RowNumber { get; set; }

        public string ColumnName { get; set; }

        public string ColumnValue { get; set; }

    }
}
