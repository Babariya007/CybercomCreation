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

                if (employeeModel.Address != null)
                {
                    emp.Address = new Address()
                    {
                        Details = employeeModel.Address.Details,
                        State = employeeModel.Address.State,
                        Country = employeeModel.Address.Country
                    };
                }

                context.Employee.Add(emp);

                context.SaveChanges();

                return emp.EmployeeID;
            }
        }
    }
}
