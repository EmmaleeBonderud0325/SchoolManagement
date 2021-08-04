using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Master
{
    public class AcademicLevelService : IAcademicLevelService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;

        public AcademicLevelService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
        }

        public List<AcademicLevelViewModel> GetAllAcademicLevel()
        {
            var response = new List<AcademicLevelViewModel>();

            var query = schoolDb.AcademicLevels;//.Where(u => u.IsActive == true);//

            var AcademicLevelList = query.ToList();

            foreach (var AcademicLevel in AcademicLevelList)
            {
                var viewModel = new AcademicLevelViewModel
                {
                    Id = AcademicLevel.Id,
                    Name = AcademicLevel.Name,
                    LevelHeadId = AcademicLevel.LevelHeadId,
                    IsActive = AcademicLevel.IsActive,
                    CreatedById = AcademicLevel.CreatedById,
                    UpdatedOn = AcademicLevel.UpdatedOn,
                    UpdatedById = AcademicLevel.UpdatedById,
                   
                };

                response.Add(viewModel);

            }

            return response;
        }
    }
}
