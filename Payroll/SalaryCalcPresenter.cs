using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Drawing;

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

        public SalaryCalcPresenter(
            GridControl grid, 
            GridBand bandFullName, 
            GridBand bandHoursWorked, 
            GridBand bandSalaryComponents, 
            GridBand bandTotal
            )
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

            foreach (DataColumn col in report.Columns)
            {
                if (IsPaymentColumn(col.Caption))
                {
                    var gridCol = _bandedGridView.Columns.AddField(col.ColumnName);
                    gridCol.OptionsColumn.AllowEdit = false;
                    gridCol.Visible = true;

                    if (!IsFormulaCalc(gridCol.FieldName))
                    {
                        gridCol.OptionsColumn.AllowEdit = true;

                        gridCol.AppearanceCell.BackColor = Color.LightGoldenrodYellow;
                    }

                    var band = new GridBand { Caption = col.ColumnName };
                    band.Columns.Add(gridCol);
                    _gridBandSalaryComponents.Children.Add(band);
                }
            }
        }

        private void AddColumn(string fieldName, GridBand targetBand)
        {
            var col = _bandedGridView.Columns.AddField(fieldName);
            col.OptionsColumn.AllowEdit = false;
            if (col.FieldName != "Подразделение")
            {
                col.Visible = true;
            }
            targetBand.Columns.Add(col);
        }
        private bool IsPaymentColumn(string columnName)
        {
            return columnName != "Employee_Id" &&
                   columnName != "ФИО" &&
                   columnName != "Подразделение" &&
                   columnName != "Отработанные часы" &&
                   columnName != "Итого";
        }
        private bool IsFormulaCalc(string columnName)
        {
            return columnName == "Начисление согласно отработанному времени" ||
                   columnName == "Удержание подоходного налога" ||
                   columnName == "Начисление премии";
        }
    }

}
