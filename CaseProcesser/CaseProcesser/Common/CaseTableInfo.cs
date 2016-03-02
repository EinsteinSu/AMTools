using System.Collections.Generic;
using CaseProcesser.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Supeng.Office;

namespace CaseProcesser.Common
{
    public class CaseTableInfo : IExcelTableInfo<Case>
    {
        private readonly IList<Case> _cases;

        public CaseTableInfo(IList<Case> cases)
        {
            _cases = cases;
        }

        public void FillRow(ExcelWorksheet worksheet, int startRow, Case c)
        {
            worksheet.Cells[startRow, 1].Value = c.CRNumber;
            worksheet.Cells[startRow, 1].AddHyperLinkText(c.CaseUrl, c.CRNumber);

            worksheet.Cells[startRow, 2].Value = c.Level.ToString();
            worksheet.Cells[startRow, 2].FillBackgroudColor(c.Level.ToColor());

            worksheet.Cells[startRow, 3].Value = c.Component;
            worksheet.Cells[startRow, 4].Value = c.AMVersion;
            worksheet.Cells[startRow, 5].Value = c.Customer;
            worksheet.Cells[startRow, 6].Value = c.Subject;
            worksheet.Cells[startRow, 7].Value = c.Location;

            worksheet.Cells[startRow, 8].Value = c.Status.ToInternalString();
            //worksheet.Cells[startRow, 8].FillBackgroudColor(c.Status.ToColor());

            worksheet.Cells[startRow, 9].Value = c.InternalStatus.ToString();
            worksheet.Cells[startRow, 9].FillBackgroudColor(c.InternalStatus.ToColor());

            worksheet.Cells[startRow, 10].Value = c.Hotfix.ToExportString();
            if (!string.IsNullOrEmpty(c.Hotfix.BugUrl))
            {
                worksheet.Cells[startRow, 10].AddHyperLinkText(c.Hotfix.BugUrl, c.Hotfix.ToExportString());
            }

            worksheet.Cells[startRow, 11].Value = c.CurrentActivity;
            if (!string.IsNullOrEmpty(c.CurrentActivity))
            {
                worksheet.Cells[startRow, 11].AddComment(c.Activities.ToComments(), "Einstein Su");
            }

            for (var i = 0; i < HeadList.Count; i++)
            {
                worksheet.Cells[startRow, i + 1].FillCellBorder(ExcelBorderStyle.Thin);
            }
        }

        public IList<ExcelTableHead> HeadList
        {
            get
            {
                var list = new List<ExcelTableHead>
                {
                    new ExcelTableHead {HeadText = "Case Id"},
                    new ExcelTableHead {HeadText = "Level"},
                    new ExcelTableHead {HeadText = "Model"},
                    new ExcelTableHead {HeadText = "Version"},
                    new ExcelTableHead {HeadText = "Customer"},
                    new ExcelTableHead {HeadText = "Subject"},
                    new ExcelTableHead {HeadText = "Location"},
                    new ExcelTableHead {HeadText = "R&D Status"},
                    new ExcelTableHead {HeadText = "R&D Internal Status"},
                    new ExcelTableHead {HeadText = "Defect Info"},
                    new ExcelTableHead {HeadText = "Current Activity"}
                };
                return list;
            }
        }

        public IList<Case> Data
        {
            get { return _cases; }
        }
    }
}