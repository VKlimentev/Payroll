using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll
{
    public class SalaryCalcPresenter
    {
        private readonly GridControl _gridControl;
        private readonly BandedGridView _bandedGridView;
        private readonly GridBand _gridBandFullName;
        private readonly GridBand _gridBandHoursWorked;
        private readonly GridBand _gridBandSalaryComponents;
        private readonly GridBand _gridBandTotal;

        private static readonly HashSet<string> FixedColumns = new HashSet<string>
        {
            "Employee_Id", "ФИО", "Подразделение", "Отработанные часы", "Итого"
        };

        private static readonly HashSet<string> AutoCalculatedColumns = new HashSet<string>
        {
            "Начисление согласно отработанному времени",
            "Удержание подоходного налога",
            "Начисление премии",
            "Сумма"
        };

        public SalaryCalcPresenter(
            GridControl grid,
            GridBand bandFullName,
            GridBand bandHoursWorked,
            GridBand bandSalaryComponents,
            GridBand bandTotal)
        {
            _gridControl = grid;
            _bandedGridView = grid.MainView as BandedGridView;
            _gridBandFullName = bandFullName;
            _gridBandHoursWorked = bandHoursWorked;
            _gridBandSalaryComponents = bandSalaryComponents;
            _gridBandTotal = bandTotal;

            AddFixedColumns();
        }

        public void DisplayReport(DataTable report)
        {
            _gridControl.DataSource = report;
            AddPaymentColumns(report);

            _bandedGridView.OptionsView.GroupDrawMode = GroupDrawMode.Standard;
            _bandedGridView.Columns["Подразделение"].GroupIndex = 0;
            _bandedGridView.ExpandAllGroups();
        }

        private void AddFixedColumns()
        {
            AddColumn("ФИО", _gridBandFullName);
            AddColumn("Подразделение", _gridBandFullName);
            AddColumn("Отработанные часы", _gridBandHoursWorked);
            AddColumn("Итого", _gridBandTotal);
        }

        private void AddPaymentColumns(DataTable report)
        {
            _gridBandSalaryComponents.Children.Clear();

            GridBand reductionBand = null;

            foreach (DataColumn col in report.Columns)
            {
                string fieldName = col.ColumnName;
                if (FixedColumns.Contains(fieldName))
                {
                    continue;
                }

                var gridCol = _bandedGridView.Columns.AddField(fieldName);
                gridCol.Visible = true;
                gridCol.OptionsColumn.AllowEdit = IsManualEntry(fieldName);


                if (fieldName == "Понижение премии за нарушение трудовой дисциплины")
                {
                    reductionBand = new GridBand { Caption = fieldName };
                    gridCol.Visible = false;
                    reductionBand.Columns.Add(gridCol);
                    continue;
                }

                if (fieldName == "Процент")
                {
                    gridCol.ColumnEdit = CreatePercentEditor();
                    gridCol.AppearanceCell.BackColor = Color.LightGoldenrodYellow;
                }

                if (fieldName == "Процент" || fieldName == "Сумма")
                {
                    if (reductionBand != null)
                    {
                        var redBand = new GridBand { Caption = fieldName };
                        redBand.Columns.Add(gridCol);
                        reductionBand.Children.Add(redBand);
                        continue;
                    }
                }

                if (gridCol.OptionsColumn.AllowEdit)
                {
                    gridCol.AppearanceCell.BackColor = Color.LightGoldenrodYellow;
                }

                var band = new GridBand { Caption = fieldName };
                band.Columns.Add(gridCol);
                _gridBandSalaryComponents.Children.Add(band);
            }

            if (reductionBand.Children.Count > 0)
            {
                _gridBandSalaryComponents.Children.Add(reductionBand);
            }
        }

        private RepositoryItemTextEdit CreatePercentEditor()
        {
            var editor = new RepositoryItemTextEdit
            {
                Mask = { MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric, EditMask = "P2", UseMaskAsDisplayFormat = true }
            };

            editor.Validating += (s, e) =>
            {
                if (s is TextEdit textEdit &&
                    decimal.TryParse(textEdit.Text.Replace("%", "").Trim(), out decimal value) &&
                    (value < 0 || value > 100))
                {
                    e.Cancel = true;
                    MessageBox.Show("Введите значение от 0 до 100%", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            return editor;
        }

        private void AddColumn(string fieldName, GridBand targetBand)
        {
            var col = _bandedGridView.Columns.AddField(fieldName);
            if (fieldName != "Подразделение")
            {
                col.Visible = true;
            }
            col.OptionsColumn.AllowEdit = false;
            targetBand.Columns.Add(col);
        }

        public bool IsPaymentColumn(string columnName) => !FixedColumns.Contains(columnName);

        private bool IsManualEntry(string columnName) => !AutoCalculatedColumns.Contains(columnName);
    }
}
