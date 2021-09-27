using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.Util.Constants.ServiceClassConstants;
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
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public AcademicYearService(SchoolManagementContext schoolDb, IConfiguration config , ICurrentUserService currentUserService)
        {
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<AcademicYearViewModel> GetAllAcademicYear()
        {
            var response = new List<AcademicYearViewModel>();

            var query = schoolDb.AcademicYears.Where(u => u.IsActive == true);

            var academicYears = query.ToList();

            foreach (var item in academicYears)
            {
                var vm = new AcademicYearViewModel
                {
                    Id = item.Id,
                    IsActive = item.IsActive,
                    CreatedOn = item.CreatedOn,
                    createdByName = item.CreatedBy.FullName,
                    UpdatedOn = item.UpdatedOn,
                    updatedByName = item.UpdatedBy.FullName,
                    UpdatedById = item.UpdatedById,

                };

                response.Add(vm);

            }

            return response;
        }

        public async Task<ResponseViewModel> SaveAcademicYear(AcademicYearViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var academicYear = schoolDb.AcademicYears.FirstOrDefault(ay => ay.Id == vm.Id);

                if (academicYear == null)
                {
                    academicYear = new AcademicYear()
                    {
                        Id = vm.Id,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = loggedInUser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id,
                    };

                    schoolDb.AcademicYears.Add(academicYear);

                    response.IsSuccess = true;
                    response.Message = AcademicYearServiceConstants.NEW_ACADEMICYEAR_SAVE_SUCCESS_MESSAGE;
                }
                else
                {
                    academicYear.Id = vm.Id;
                    academicYear.IsActive = true;
                    academicYear.UpdatedOn = DateTime.UtcNow;
                    academicYear.UpdatedById = loggedInUser.Id;

                    schoolDb.AcademicYears.Update(academicYear);

                    response.IsSuccess = true;
                    response.Message = AcademicYearServiceConstants.EXISTING_ACADEMICYEAR_SAVE_SUCCESS_MESSAGE;

                }

                await schoolDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = AcademicYearServiceConstants.ACADEMICYEAR_SAVE_EXCEPTION_MESSAGE;
            }
            return response;
        }

        public async Task<ResponseViewModel> DeleteAcademicYear(int id)
        {
            var response = new ResponseViewModel();

            try
            {
                var academicYear = schoolDb.AcademicYears.FirstOrDefault(ay => ay.Id == id);

                academicYear.IsActive = false;
                schoolDb.AcademicYears.Update(academicYear);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Academic Year successfully deleted";
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
