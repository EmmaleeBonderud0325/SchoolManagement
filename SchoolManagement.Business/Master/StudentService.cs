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

            var studentList = query.ToList();

            foreach (var item in studentList)
            {
                var vm = new StudentViewModel
                {
                    Id = item.Id,
                    AdmissionNo = item.AdmissionNo,
                    EmegencyContactNo1 = item.EmegencyContactNo1,
                    EmegencyContactNo2 = item.EmegencyContactNo2,
                    Gender = item.Gender,
                    DateOfBirth = item.DateOfBirth,
                    IsActive = item.IsActive,
                };

                response.Add(vm);
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
                    //Add student as a user
                    var user = new User()
                    {
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
                    schoolDb.Users.Add(user);
                    await schoolDb.SaveChangesAsync();

                    //get inserted user id
                    var insertedId = schoolDb.Users.Max(i => i.Id);

                    //Add student role to UserRoles table
                    var roleItems = schoolDb.Roles.Where(s => s.Name == "student");
                    foreach (var item in roleItems)
                    {
                        var role = new Role()
                        {
                            Id = item.Id
                        };

                        var userRole = new UserRole()
                        {
                            UserId = insertedId,
                            RoleId = role.Id,
                            IsActive = true,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedOn = DateTime.UtcNow,
                            CreatedById = loggedInUser.Id,
                            UpdatedById = loggedInUser.Id
                        };
                        schoolDb.UserRoles.Add(userRole);
                        await schoolDb.SaveChangesAsync();
                    }

                    //Add student to Student table
                    student = new Student()
                    {
                        Id = insertedId,
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

                    schoolDb.Students.Add(student);

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
                    await schoolDb.SaveChangesAsync();

                    var user = schoolDb.Users.Find(student.Id);
                    user.FullName = vm.FullName;
                    


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
