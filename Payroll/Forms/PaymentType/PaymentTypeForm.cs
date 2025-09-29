using BusinessLogic;
using System;
using System.Windows.Forms;

namespace Payroll.Forms
{
    public partial class PaymentTypeForm : Form
    {
        private readonly PaymentTypeService _paymentTypeService;


        public PaymentTypeForm(PaymentTypeService paymentTypeService)
        {
            InitializeComponent();

            _paymentTypeService = paymentTypeService;
        }

        private void LoadPaymentTypes()
        {
            var paymentTypes = _paymentTypeService.GetAll();
            gridControl.DataSource = paymentTypes;
        }

        private void barBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                PaymentTypeEditForm form = new PaymentTypeEditForm(_paymentTypeService);
                form.ShowDialog();
                LoadPaymentTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении типа оплаты: " + ex.Message);
            }
        }

        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var value = gridView.GetFocusedRowCellValue("Id");
                if (value == null || !int.TryParse(value.ToString(), out int paymentTypeId))
                {
                    MessageBox.Show("Не удалось получить ID типа оплаты для редактирования.");
                    return;
                }

                var paymentType = _paymentTypeService.GetById(paymentTypeId);

                PaymentTypeEditForm form = new PaymentTypeEditForm(_paymentTypeService, paymentType);
                form.ShowDialog();
                LoadPaymentTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании типа оплаты: " + ex.Message);
            }
        }

        private void barBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridView.DataRowCount == 0)
                {
                    return;
                }

                if (MessageBox.Show("Подтвердите удаление", "Внимание", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                var value = gridView.GetFocusedRowCellValue("Id");
                if (value == null || !int.TryParse(value.ToString(), out int paymentTypeId))
                {
                    MessageBox.Show("Не удалось получить ID типа оплаты для удаления.");
                    return;
                }

                _paymentTypeService.Delete(paymentTypeId);

                LoadPaymentTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении типа оплаты: " + ex.Message);
            }
        }

        private void PaymentTypesForm_Activated(object sender, EventArgs e)
        {
            LoadPaymentTypes();
        }
    }
}
