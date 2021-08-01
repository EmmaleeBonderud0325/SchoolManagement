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
    public class SubjectService : ISubjectService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;

        public SubjectService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)//ctor and press double tab
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;

        }

        public List<SubjectViewModel> GetAllSubjects()
        {
            var response = new List<SubjectViewModel>();

            var query = schoolDb.Subjects.Where(u => u.IsActive == true);

            var SubjectList = query.ToList();

            foreach (var subject in SubjectList)
            {
                var vm = new SubjectViewModel
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    SubjectCode = subject.SubjectCode,
                    SubjectCategory = subject.SubjectCategory,
                    IsParentBasketSubject = subject.IsParentBasketSubject,
                    IsBuscketSubject = subject.IsBuscketSubject,
                    ParentBasketSubjectId = subject.ParentBasketSubjectId,
                    SubjectStreamId = subject.SubjectStreamId,
                    IsActive = subject.IsActive,
                };

                response.Add(vm);

            }

            return response;

        }
    }
}
