namespace Payroll.Forms
{
    partial class WorkSheduleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkSheduleForm));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.monthEditor = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBonusPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnSave});
            this.barManager.MaxItemId = 7;
            // 
            // bar1
            // 
            this.bar1.BarName = "Сервис";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSave)});
            this.bar1.Text = "Сервис";
            // 
            // barBtnSave
            // 
            this.barBtnSave.Caption = "Сохранить";
            this.barBtnSave.Enabled = false;
            this.barBtnSave.Id = 5;
            this.barBtnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnSave.ImageOptions.Image")));
            this.barBtnSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnSave.ImageOptions.LargeImage")));
            this.barBtnSave.Name = "barBtnSave";
            this.barBtnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSave_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(800, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 419);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 31);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 419);
            // 
            // monthEditor
            // 
            this.monthEditor.AutoHeight = false;
            this.monthEditor.Name = "monthEditor";
            this.monthEditor.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.monthEditor_CustomDisplayText);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colMonth,
            this.colYear,
            this.colStandardHours,
            this.colBonusPercent,
            this.colTaxPercent});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colMonth
            // 
            this.colMonth.Caption = "Месяц";
            this.colMonth.ColumnEdit = this.monthEditor;
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.OptionsColumn.AllowEdit = false;
            this.colMonth.Visible = true;
            this.colMonth.VisibleIndex = 0;
            // 
            // colYear
            // 
            this.colYear.Caption = "Год";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowEdit = false;
            this.colYear.Visible = true;
            this.colYear.VisibleIndex = 1;
            // 
            // colStandardHours
            // 
            this.colStandardHours.AppearanceCell.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.colStandardHours.AppearanceCell.Options.UseBackColor = true;
            this.colStandardHours.Caption = "Общее кол-во часов";
            this.colStandardHours.FieldName = "StandardHours";
            this.colStandardHours.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("colStandardHours.ImageOptions.Image")));
            this.colStandardHours.Name = "colStandardHours";
            this.colStandardHours.ToolTip = "Редактируемое поле: введите общее количество часов работы в данном месяце";
            this.colStandardHours.Visible = true;
            this.colStandardHours.VisibleIndex = 2;
            // 
            // colBonusPercent
            // 
            this.colBonusPercent.AppearanceCell.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.colBonusPercent.AppearanceCell.Options.UseBackColor = true;
            this.colBonusPercent.Caption = "Процент премии";
            this.colBonusPercent.FieldName = "BonusPercent";
            this.colBonusPercent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("colBonusPercent.ImageOptions.Image")));
            this.colBonusPercent.Name = "colBonusPercent";
            this.colBonusPercent.ToolTip = "Редактируемое поле: введите процент премии";
            this.colBonusPercent.Visible = true;
            this.colBonusPercent.VisibleIndex = 3;
            // 
            // colTaxPercent
            // 
            this.colTaxPercent.AppearanceCell.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.colTaxPercent.AppearanceCell.Options.UseBackColor = true;
            this.colTaxPercent.Caption = "Процент подоходного налога";
            this.colTaxPercent.FieldName = "TaxPercent";
            this.colTaxPercent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("colTaxPercent.ImageOptions.Image")));
            this.colTaxPercent.Name = "colTaxPercent";
            this.colTaxPercent.ToolTip = "Редактируемое поле: введите процент подоходного надлога";
            this.colTaxPercent.Visible = true;
            this.colTaxPercent.VisibleIndex = 4;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 31);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.monthEditor});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(800, 419);
            this.gridControl.TabIndex = 0;
            this.gridControl.UseDisabledStatePainter = false;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // WorkSheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "WorkSheduleForm";
            this.Text = "График работы";
            this.Activated += new System.EventHandler(this.EmployeesForm_Activated);
            this.Load += new System.EventHandler(this.WorkSheduleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit monthEditor;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardHours;
        private DevExpress.XtraGrid.Columns.GridColumn colBonusPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxPercent;
        private DevExpress.XtraBars.BarButtonItem barBtnSave;
    }
}