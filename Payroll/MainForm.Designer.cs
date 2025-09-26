namespace Payroll
{
    partial class MainForm
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
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenu = new DevExpress.XtraBars.Bar();
            this.barBtnMenu = new DevExpress.XtraBars.BarSubItem();
            this.barBtnWorkShedule = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnWorkTimeLog = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSalaryCalc = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDirectory = new DevExpress.XtraBars.BarSubItem();
            this.barBtnEmployees = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDepartaments = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPaymentTypes = new DevExpress.XtraBars.BarButtonItem();
            this.barReports = new DevExpress.XtraBars.BarSubItem();
            this.barBtnDepReport = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnYearReport = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPayslipReport = new DevExpress.XtraBars.BarButtonItem();
            this.bar = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.mainMenu,
            this.bar});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnDirectory,
            this.barBtnEmployees,
            this.barBtnDepartaments,
            this.barBtnMenu,
            this.barReports,
            this.barBtnPaymentTypes,
            this.barBtnDepReport,
            this.barBtnYearReport,
            this.barBtnPayslipReport,
            this.barBtnWorkShedule,
            this.barBtnWorkTimeLog,
            this.barBtnSalaryCalc});
            this.barManager.MainMenu = this.mainMenu;
            this.barManager.MaxItemId = 15;
            this.barManager.StatusBar = this.bar;
            // 
            // mainMenu
            // 
            this.mainMenu.BarName = "Главное меню";
            this.mainMenu.DockCol = 0;
            this.mainMenu.DockRow = 0;
            this.mainMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.mainMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDirectory),
            new DevExpress.XtraBars.LinkPersistInfo(this.barReports)});
            this.mainMenu.OptionsBar.MultiLine = true;
            this.mainMenu.OptionsBar.UseWholeRow = true;
            this.mainMenu.Text = "Главное меню";
            // 
            // barBtnMenu
            // 
            this.barBtnMenu.Caption = "Главная";
            this.barBtnMenu.Id = 6;
            this.barBtnMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnWorkShedule),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnWorkTimeLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSalaryCalc)});
            this.barBtnMenu.Name = "barBtnMenu";
            // 
            // barBtnWorkShedule
            // 
            this.barBtnWorkShedule.Caption = "График работы";
            this.barBtnWorkShedule.Id = 12;
            this.barBtnWorkShedule.Name = "barBtnWorkShedule";
            this.barBtnWorkShedule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnWorkShedule_ItemClick);
            // 
            // barBtnWorkTimeLog
            // 
            this.barBtnWorkTimeLog.Caption = "Учет времени";
            this.barBtnWorkTimeLog.Id = 13;
            this.barBtnWorkTimeLog.Name = "barBtnWorkTimeLog";
            this.barBtnWorkTimeLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnWorkTimeLog_ItemClick);
            // 
            // barBtnSalaryCalc
            // 
            this.barBtnSalaryCalc.Caption = "Расчет зарплаты";
            this.barBtnSalaryCalc.Id = 14;
            this.barBtnSalaryCalc.Name = "barBtnSalaryCalc";
            this.barBtnSalaryCalc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSalaryCalc_ItemClick);
            // 
            // barBtnDirectory
            // 
            this.barBtnDirectory.Caption = "Справочники";
            this.barBtnDirectory.Id = 1;
            this.barBtnDirectory.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnEmployees),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDepartaments),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPaymentTypes)});
            this.barBtnDirectory.Name = "barBtnDirectory";
            // 
            // barBtnEmployees
            // 
            this.barBtnEmployees.Caption = "Работники";
            this.barBtnEmployees.Id = 2;
            this.barBtnEmployees.Name = "barBtnEmployees";
            this.barBtnEmployees.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnEmployees_ItemClick);
            // 
            // barBtnDepartaments
            // 
            this.barBtnDepartaments.Caption = "Подразделения";
            this.barBtnDepartaments.Id = 3;
            this.barBtnDepartaments.Name = "barBtnDepartaments";
            this.barBtnDepartaments.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDepartaments_ItemClick);
            // 
            // barBtnPaymentTypes
            // 
            this.barBtnPaymentTypes.Caption = "Виды оплат";
            this.barBtnPaymentTypes.Id = 8;
            this.barBtnPaymentTypes.Name = "barBtnPaymentTypes";
            this.barBtnPaymentTypes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnPaymentTypes_ItemClick);
            // 
            // barReports
            // 
            this.barReports.Caption = "Отчёты";
            this.barReports.Id = 7;
            this.barReports.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDepReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnYearReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPayslipReport)});
            this.barReports.Name = "barReports";
            // 
            // barBtnDepReport
            // 
            this.barBtnDepReport.Caption = "По начислению з/п за месяц по подразделениям";
            this.barBtnDepReport.Id = 9;
            this.barBtnDepReport.Name = "barBtnDepReport";
            this.barBtnDepReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDepReport_ItemClick);
            // 
            // barBtnYearReport
            // 
            this.barBtnYearReport.Caption = "Справка по з/п работника за год";
            this.barBtnYearReport.Id = 10;
            this.barBtnYearReport.Name = "barBtnYearReport";
            this.barBtnYearReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnYearReport_ItemClick);
            // 
            // barBtnPayslipReport
            // 
            this.barBtnPayslipReport.Caption = "Расчетный листок работника";
            this.barBtnPayslipReport.Id = 11;
            this.barBtnPayslipReport.Name = "barBtnPayslipReport";
            this.barBtnPayslipReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnPayslipReport_ItemClick);
            // 
            // bar
            // 
            this.bar.BarName = "Строка состояния";
            this.bar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar.OptionsBar.AllowQuickCustomization = false;
            this.bar.OptionsBar.DrawDragBorder = false;
            this.bar.OptionsBar.UseWholeRow = true;
            this.bar.Text = "Строка состояния";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(800, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 427);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 405);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 22);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 405);
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчет заработной платы";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar mainMenu;
        private DevExpress.XtraBars.Bar bar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barBtnDirectory;
        private DevExpress.XtraBars.BarButtonItem barBtnEmployees;
        private DevExpress.XtraBars.BarButtonItem barBtnDepartaments;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraBars.BarSubItem barBtnMenu;
        private DevExpress.XtraBars.BarButtonItem barBtnWorkShedule;
        private DevExpress.XtraBars.BarButtonItem barBtnWorkTimeLog;
        private DevExpress.XtraBars.BarButtonItem barBtnSalaryCalc;
        private DevExpress.XtraBars.BarButtonItem barBtnPaymentTypes;
        private DevExpress.XtraBars.BarSubItem barReports;
        private DevExpress.XtraBars.BarButtonItem barBtnDepReport;
        private DevExpress.XtraBars.BarButtonItem barBtnYearReport;
        private DevExpress.XtraBars.BarButtonItem barBtnPayslipReport;
    }
}