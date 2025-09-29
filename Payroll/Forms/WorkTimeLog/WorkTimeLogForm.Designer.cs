namespace Payroll.Forms
{
    partial class WorkTimeLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkTimeLogForm));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barEditMonth = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barEditYear = new DevExpress.XtraBars.BarEditItem();
            this.repItemComboBoxYear = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barBtnShow = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBandMain = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBandFullName = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBandMonth = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBandTotal = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemComboBoxYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView)).BeginInit();
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
            this.barEditYear,
            this.barStaticItem2,
            this.barBtnShow,
            this.barStaticItem1,
            this.barEditMonth,
            this.barBtnSave});
            this.barManager.MaxItemId = 24;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemComboBoxYear,
            this.repositoryItemLookUpEdit,
            this.repositoryItemComboBox});
            // 
            // bar1
            // 
            this.bar1.BarName = "Сервис";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(2295, 129);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditMonth, "", false, true, true, 84),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditYear, "", false, true, true, 62),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnShow)});
            this.bar1.Text = "Сервис";
            // 
            // barBtnSave
            // 
            this.barBtnSave.Caption = "Сохранить";
            this.barBtnSave.Enabled = false;
            this.barBtnSave.Id = 23;
            this.barBtnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnSave.ImageOptions.Image")));
            this.barBtnSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnSave.ImageOptions.LargeImage")));
            this.barBtnSave.Name = "barBtnSave";
            this.barBtnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSave_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Месяц";
            this.barStaticItem1.Id = 20;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barEditMonth
            // 
            this.barEditMonth.Edit = this.repositoryItemComboBox;
            this.barEditMonth.Id = 21;
            this.barEditMonth.Name = "barEditMonth";
            // 
            // repositoryItemComboBox
            // 
            this.repositoryItemComboBox.AutoHeight = false;
            this.repositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.repositoryItemComboBox.Name = "repositoryItemComboBox";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "Год";
            this.barStaticItem2.Id = 8;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // barEditYear
            // 
            this.barEditYear.Edit = this.repItemComboBoxYear;
            this.barEditYear.Id = 7;
            this.barEditYear.Name = "barEditYear";
            // 
            // repItemComboBoxYear
            // 
            this.repItemComboBoxYear.AutoHeight = false;
            this.repItemComboBoxYear.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemComboBoxYear.Name = "repItemComboBoxYear";
            // 
            // barBtnShow
            // 
            this.barBtnShow.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.barBtnShow.Caption = "Отобразить";
            this.barBtnShow.Id = 10;
            this.barBtnShow.Name = "barBtnShow";
            this.barBtnShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnShow_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1067, 33);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 554);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1067, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 33);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 521);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1067, 33);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 521);
            // 
            // repositoryItemLookUpEdit
            // 
            this.repositoryItemLookUpEdit.AutoHeight = false;
            this.repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit.Name = "repositoryItemLookUpEdit";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl.Location = new System.Drawing.Point(0, 33);
            this.gridControl.MainView = this.bandedGridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl.MenuManager = this.barManager;
            this.gridControl.Name = "gridControl";
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1067, 521);
            this.gridControl.TabIndex = 5;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView});
            // 
            // bandedGridView
            // 
            this.bandedGridView.Appearance.BandPanel.Options.UseTextOptions = true;
            this.bandedGridView.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView.Appearance.BandPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridView.Appearance.BandPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bandedGridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bandedGridView.Appearance.Row.Options.UseFont = true;
            this.bandedGridView.BandPanelRowHeight = 40;
            this.bandedGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBandMain});
            this.bandedGridView.DetailHeight = 431;
            this.bandedGridView.GridControl = this.gridControl;
            this.bandedGridView.Name = "bandedGridView";
            this.bandedGridView.OptionsBehavior.AutoPopulateColumns = false;
            this.bandedGridView.OptionsView.ShowColumnHeaders = false;
            this.bandedGridView.OptionsView.ShowGroupPanel = false;
            this.bandedGridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.bandedGridView_CellValueChanged);
            // 
            // gridBandMain
            // 
            this.gridBandMain.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridBandMain.AppearanceHeader.Options.UseFont = true;
            this.gridBandMain.Caption = "Табель рабочего времени за года";
            this.gridBandMain.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBandFullName,
            this.gridBandMonth,
            this.gridBandTotal});
            this.gridBandMain.Name = "gridBandMain";
            this.gridBandMain.VisibleIndex = 0;
            this.gridBandMain.Width = 286;
            // 
            // gridBandFullName
            // 
            this.gridBandFullName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridBandFullName.AppearanceHeader.Options.UseFont = true;
            this.gridBandFullName.Caption = "ФИО";
            this.gridBandFullName.MinWidth = 13;
            this.gridBandFullName.Name = "gridBandFullName";
            this.gridBandFullName.VisibleIndex = 0;
            this.gridBandFullName.Width = 100;
            // 
            // gridBandMonth
            // 
            this.gridBandMonth.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridBandMonth.AppearanceHeader.Options.UseFont = true;
            this.gridBandMonth.Caption = "Числа месяца";
            this.gridBandMonth.MinWidth = 13;
            this.gridBandMonth.Name = "gridBandMonth";
            this.gridBandMonth.VisibleIndex = 1;
            this.gridBandMonth.Width = 93;
            // 
            // gridBandTotal
            // 
            this.gridBandTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridBandTotal.AppearanceHeader.Options.UseFont = true;
            this.gridBandTotal.Caption = "Итого";
            this.gridBandTotal.MinWidth = 13;
            this.gridBandTotal.Name = "gridBandTotal";
            this.gridBandTotal.VisibleIndex = 2;
            this.gridBandTotal.Width = 93;
            // 
            // WorkTimeLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorkTimeLogForm";
            this.Text = "Табель рабочего времени";
            this.Activated += new System.EventHandler(this.WorkTimeLogForm_Activated);
            this.Load += new System.EventHandler(this.WorkTimeLogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemComboBoxYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView)).EndInit();
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
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarEditItem barEditYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repItemComboBoxYear;
        private DevExpress.XtraBars.BarButtonItem barBtnShow;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem barEditMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox;
        private DevExpress.XtraBars.BarButtonItem barBtnSave;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandMain;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandFullName;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandMonth;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandTotal;
    }
}