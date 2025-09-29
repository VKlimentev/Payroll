using BusinessLogic;
using DataAccess.Models;
using System;
using System.Windows.Forms;

namespace Payroll.Forms
{
    public partial class PaymentTypeEditForm : Form
    {
        private readonly PaymentTypeService _paymentTypeService;
        private readonly PaymentType _paymentType;

        public PaymentTypeEditForm(PaymentTypeService paymentTypeService, PaymentType paymentType = null)
        {
            InitializeComponent();

            _paymentTypeService = paymentTypeService;
            _paymentType = paymentType ?? new PaymentType();
        }

        private void dtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider.Validate())
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                _paymentType.PaymentTypeName = memoName.Text;
                _paymentType.PaymentCategory = comboBoxType.Text;

                if (_paymentType.Id == 0)
                {
                    _paymentTypeService.Add(_paymentType);
                }
                else
                {
                    _paymentTypeService.Update(_paymentType);
                }

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при закрытии формы: " + ex.Message);
            }
        }

        private void PaymentTypeEditForm_Load(object sender, EventArgs e)
        {
            if (_paymentType.Id != 0)
            {
                memoName.Text = _paymentType.PaymentTypeName;
                comboBoxType.SelectedIndex = _paymentType.PaymentCategory == "Начисление" ? 0 : 1;
            }
        }
    }
}
