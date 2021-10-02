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
    public class MCQQuestionStudentAnswerService : IMCQQuestionStudentAnswerService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public MCQQuestionStudentAnswerService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<MCQQuestionStudetAnswerViewModel> GetAllMCQQuestionStudentAnswers()
        {
            var response = new List<MCQQuestionStudetAnswerViewModel>();
            var query = schoolDb.MCQQuestionStudentAnswers.Where(u => u.QuestionId != null);
            var MCQQuestionStudentAnswerList = query.ToList();

            foreach (var item in MCQQuestionStudentAnswerList)
            {
                var vm = new MCQQuestionStudetAnswerViewModel
                {
                    QuestionId = item.QuestionId,
                    QuestionName = item.MCQQuestionAnswer.Question.QuestionText,
                    StudentId = item.StudentId,
                    StudentName = item.StudentMCQQuestion.Student.User.FullName,
                    MCQQuestionAnswerId = item.MCQQuestionAnswerId,
                    MCQQuestionAnswerName = item.MCQQuestionAnswer.AnswerText,
                    AnswerText = item.AnswerText,
                    SequnceNo = item.SequnceNo,
                    IsChecked = item.IsChecked,
                };
                response.Add(vm);
            }
            return response;
        }


        public async Task <ResponseViewModel> SaveMCQQuestionStudentAnswer (MCQQuestionStudetAnswerViewModel vm, string userName)
        {
            var responce = new ResponseViewModel();
            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());
                var MCQQuestionStudentAnswers = schoolDb.MCQQuestionStudentAnswers.FirstOrDefault(x => x.QuestionId == vm.QuestionId);
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                if (MCQQuestionStudentAnswers == null)
                {
                    MCQQuestionStudentAnswers = new MCQQuestionStudentAnswer()
                    {
                        QuestionId = vm.QuestionId,
                        StudentId = vm.StudentId,
                        MCQQuestionAnswerId = vm.MCQQuestionAnswerId,
                        AnswerText = vm.AnswerText,
                        SequnceNo = vm.SequnceNo,
                        IsChecked = vm.IsChecked,
                    };

                    schoolDb.MCQQuestionStudentAnswers.Add(MCQQuestionStudentAnswers);
                    responce.IsSuccess = true;
                    responce.Message = " MCQ Question Student Answers are added successfully";

                }

                else
                {
                    MCQQuestionStudentAnswers.AnswerText = vm.AnswerText;
                    //MCQQuestionStudentAnswers.SequnceNo = vm.SequnceNo;
                    MCQQuestionStudentAnswers.IsChecked = vm.IsChecked;

                    schoolDb.MCQQuestionStudentAnswers.Update(MCQQuestionStudentAnswers);
                    responce.IsSuccess = true;
                    responce.Message = " MCQ Question Student Answers are Updated successfully";
                }

                await schoolDb.SaveChangesAsync();
            }
            
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.ToString();
            }

            return responce;
        }





        public List<DropDownViewModel> GetAllQuestion()
        {
            var question = schoolDb.Questions
            .Where(x => x.IsActive == true)
            .Select(q => new DropDownViewModel() { Id = q.Id, Name = string.Format("{0}", q.QuestionText) })
            .Distinct().ToList();

            return question;
        }

        public List<DropDownViewModel> GetAllStudentName()
        {
            var student = schoolDb.Students
            .Where(x => x.IsActive == true)
            .Select(s => new DropDownViewModel() { Id = s.Id, Name = string.Format("{0}", s.User.FullName) })
            .Distinct().ToList();

            return student;
        }

        public List<DropDownViewModel> GetAllTeacherAnswer()
        {
            var teacher = schoolDb.MCQQuestionAnswers
             .Where(x => x.Question.Id != null)
             .Select(t => new DropDownViewModel() { Id = t.Id, Name = string.Format("{0}", t.AnswerText) })
             .Distinct().ToList();

            return teacher;
        }

        public PaginatedItemsViewModel<BasicMCQQuestionStudentAnswerViewModel> GetStudentList(string searchText, int currentPage, int pageSize, int studentId, int questionId)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;

            var vmu = new List<BasicMCQQuestionStudentAnswerViewModel>();

            var student = schoolDb.MCQQuestionStudentAnswers.OrderBy(x => x.QuestionId);

            if (!string.IsNullOrEmpty(searchText))
            {
                student = student.Where(x => x.MCQQuestionAnswer.Question.QuestionText.Contains(searchText)).OrderBy(x => x.QuestionId);
            }

            if (studentId > 0)
            {
                student = student.Where(x => x.StudentId == studentId).OrderBy(x => x.StudentId);
            }

            if (questionId > 0)
            {
                student = student.Where(x => x.QuestionId == questionId).OrderBy(x => x.QuestionId);
            }

            totalRecordCount = student.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var studentList = student.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            studentList.ForEach(student =>
            {
                var vm = new BasicMCQQuestionStudentAnswerViewModel()
                {
                    QuestionId = student.QuestionId,
                    QuestionName = student.MCQQuestionAnswer.Question.QuestionText,
                    StudentId = student.StudentId,
                    StudentName = student.StudentMCQQuestion.Student.User.FullName,
                    MCQQuestionAnswerId = student.MCQQuestionAnswerId,
                    MCQQuestionAnswerName = student.MCQQuestionAnswer.AnswerText,
                    AnswerText = student.AnswerText,
                    SequnceNo = student.SequnceNo,
                    IsChecked = student.IsChecked,

                };
                vmu.Add(vm);
            });

            var container = new PaginatedItemsViewModel<BasicMCQQuestionStudentAnswerViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vmu);

            return container;
        }
    }
}
