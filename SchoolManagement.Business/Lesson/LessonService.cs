using Microsoft.Extensions.Configuration;
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
        public List<LessonViewModel> GetAllLessons(int id)
        {
            var response = new List<LessonViewModel>();

            var query = schoolDb.Lessons.Where(u => u.Id == id);

            var lessonList = query.ToList();

            foreach (var lesson in lessonList)
            {
                
                var vm = new LessonViewModel
                {
                    Id = lesson.Id,
                    Name = lesson.Name,
                    Description = lesson.Description,
                    //OwnerId = lesson.OwnerId,
                    //AcademicLevelId = lesson.AcademicLevelId,
                    //ClassNameId = lesson.ClassNameId,
                    //AcademicYearId = lesson.AcademicYearId,
                    //SubjectId = lesson.SubjectId,
                    VersionNo = lesson.VersionNo,
                    LearningOutcome = lesson.LearningOutcome,
                    PlannedDate = lesson.PlannedDate,
                    CompletedDate = lesson.CompletedDate,
                    CreatedOn = lesson.CreatedOn,
                    CreatedById = lesson.CreatedById,
                    UpdatedOn = lesson.UpdatedOn,
                    UpdatedById = lesson.UpdatedById

                };

                response.Add(vm);
            }

            return response;
        }

        public async Task<ResponseViewModel> SaveLesson(LessonViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var lesson = schoolDb.Lessons.FirstOrDefault(x => x.Id == vm.Id);

                if (lesson == null)
                {
                    lesson = new Lesson()
                    {
                        Id = vm.Id,
                        Description = vm.Description,
                        OwnerId = loggedInUser.Id,
                        AcademicLevelId = vm.SelectedAcademicLevel.Id,
                        ClassNameId = vm.SelectedClassName.Id,
                        AcademicYearId = vm.SelectedAcademicYear.Id,
                        SubjectId = vm.SelectedSubject.Id,
                        LearningOutcome = vm.LearningOutcome,
                        PlannedDate = vm.PlannedDate,
                        VersionNo = vm.VersionNo,
                        Status = LessonStatus.Design,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = loggedInUser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id

                    };

                    schoolDb.Lessons.Add(lesson);

                    response.IsSuccess = true;
                    response.Message = "Lesson Added Successfull.";
                }
                else
                {
                    lesson.Description = vm.Description;
                    lesson.OwnerId = loggedInUser.Id;
                    lesson.AcademicLevelId = vm.SelectedAcademicLevel.Id;
                    lesson.ClassNameId = vm.SelectedClassName.Id;
                    lesson.AcademicYearId = vm.SelectedAcademicYear.Id;
                    lesson.SubjectId = vm.SelectedSubject.Id;
                    lesson.LearningOutcome = vm.LearningOutcome;
                    lesson.PlannedDate = vm.PlannedDate;
                    lesson.VersionNo = vm.VersionNo;
                    lesson.UpdatedOn = DateTime.UtcNow;
                    lesson.UpdatedById = loggedInUser.Id;

                    schoolDb.Lessons.Update(lesson);

                    response.IsSuccess = true;
                    response.Message = "Lesson Update Successfull";
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

        public async Task<ResponseViewModel> SaveTopic(TopicViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var topic = schoolDb.Topics.FirstOrDefault(x => x.Id == vm.Id);

                if(topic == null)
                {
                    topic = new Topic()
                    {
                        Id = vm.Id,
                        LessonId = vm.LessonId,
                        SequenceNo = vm.SequenceNo,
                        LearningExperience = vm.LearningExperience,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        ModifiedOn = DateTime.UtcNow,
                    };

                    schoolDb.Topics.Add(topic);

                    response.IsSuccess = true;
                    response.Message = "Topic Added Successfull.";
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            await schoolDb.SaveChangesAsync();
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
