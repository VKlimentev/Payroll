using BusinessLogic;
using System;
using System.Windows.Forms;

namespace Payroll
{
    public partial class EmployeeForm : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;

        public EmployeeForm(EmployeeService employeeService, DepartmentService departmentService)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        private void LoadEmployees()
        {
            var employees = _employeeService.GetAll();
            gridControl.DataSource = employees;
        }

        private void barBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                EmployeeEditForm form = new EmployeeEditForm(_employeeService, _departmentService);
                form.ShowDialog();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении сотрудника: " + ex.Message);
            }
        }

        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var value = gridView.GetFocusedRowCellValue("Id");
                if (value == null || !int.TryParse(value.ToString(), out int employeeId))
                {
                    MessageBox.Show("Не удалось получить ID сотрудника для редактирования.");
                    return;
                }

                var employee = _employeeService.GetById(employeeId);

                EmployeeEditForm form = new EmployeeEditForm(_employeeService, _departmentService, employee);
                form.ShowDialog();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании сотрудника: " + ex.Message);
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
                if (value == null || !int.TryParse(value.ToString(), out int employeeId))
                {
                    MessageBox.Show("Не удалось получить ID сотрудника для удаления.");
                    return;
                }

                _employeeService.Delete(employeeId);

                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении сотрудника: " + ex.Message);
            }
        }

        private void EmployeesForm_Activated(object sender, EventArgs e)
        {
            LoadEmployees();
        }



        /*private readonly string _connectionString = ConfigurationManager.ConnectionStrings["PayrollConnection"].ConnectionString;
        private DataTable _employeesTable = new DataTable();
        private DataTable _departmentsTable = new DataTable();

        public EmployeesForm()
        {
            InitializeComponent();

            try
            {
                Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при активации формы: " + ex.Message);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM Employees";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    _employeesTable.Clear();
                    adapter.Fill(_employeesTable);
                    gridControl.DataSource = _employeesTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке сотрудников: " + ex.Message);
            }
        }

        private void LoadDepartments()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM Departments";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    _departmentsTable.Clear();
                    adapter.Fill(_departmentsTable);

                    RepositoryItemLookUpEdit departmentEditor = new RepositoryItemLookUpEdit
                    {
                        DataSource = _departmentsTable,
                        DisplayMember = "DepartmentName",
                        ValueMember = "Id"
                    };

                    gridView.Columns["Department_Id"].ColumnEdit = departmentEditor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке подразделений: " + ex.Message);
            }
        }

        private void barBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                EditEmployeeForm form = new EditEmployeeForm();
                form.ShowDialog();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении сотрудника: " + ex.Message);
            }
        }

        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var value = gridView.GetFocusedRowCellValue("Id");
                if (value == null || !int.TryParse(value.ToString(), out int employeeId))
                {
                    MessageBox.Show("Не удалось получить ID сотрудника для редактирования.");
                    return;
                }

                EditEmployeeForm form = new EditEmployeeForm(employeeId, true);
                form.ShowDialog();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании сотрудника: " + ex.Message);
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
                if (value == null || !int.TryParse(value.ToString(), out int employeeId))
                {
                    MessageBox.Show("Не удалось получить ID сотрудника для удаления.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Employees WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", employeeId);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Сотрудник удалён.");
                    }
                    else
                    {
                        MessageBox.Show("Сотрудник не найден.");
                    }
                }

                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении сотрудника: " + ex.Message);
            }
        }

        private void EmployeesForm_Activated(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadDepartments();
        }*/
    }
}
