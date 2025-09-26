using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;

namespace Payroll
{
    public class WorkTimePresenter
    {
        private readonly GridControl gridControl;
        private readonly BandedGridView bandedGridView;
        private readonly GridBand gridBandFullName;
        private readonly GridBand gridBandMonth;
        private readonly GridBand gridBandTotal;

        public WorkTimePresenter(GridControl grid, GridBand bandFullName, GridBand bandMonth, GridBand bandTotal)
        {
            gridControl = grid;
            bandedGridView = grid.MainView as BandedGridView;
            gridBandFullName = bandFullName;
            gridBandMonth = bandMonth;
            gridBandTotal = bandTotal;

            AddFixedColumns();
            AddTotalColumn();
        }

        public void DisplayReport(DataTable report, int year, int month)
        {
            gridControl.DataSource = report;

            AddDayColumns(year, month);

            bandedGridView.OptionsView.GroupDrawMode = GroupDrawMode.Standard;
            bandedGridView.Columns["Подразделение"].GroupIndex = 0;
            bandedGridView.ExpandAllGroups();
            bandedGridView.BestFitColumns();
        }

        private void AddFixedColumns()
        {
            AddColumn("ФИО", gridBandFullName);
            AddColumn("Подразделение", gridBandFullName);
        }

        private void AddDayColumns(int year, int month)
        {
            gridBandMonth.Children.Clear();

            int daysInMonth = DateTime.DaysInMonth(year, month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                string fieldName = day.ToString();
                DateTime date = new DateTime(year, month, day);
                string dayOfWeek = date.ToString("ddd", new CultureInfo("ru-RU"));

                var col = bandedGridView.Columns.AddField(fieldName);
                col.Visible = true;

                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    //col.OptionsColumn.AllowEdit = false;
                    col.AppearanceCell.BackColor = Color.LightCoral;
                    col.AppearanceCell.Options.UseBackColor = true;
                }

                var bandDay = new GridBand
                {
                    Caption = $"{day}{Environment.NewLine}{dayOfWeek}"
                };

                bandDay.Columns.Add(col);
                gridBandMonth.Children.Add(bandDay);
            }
        }

        private void AddTotalColumn()
        {
            var colTotal = bandedGridView.Columns.AddField("Итого");
            colTotal.Visible = true;
            gridBandTotal.Columns.Add(colTotal);
        }

        private void AddColumn(string fieldName, GridBand targetBand)
        {
            var col = bandedGridView.Columns.AddField(fieldName);
            if (col.FieldName != "Подразделение")
            {
                col.Visible = true;
            }
            targetBand.Columns.Add(col);
        }
    }

}
