CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100) NOT NULL
);

CREATE TABLE PaymentTypes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PaymentTypeName NVARCHAR(100) NOT NULL,
    PaymentCategory NVARCHAR(20) NOT NULL CHECK (PaymentCategory IN ('����������', '���������'))
);

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(150) NOT NULL,
    Department_Id INT NOT NULL,
    Gender NVARCHAR(1) CHECK (Gender IN ('�', '�')),
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

    -- �������� ������� �������� ���������
    SELECT @BaseSalary = BaseSalary
    FROM Employees
    WHERE Id = @EmployeeId;

    -- �������� ������ ������
    SELECT @ScheduleId = Id,
           @StandardHours = StandardHours,
           @BonusPercent = BonusPercent,
           @TaxPercent = TaxPercent
    FROM WorkSchedule
    WHERE Month = @Month AND Year = @Year;

    -- ������� ����� ���������� ������������ �����
    SELECT @HoursWorked = ISNULL(SUM(HoursWorked), 0)
    FROM WorkTimeLog
    WHERE Employee_Id = @EmployeeId
      AND MONTH(WorkDate) = @Month
      AND YEAR(WorkDate) = @Year;

    -- ������� ������ ������ SalaryDetails ��� ����� ������
    DELETE FROM SalaryDetails
    WHERE Employee_Id = @EmployeeId AND Schedule_Id = @ScheduleId;

    -- ���������� �������� ������������� �������
    DECLARE @BasePayment DECIMAL(10,2) = 
        ROUND(@BaseSalary * (@HoursWorked / NULLIF(@StandardHours, 0)), 2);

    -- ��������� ����������� ������ �����
    DECLARE @TaxDeduction DECIMAL(10,2) = 
        ROUND(@BasePayment * (@TaxPercent / 100), 2);

    -- ���������� ������
    DECLARE @BonusPayment DECIMAL(10,2) = 
        ROUND(@BasePayment * (@BonusPercent / 100), 2);


    -- �������� ID ����� ������
    DECLARE @BasePaymentTypeId INT, 
			@TaxPaymentTypeId INT, 
			@BonusPaymentTypeId INT;

    SELECT @BasePaymentTypeId = Id FROM PaymentTypes WHERE PaymentTypeName = '���������� �������� ������������� �������';
    SELECT @TaxPaymentTypeId = Id FROM PaymentTypes WHERE PaymentTypeName = '��������� ����������� ������';
    SELECT @BonusPaymentTypeId = Id FROM PaymentTypes WHERE PaymentTypeName = '���������� ������';

    -- ��������� ������
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
(N'�����������'),
(N'����� ������'),
(N'��'),
(N'������������');

INSERT INTO PaymentTypes (PaymentTypeName, PaymentCategory) VALUES
(N'���������� �������� ������������� �������', N'����������'),
(N'��������� ����������� ������', N'���������'),
(N'���������� ������', N'����������'),
(N'�������������� ������ �� ���������� ����� �����', N'����������'),
(N'��������� ������ �� ��������� �������� ����������', N'���������'),
(N'��������� �� ������', N'���������');

INSERT INTO Employees (FullName, Department_Id, Gender, BaseSalary) VALUES 
('������ ����', 1, '�', 1000),
('������� ����', 2, '�', 1200),
('������� �������', 1, '�', 1000),
('��������� �����', 3, '�', 1500),
('����� �������', 2, '�', 1000),
('�������� �����', 3, '�', 1500),
('������� �����', 1, '�', 1300),
('������� �������', 2, '�', 1200),
('������ �����', 3, '�', 1600),
('�������� �����', 1, '�', 1100);

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
        VALUES (@EmployeeId, @CurrentDate, 8.00); -- ����������� ������� ����

        SET @EmployeeId = @EmployeeId + 1;
    END
    SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate);
END

