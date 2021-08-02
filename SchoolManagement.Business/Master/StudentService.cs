using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
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

        public StudentService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
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
    }
}
