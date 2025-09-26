namespace Payroll
{
    partial class PaymentTypeEditForm
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
            this.dtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.memoName = new DevExpress.XtraEditors.MemoEdit();
            this.comboBoxType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtnOK
            // 
            this.dtnOK.Location = new System.Drawing.Point(52, 126);
            this.dtnOK.Name = "dtnOK";
            this.dtnOK.Size = new System.Drawing.Size(75, 23);
            this.dtnOK.TabIndex = 0;
            this.dtnOK.Text = "ОК";
            this.dtnOK.Click += new System.EventHandler(this.dtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(179, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Название";
            // 
            // memoName
            // 
            this.memoName.EditValue = "";
            this.memoName.Location = new System.Drawing.Point(66, 12);
            this.memoName.Name = "memoName";
            this.memoName.Size = new System.Drawing.Size(219, 69);
            this.memoName.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Название не должно быть пустым";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.dxValidationProvider.SetValidationRule(this.memoName, conditionValidationRule1);
            // 
            // comboBoxType
            // 
            this.comboBoxType.EditValue = "";
            this.comboBoxType.Location = new System.Drawing.Point(66, 87);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxType.Properties.Items.AddRange(new object[] {
            "Начисление",
            "Удержание"});
            this.comboBoxType.Size = new System.Drawing.Size(84, 20);
            this.comboBoxType.TabIndex = 6;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Выберите тип";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.dxValidationProvider.SetValidationRule(this.comboBoxType, conditionValidationRule2);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Тип";
            // 
            // PaymentTypeEditForm
            // 
            this.AcceptButton = this.dtnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(300, 167);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtnOK);
            this.Controls.Add(this.memoName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PaymentTypeEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление нового вида оплаты";
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton dtnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        private DevExpress.XtraEditors.MemoEdit memoName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxType;
    }
}