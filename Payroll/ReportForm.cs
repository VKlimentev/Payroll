using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Payroll
{
    public partial class ReportForm : Form
    {
        public ReportForm(XtraReport report, string title = "Отчёт")
        {
            InitializeComponent();

            Text = title;
            Name = report.GetType().ToString();
            documentViewer.DocumentSource = report;
        }
    }
}
