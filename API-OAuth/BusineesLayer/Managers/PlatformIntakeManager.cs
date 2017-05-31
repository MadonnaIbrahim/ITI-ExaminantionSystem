using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusineesLayer.Managers
{
    public class PlatformIntakeManager : DataFactory<DataBaseCTX, PlatfromIntake>
    {
        PlatformIntakeManager Pmgr;
        public PlatfromIntake Get_PlatformIntake(int plaltformintake_Id)
        {
            Pmgr = new PlatformIntakeManager(); ;
            var p = Pmgr.FindBy(x => x.PlatformIntakeID.Equals(plaltformintake_Id));
            return p;
        }


        public List<PlatfromIntake> ExamForTracks(int Branch_Id,List<int> subTrack_Ids)
        {
            Pmgr = new PlatformIntakeManager();
            List<PlatfromIntake> PlatForm_BranchList;
            List<PlatfromIntake> FinalPlatFormIntake_List = new List<PlatfromIntake>();

            PlatForm_BranchList = Pmgr.FindListBy(x => x.BranchID.Equals(Branch_Id)).ToList();
            foreach (var id in subTrack_Ids)
            {
                var PlatFormIntake = PlatForm_BranchList.Where(x => x.SubTrackID.Equals(id)).FirstOrDefault();
                FinalPlatFormIntake_List.Add(PlatFormIntake);
            }
            return FinalPlatFormIntake_List;
        }

        public int GetPlatFormIntakeId(int branch_Id,int subTrack_id)
        {
            Pmgr = new PlatformIntakeManager();
            var PlatfromIntake = Pmgr.FindListBy(x => x.BranchID.Value.Equals(branch_Id)).ToList();
            PlatfromIntake P=new PlatfromIntake();
            foreach (var PLATformIntake in PlatfromIntake)
            {
               P = Pmgr.FindBy(x => x.SubTrackID.Value.Equals(subTrack_id));
            }

            return P.PlatformIntakeID;
        }

    }
}