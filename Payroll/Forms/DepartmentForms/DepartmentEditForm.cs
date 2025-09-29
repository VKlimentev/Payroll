using BusinessLogic;
using DataAccess.Models;
using System;
using System.Windows.Forms;

namespace Payroll.Forms
{
    public partial class DepartmentEditForm : Form
    {
        private readonly DepartmentService _departmentService;
        private readonly Department _department;

        public DepartmentEditForm(DepartmentService departmentService, Department department = null)
        {
            InitializeComponent();

            _departmentService = departmentService;
            _department = department ?? new Department();
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

                _department.DepartmentName = txtName.Text;

                if (_department.Id == 0)
                {
                    _departmentService.Add(_department);
                }
                else
                {
                    _departmentService.Update(_department);
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

        private void DepartmentEditForm_Load(object sender, EventArgs e)
        {
            if (_department.Id != 0)
            {
                txtName.Text = _department.DepartmentName;
            }
        }
    }
}
