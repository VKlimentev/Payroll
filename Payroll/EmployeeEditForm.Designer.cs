namespace Payroll
{
    partial class EmployeeEditForm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxGender = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spinSalary = new DevExpress.XtraEditors.SpinEdit();
            this.lookUpDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(106, 3);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(194, 20);
            this.txtFullName.TabIndex = 2;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Поле обязательное для заполнения";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.dxValidationProvider.SetValidationRule(this.txtFullName, conditionValidationRule1);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "ФИО";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Подразделение";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 29);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(19, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Пол";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(3, 81);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(33, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Оклад";
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.Location = new System.Drawing.Point(106, 29);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxGender.Properties.Items.AddRange(new object[] {
            "М",
            "Ж"});
            this.comboBoxGender.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxGender.Size = new System.Drawing.Size(51, 20);
            this.comboBoxGender.TabIndex = 7;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Выберите пол";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.dxValidationProvider.SetValidationRule(this.comboBoxGender, conditionValidationRule2);
            // 
            // spinSalary
            // 
            this.spinSalary.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinSalary.Location = new System.Drawing.Point(106, 81);
            this.spinSalary.Name = "spinSalary";
            this.spinSalary.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinSalary.Properties.DisplayFormat.FormatString = "f2";
            this.spinSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinSalary.Properties.EditFormat.FormatString = "f2";
            this.spinSalary.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinSalary.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.spinSalary.Size = new System.Drawing.Size(88, 20);
            this.spinSalary.TabIndex = 8;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule3.ErrorText = "Оклад не может быть нулевым";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            conditionValidationRule3.Value1 = "0,00";
            this.dxValidationProvider.SetValidationRule(this.spinSalary, conditionValidationRule3);
            // 
            // lookUpDepartment
            // 
            this.lookUpDepartment.Location = new System.Drawing.Point(106, 55);
            this.lookUpDepartment.Name = "lookUpDepartment";
            this.lookUpDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDepartment.Properties.NullText = "";
            this.lookUpDepartment.Properties.ShowFooter = false;
            this.lookUpDepartment.Properties.ShowHeader = false;
            this.lookUpDepartment.Size = new System.Drawing.Size(140, 20);
            this.lookUpDepartment.TabIndex = 9;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "Выберите подразделение";
            conditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.dxValidationProvider.SetValidationRule(this.lookUpDepartment, conditionValidationRule4);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66F));
            this.tableLayoutPanel.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.spinSalary, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.labelControl3, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.labelControl2, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.comboBoxGender, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelControl4, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.txtFullName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lookUpDepartment, 1, 2);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(303, 104);
            this.tableLayoutPanel.TabIndex = 10;
            // 
            // dtnOK
            // 
            this.dtnOK.Location = new System.Drawing.Point(3, 3);
            this.dtnOK.Name = "dtnOK";
            this.dtnOK.Size = new System.Drawing.Size(75, 21);
            this.dtnOK.TabIndex = 0;
            this.dtnOK.Text = "ОК";
            this.dtnOK.Click += new System.EventHandler(this.dtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(154, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dtnOK, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(46, 131);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(232, 27);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // EmployeeEditForm
            // 
            this.AcceptButton = this.dtnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(323, 170);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление нового работника";
            this.Load += new System.EventHandler(this.EmployeeEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxGender;
        private DevExpress.XtraEditors.SpinEdit spinSalary;
        private DevExpress.XtraEditors.LookUpEdit lookUpDepartment;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private DevExpress.XtraEditors.SimpleButton dtnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}