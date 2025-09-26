using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace Payroll
{
    public partial class WorkTimeLogForm : Form
    {
        private readonly WorkTimeLogService _workTimeService;
        private readonly SalaryCalculationService _salaryCalcService;
        private WorkTimePresenter _presenter;

        private DataTable _timeTable;

        private Dictionary<string, int> months = new Dictionary<string, int>
        {
            { "Январь", 1 },
            { "Февраль", 2 },
            { "Март", 3 },
            { "Апрель", 4 },
            { "Май", 5 },
            { "Июнь", 6 },
            { "Июль", 7 },
            { "Август", 8 },
            { "Сентябрь", 9 },
            { "Октябрь", 10 },
            { "Ноябрь", 11 },
            { "Декабрь", 12 }
        };

        public WorkTimeLogForm(WorkTimeLogService workTimeService, SalaryCalculationService salaryCalcService)
        {
            InitializeComponent();
            _workTimeService = workTimeService;
            _salaryCalcService = salaryCalcService;
            _presenter = new WorkTimePresenter(gridControl, gridBandFullName, gridBandMonth, gridBandTotal);
        }

        private void LoadWorkHours(int year = 0, int month = 0)
        {
            if (month == 0)
            {
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;
            }

            barEditMonth.EditValue = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetMonthName(month);
            barEditYear.EditValue = year;
            gridBandMain.Caption = $"Табель рабочего времени за {barEditMonth.EditValue} {year} года";

            _timeTable = _workTimeService.BuildMonthlyWorkTimeTable(year, month);
            _presenter.DisplayReport(_timeTable, year, month);
        }

        private void barBtnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int year = int.Parse(barEditYear.EditValue?.ToString());
                string month = barEditMonth.EditValue?.ToString();
                months.TryGetValue(month, out int monthNumber);

                LoadWorkHours(year, monthNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при активации формы: " + ex.Message);
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
            if (result == DialogResult.No)
            {
                LoadWorkHours();
                return;
            }

            try
            {
                bandedGridView.CloseEditor();
                bandedGridView.UpdateCurrentRow();

                int year = int.Parse(barEditYear.EditValue?.ToString());
                string monthName = barEditMonth.EditValue?.ToString();
                months.TryGetValue(monthName, out int monthNumber);
                int daysInMonth = DateTime.DaysInMonth(year, monthNumber);

                foreach (DataRow row in _timeTable.Rows)
                {
                    if (row.RowState == DataRowState.Deleted || row.RowState == DataRowState.Detached)
                        continue;

                    int employeeId = Convert.ToInt32(row["Employee_Id"]);

                    for (int day = 1; day <= daysInMonth; day++)
                    {
                        string columnName = day.ToString();
                        if (!_timeTable.Columns.Contains(columnName))
                            continue;

                        var cellValue = row[columnName];
                        if (cellValue != DBNull.Value && decimal.TryParse(cellValue.ToString(), out decimal hours))
                        {
                            DateTime workDate = new DateTime(year, monthNumber, day);
                            _workTimeService.UpsertWorkTime(employeeId, workDate, hours);
                        }
                    }
                }

                _salaryCalcService.RecalculateForMonth(year, monthNumber);

                MessageBox.Show("Табель успешно сохранён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWorkHours(year, monthNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bandedGridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            barBtnSave.Enabled = true;

            if (e.Column.FieldName == "Итого")
            {
                return;
            }

            RecalculateTotalForRow(e.RowHandle);
        }

        private void RecalculateTotalForRow(int rowHandle)
        {
            decimal total = 0;

            int year = int.Parse(barEditYear.EditValue?.ToString());
            string monthName = barEditMonth.EditValue?.ToString();
            months.TryGetValue(monthName, out int monthNumber);

            int daysInMonth = DateTime.DaysInMonth(year, monthNumber);

            for (int day = 1; day <= daysInMonth; day++)
            {
                string columnName = day.ToString();
                var cellValue = bandedGridView.GetRowCellValue(rowHandle, bandedGridView.Columns[columnName]);

                if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal hours))
                {
                    total += hours;
                }
            }

            bandedGridView.SetRowCellValue(rowHandle, bandedGridView.Columns["Итого"], total);
        }

        private void WorkTimeLogForm_Activated(object sender, EventArgs e)
        {
            try
            {
                LoadWorkHours();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void WorkTimeLogForm_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Today.Year; i >= 2000; i--)
            {
                repItemComboBoxYear.Items.Add(i);
            }

            LoadWorkHours();
        }
    }
}