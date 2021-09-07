
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

        public List<LessonAssignmentSubmissionViewModel> GetLessonAssignmentSubmissions()
        {
            var response = new List<LessonAssignmentSubmissionViewModel>();

            var query = schoolDb.LessonAssignmentSubmissions.Where(u => u.StudentId != null);

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
                    LessonAssignmentSubmissions.SubmissionPath = vm.SubmissionPath;
                    LessonAssignmentSubmissions.SubmissionDate = vm.SubmissionDate;
                    LessonAssignmentSubmissions.Marks = vm.Marks;
                    LessonAssignmentSubmissions.TeacherComments= vm.TeacherComments;
                    


                    schoolDb.LessonAssignmentSubmissions.Update(LessonAssignmentSubmissions);
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
