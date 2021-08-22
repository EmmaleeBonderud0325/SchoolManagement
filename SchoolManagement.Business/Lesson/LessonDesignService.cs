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
    public class LessonDesignService : ILessonDesignService
    {
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public LessonDesignService(SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }
        public List<LessonViewModel> GetAllLessons(LessonFilterViewModel filters, string userName)
        {
            var response = new List<LessonViewModel>();

            var loggedInUser = currentUserService.GetUserByUsername(userName);

            var query = schoolDb.Lessons.Where(u => u.IsActive == true && u.OwnerId == loggedInUser.Id).OrderBy(x => x.CreatedOn);

            if (filters.SelectedAcademicYearId > 0)
            {
                query = query.Where(x => x.AcademicYearId == filters.SelectedAcademicYearId).OrderBy(o => o.CreatedOn);
            }

            if (filters.SelectedAcademicLevelId > 0)
            {
                query = query.Where(x => x.AcademicLevelId == filters.SelectedAcademicLevelId).OrderBy(o => o.CreatedOn);
            }

            if (filters.SelectedClassNameId > 0)
            {
                query = query.Where(x => x.ClassNameId == filters.SelectedClassNameId).OrderBy(o => o.CreatedOn);
            }

            if (filters.SelectedSubjectId > 0)
            {
                query = query.Where(x => x.SubjectId == filters.SelectedSubjectId).OrderBy(o => o.CreatedOn);
            }

            var lessonList = query.ToList();

            foreach (var lesson in lessonList)
            {

                var vm = new LessonViewModel
                {
                    Id = lesson.Id,
                    Name = lesson.Name,
                    Description = lesson.Description,
                    OwnerId = lesson.OwnerId,
                    SelectedAcademicLevelId = lesson.AcademicLevelId,
                    SelectedClassNameId = lesson.ClassNameId,
                    SelectedAcademicYearId = lesson.AcademicYearId,
                    SelectedSubjectId = lesson.SubjectId,
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
                        AcademicLevelId = vm.SelectedAcademicLevelId,
                        ClassNameId = vm.SelectedClassNameId,
                        AcademicYearId = vm.SelectedAcademicYearId,
                        SubjectId = vm.SelectedSubjectId,
                        LearningOutcome = vm.LearningOutcome,
                        PlannedDate = vm.PlannedDate,
                        VersionNo = 1,
                        Status = LessonStatus.Design,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = loggedInUser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id

                    };

                    schoolDb.Lessons.Add(lesson);

                    response.IsSuccess = true;
                    response.Message = "Lesson Added Successfully.";
                }
                else
                {
                    lesson.Name = vm.Name;
                    lesson.Description = vm.Description;
                    lesson.OwnerId = vm.selectedOwner.Id;
                    lesson.AcademicLevelId = vm.SelectedAcademicLevelId;
                    lesson.ClassNameId = vm.SelectedClassNameId;
                    lesson.AcademicYearId = vm.SelectedAcademicYearId;
                    lesson.SubjectId = vm.SelectedSubjectId;
                    lesson.LearningOutcome = vm.LearningOutcome;
                    lesson.PlannedDate = vm.PlannedDate;
                    lesson.UpdatedOn = DateTime.UtcNow;
                    lesson.UpdatedById = loggedInUser.Id;

                    schoolDb.Lessons.Update(lesson);

                    response.IsSuccess = true;
                    response.Message = "Lesson Updated Successfully";
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

                if (topic == null)
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
                    response.Message = "Topic Added Successfully.";
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            await schoolDb.SaveChangesAsync();
            return response;
        }
        public async Task<ResponseViewModel> DeleteLesson(int id)
        {
            var response = new ResponseViewModel();

            try
            {
                var lesson = schoolDb.Lessons.FirstOrDefault(x => x.Id == id);

                lesson.IsActive = false;

                schoolDb.Lessons.Update(lesson);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Lesson deleted Successfully";

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
