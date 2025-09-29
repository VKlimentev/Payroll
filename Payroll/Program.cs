using BusinessLogic;
using DataAccess;
using DataAccess.Repositories;
using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Payroll.Forms;

namespace Payroll
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var services = new ServiceCollection();

            var connectionString = ConfigurationManager.ConnectionStrings["PayrollConnection"].ConnectionString;

            services.AddSingleton(new DbManager(connectionString));

            services.AddScoped<DepartmentRepository>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<PaymentTypeRepository>();
            services.AddScoped<SalaryDetailsRepository>();
            services.AddScoped<WorkScheduleRepository>();
            services.AddScoped<WorkTimeLogRepository>();

            services.AddScoped<DepartmentService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<PaymentTypeService>();
            services.AddScoped<SalaryDetailService>();
            services.AddScoped<WorkScheduleService>();
            services.AddScoped<WorkTimeLogService>();

            services.AddTransient<MainForm>();
            services.AddTransient<DepartmentForm>();
            services.AddTransient<DepartmentEditForm>();
            services.AddTransient<EmployeeForm>();
            services.AddTransient<EmployeeEditForm>();
            services.AddTransient<PaymentTypeForm>();
            services.AddTransient<PaymentTypeEditForm>();
            services.AddTransient<ReportForm>();
            services.AddTransient<SalaryCalcForm>();
            services.AddTransient<WorkSheduleForm>();
            services.AddTransient<WorkTimeLogForm>();

            var provider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(provider.GetRequiredService<MainForm>());
        }
    }
}
