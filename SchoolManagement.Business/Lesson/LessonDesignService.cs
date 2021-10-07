using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces;
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
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class LessonDesignService : ILessonDesignService
    {
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;
    private readonly IAzureBlobService azureBlobService;

        public LessonDesignService(SchoolManagementContext schoolDb, IConfiguration config, IAzureBlobService azureBlobService, ICurrentUserService currentUserService)
        {
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
      this.azureBlobService = azureBlobService;
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

                var lesson = schoolDb.Lessons.FirstOrDefault(x => x.Id == vm.LessonDetail.LessonId);

                if (lesson == null)
                {
                    lesson = new Lesson()
                    {
                        Id = vm.Id,
                        Name = vm.LessonDetail.Name,
                        Description = vm.LessonDetail.Description,
                        OwnerId = loggedInUser.Id,
                        AcademicLevelId = vm.LessonDetail.AcademicLevelId,
                        ClassNameId = vm.LessonDetail.ClassNameId,
                        AcademicYearId = vm.LessonDetail.AcademicYearId,
                        SubjectId = vm.LessonDetail.SubjectId,
                        LearningOutcome = vm.LessonDetail.LearningOutcome,
                        PlannedDate = vm.LessonDetail.PlannedDate,
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
                    lesson.Name = vm.LessonDetail.Name;
                    lesson.Description = vm.LessonDetail.Description;
                    lesson.AcademicLevelId = vm.LessonDetail.AcademicLevelId;
                    lesson.ClassNameId = vm.LessonDetail.ClassNameId;
                    lesson.AcademicYearId = vm.LessonDetail.AcademicYearId;
                    lesson.SubjectId = vm.LessonDetail.SubjectId;
                    lesson.PlannedDate = vm.LessonDetail.PlannedDate;
                    lesson.LearningOutcome = vm.LessonDetail.LearningOutcome;
                    lesson.PlannedDate = vm.LessonDetail.PlannedDate;
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
        public async Task<TopicViewModel> SaveTopic(TopicViewModel vm, string userName)
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
                        Name = vm.Name,
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
                    topic.Name = vm.Name;
                    topic.LearningExperience = vm.LearningExperience;
                    topic.ModifiedOn = DateTime.UtcNow;

                    schoolDb.Topics.Update(topic);
                }


                await schoolDb.SaveChangesAsync();
                vm.Id = topic.Id;
            }
            catch (Exception ex)
            {

            }

            return vm;
        }

        public async Task<TopicContentViewModel> SaveTopicContent(TopicContentViewModel vm, string userName)
        {
            var topicContent = schoolDb.TopicContents.FirstOrDefault(x => x.Id == vm.Id);

            if (topicContent == null)
            {
                topicContent = new TopicContent()
                {
                    Name =vm.Name,
                    TopicId = vm.TopicId,
                    ContentType = TopicContentType.Text,
                    Introduction = vm.Introduction,
                    UpdatedOn = DateTime.UtcNow,
                    CreatedOn = DateTime.UtcNow
                };

                schoolDb.TopicContents.Add(topicContent);
            }
            else
            {
                topicContent.Name = vm.Name;
                topicContent.Introduction = vm.Introduction;
                if (vm.ContentType == TopicContentType.Text || vm.ContentType==TopicContentType.YoutubeVideo)
                {
                    topicContent.Content = vm.Content;
                }
                topicContent.ContentType = vm.ContentType;
                topicContent.UpdatedOn = DateTime.UtcNow;

                schoolDb.Update(topicContent);
            }

            await schoolDb.SaveChangesAsync();

            vm.Id = topicContent.Id;

            return vm;
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

            response.AcademicYears = schoolDb.AcademicYears.OrderBy(x => x.Id).Select(ay => new DropDownViewModel() { Id = ay.Id, Name = ay.Id.ToString() }).ToList();

            response.AcademicLevels = schoolDb.AcademicLevels.Select(al => new DropDownViewModel() { Id = al.Id, Name = al.Name }).ToList();

            response.CurrentYearId = schoolDb.AcademicYears.FirstOrDefault(x => x.IsCurrentYear == true).Id;

            return response;
        }
        public PaginatedItemsViewModel<BasicLessonViewModel> GetLessonList(string searchText, int academicYearId, int academicLevelId,
                                                                            int currentPage, int classNameId, int subjectId, int pageSize, string userName)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;

            var vml = new List<BasicLessonViewModel>();

            var loggedInUser = currentUserService.GetUserByUsername(userName);

            var query = schoolDb.Lessons.Where(u => u.IsActive == true && u.OwnerId == loggedInUser.Id).OrderBy(x => x.CreatedOn);

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(x => x.Name.Contains(searchText)).OrderBy(o => o.CreatedOn);
            }

            if (academicYearId > 0)
            {
                query = query.Where(x => x.AcademicYearId == academicYearId).OrderBy(o => o.CreatedOn);
            }

            if (academicLevelId > 0)
            {
                query = query.Where(x => x.AcademicLevelId == academicLevelId).OrderBy(o => o.CreatedOn);
            }

            if (classNameId > 0)
            {
                query = query.Where(x => x.ClassNameId == classNameId).OrderBy(o => o.CreatedOn);
            }

            if (subjectId > 0)
            {
                query = query.Where(x => x.SubjectId == subjectId).OrderBy(o => o.CreatedOn);
            }

            totalRecordCount = query.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var lessonList = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            //var lessonList = query.ToList();

            foreach (var item in lessonList)
            {
                var vm = new BasicLessonViewModel()
                {
                    Id = item.Id,
                    LessonName = item.Name,
                    Description = item.Description

                };

                if (item.AcademicYearId.HasValue)
                {
                    vm.AcademicYearId = item.AcademicYearId.Value;
                }

                if (item.ClassNameId.HasValue)
                {
                    vm.ClassName = item.Class.Name;
                }

                if (item.SubjectId.HasValue)
                {
                    vm.SubjectName = item.SubjectAcedemicLevel.Subject.Name;
                }


                vml.Add(vm);
            }

            var container = new PaginatedItemsViewModel<BasicLessonViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vml);

            return container;

        }
        public LessonViewModel GetLessonById(int id)
        {
            var response = new LessonViewModel();

            var lesson = schoolDb.Lessons.FirstOrDefault(u => u.Id == id);

            response.Id = lesson.Id;
            response.LessonDetail.LessonId = lesson.Id;
            response.LessonDetail.Name = lesson.Name;
            response.LessonDetail.AcademicLevelId = lesson.AcademicLevelId.HasValue ? lesson.AcademicLevelId.Value : 0;
            response.LessonDetail.ClassNameId = lesson.ClassNameId.HasValue ? lesson.ClassNameId.Value : 0;
            response.LessonDetail.AcademicYearId = lesson.AcademicYearId.HasValue ? lesson.AcademicYearId.Value : 0;
            response.LessonDetail.SubjectId = lesson.SubjectId.HasValue ? lesson.SubjectId.Value : 0;
            response.LessonDetail.LearningOutcome = lesson.LearningOutcome;
            response.LessonDetail.Description = lesson.Description;
            response.LessonDetail.PlannedDate = lesson.PlannedDate;

            lesson.Topics.ToList().ForEach(t =>
            {
                var topic = new TopicViewModel()
                {
                    Id = t.Id,
                    LessonId = t.LessonId,
                    Name = t.Name,
                    SequenceNo = t.SequenceNo,
                    LearningExperience = t.LearningExperience,
                    IsActive = t.IsActive,
                    CreatedOn = t.CreatedOn,
                    ModifiedOn = t.ModifiedOn
                };

                t.TopicContents.ToList().ForEach(tc =>
                {
                    var topicContent = new TopicContentViewModel()
                    {
                        Id = tc.Id,
                        TopicId = tc.TopicId,
                        Name = tc.Name,
                        Introduction = tc.Introduction,
                        ContentType = tc.ContentType,
                        Content = tc.Content,
                        CreatedOn = tc.CreatedOn,
                        UpdatedOn = tc.UpdatedOn
                    };

                    topic.TopicContents.Add(topicContent);

                });

                response.Topics.Add(topic);

            });

            return response;




        }

        public async Task<LessonViewModel> CreateNewLesson(string userName)
        {
            var loggedInUser = currentUserService.GetUserByUsername(userName);

            var totalLessonCount = schoolDb.Lessons.Where(x => x.OwnerId == loggedInUser.Id && x.IsActive == true).Count();

            var lesson = new Lesson()
            {
                OwnerId = loggedInUser.Id,
                Name = $"Lesson {totalLessonCount + 1}",
                CreatedOn = DateTime.UtcNow,
                CreatedById = loggedInUser.Id,
                UpdatedOn = DateTime.UtcNow,
                UpdatedById = loggedInUser.Id,
                Status = LessonStatus.Design,
                IsActive = true,
                AcademicYearId = schoolDb.AcademicYears.Select(x => x.Id).Max(),
                VersionNo = 1
            };

            schoolDb.Add(lesson);
            await schoolDb.SaveChangesAsync();

            var response = new LessonViewModel()
            {
                Id = lesson.Id,
            };

            response.LessonDetail.Name = lesson.Name;
            response.LessonDetail.Status = lesson.Status;


            return response;

        }

    public async Task<TopicContentViewModel> UploadTopicContentFile(TopicContentViewModel vm, IFormFile file, string userName)
    {
      try
      {
        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        string fileURL = await azureBlobService.UploadAsync(file.OpenReadStream(), fileName, file.ContentType);

        var record = schoolDb.TopicContents.FirstOrDefault(x => x.Id == vm.Id);
        record.Content = fileURL;
        record.ContentType = vm.ContentType;

        schoolDb.TopicContents.Update(record);

        await schoolDb.SaveChangesAsync();

        vm.Content = fileURL;
      }
      catch(Exception ex)
      {
        //Log error 
      }


      return vm;
    }
  }
}
