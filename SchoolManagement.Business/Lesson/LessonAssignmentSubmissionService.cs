
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
    public class LessonAssignmentSubmissionService: ILessonAssignmentSubmissionService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public LessonAssignmentSubmissionService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<DropDownViewModel> GetAllLessonAssignments()
        {
            var assignments = schoolDb.LessonAssignments
            .Where(x => x.IsActive == true)
            .Select(la => new DropDownViewModel() { Id = la.Id, Name = string.Format("{0}", la.Name) })
            .Distinct().ToList();

            return assignments;
        }

        public List<DropDownViewModel> GetAllStudents()
        {
            var students = schoolDb.Students
           .Where(x => x.IsActive == true)
           .Select(st => new DropDownViewModel() { Id = st.Id, Name = string.Format("{0}", st.User.FullName) })
           .Distinct().ToList();

            return students;
        }

        public PaginatedItemsViewModel<BasicLessonAssignmnetSubmissionViewModel> GetLessonAssignmentsList(string searchText, int currentPage, int pageSize, int lessonassignmentId)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;

            var vmu = new List<BasicLessonAssignmnetSubmissionViewModel>();

            var lessonassignmentsubmissions = schoolDb.LessonAssignmentSubmissions.OrderBy(u => u.LessonAssignmentId);

            if (!string.IsNullOrEmpty(searchText))
            {
                lessonassignmentsubmissions = lessonassignmentsubmissions.Where(x => x.LessonAssignment.Name.Contains(searchText)).OrderBy(u => u.LessonAssignmentId);
            }

            if (lessonassignmentId > 0)
            {
                lessonassignmentsubmissions = lessonassignmentsubmissions.Where(x => x.LessonAssignmentId== lessonassignmentId).OrderBy(u => u.LessonAssignmentId);
            }


            totalRecordCount = lessonassignmentsubmissions.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var lessonassignmentList = lessonassignmentsubmissions.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            lessonassignmentList.ForEach(lessonassignmentsubmissions =>
            {
                var vm = new BasicLessonAssignmnetSubmissionViewModel()
                {
                    Id = lessonassignmentsubmissions.Id,
                    LessonAssignmentId = lessonassignmentsubmissions.LessonAssignmentId,
                    LessonAssignmentName = lessonassignmentsubmissions.LessonAssignment.Name,
                    StudentId = lessonassignmentsubmissions.StudentId,
                    StudentName = lessonassignmentsubmissions.Student.User.FullName,
                    SubmissionPath = lessonassignmentsubmissions.SubmissionPath,
                    SubmissionDate = lessonassignmentsubmissions.SubmissionDate,
                    Marks = lessonassignmentsubmissions.Marks,
                    TeacherComments = lessonassignmentsubmissions.TeacherComments


                };
                vmu.Add(vm);
            });

            var container = new PaginatedItemsViewModel<BasicLessonAssignmnetSubmissionViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vmu);

            return container;
        }

        /*public List<DropDownViewModel> GetAllStudents()
        {
            var students = schoolDb.Students
            .Where(x => x.IsActive == true)
            .Select(st => new DropDownViewModel() { Id = st.Id, Name = string.Format("{0}", st.User.FullName) })
            .Distinct().ToList();

            return students;
        }
        */


        public List<LessonAssignmentSubmissionViewModel> GetLessonAssignmentSubmissions()
        {
            var response = new List<LessonAssignmentSubmissionViewModel>();

            var query = schoolDb.LessonAssignmentSubmissions.Where(u => u.Id != null);

            var LessonAssignmentSubmissionList = query.ToList();

            foreach (var item in LessonAssignmentSubmissionList)
            {
                var vm = new LessonAssignmentSubmissionViewModel
                {
                    Id = item.Id,
                    LessonAssignmentId = item.LessonAssignmentId,
                    LessonAssignmentName = item.LessonAssignment.Name,
                    StudentId = item.StudentId,
                    StudentName = item.Student.User.FullName,
                    SubmissionPath = item.SubmissionPath,
                    SubmissionDate = item.SubmissionDate,
                    Marks = item.Marks,
                    TeacherComments = item.TeacherComments
                };

                response.Add(vm);
            }
            return response;

        }
        public async Task<ResponseViewModel> SaveLessonAssignmentSubmission(LessonAssignmentSubmissionViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());

                var LessonAssignmentSubmissions = schoolDb.LessonAssignmentSubmissions.FirstOrDefault(x => x.Id == vm.Id);

                var loggedInUser = currentUserService.GetUserByUsername(userName);


                if (LessonAssignmentSubmissions == null)

                {
                    LessonAssignmentSubmissions = new LessonAssignmentSubmission()
                    {
                        Id = vm.Id,
                        LessonAssignmentId = vm.LessonAssignmentId,
                        StudentId = vm.StudentId,
                        SubmissionPath = vm.SubmissionPath,
                        SubmissionDate = vm.SubmissionDate,
                        Marks = vm.Marks,
                        TeacherComments = vm.TeacherComments
                       

                    };

                    schoolDb.LessonAssignmentSubmissions.Add(LessonAssignmentSubmissions);

                    response.IsSuccess = true;
                    response.Message = "Lesson Assignmnet Submission  is Added Successfully";

                }
                else
                {
                   // LessonAssignmentSubmissions.SubmissionPath = vm.SubmissionPath;
                   // LessonAssignmentSubmissions.SubmissionDate = vm.SubmissionDate;
                    LessonAssignmentSubmissions.Marks = vm.Marks;
                    LessonAssignmentSubmissions.TeacherComments= vm.TeacherComments;
                    


                    schoolDb.LessonAssignmentSubmissions.Update(LessonAssignmentSubmissions);

                    response.IsSuccess = true;
                    response.Message = " Lesson Assignment Submission Successfully Updated.";

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
