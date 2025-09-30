using BusinessLogic;
using DataAccess.Models;
using Payroll.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Payroll.Forms
{
    public partial class WorkSheduleForm : Form
    {
        private readonly WorkScheduleService _workSheduleService;
        private readonly SalaryDetailService _salaryService;

        private List<WorkSchedule> _schedules;
        private HashSet<WorkSchedule> _modifiedSchedules = new HashSet<WorkSchedule>();
        
        public WorkSheduleForm(WorkScheduleService workSheduleService, SalaryDetailService salaryService)
        {
            InitializeComponent();
            _workSheduleService = workSheduleService;
            _salaryService = salaryService;
        }

        private void LoadWorkSchedule()
        {
            _schedules = _workSheduleService.GetAll();
            gridControl.DataSource = _schedules;
            _modifiedSchedules.Clear();
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = MessageBox.Show("Сохранить изменения в графике?", "Подтверждение", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            barBtnSave.Enabled = false;
            if (result == DialogResult.No)
            {
                LoadWorkSchedule();
                return;
            }

            try
            {
                gridView.CloseEditor();
                gridView.UpdateCurrentRow();

                foreach (var sched in _schedules)
                {
                    if (sched.Id == 0)
                    {
                        _workSheduleService.Add(sched);
                        _salaryService.RecalculateForMonth(sched.Year, sched.Month);
                    }
                    else if (_modifiedSchedules.Contains(sched))
                    {
                        _workSheduleService.Update(sched);
                        _salaryService.RecalculateForMonth(sched.Year, sched.Month); 
                    }
                }

                MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWorkSchedule();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddCurrentMonthRowIfMissing()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            bool exists = _schedules.Any(s => s.Month == currentMonth && s.Year == currentYear);

            if (exists)
            {
                return;
            }
            var newSchedule = new WorkSchedule
            {
                Month = currentMonth,
                Year = currentYear,
                StandardHours = 0,
                BonusPercent = 0,
                TaxPercent = 0
            };

            _workSheduleService.Add(newSchedule);
            LoadWorkSchedule();
        }


        private void monthEditor_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (int.TryParse(e.Value?.ToString(), out int month))
            {
                e.DisplayText = MonthHelper.GetMonthName(month);
            }
        }
        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            barBtnSave.Enabled = true;

            var sched = gridView.GetRow(e.RowHandle) as WorkSchedule;

            if (sched != null && sched.Id != 0)
            {
                _modifiedSchedules.Add(sched);
            }
        }


        private void EmployeesForm_Activated(object sender, EventArgs e)
        {
            try
            {
                LoadWorkSchedule();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }
        private void WorkSheduleForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadWorkSchedule();
                AddCurrentMonthRowIfMissing();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }
    }
}
