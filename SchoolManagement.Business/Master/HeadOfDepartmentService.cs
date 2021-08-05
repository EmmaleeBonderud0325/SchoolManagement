using Microsoft.Extensions.Configuration;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Master
{
    public class HeadOfDepartmentService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;

        public HeadOfDepartmentService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
        }

        public List<HeadOfDepartmentViewModel> GetAllHeadOfDepartment()
        {
            var response = new List<HeadOfDepartmentViewModel>();

            var query = schoolDb.HeadOfDepartments;//.Where(u => u.IsActive == true);//

            var HeadOfDepartmentList = query.ToList();

            foreach (var HeadOfDepartment in HeadOfDepartmentList)
            {
                var viewModel = new HeadOfDepartmentViewModel
                {
                    Id = HeadOfDepartment.Id,
                    SubjectId = HeadOfDepartment.SubjectId,
                    AcademicLevelId = HeadOfDepartment.AcademicLevelId,
                    AcademicYearId = HeadOfDepartment.AcademicYearId,
                    TeacherId = HeadOfDepartment.TeacherId,
                    IsActive = HeadOfDepartment.IsActive,
                    CreateOn = HeadOfDepartment.CreateOn,
                    CreatedById = HeadOfDepartment.CreatedById,
                    UpdateOn = HeadOfDepartment.UpdateOn,
                    UpdatedById = HeadOfDepartment.UpdatedById,
                };

                response.Add(viewModel);

            }

            return response;
        }
    }
}
