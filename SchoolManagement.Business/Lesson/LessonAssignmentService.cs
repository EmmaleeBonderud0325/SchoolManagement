
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



        public async Task<ResponseViewModel> DeleteLessonAssignment(int lessonassignmentid)
        {
            var response = new ResponseViewModel();

            try
            {
                var lessonAssignment = schoolDb.LessonAssignments.FirstOrDefault(x => x.Id == lessonassignmentid);
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

        public List<DropDownViewModel> GetAllLessons()
        {
            var lessons = schoolDb.Lessons
            .Where(x => x.IsActive == true)
            .Select(le => new DropDownViewModel() { Id = le.Id, Name = string.Format("{0}", le.Name) })
            .Distinct().ToList();

            return lessons;
        }

        public List<LessonAssignmentViewModel> GetLessonAssignments()
        {
            var response = new List<LessonAssignmentViewModel>();

            var query = schoolDb.LessonAssignments.Where(u => u.IsActive == true);

            var LessonAssignmentList = query.ToList();

            foreach (var item in LessonAssignmentList)
            {
                var vm = new LessonAssignmentViewModel
                {
                    Id = item.Id,
                    LessonId = item.LessonId,
                    LessonName = item.Lesson.Name,
                    Name = item.Name,
                    Description = item.Description,
                    StartDate = (DateTime)item.StartDate,
                    DuetDate = (DateTime)item.DuetDate,
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    CreatedById = item.CreatedById,
                    CreatedByName = item.CreatedBy.FullName,
                    UpdatedOn = DateTime.UtcNow,
                    UpdatedById = item.UpdatedById,
                    UpdatedByName = item.UpdatedBy.FullName,


                };
                response.Add(vm);
            }

            return response;
        }

        public PaginatedItemsViewModel<BasicLessonAssignmentViewModel> GetLessonList(string searchText, int currentPage, int pageSize, int lessonId)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;

            var vmu = new List<BasicLessonAssignmentViewModel>();

            var lessonassignments = schoolDb.LessonAssignments.OrderBy(u => u.Name); 

            if (!string.IsNullOrEmpty(searchText))
            {
                lessonassignments = lessonassignments.Where(x => x.Lesson.Name.Contains(searchText)).OrderBy(u => u.Name);
            }

            if (lessonId > 0)
            {
                lessonassignments = lessonassignments.Where(x => x.LessonId == lessonId).OrderBy(u => u.Name);
            }


            totalRecordCount = lessonassignments.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var lessonList = lessonassignments.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            lessonList.ForEach(lessonassignments =>
            {
                var vm = new BasicLessonAssignmentViewModel()
                {
                    Id = lessonassignments.Id,
                    LessonId = lessonassignments.LessonId,
                    LessonName= lessonassignments.Lesson.Name,
                    Name = lessonassignments.Name,
                    Description = lessonassignments.Description,
                    StartDate = (DateTime)lessonassignments.StartDate,
                    DuetDate = (DateTime)lessonassignments.DuetDate,
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    CreatedById = lessonassignments.CreatedById,
                    CreatedByName = lessonassignments.CreatedBy.FullName,
                    UpdatedOn = DateTime.UtcNow,
                    UpdatedById = lessonassignments.UpdatedById,
                    UpdatedByName = lessonassignments.UpdatedBy.FullName,


                };
                vmu.Add(vm);
            });

            var container = new PaginatedItemsViewModel<BasicLessonAssignmentViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vmu);

            return container;
        }

        public async Task<ResponseViewModel> SaveLessonAssignment(LessonAssignmentViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {

                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var LessonAssignments = schoolDb.LessonAssignments.FirstOrDefault(x => x.Id == vm.Id);

                


                if (LessonAssignments == null)

                {
                    LessonAssignments = new LessonAssignment()
                    {
                        Id = vm.Id,
                        LessonId = vm.LessonId,
                        Name = vm.Name,
                        Description = vm.Description,
                        StartDate = vm.StartDate,
                        DuetDate = vm.DuetDate,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = loggedInUser.Id,
                        UpdatedOn= DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id
         

                };

                    schoolDb.LessonAssignments.Add(LessonAssignments);

                    response.IsSuccess = true;
                    response.Message = "Lesson Assignmnet   is Added Successfully";

                }
                else
                {
                    LessonAssignments.Name = vm.Name;
                    LessonAssignments.Description = vm.Description;
                    LessonAssignments.StartDate = vm.StartDate;
                    LessonAssignments.DuetDate = vm.DuetDate;
                    LessonAssignments.IsActive = true;
                    LessonAssignments.UpdatedOn = DateTime.UtcNow;
                    LessonAssignments.UpdatedById = loggedInUser.Id;


                    schoolDb.LessonAssignments.Update(LessonAssignments);

                    response.IsSuccess = true;
                    response.Message = " Lesson Assignment Successfully Updated.";
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
