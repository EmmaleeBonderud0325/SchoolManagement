using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.LessonData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.ViewModel;
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
                        AcademicLevelId = vm.AcademicLevelId,
                        ClassNameId = vm.ClassNameId,
                        AcademicYearId = vm.AcademicYearId,
                        SubjectId = vm.SubjectId,
                        LearningOutcome = vm.LearningOutcome,
                        PlannedDate = vm.PlannedDate,
                        CompletedDate = DateTime.UtcNow,
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
                    lesson.AcademicLevelId = vm.AcademicLevelId;
                    lesson.ClassNameId = vm.ClassNameId;
                    lesson.AcademicYearId = vm.AcademicYearId;
                    lesson.SubjectId = vm.SubjectId;
                    lesson.PlannedDate = vm.PlannedDate;
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
                response.Message = "Error has been Occured.Please Try Again";
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
        public LessonMasterDataViewModel GetLessonMasterData()
        {
            var response = new LessonMasterDataViewModel();

            response.AcademicLevels = schoolDb.AcademicLevels.OrderBy(x => x.Id).Select(a => new DropDownViewModel() { Id = a.Id, Name = a.Name }).ToList();
            response.ClassNames = schoolDb.ClassNames.OrderBy(x => x.Name).Select(c => new DropDownViewModel() { Id = c.Id, Name = c.Name }).ToList();
            response.AcademicYears = schoolDb.AcademicYears.OrderBy(x => x.Id).Select(ay => new DropDownViewModel() { Id = ay.Id, Name = ay.Id.ToString() }).ToList();
            response.Subjects = schoolDb.Subjects.OrderBy(x => x.Id).Select(s => new DropDownViewModel() { Id = s.Id, Name = s.Name }).ToList();

            return response;
        }
        public PaginatedItemsViewModel<BasicLessonViewModel> GetLessonList(LessonFilterViewModel filters,int cuttrentPage, int pageSize, string userName)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;

            var vml = new List<BasicLessonViewModel>();

            var loggedInUser = currentUserService.GetUserByUsername(userName);
            //var lessons = schoolDb.Lessons.OrderBy(l => l.Name && loggedInUser.Id);
            var query = schoolDb.Lessons.Where(u => u.IsActive == true && u.OwnerId == loggedInUser.Id).OrderBy(o => o.Name);

            if (!string.IsNullOrEmpty(filters.searchText))
            {
                query = query.Where(x => x.Name.Contains(filters.searchText)).OrderBy(o => o.Name);
            }

            if (filters.SelectedAcademicYearId > 0)
            {
                query = query.Where(x => x.AcademicYearId == filters.SelectedAcademicYearId).OrderBy(o => o.Name);
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

            totalRecordCount = query.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var lessonList = query.Skip((cuttrentPage - 1) * pageSize).Take(pageSize).ToList();

            foreach (var item in lessonList)
            {
                var vm = new BasicLessonViewModel()
                {
                    LessonName = item.Name,
                    AcademicLevelId = item.AcademicLevelId,
                    ClassNameId = item.ClassNameId,
                    AcademicYearId = item.AcademicYearId,
                    SubjectId = item.SubjectId
                    
                };
                vml.Add(vm);
            }

            var container = new PaginatedItemsViewModel<BasicLessonViewModel>(pageSize, totalPageCount, totalRecordCount,vml);

            return container;

        }
    }
}
