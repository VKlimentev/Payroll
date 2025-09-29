using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using Microsoft.Extensions.DependencyInjection;
using Payroll.Reports;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Payroll.Forms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _provider;

        public MainForm(IServiceProvider provider)
        {
            InitializeComponent();

            _provider = provider;
        }


        private bool IsFormActivated(Form form)
        {
            if (MdiChildren.Count() > 0)
            {
                foreach (var child in MdiChildren)
                {
                    if (form.Name == child.Name)
                    {
                        xtraTabbedMdiManager.Pages[child].MdiChild.Activate();
                        return true;
                    }
                }
            }

            return false;
        }
        private void ViewChildForm(Form childform)
        {
            if (IsFormActivated(childform))
            {
                return;
            }

            childform.MdiParent = this;
            childform.Show();
        }


        private void barBtnWorkShedule_ItemClick(object sender, ItemClickEventArgs e)
        {
            WorkSheduleForm childForm = _provider.GetRequiredService<WorkSheduleForm>();
            ViewChildForm(childForm);
        }
        private void barBtnWorkTimeLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            WorkTimeLogForm childForm = _provider.GetRequiredService<WorkTimeLogForm>();
            ViewChildForm(childForm);
        }
        private void barBtnSalaryCalc_ItemClick(object sender, ItemClickEventArgs e)
        {
            SalaryCalcForm childForm = _provider.GetRequiredService<SalaryCalcForm>();
            ViewChildForm(childForm);
        }


        private void barBtnEmployees_ItemClick(object sender, ItemClickEventArgs e)
        {
            EmployeeForm childForm = _provider.GetRequiredService<EmployeeForm>();
            ViewChildForm(childForm);
        }
        private void barBtnDepartaments_ItemClick(object sender, ItemClickEventArgs e)
        {
            DepartmentForm childForm = _provider.GetRequiredService<DepartmentForm>();
            ViewChildForm(childForm);
        }
        private void barBtnPaymentTypes_ItemClick(object sender, ItemClickEventArgs e)
        {
            PaymentTypeForm childForm = _provider.GetRequiredService<PaymentTypeForm>();
            ViewChildForm(childForm);
        }


        private void barBtnDepReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var report = new DepartmentReport();
            var title = "Отчет по подразделениям";
            ViewReport(report, title);
        }
        private void barBtnYearReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var report = new EmployeeYearReport();
            var title = "Годовой отчет";
            ViewReport(report, title);
        }
        private void barBtnPayslipReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var report = new PayslipReport();
            var title = "Расчетный листок";
            ViewReport(report, title);
        }

        private void ViewReport(XtraReport report, string title)
        {
            var reportForm = ActivatorUtilities.CreateInstance<ReportForm>(_provider, report, title);
            ViewChildForm(reportForm);
        }
    }
}
