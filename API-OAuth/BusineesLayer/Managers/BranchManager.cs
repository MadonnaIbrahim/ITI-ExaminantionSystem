using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusineesLayer.Managers
{
    public class BranchManager : DataFactory<DataBaseCTX, Branch>
    {
       
        public Branch GetBranchById(int branch_Id)
        {
            BranchManager BMgr = new BranchManager();
            var branch = BMgr.FindBy(x => x.BranchID.Equals(branch_Id));
            return branch;
        }


    }
}
