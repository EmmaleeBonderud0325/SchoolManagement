using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces;
using SchoolManagement.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.Model.Common.Enums;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class DropDownService : IDropDownService
    {
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;
        public DropDownService(SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        //GetSubject Categorys Type DropDown Service
        public List<DropDownViewModel> GetAllSubjectCategorys()
        {
            var response = Enum.GetValues(typeof(SubjectCategory)).Cast<SubjectCategory>()
                .Select(t => new DropDownViewModel { Id = (int)t, Name = t.ToString() })
                .ToList();

            return response;
        }

        //GetSubject Type DropDown Service
        public List<DropDownViewModel> GetSubjectTypes()
        {
            var response = Enum.GetValues(typeof(SubjectType)).Cast<SubjectType>()
                .Select(t => new DropDownViewModel { Id = (int)t, Name = t.ToString()})
                .ToList();

            return response;

        }
    }
}
