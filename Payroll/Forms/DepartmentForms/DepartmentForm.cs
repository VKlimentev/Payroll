using BusinessLogic;
using DataAccess.Models;
using System;
using System.Windows.Forms;

namespace Payroll.Forms
{
    public partial class DepartmentForm : Form
    {
        private readonly DepartmentService _departmentService;


        public DepartmentForm(DepartmentService departmentService)
        {
            InitializeComponent();
            _departmentService = departmentService;
        }

        private void LoadDepartments()
        {
            var departments = _departmentService.GetAll();
            gridControl.DataSource = departments;
        }

        private void barBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DepartmentEditForm form = new DepartmentEditForm(_departmentService);
                form.ShowDialog();
                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении подразделения: " + ex.Message);
            }
        }

        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var value = gridView.GetFocusedRowCellValue("Id");
                if (value == null || !int.TryParse(value.ToString(), out int departmentId))
                {
                    MessageBox.Show("Не удалось получить ID подразделения для редактирования.");
                    return;
                }

                var department = _departmentService.GetById(departmentId);

                DepartmentEditForm form = new DepartmentEditForm(_departmentService, department);
                form.ShowDialog();
                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании подразделения: " + ex.Message);
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
                if (value == null || !int.TryParse(value.ToString(), out int departmentId))
                {
                    MessageBox.Show("Не удалось получить ID подразделения для удаления.");
                    return;
                }

                _departmentService.Delete(departmentId);

                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении подразделения: " + ex.Message);
            }
        }

        private void DepartmentsForm_Activated(object sender, EventArgs e)
        {
            LoadDepartments();
        }
    }
}
