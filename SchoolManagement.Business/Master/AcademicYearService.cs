using Microsoft.Extensions.Configuration;
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
    public class AcademicYearService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;

        public AcademicYearService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
        }

        public List<AcademicYearViewModel> GetAllAcademicYear()
        {
            var response = new List<AcademicYearViewModel>();

            var query = schoolDb.AcademicYears;//.Where(u => u.IsActive == true);//

            var AcademicYearList = query.ToList();

            foreach (var AcademicYear in AcademicYearList)
            {
                var viewModel = new AcademicYearViewModel
                {
                    Id = AcademicYear.Id,
                    IsActive = AcademicYear.IsActive,
                    CreatedOn = AcademicYear.CreatedOn,
                    CreatedById = AcademicYear.CreatedById,
                    UpdatedOn = AcademicYear.UpdatedOn,
                    UpdatedById = AcademicYear.UpdatedById,

                };

                response.Add(viewModel);

            }

            return response;
        }
    }
}
