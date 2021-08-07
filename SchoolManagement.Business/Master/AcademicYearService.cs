using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Master
{
    public class AcademicYearService : IAcademicYearService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public AcademicYearService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config , ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<AcademicYearViewModel> GetAllAcademicYear()
        {
            var response = new List<AcademicYearViewModel>();

            var query = schoolDb.AcademicYears.Where(u => u.IsActive == true);

            var AcademicYearList = query.ToList();

            foreach (var AcademicYear in AcademicYearList)
            {
                var viewModel = new AcademicYearViewModel
                {
                    Id = AcademicYear.Id,
                    //Name = AcademicYear.Name,
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

        public async Task<ResponseViewModel> SaveAcademicYear(AcademicYearViewModel academicYearVM, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = currentUserService.GetUserByUsername(userName);

                var academicYearExist = schoolDb.AcademicYears.FirstOrDefault(ay => ay.Id == academicYearVM.Id);

                if (academicYearExist == null)
                {
                    academicYearExist = new AcademicYear()
                    {
                        Id = academicYearVM.Id,
                        //Name = academicYearVM.Name,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = currentuser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = currentuser.Id,
                    };

                    schoolDb.AcademicYears.Add(academicYearExist);

                    response.IsSuccess = true;
                    response.Message = "Academic Year successfully created";
                }
                else
                {
                    //academicYearExist.Name = academicYearVM.Name;
                    academicYearExist.IsActive = true;
                    academicYearExist.UpdatedOn = DateTime.UtcNow;
                    academicYearExist.UpdatedById = currentuser.Id;

                    schoolDb.AcademicYears.Update(academicYearExist);

                    response.IsSuccess = true;
                    response.Message = "Academic Year successfully updated";
                    
                }

                await schoolDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            return response;
        }
    }
}
