-- 1.  Get First_Name from employee table using alias name “Employee Name”
SELECT First_name AS "Employee Name" FROM Employee


-- 2. Get position of 'o' in name 'John' from employee table
SELECT CHARINDEX('o', 'John') As "First Way"												-- 1st Way
SELECT CHARINDEX('o', FIrst_name) As "Second Way" FROM Employee WHERE First_name = 'John'   -- 2nd Way


-- 3. Get FIRST_NAME ,Joining year,Joining Month and Joining Date from employee table
SELECT First_Name, YEAR(Joining_Date) AS "Joining Year", MONTH(Joining_Date) AS "Joining Month", DAY(Joining_Date) AS "Joining Date"
FROM Employee


-- 4. Get all employee details from the employee table order by First_Name Ascending and Salary descending
SELECT * FROM Employee
ORDER BY First_name, Salary DESC


-- 5. Get employee details from employee table whose employee name are not “John” and “Roy”
SELECT * FROM Employee
WHERE First_name NOT IN ('John','Roy')


-- 6. Get employee details from employee table whose first name ends with 'n'SELECT * FROM EmployeeWHERE First_name LIKE '%n'-- 7. Get employee details from employee table whose first name ends with 'n' and name contains 4 LettersSELECT * FROM EmployeeWHERE First_name LIKE '___n'   -- Here put 3 Underscore for Name Length is 4 with last char n-- 8. Get employee details from employee table whose Salary less than 800000SELECT * FROM EmployeeWHERE Salary < 800000-- 9. Get employee details from employee table who joined before January 1st 2013SELECT * FROM EmployeeWHERE Joining_Date < '01/01/2013'		--Here date formate is (mm/dd/yyyy)-- 10. Get difference between JOINING_DATE and INCENTIVE_DATE from employee and incentives tableSELECT First_name, DATEDIFF(DAY, Joining_Date, Incentive_date) AS "Incentive In Days" FROM EmployeeINNER JOIN IncentivesON Incentives.Employee_ref_id = Employee.Employee_id-- 11. Print database dateSELECT getdate()		--It's Show Database Date and timeEXEC sp_helpdb 'Test'	--ii's show details of database in creation date-- 12. Get department,total salary with respect to a department from employee table.SELECT Department, SUM(Salary) AS "Total Salary"FROM EmployeeGROUP BY Department-- 13. Get department,no of employees in a department,total salary with respect to a department from employee table order by total salary descendingSELECT Department, COUNT(First_name) AS "Total Employee", SUM(Salary) AS "Total Salary"FROM EmployeeGROUP BY DepartmentORDER BY [Total Salary] DESC-- 14. Select no of employees joined with respect to year and month from employee tableSELECT Count(First_name) AS "Employees", DATEPART(YYYY, Joining_Date) AS "Joining Year", DATEPART(MM, Joining_Date) AS "Joining Month"FROM EmployeeGROUP BY DATEPART(YYYY, Joining_Date), DATEPART(MM, Joining_Date)-- 15. Update incentive table with employee's Incentive_amount as '12000' where employee name is 'John'UPDATE IncentivesSET Incentive_amount = 12000WHERE Employee_ref_id = (SELECT Employee_id FROM Employee WHERE First_name = 'John')-- 16. Select TOP 2 salary from employee tableSELECT TOP 2 Salary FROM Employee-- 17. Select 2nd Highest salary from employee tableSELECT MAX(Salary) AS "Salary"FROM EmployeeWHERE Salary < (SELECT MAX(Salary) FROM Employee)-- 19 Write a syntax for CREATE Employee TableCREATE TABLE Employee(	Employee_id		int,	First_name		varchar(50),	Last_name		varchar(50),	Salary			decimal(10,2),	Joining_date	datetime,	Department		varchar(50))-- 20. Write a syntax for truncate all data from Emplyee Table.TRUNCATE TABLE Employee-- 21. Write a syntax for CREATE Procedure to display the Employee details by passing the “EmployeeId” in the procedure.CREATE PROCEDURE [dbo].[PR_Employee_SelectAll]	@EmployeeID intASSELECT * FROM EmployeeWHERE Employee_id = @EmployeeID--[dbo].[PR_Employee_SelectAll] 2-- 22. Write a syntax for CREATE SQL function, which accept three number as argument and return the highest numberCREATE FUNCTION MaxOfThree(@Number1 int, @Number2 int, @Number3 int)Returns intASBEGIN	Declare @MaxNumber int;	If(@Number1 > @Number2 AND @Number1 > @Number3)		SET @MaxNumber = @Number1;	Else If(@Number2 > @Number3)		SET @MaxNumber = @Number2;	Else		SET @MaxNumber = @Number3;	Return @MaxNumber;END-- 23. Write a syntax for Update the Employee's salary whose department is “Insurance”.UPDATE EmployeeSET Salary = Salary + (Salary*0.10)WHERE Department = 'Insurance'-- 25. Write a query that insert the data into Employee table, data as mentionedINSERT INTO Employee	  (First_name, Last_name, Salary, Joining_Date, Department)VALUES('Critiano', 'Ronaldo', 30000, '01-FEB-13 12:00:00 AM', 'Banking')