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

namespace SchoolManagement.Business.Lesson
{
    public class LessonService : ILessonService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public LessonService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }
        public List<LessonViewModel> GetAllLessons()
        {
            var response = new List<LessonViewModel>();
            var query = schoolDb.Lessons.Where(u => u.Id == 123);
            var LessonList = query.ToList();

            foreach (var Lesson in LessonList)
            {
                var vm = new LessonViewModel
                {
                    Id = Lesson.Id,
                    Name = Lesson.Name,
                    Description = Lesson.Description,
                    OwnerId = Lesson.OwnerId,
                    AcademicLevelId = Lesson.AcademicLevelId,
                    ClassNameId = Lesson.ClassNameId,
                    AcademicYearId = Lesson.AcademicYearId,
                    SubjectId = Lesson.SubjectId,
                    VersionNo = Lesson.VersionNo,
                    LearningOutcome = Lesson.LearningOutcome,
                    PlannedDate = Lesson.PlannedDate,
                    CompletedDate = Lesson.CompletedDate,
                    CreatedOn = Lesson.CreatedOn,
                    CreatedById = Lesson.CreatedById,
                    UpdatedOn = Lesson.UpdatedOn,
                    UpdatedById = Lesson.UpdatedById

                };
                response.Add(vm);
            }
            return response;
        }
        //public async Task<ResponseViewModel> SaveLesson(LessonViewModel vm, string userName)
        //{
        //    var response = new ResponseViewModel();
        //    try
        //    {
        //        var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());
        //        var MCQQuestionAnswers = schoolDb.MCQQuestionAnswers.FirstOrDefault(x => x.Id == vm.Id);
        //        var loggedInUser = currentUserService.GetUserByUsername(userName);

        //        if (Lesson == null)
        //        {
        //            Lesson = new Lessons()
        //            {
        //                Id = vm.Id,
        //                Name = vm.Name,
        //                Description = vm.Description,
        //                OwnerId = vm.OwnerId,
        //                AcademicLevelId = vm.AcademicLevelId,
        //                ClassNameId = vm.ClassNameId,
        //                AcademicYearId = vm.AcademicYearId,
        //                SubjectId = vm.SubjectId,
        //                VersionNo = vm.VersionNo,
        //                LearningOutcome = vm.LearningOutcome,
        //                PlannedDate = vm.PlannedDate,
        //                CompletedDate = vm.CompletedDate,
        //                CreatedOn = vm.CreatedOn,
        //                CreatedById = vm.CreatedById,
        //                UpdatedOn = vm.UpdatedOn,
        //                UpdatedById = vm.UpdatedById
        //            };
        //            schoolDb.Lessons.Add(Lesson);
        //            response.IsSuccess = true;
        //            response.Message = " Lesson is added successfully";
        //        }
        //        else
        //        {

        //            schoolDb.Lessons.Update(Lesson);
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}
