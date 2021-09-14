using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class SubjectTeacherController : ControllerBase
  {
    private readonly ISubjectTeacherService subjectTeacherService;
    private readonly IIdentityService identityService;

    public SubjectTeacherController(ISubjectTeacherService subjectTeacherService, IIdentityService identityService)
    {
      this.subjectTeacherService = subjectTeacherService;
      this.identityService = identityService;
    }

    [HttpPost]
    [Route("getAllSubjectTeachers")]
    public ActionResult GetAllSubjectTeachers(SubjectTeacherFilter filter)
    {
      var response = subjectTeacherService.GetAllSubjectTeachers(filter);
      return Ok(response);
    }

    [HttpPost]
    [Route("saveSubjectTeacher")]
    public async Task<ActionResult> SaveSubjectTeacher([FromBody] SubjectTeachersViewModel vm)
    {
      var userName = identityService.GetUserName();
      var response = await subjectTeacherService.SaveSubjectTeacher(vm, userName);
      return Ok(response);
    }

    [HttpGet]
    [Route("getSubjectTeacherMasterData")]
    public SubjectTeacherMasterDataViewModel GetSubjectTeacherMasterData()
    {
      var response = subjectTeacherService.GetSubjectTeacherMasterData();

      return response;
    }

    [HttpGet]
    [Route("getSubjectsForSelectedAcademicLevel/{academicLevelId}")]
    public List<DropDownViewModel> GetSubjectsForSelectedAcademicLevel(int academicLevelId)
    {
      var response = subjectTeacherService.GetSubjectsForSelectedAcademicLevel(academicLevelId);
      return response;
    }
  }
}


