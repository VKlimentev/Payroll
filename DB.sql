CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100) NOT NULL
);

CREATE TABLE PaymentTypes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PaymentTypeName NVARCHAR(100) NOT NULL,
    PaymentCategory NVARCHAR(20) NOT NULL CHECK (PaymentCategory IN ('Начисление', 'Удержание'))
);

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(150) NOT NULL,
    Department_Id INT NOT NULL,
    Gender NVARCHAR(1) CHECK (Gender IN ('М', 'Ж')),
    BaseSalary DECIMAL(10,2) NOT NULL CHECK (BaseSalary >= 0),
    FOREIGN KEY (Department_Id) REFERENCES Departments(Id)
);

CREATE TABLE WorkTimeLog (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Employee_Id INT NOT NULL,
    WorkDate DATE NOT NULL,
    HoursWorked DECIMAL(4,2) NOT NULL CHECK (HoursWorked >= 0),
    FOREIGN KEY (Employee_Id) REFERENCES Employees(Id)
);

CREATE TABLE WorkSchedule (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Month INT NOT NULL CHECK (Month BETWEEN 1 AND 12),
    Year INT NOT NULL CHECK (Year >= 2000),
    StandardHours DECIMAL(5,2) NOT NULL DEFAULT 0,
    BonusPercent DECIMAL(5,2) NOT NULL DEFAULT 0 CHECK (BonusPercent >= 0),
    TaxPercent DECIMAL(5,2) NOT NULL DEFAULT 0 CHECK (TaxPercent >= 0),
);

CREATE TABLE SalaryDetails (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Employee_Id INT NOT NULL,
    Schedule_Id INT NOT NULL,
    PaymentType_Id INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL CHECK (Amount >= 0),
    FOREIGN KEY (Employee_Id) REFERENCES Employees(Id),
    FOREIGN KEY (Schedule_Id) REFERENCES WorkSchedule(Id),
    FOREIGN KEY (PaymentType_Id) REFERENCES PaymentTypes(Id)
);

CREATE INDEX IX_Employees_Department_Id ON Employees(Department_Id);
CREATE INDEX IX_WorkTimeLog_EmployeeID ON WorkTimeLog(Employee_Id);
CREATE INDEX IX_SalaryDetails_EmployeeID ON SalaryDetails(Employee_Id);
CREATE INDEX IX_SalaryDetails_ScheduleID ON SalaryDetails(Schedule_Id);
CREATE INDEX IX_SalaryDetails_PaymentTypeID ON SalaryDetails(PaymentType_Id);


CREATE PROCEDURE CalculateSalary
    @EmployeeId INT,
    @Month INT,
    @Year INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @BaseSalary DECIMAL(10,2);
    DECLARE @StandardHours DECIMAL(5,2);
    DECLARE @BonusPercent DECIMAL(5,2);
    DECLARE @TaxPercent DECIMAL(5,2);
    DECLARE @HoursWorked DECIMAL(10,2);
    DECLARE @ScheduleId INT;

    -- Получаем базовую зарплату работника
    SELECT @BaseSalary = BaseSalary
    FROM Employees
    WHERE Id = @EmployeeId;

    -- Получаем график работы
    SELECT @ScheduleId = Id,
           @StandardHours = StandardHours,
           @BonusPercent = BonusPercent,
           @TaxPercent = TaxPercent
    FROM WorkSchedule
    WHERE Month = @Month AND Year = @Year;

    -- Считаем общее количество отработанных часов
    SELECT @HoursWorked = ISNULL(SUM(HoursWorked), 0)
    FROM WorkTimeLog
    WHERE Employee_Id = @EmployeeId
      AND MONTH(WorkDate) = @Month
      AND YEAR(WorkDate) = @Year;

    -- Удаляем старые записи SalaryDetails для этого месяца
    DELETE FROM SalaryDetails
    WHERE Employee_Id = @EmployeeId AND Schedule_Id = @ScheduleId;

    -- Начисление согласно отработанному времени
    DECLARE @BasePayment DECIMAL(10,2) = 
        ROUND(@BaseSalary * (@HoursWorked / NULLIF(@StandardHours, 0)), 2);

    -- Удержание подоходного налога налог
    DECLARE @TaxDeduction DECIMAL(10,2) = 
        ROUND(@BasePayment * (@TaxPercent / 100), 2);

    -- Начисление премии
    DECLARE @BonusPayment DECIMAL(10,2) = 
        ROUND(@BasePayment * (@BonusPercent / 100), 2);


    -- Получаем ID типов выплат
    DECLARE @BasePaymentTypeId INT, 
			@TaxPaymentTypeId INT, 
			@BonusPaymentTypeId INT;

    SELECT @BasePaymentTypeId = Id FROM PaymentTypes WHERE PaymentTypeName = 'Начисление согласно отработанному времени';
    SELECT @TaxPaymentTypeId = Id FROM PaymentTypes WHERE PaymentTypeName = 'Удержание подоходного налога';
    SELECT @BonusPaymentTypeId = Id FROM PaymentTypes WHERE PaymentTypeName = 'Начисление премии';

    -- Добавляем записи
    INSERT INTO SalaryDetails (Employee_Id, Schedule_Id, PaymentType_Id, Amount)
    VALUES (@EmployeeId, @ScheduleId, @BasePaymentTypeId, @BasePayment),
           (@EmployeeId, @ScheduleId, @BonusPaymentTypeId, @BonusPayment);

    INSERT INTO SalaryDetails (Employee_Id, Schedule_Id, PaymentType_Id, Amount)
    VALUES (@EmployeeId, @ScheduleId, @TaxPaymentTypeId, @TaxDeduction);
END;


CREATE VIEW SalarySummary AS
SELECT 
	e.Id,
    e.FullName,
	ws.Id AS ScheduleId,
    ws.Month,
    ws.Year,
    ws.StandardHours,
    (
        SELECT SUM(HoursWorked)
        FROM WorkTimeLog wtl
        WHERE wtl.Employee_Id = e.Id
          AND MONTH(wtl.WorkDate) = ws.Month
          AND YEAR(wtl.WorkDate) = ws.Year
    ) AS TotalWorkedHours,
    (
        SELECT STRING_AGG(pt.PaymentTypeName + ': ' + FORMAT(sd.Amount, 'N2'), ', ')
        FROM SalaryDetails sd
        JOIN PaymentTypes pt ON pt.Id = sd.PaymentType_Id
        WHERE sd.Employee_Id = e.Id AND sd.Schedule_Id = ws.Id
    ) AS PaymentBreakdown
FROM Employees e
JOIN SalaryDetails sd ON sd.Employee_Id = e.Id
JOIN WorkSchedule ws ON ws.Id = sd.Schedule_Id
GROUP BY e.Id, e.FullName, ws.Id, ws.Month, ws.Year, ws.StandardHours;




INSERT INTO Departments (DepartmentName) VALUES
(N'Бухгалтерия'),
(N'Отдел кадров'),
(N'ИТ'),
(N'Производство');

INSERT INTO PaymentTypes (PaymentTypeName, PaymentCategory) VALUES
(N'Начисление согласно отработанному времени', N'Начисление'),
(N'Удержание подоходного налога', N'Удержание'),
(N'Начисление премии', N'Начисление'),
(N'Дополнительная премия за повышенный объём работ', N'Начисление'),
(N'Понижение премии за нарушение тредовой дисциплины', N'Удержание'),
(N'Удержание за кредит', N'Удержание');

INSERT INTO Employees (FullName, Department_Id, Gender, BaseSalary) VALUES 
('Иванов Иван', 1, 'М', 1000),
('Петрова Анна', 2, 'Ж', 1200),
('Сидоров Алексей', 1, 'М', 1000),
('Кузнецова Мария', 3, 'Ж', 1500),
('Орлов Дмитрий', 2, 'М', 1000),
('Смирнова Ольга', 3, 'Ж', 1500),
('Тихонов Павел', 1, 'М', 1300),
('Егорова Наталья', 2, 'Ж', 1200),
('Зайцев Артем', 3, 'М', 1600),
('Морозова Елена', 1, 'Ж', 1100);

INSERT INTO WorkSchedule (Month, Year, StandardHours, BonusPercent, TaxPercent) VALUES
(8, 2025, 160.00, 10.00, 13.00),
(9, 2025, 160.00, 10.00, 13.00);

DECLARE @StartDate DATE = '2025-09-01';
DECLARE @EndDate DATE = '2025-09-30';

DECLARE @CurrentDate DATE = @StartDate;
DECLARE @EmployeeId INT;

WHILE @CurrentDate <= @EndDate
BEGIN
    SET @EmployeeId = 1;
    WHILE @EmployeeId <= 10
    BEGIN
        INSERT INTO WorkTimeLog (Employee_Id, WorkDate, HoursWorked)
        VALUES (@EmployeeId, @CurrentDate, 8.00); -- стандартный рабочий день

        SET @EmployeeId = @EmployeeId + 1;
    END
    SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate);
END

