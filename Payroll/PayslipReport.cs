using DevExpress.XtraReports.UI;
using System;

namespace Payroll
{
    public partial class PayslipReport : XtraReport
    {
        public PayslipReport()
        {
            InitializeComponent();

            DateTime today = DateTime.Now;

            Parameters["month"].Value = today.Month;
            Parameters["year"].Value = today.Year;
        }
    }
}
