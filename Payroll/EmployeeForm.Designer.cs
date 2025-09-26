namespace Payroll
{
    partial class EmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
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
            this.barBtnEdit,
            this.barBtnDelete,
            this.barBtnAdd});
            this.barManager.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Сервис";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDelete)});
            this.bar1.Text = "Сервис";
            // 
            // barBtnAdd
            // 
            this.barBtnAdd.Caption = "Добавить";
            this.barBtnAdd.Id = 4;
            this.barBtnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnAdd.ImageOptions.Image")));
            this.barBtnAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnAdd.ImageOptions.LargeImage")));
            this.barBtnAdd.Name = "barBtnAdd";
            this.barBtnAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAdd_ItemClick);
            // 
            // barBtnEdit
            // 
            this.barBtnEdit.Caption = "Редактировать";
            this.barBtnEdit.Id = 2;
            this.barBtnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnEdit.ImageOptions.Image")));
            this.barBtnEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnEdit.ImageOptions.LargeImage")));
            this.barBtnEdit.Name = "barBtnEdit";
            this.barBtnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnEdit_ItemClick);
            // 
            // barBtnDelete
            // 
            this.barBtnDelete.Caption = "Удалить";
            this.barBtnDelete.Id = 3;
            this.barBtnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnDelete.ImageOptions.Image")));
            this.barBtnDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnDelete.ImageOptions.LargeImage")));
            this.barBtnDelete.Name = "barBtnDelete";
            this.barBtnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDelete_ItemClick);
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
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colDepartment_Id,
            this.colGender,
            this.colSalary});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ShowFooter = true;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "ФИО";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 0;
            // 
            // colDepartment_Id
            // 
            this.colDepartment_Id.Caption = "Подразделение";
            this.colDepartment_Id.FieldName = "DepartmentName";
            this.colDepartment_Id.Name = "colDepartment_Id";
            this.colDepartment_Id.Visible = true;
            this.colDepartment_Id.VisibleIndex = 1;
            // 
            // colGender
            // 
            this.colGender.Caption = "Пол";
            this.colGender.FieldName = "Gender";
            this.colGender.Name = "colGender";
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 2;
            // 
            // colSalary
            // 
            this.colSalary.Caption = "Оклад";
            this.colSalary.FieldName = "BaseSalary";
            this.colSalary.Name = "colSalary";
            this.colSalary.Visible = true;
            this.colSalary.VisibleIndex = 3;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 31);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(800, 419);
            this.gridControl.TabIndex = 0;
            this.gridControl.UseDisabledStatePainter = false;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "EmployeeForm";
            this.Text = "Справочник работников";
            this.Activated += new System.EventHandler(this.EmployeesForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem barBtnAdd;
        private DevExpress.XtraBars.BarButtonItem barBtnEdit;
        private DevExpress.XtraBars.BarButtonItem barBtnDelete;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colGender;
        private DevExpress.XtraGrid.Columns.GridColumn colSalary;
    }
}