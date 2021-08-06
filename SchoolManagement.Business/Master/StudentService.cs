using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Master
{
    public class StudentService : IStudentService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public StudentService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<StudentViewModel> GetAllStudent()
        {
            var response = new List<StudentViewModel>();

            var query = schoolDb.Students.Where(u => u.IsActive == true);

            var StudentList = query.ToList();

            foreach (var Student in StudentList)
            {
                var viewModelOb = new StudentViewModel
                {
                    Id = Student.Id,
                    AdmissionNo = Student.AdmissionNo,
                    EmegencyContactNo1 = Student.EmegencyContactNo1,
                    EmegencyContactNo2 = Student.EmegencyContactNo2,
                    Gender = Student.Gender,
                    DateOfBirth = Student.DateOfBirth,
                    IsActive = Student.IsActive,
                };

                response.Add(viewModelOb);
            }

            return response;
        }

        public async Task<ResponseViewModel> SaveStudent(StudentViewModel studentView, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var studentIsAvailable = schoolDb.Students.FirstOrDefault(a => a.Id == studentView.Id);

                if (studentIsAvailable == null)
                {
                    studentIsAvailable = new Student()
                    {
                        Id = studentView.Id,
                        AdmissionNo = studentView.AdmissionNo,
                        EmegencyContactNo1 = studentView.EmegencyContactNo1,
                        EmegencyContactNo2 = studentView.EmegencyContactNo2,
                        Gender = studentView.Gender,
                        DateOfBirth = studentView.DateOfBirth,
                        IsActive = true,
                        CreateOn = DateTime.UtcNow,
                        CreatedById = loggedInUser.Id,
                        UpdateOn = DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id,
                    };

                    schoolDb.Students.Add(studentIsAvailable);

                    response.IsSuccess = true;
                    response.Message = "Student added successfully";
                }  
                else
                {
                    response.IsSuccess = false;
                    response.Message = "error";
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
