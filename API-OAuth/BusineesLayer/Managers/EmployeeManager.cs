using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusineesLayer.Managers
{
    public class EmployeeManager : DataFactory<DataBaseCTX, Employee>
    {
        EmployeeManager empMgr;
        public List<Employee> GetEmployees()
        {
            var xx = new EmployeeManager().GetAll();
            var y = xx.ToList();
            return y;
        }

        public int GetEmpBranchId(int emp_Id)
        {
            empMgr = new EmployeeManager();
            var employee=empMgr.FindBy(x => x.EmployeeID.Equals(emp_Id));
            var BranchId = employee.BranchID;
            return BranchId;
        }


    }
}
