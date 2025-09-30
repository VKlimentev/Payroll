using BusinessLogic;
using Payroll.Utils;
using System;
using System.Data;
using System.Windows.Forms;

namespace Payroll.Forms
{
    public partial class WorkTimeLogForm : Form
    {
        private readonly WorkTimeLogService _workTimeService;
        private readonly WorkScheduleService _workScheduleService;
        private readonly SalaryDetailService _salaryService;
        private readonly WorkTimePresenter _presenter;
        private DataTable _timeTable;
        private SelectedPeriod _period;

        public WorkTimeLogForm(WorkTimeLogService workTimeService, WorkScheduleService workScheduleService, SalaryDetailService salaryService)
        {
            InitializeComponent();
            _workTimeService = workTimeService;
            _workScheduleService = workScheduleService;
            _salaryService = salaryService;
            _presenter = new WorkTimePresenter(gridControl, gridBandFullName, gridBandMonth, gridBandTotal);
        }

        private void UpdateSelectedPeriod()
        {
            int year = int.TryParse(barEditYear.EditValue?.ToString(), out var y) ? y : DateTime.Now.Year;
            string monthName = barEditMonth.EditValue?.ToString();
            int month = MonthHelper.GetMonthNumber(monthName ?? "");

            _period = new SelectedPeriod { Year = year, Month = month };

            var months = _workScheduleService.GetDistinctMonthsForYear(_period.Year);

            repItemComboBoxMonth.Items.Clear();
            foreach (var m in months)
            {
                repItemComboBoxMonth.Items.Add(MonthHelper.GetMonthName(m));
            }
        }

        private void LoadWorkHours()
        {
            if (_period.Year == 0 || _period.Month == 0)
            {
                UpdateSelectedPeriod();
            }

            barEditMonth.EditValue = _period.MonthName;
            barEditYear.EditValue = _period.Year;
            gridBandMain.Caption = $"Табель рабочего времени за {barEditMonth.EditValue} {_period.Year} года";

            _timeTable = _workTimeService.BuildMonthlyWorkTimeTable(_period.Year, _period.Month);
            _presenter.DisplayReport(_timeTable, _period.Year, _period.Month);
        }

        private void barBtnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UpdateSelectedPeriod();
                LoadWorkHours();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при активации формы: {ex.Message}");
            }
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = MessageBox.Show("Сохранить изменения в табеле?", "Подтверждение", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            barBtnSave.Enabled = false;
            if (result == DialogResult.No) { LoadWorkHours(); return; }

            try
            {
                bandedGridView.CloseEditor();
                bandedGridView.UpdateCurrentRow();

                int daysInMonth = DateTime.DaysInMonth(_period.Year, _period.Month);

                foreach (DataRow row in _timeTable.Rows)
                {
                    if (row.RowState == DataRowState.Deleted || row.RowState == DataRowState.Detached)
                    {
                        continue;
                    }

                    int employeeId = Convert.ToInt32(row["Employee_Id"]);

                    for (int day = 1; day <= daysInMonth; day++)
                    {
                        string columnName = day.ToString();
                        if (!_timeTable.Columns.Contains(columnName))
                        {
                            continue;
                        }

                        var cellValue = row[columnName];
                        if (cellValue != DBNull.Value && decimal.TryParse(cellValue.ToString(), out var hours))
                        {
                            var workDate = new DateTime(_period.Year, _period.Month, day);
                            _workTimeService.UpsertWorkTime(employeeId, workDate, hours);
                        }
                    }
                }

                _salaryService.RecalculateForMonth(_period.Year, _period.Month);

                MessageBox.Show("Табель успешно сохранён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWorkHours();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bandedGridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            barBtnSave.Enabled = true;
            if (e.Column.FieldName != "Итого")
            {
                RecalculateTotalForRow(e.RowHandle);
            }
        }

        private void RecalculateTotalForRow(int rowHandle)
        {
            decimal total = 0;
            int daysInMonth = DateTime.DaysInMonth(_period.Year, _period.Month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                string columnName = day.ToString();
                var cellValue = bandedGridView.GetRowCellValue(rowHandle, bandedGridView.Columns[columnName]);

                if (cellValue != null && decimal.TryParse(cellValue.ToString(), out var hours))
                {
                    total += hours;
                }
            }

            bandedGridView.SetRowCellValue(rowHandle, bandedGridView.Columns["Итого"], total);
        }

        private void WorkTimeLogForm_Activated(object sender, EventArgs e)
        {
            try { LoadWorkHours(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void WorkTimeLogForm_Load(object sender, EventArgs e)
        {
            var years = _workScheduleService.GetDistinctYears();

            foreach (var year in years)
            {
                repItemComboBoxYear.Items.Add(year);
            }

            UpdateSelectedPeriod();
            LoadWorkHours();
        }
    }
}