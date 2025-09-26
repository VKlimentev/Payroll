using BusinessLogic;
using DataAccess.Models;
using System;
using System.Windows.Forms;

namespace Payroll
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

                _paymentType.PaymentCategory = memoName.Text;
                _paymentType.PaymentTypeName = comboBoxType.Text;

                if (_paymentType.Id == 0)
                {
                    _paymentTypeService.Add(_paymentType);
                }
                else
                {
                    _paymentTypeService.Update(_paymentType);
                }

                /*
                bool success = _department.Id == 0
                             ? _departmentService.Add(_department)
                             : _departmentService.Update(_department);
                             */

                //if (success)

                DialogResult = DialogResult.OK;
                Close();

                //MessageBox.Show("Ошибка: проверьте введённые данные.");

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
    }
}
