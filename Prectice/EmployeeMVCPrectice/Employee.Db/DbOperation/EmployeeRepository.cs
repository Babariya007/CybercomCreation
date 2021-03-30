using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace Employee.Db.DbOperation
{
    public class EmployeeRepository
    {
        #region AddEmployee
        public int AddEmployee(EmployeeModel employeeModel)
        {
            using (var context = new EmployeeDBEntitiesCS())
            {
                Employee emp = new Employee()
                {
                    FirstName = employeeModel.FirstName,
                    LastName = employeeModel.LastName,
                    Email = employeeModel.Email,
                    Code = employeeModel.Code,
                };

                context.Employee.Add(emp);

                context.SaveChanges();

                return emp.EmployeeID;
            }
        }
        #endregion AddEmployee

        #region UpdateEmployee
        public List<EmployeeModel> UpdateEmployee()
        {
            using (var context = new EmployeeDBEntitiesCS())
            {
                var result = context.Employee.Select(x => new EmployeeModel()
                {
                    EmployeeID = x.EmployeeID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Code = x.Code
                }).ToList();

                return result;
            }
        }
        public EmployeeModel UpdateEmployee(int id)
        {
            using (var context = new EmployeeDBEntitiesCS())
            {
                var result = context.Employee.Where(x => x.EmployeeID == id).Select(x => new EmployeeModel()
                {
                    EmployeeID = x.EmployeeID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Code = x.Code
                }).FirstOrDefault();

                return result;
            }
        }
        public bool UpdateEmployee(EmployeeModel empModel)
        {
            using (var context = new EmployeeDBEntitiesCS())
            {
                var emp = new Employee();

                if (emp != null)
                {
                    emp.EmployeeID = empModel.EmployeeID;
                    emp.FirstName = empModel.FirstName;
                    emp.LastName = empModel.LastName;
                    emp.Email = empModel.Email;
                    emp.Code = empModel.Code;
                }

                context.Entry(emp).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();

                return true;
            }
        }
        #endregion UpdateEmployee

        #region DeleteEmployee
        public bool DeleteEmployee(int id)
        {
            using (var context = new EmployeeDBEntitiesCS())
            {
                var emp = new Employee()
                {
                    EmployeeID = id
                };

                context.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

                return false;
            }
        }
        #endregion DeleteEmployee

    }
}
