using BusinessLogic;
using DataAccess;
using DataAccess.Repositories;
using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddScoped<EmployeeRepository>();
            services.AddScoped<DepartmentRepository>();
            services.AddScoped<PaymentTypeRepository>();
            services.AddScoped<WorkScheduleRepository>();
            services.AddScoped<WorkTimeLogRepository>();
            services.AddScoped<SalaryDetailsRepository>();

            services.AddScoped<EmployeeService>();
            services.AddScoped<DepartmentService>();
            services.AddScoped<PaymentTypeService>();
            services.AddScoped<WorkScheduleService>();
            services.AddScoped<WorkTimeLogService>();
            services.AddScoped<SalaryDetailService>();
            services.AddScoped<SalaryCalculationService>();

            services.AddTransient<MainForm>();
            services.AddTransient<EmployeeForm>();
            services.AddTransient<EmployeeEditForm>();
            services.AddTransient<DepartmentForm>();
            services.AddTransient<DepartmentEditForm>();
            services.AddTransient<PaymentTypeForm>();
            services.AddTransient<PaymentTypeEditForm>();
            services.AddTransient<WorkTimeLogForm>();
            services.AddTransient<WorkSheduleForm>();
            services.AddTransient<SalaryCalcForm>();
            services.AddTransient<ReportForm>();

            var provider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(provider.GetRequiredService<MainForm>());
        }
    }
}
