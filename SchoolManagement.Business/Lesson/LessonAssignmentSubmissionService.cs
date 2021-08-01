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
    public class LessonAssignmentSubmissionService: ILessonAssignmentSubmissionService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;

        public LessonAssignmentSubmissionService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
        }

        public async Task<ResponseViewModel> SaveLessonAssignmentSubmission(LessonAssignmentSubmissionViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());

                var LessonAssignmentSubmissions = schoolDb.LessonAssignmentSubmissions.FirstOrDefault(x => x.Id == vm.Id);


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
