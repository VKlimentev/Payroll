using DevExpress.XtraReports.UI;
using System;

namespace Payroll.Reports
{
    public partial class EmployeeYearReport : XtraReport
    {
        public EmployeeYearReport()
        {
            InitializeComponent();

            DateTime today = DateTime.Now;

            Parameters["year"].Value = today.Year;
        }
    }
}
