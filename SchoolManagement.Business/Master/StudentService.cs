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
                var user = schoolDb.Users.FirstOrDefault(x => x.Id == id);
                var student = schoolDb.Students.FirstOrDefault(a => a.Id == id);
                var userRole = schoolDb.UserRoles.FirstOrDefault(d => d.UserId == id);

                user.IsActive = false;
                schoolDb.Users.Update(user);
                await schoolDb.SaveChangesAsync();

                userRole.IsActive = false;
                schoolDb.UserRoles.Update(userRole);
                await schoolDb.SaveChangesAsync();

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

            var studentQuery = schoolDb.Students.Where(u => u.IsActive == true);
            var studentList = studentQuery.ToList();
                
            foreach (var item in studentList)
            {
                var user = schoolDb.Users.Find(item.Id);
                //var studentClassList = schoolDb.StudentClasses.Find(item.Id);

                if (user != null)
                {
                    var vm = new StudentViewModel
                    {
                        Id = item.Id,
                        AdmissionNo = item.AdmissionNo,
                        EmegencyContactNo = item.EmegencyContactNo2,
                        //EmegencyContactNo2 = user.MobileNo,
                        Gender = item.Gender,
                        DateOfBirth = item.DateOfBirth,
                        IsActive = item.IsActive,
                        FullName = user.FullName,
                        Email = user.Email,
                        Password = user.Password,
                        MobileNo = user.MobileNo,
                        Username = user.Username,
                        Address = user.Address,
                    };
                    response.Add(vm);
                }
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

                    //get inserted user id  sss
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
                        EmegencyContactNo1 = user.MobileNo,
                        EmegencyContactNo2 = vm.EmegencyContactNo,
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
                    student.EmegencyContactNo1 = vm.MobileNo;
                    student.EmegencyContactNo2 = vm.EmegencyContactNo;
                    student.Gender = vm.Gender;
                    student.IsActive = true;
                    student.UpdatedById = loggedInUser.Id;
                    student.UpdateOn = DateTime.UtcNow;
                    student.DateOfBirth = vm.DateOfBirth;

                    schoolDb.Students.Update(student);
                    await schoolDb.SaveChangesAsync();

                    var user = schoolDb.Users.Find(student.Id);
                    user.FullName = vm.FullName;
                    user.Address = vm.Address;
                    user.UpdatedById = loggedInUser.Id;
                    user.Email = vm.Email;
                    user.MobileNo = vm.MobileNo;
                    user.Username = vm.Username;
                    user.Password = CustomPasswordHasher.GenerateHash(vm.Password);
                    user.UpdatedOn = DateTime.UtcNow;

                    schoolDb.Users.Update(user);
                    await schoolDb.SaveChangesAsync();

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
