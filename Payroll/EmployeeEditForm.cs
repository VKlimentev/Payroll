using BusinessLogic;
using DataAccess.Models;
using DevExpress.XtraEditors.Controls;
using System;
using System.Windows.Forms;

namespace Payroll
{
    public partial class EmployeeEditForm : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private readonly Employee _employee;

        public EmployeeEditForm(EmployeeService employeeService, DepartmentService departmentService, Employee employee = null)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _departmentService = departmentService;
            _employee = employee ?? new Employee();
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

                if (lookUpDepartment.EditValue == null || !int.TryParse(lookUpDepartment.EditValue.ToString(), out int departmentId))
                {
                    MessageBox.Show("Некорректное подразделение.");
                    return;
                }

                _employee.FullName = txtFullName.Text;
                _employee.Gender = comboBoxGender.SelectedItem?.ToString();
                _employee.DepartmentId = departmentId;
                _employee.BaseSalary = spinSalary.Value;

                bool success = _employee.Id == 0
                    ? _employeeService.Add(_employee)
                    : _employeeService.Update(_employee);

                if (success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка: проверьте введённые данные.");
                }
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

        private void EmployeeEditForm_Load(object sender, EventArgs e)
        {
            lookUpDepartment.Properties.DataSource = _departmentService.GetAll();
            lookUpDepartment.Properties.DisplayMember = "DepartmentName";
            lookUpDepartment.Properties.ValueMember = "Id";

            lookUpDepartment.Properties.Columns.Clear();
            lookUpDepartment.Properties.Columns.Add(new LookUpColumnInfo("DepartmentName", "Подразделение"));

            if (_employee.Id != 0)
            {
                txtFullName.Text = _employee.FullName;
                comboBoxGender.SelectedItem = _employee.Gender;
                lookUpDepartment.EditValue = _employee.DepartmentId;
                spinSalary.Value = _employee.BaseSalary;
            }
        }
    }
}
