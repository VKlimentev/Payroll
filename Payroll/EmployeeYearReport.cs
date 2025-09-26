using DevExpress.XtraReports.UI;
using NPetrovichLite;
using System;

namespace Payroll
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
