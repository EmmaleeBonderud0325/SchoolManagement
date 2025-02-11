﻿using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface IClassTeacherService
    {
        List<ClassTeacherViewModel> GetClassTeachers();
        Task<ResponseViewModel> SavaClassTeacher(ClassTeacherViewModel vm, string userName);
        Task<ResponseViewModel> DeleteClassTeacher(int id);
        List<DropDownViewModel> GetAllClassNames();
        List<DropDownViewModel> GetAllAcademicLevels();
        List<DropDownViewModel> GetAllAcademicYears();
        List<DropDownViewModel> GetAllTeachers();
    }
}
