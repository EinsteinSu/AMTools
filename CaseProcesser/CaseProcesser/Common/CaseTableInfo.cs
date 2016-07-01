using System.Collections.Generic;
using System.Drawing;
using CaseProcesser.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Supeng.Office;

namespace CaseProcesser.Common
{
    public class CaseTableInfo : IExcelTableInfo<Case>
    {
        public CaseTableInfo(IList<Case> cases)
        {
            Data = cases;
        }

        public void FillRow(ExcelWorksheet worksheet, int startRow, Case c)
        {
            worksheet.Cells[startRow, 1].Value = c.CRNumber;
            worksheet.Cells[startRow, 1].AddHyperLinkText(c.CaseUrl, c.CRNumber);

            worksheet.Cells[startRow, 2].Value = c.Level.ToString();
            worksheet.Cells[startRow, 2].FillBackgroudColor(c.Level.ToColor());

            worksheet.Cells[startRow, 3].Value = c.InternalStatus;
            worksheet.Cells[startRow, 3].FillBackgroudColor(c.InternalStatus.ToColor());

            worksheet.Cells[startRow, 4].Value = c.Status;
            worksheet.Cells[startRow, 5].Value = c.Component;
            worksheet.Cells[startRow, 6].Value = c.AMVersion;
            worksheet.Cells[startRow, 7].Value = c.Customer;
            worksheet.Cells[startRow, 8].Value = c.Subject;

            worksheet.Cells[startRow, 9].Value = c.Hotfix.ToExportString();
            if (!string.IsNullOrEmpty(c.Hotfix.BugUrl))
            {
                worksheet.Cells[startRow, 9].AddHyperLinkText(c.Hotfix.BugUrl, c.Hotfix.ToExportString());
            }

            worksheet.Cells[startRow, 10].Value = c.CurrentActivity;
            if (!string.IsNullOrEmpty(c.CurrentActivity))
            {
                worksheet.Cells[startRow, 10].AddComment(c.Activities.ToComments(), "Sue Su");
            }

            worksheet.Cells[startRow, 12].Value = c.Location;
            worksheet.Cells[startRow, 13].Value = c.Owner;

            for (var i = 0; i < HeadList.Count; i++)
            {
                worksheet.Cells[startRow, i + 1].FillCellBorder(ExcelBorderStyle.Thin);
                if (c.Status == CaseStatus.Closed)
                {
                    worksheet.Cells[startRow, i + 1].FillBackgroudColor(Color.LimeGreen);
                }
            }
        }

        public IList<ExcelTableHead> HeadList
        {
            get
            {
                var list = new List<ExcelTableHead>
                {
                    new ExcelTableHead {HeadText = "SR"},
                    new ExcelTableHead {HeadText = "Level"},
                    new ExcelTableHead {HeadText = "R&D Status"},
                    new ExcelTableHead {HeadText = "Siebel Status"},
                    new ExcelTableHead {HeadText = "Module"},
                    new ExcelTableHead {HeadText = "Version"},
                    new ExcelTableHead {HeadText = "Customer"},
                    new ExcelTableHead {HeadText = "Subject"},
                    new ExcelTableHead {HeadText = "Defect Info"},
                    new ExcelTableHead {HeadText = "Current Activity"},
                    new ExcelTableHead {HeadText = "Support Updates"},
                    new ExcelTableHead {HeadText = "Location"},
                    new ExcelTableHead {HeadText = "Owner"}
                };
                return list;
            }
        }

        public IList<Case> Data { get; }
    }
}