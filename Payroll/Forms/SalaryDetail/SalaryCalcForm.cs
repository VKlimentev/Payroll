using BusinessLogic;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using Payroll.Utils;
using System;
using System.Data;
using System.Windows.Forms;

namespace Payroll.Forms
{
    public partial class SalaryCalcForm : Form
    {
        private readonly SalaryDetailService _salaryService;
        private readonly WorkTimeLogService _workTimeService;
        private readonly SalaryCalcPresenter _presenter;
        private DataTable _salaryTable;
        private SelectedPeriod _period;


        public SalaryCalcForm(SalaryDetailService salaryService, WorkTimeLogService workTimeService)
        {
            InitializeComponent();
            _salaryService = salaryService;
            _workTimeService = workTimeService;
            _presenter = new SalaryCalcPresenter(gridControl, gridBandFullName, gridBandHoursWorked, gridBandSalaryComponents, gridBandTotal);
        }


        private void UpdateSelectedPeriod()
        {
            int year = int.TryParse(barEditYear.EditValue?.ToString(), out var y) ? y : DateTime.Now.Year;
            string monthName = barEditMonth.EditValue?.ToString();
            int month = MonthHelper.GetMonthNumber(monthName ?? "");

            _period = new SelectedPeriod { Year = year, Month = month };
        }
        private void LoadWorkHours()
        {
            barEditMonth.EditValue = _period.MonthName;
            barEditYear.EditValue = _period.Year;
            gridBandMain.Caption = $"Расчет заработной платы за {barEditMonth.EditValue} {_period.Year} года";

            _salaryTable = _salaryService.BuildSalaryReport(_period.Year, _period.Month);
            _presenter.DisplayReport(_salaryTable);
        }


        private void barBtnShow_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                UpdateSelectedPeriod();
                LoadWorkHours();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при активации формы: " + ex.Message);
            }
        }
        private void barBtnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            var result = MessageBox.Show("Сохранить изменения в табеле?", "Подтверждение", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            if (result == DialogResult.No) { LoadWorkHours(); return; }

            try
            {
                bandedGridView.CloseEditor();
                bandedGridView.UpdateCurrentRow();

                SaveSalaryDetails();
                _salaryService.RecalculateForMonth(_period.Year, _period.Month);

                MessageBox.Show("Табель успешно сохранён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                barBtnSave.Enabled = false;
                LoadWorkHours();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bandedGridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            barBtnSave.Enabled = true;

            if (e.Column.FieldName == "Итого")
            {
                return;
            }

            if (e.Column.FieldName == "Процент")
            {
                var row = bandedGridView.GetDataRow(e.RowHandle);
                if (row == null)
                {
                    return;
                }

                if (decimal.TryParse(row[e.Column.FieldName]?.ToString(), out decimal percent) &&
                    decimal.TryParse(row["Начисление премии"]?.ToString(), out decimal bonus))
                {
                    var reduction = Math.Round(bonus * percent / 100, 2);
                    bandedGridView.SetRowCellValue(e.RowHandle, bandedGridView.Columns["Понижение премии за нарушение трудовой дисциплины"], reduction);
                    bandedGridView.SetRowCellValue(e.RowHandle, bandedGridView.Columns["Сумма"], reduction);
                }
            }

            RecalculateTotalForRow(e.RowHandle);
        }

        private void SaveSalaryDetails()
        {
            foreach (DataRow row in _salaryTable.Rows)
            {
                if (row.RowState == DataRowState.Deleted || row.RowState == DataRowState.Detached)
                {
                    continue;
                }

                int employeeId = Convert.ToInt32(row["Employee_Id"]);
                int scheduleId = _salaryService.GetScheduleIdForEmployee(employeeId, _period.Year, _period.Month);

                foreach (DataColumn col in _salaryTable.Columns)
                {
                    string columnName = col.ColumnName;
                    if (columnName == "Процент" || columnName == "Сумма")
                    {
                        continue;
                    }

                    if (_presenter.IsPaymentColumn(columnName) &&
                        decimal.TryParse(row[columnName]?.ToString(), out decimal amount))
                    {
                        int paymentTypeId = _salaryService.GetPaymentTypeIdByName(columnName);
                        _salaryService.UpsertSalaryDetail(employeeId, scheduleId, paymentTypeId, amount);
                    }
                }
            }
        }

        private void RecalculateTotalForRow(int rowHandle)
        {
            var row = bandedGridView.GetDataRow(rowHandle);
            if (row == null)
            {
                return;
            }

            decimal accruals = 0, deductions = 0;

            foreach (DataColumn col in _salaryTable.Columns)
            {
                string columnName = col.ColumnName;
                if (!_presenter.IsPaymentColumn(columnName))
                {
                    continue;
                }

                if (decimal.TryParse(row[columnName]?.ToString(), out decimal amount))
                {
                    string category = _salaryService.GetPaymentCategoryByName(columnName);
                    if (category == "Начисление")
                    {
                        accruals += amount;
                    }
                    else if (category == "Удержание")
                    {
                        deductions += amount;
                    }
                }
            }

            bandedGridView.SetRowCellValue(rowHandle, bandedGridView.Columns["Итого"], accruals - deductions);
        }

        private void SalaryCalcForm_Activated(object sender, EventArgs e) => LoadWorkHours();

        private void SalaryCalcForm_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Today.Year; i >= 2000; i--)
            {
                repItemComboBoxYear.Items.Add(i);
            }

            UpdateSelectedPeriod();
            LoadWorkHours();
        }
    }
}
