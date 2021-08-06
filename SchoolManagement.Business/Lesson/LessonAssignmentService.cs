using Castle.Core.Configuration;
using SchoolManagement.Business.Interfaces.LessonData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class LessonAssignmentService: ILessonAssignmentService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public LessonAssignmentService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService; 
        }



        public async Task<ResponseViewModel> DeleteLessonAssignment(int Id)
        {
            var response = new ResponseViewModel();

            try
            {
                var lessonAssignment = schoolDb.LessonAssignments.FirstOrDefault(x => x.Id == Id);

                lessonAssignment.IsActive = false;

                schoolDb.LessonAssignments.Update(lessonAssignment);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Lesson Assignment Delete Successfull";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            return response;
        }

        public List<LessonAssignmentViewModel> GetLessonAssignments()
        {
            var response = new List<LessonAssignmentViewModel>();

            var query = schoolDb.LessonAssignments.Where(u => u.IsActive == true);

            var LessonAssignmentList = query.ToList();

            foreach(var lessonassignment in LessonAssignmentList)
            {
                var vm = new LessonAssignmentViewModel
                {
                    Id = lessonassignment.Id,
                    LessonId = lessonassignment.LessonId,
                    Name = lessonassignment.Name,
                    Descripstion = lessonassignment.Descripstion,
                    IsActive = lessonassignment.IsActive,
                    CreatedOn = lessonassignment.CreatedOn,
                    CreatedById = lessonassignment.CreatedById,
                    UpdatedOn = lessonassignment.UpdatedOn,
                    UpdatedById = lessonassignment.UpdatedById
                };

                response.Add(vm);
            }
            return response;
    }

    public async Task<ResponseViewModel> SaveLessonAssignment(LessonAssignmentViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());

                var LessonAssignments = schoolDb.LessonAssignments.FirstOrDefault(x => x.Id == vm.Id);

                var loggedInUser = currentUserService.GetUserByUsername(userName);


                if (LessonAssignments == null)

                {
                    LessonAssignments = new LessonAssignment()
                    {
                        Id = vm.Id,
                        LessonId = vm.LessonId,
                        Name = vm.Name,
                        Descripstion = vm.Descripstion,
                        IsActive = vm.IsActive,
                        CreatedOn = vm.CreatedOn,
                        CreatedById = vm.CreatedById,
                        UpdatedOn = vm.UpdatedOn,
                        UpdatedById = vm.UpdatedById

                    };

                    schoolDb.LessonAssignments.Add(LessonAssignments);

                    response.IsSuccess = true;
                    response.Message = "Lesson Assignmnet   is Added Successfully";

                }
                else
                {
                    LessonAssignments.Name = vm.Name;
                    LessonAssignments.Descripstion = vm.Descripstion;
                    LessonAssignments.IsActive = vm.IsActive;
                    LessonAssignments.CreatedOn = vm.CreatedOn;
                    //LessonAssignments.CreatedById = vm.CreatedById;
                    LessonAssignments.UpdatedOn = vm.UpdatedOn;
                    //LessonAssignments.UpdatedById = vm.UpdatedById


                    schoolDb.LessonAssignments.Update(LessonAssignments);
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
