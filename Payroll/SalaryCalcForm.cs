using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Payroll
{
    public partial class SalaryCalcForm : Form
    {
        private readonly SalaryDetailService _reportService;
        private readonly WorkTimeLogService _workTimeService;
        private readonly SalaryCalculationService _salaryCalcService;

        private SalaryCalcPresenter _presenter;

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

        public SalaryCalcForm(SalaryDetailService reportService, WorkTimeLogService workTimeService, SalaryCalculationService salaryCalcService)
        {
            InitializeComponent();
            _reportService = reportService;
            _workTimeService = workTimeService;
            _salaryCalcService = salaryCalcService;
            _presenter = new SalaryCalcPresenter(
                gridControl,
                gridBandFullName,
                gridBandHoursWorked,
                gridBandSalaryComponents,
                gridBandTotal);
        }

        private void LoadWorkHours(int year = 0, int month = 0)
        {
            if (month == 0)
            {
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;
            }

            barEditMonth.EditValue = months.FirstOrDefault(x => x.Value == month).Key;
            barEditYear.EditValue = year;
            gridBandMain.Caption = $"Расчет заработной платы за {barEditMonth.EditValue} {year} года";

            var report = _reportService.BuildSalaryReport(year, month);
            _presenter.DisplayReport(report);
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

            if (result == DialogResult.No)
            {
                barBtnShow_ItemClick(sender, e);
                return;
            }

            try
            {
                int year = int.Parse(barEditYear.EditValue?.ToString());
                string monthName = barEditMonth.EditValue?.ToString();
                months.TryGetValue(monthName, out int monthNumber);

                _salaryCalcService.RecalculateForMonth(year, monthNumber);

                MessageBox.Show("Табель успешно сохранён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                barBtnSave.Enabled = false;
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

            
                /*string columnName = day.ToString();
                var cellValue = bandedGridView.GetRowCellValue(rowHandle, bandedGridView.Columns[columnName]);

                if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal hours))
                {
                    total += hours;
                }*/

            bandedGridView.SetRowCellValue(rowHandle, bandedGridView.Columns["Итого"], total);
        }

        private void SalaryCalcForm_Activated(object sender, EventArgs e)
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

        private void SalaryCalcForm_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Today.Year; i >= 2000; i--)
            {
                repItemComboBoxYear.Items.Add(i);
            }

            LoadWorkHours();
        }
    }
}
