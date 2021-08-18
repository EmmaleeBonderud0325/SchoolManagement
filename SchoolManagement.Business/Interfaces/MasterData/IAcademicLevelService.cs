using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface IAcademicLevelService
    {
        List<AcademicLevelViewModel> GetAllAcademicLevel();
        Task<ResponseViewModel> SaveAcademicLevel (AcademicLevelViewModel academicLevelVM, String userName);
        Task<ResponseViewModel> DeleteAcademicLevel(int id);
        List<DropDownViewModel> GetAllLevelHeads();
    }
}
