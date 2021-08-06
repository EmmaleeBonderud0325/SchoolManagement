﻿using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
    public class SubjectViewModel
    {
        public SubjectViewModel()
        {
            SubjectAcademicLevels = new List<SubjectAcademicLevelViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public SubjectCategory SubjectCategory { get; set; }
        public bool IsParentBasketSubject { get; set; }
        public bool IsBuscketSubject { get; set; }
        public int? ParentBasketSubjectId { get; set; }
        public int SubjectStreamId { get; set; }
        public bool IsActive { get; set; }
        public List<SubjectAcademicLevelViewModel> SubjectAcademicLevels { get; set; }

    }
}

           

