using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.Model.Common.Enums;
using SchoolManagement.ViewModel.Common;
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
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public AcademicLevelService(SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<AcademicLevelViewModel> GetAllAcademicLevel()
        {
            var response = new List<AcademicLevelViewModel>();

            var query = schoolDb.AcademicLevels.Where(al => al.IsActive == true);

            var academicLevels = query.ToList();

            foreach (var item in academicLevels)
            {
                var vm = new AcademicLevelViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    LevelHeadId = item.LevelHeadId,
                    LevelHeadName = item.LevelHead.FullName,
                    IsActive = item.IsActive,
                    CreatedOn = item.CreatedOn,
                    CreatedById = item.CreatedById,
                    CreatedByName = item.CreatedBy.FullName,
                    UpdatedOn = item.UpdatedOn,
                    UpdatedById = item.UpdatedById,
                    UpdatedByName = item.UpdatedBy.FullName  
                };

                response.Add(vm);

            }

            return response;
        }

        public async Task<ResponseViewModel> SaveAcademicLevel(AcademicLevelViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = currentUserService.GetUserByUsername(userName);

                var academicLevelExist = schoolDb.AcademicLevels.FirstOrDefault(al => al.Id == vm.Id);

                if (academicLevelExist == null)
                {
                    academicLevelExist = new AcademicLevel()
                    {
                        Id = vm.Id,
                        Name = vm.Name,
                        LevelHeadId = vm.LevelHeadId,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = currentuser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = currentuser.Id,
                    };

                    schoolDb.AcademicLevels.Add(academicLevelExist);

                    response.IsSuccess = true;
                    response.Message = "Academic Level successfully created";
                }
                else
                {
                    academicLevelExist.Name = vm.Name;
                    academicLevelExist.LevelHeadId = vm.LevelHeadId;
                    academicLevelExist.IsActive = true;
                    academicLevelExist.UpdatedById = currentuser.Id;
                    academicLevelExist.UpdatedOn = DateTime.UtcNow;
                    
                    schoolDb.AcademicLevels.Update(academicLevelExist);

                    response.IsSuccess = true;
                    response.Message = "Academic Level successfully updated";
                }

                await schoolDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while saving the acdemic level.";
            }
            return response;
        }

        public async Task<ResponseViewModel> DeleteAcademicLevel(int id)
        {
            var response = new ResponseViewModel();

            try
            {
                var academicLevel = schoolDb.AcademicLevels.FirstOrDefault(al => al.Id == id);

                academicLevel.IsActive = false;
                schoolDb.AcademicLevels.Update(academicLevel);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Academic Level successfully deleted";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }

            return response;
        }

        public List<DropDownViewModel> GetAllLevelHeads()
        {
            var levelHeads = schoolDb.UserRoles
                .Where(x => x.RoleId == (int)RoleType.LevelHead)
                .Select(u => new DropDownViewModel() { Id = u.User.Id, Name = string.Format("{0}", u.User.FullName) })
                .Distinct().ToList();

            return levelHeads;
        }
    }

}
