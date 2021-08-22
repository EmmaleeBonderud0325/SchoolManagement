using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.Util;
using SchoolManagement.Util.Constants.ServiceClassConstants;
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

        public async Task<ResponseViewModel> DeleteStudent(int id)
        {
            var response = new ResponseViewModel();

            try
            {
                var student = schoolDb.Students.FirstOrDefault(a => a.Id == id);

                student.IsActive = false;
                schoolDb.Students.Update(student);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = StudentServiceConstants.STUDENT_DISABLE_MESSAGE;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }

            return response;
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

        public async Task<ResponseViewModel> SaveStudent(StudentViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var student = schoolDb.Students.FirstOrDefault(a => a.Id == vm.Id);

                if (student == null)
                {
                    var user = new User()
                    {
                        Id = vm.Id,
                        Username = vm.Email,
                        Email = vm.Email,
                        FullName = vm.FullName,
                        MobileNo = vm.MobileNo,
                        Password = CustomPasswordHasher.GenerateHash(vm.Password),
                        IsActive = true,
                        CreatedById = loggedInUser.Id,
                        CreatedOn = DateTime.UtcNow,
                        UpdatedOn = DateTime.UtcNow,
                        Address = vm.Address,
                        ProfileImage = 0,
                        LastLoginDate = DateTime.UtcNow,
                        LoginSessionId = 0
                    };
                    
                    user.Student = new Student()
                    {
                        Id = user.Id,
                        AdmissionNo = vm.AdmissionNo,
                        EmegencyContactNo1 = vm.EmegencyContactNo1,
                        EmegencyContactNo2 = vm.EmegencyContactNo2,
                        Gender = vm.Gender,
                        DateOfBirth = vm.DateOfBirth,
                        IsActive = true,
                        CreateOn = DateTime.UtcNow,
                        CreatedById = loggedInUser.Id,
                        UpdateOn = DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id,
                    };

                    schoolDb.Students.Add(user.Student);

                    response.IsSuccess = true;
                    response.Message = StudentServiceConstants.NEW_STUDENT_ADD_SUCCESS_MESSAGE;
                }  
                else
                {
                    student.AdmissionNo = vm.AdmissionNo;
                    student.EmegencyContactNo1 = vm.EmegencyContactNo1;
                    student.EmegencyContactNo2 = vm.EmegencyContactNo2;
                    student.Gender = vm.Gender;
                    student.IsActive = true;
                    student.UpdatedById = loggedInUser.Id;
                    student.UpdateOn = DateTime.UtcNow;
                    student.DateOfBirth = vm.DateOfBirth;

                    schoolDb.Students.Update(student);

                    response.IsSuccess = true;
                    response.Message = StudentServiceConstants.STUDENT_UPDATE_MESSAGE;
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
