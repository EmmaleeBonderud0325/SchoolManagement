﻿using SchoolManagement.Model;
using SchoolManagement.ViewModel.Account;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
    public class StudentViewModel
    {

        public int Id { get; set; }
        public int AdmissionNo { get; set; }
        public string EmegencyContactNo { get; set; }
        public Gender Gender { get; set; }
        public List<DropDownViewModel> AllGenders { get; set; }
        public string GenderName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsActive { get; set; }


        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public int Classes { get; set; }
        public string ClassName { get; set; }
        public int AcademicYear { get; set; }
        public int AcademicLevel { get; set; }

        /*public int ClassNameId { get; set; }
        public string ClassClassName { get; set; }
        public int AcademicLevelId { get; set; }
        public int AcademicYearId { get; set; }
        */
    }
}
