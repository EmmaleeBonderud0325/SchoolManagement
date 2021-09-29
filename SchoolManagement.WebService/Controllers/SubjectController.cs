using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Master;
using SchoolManagement.ViewModel.Master.Subject;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;
        private readonly IIdentityService identityService;

        public SubjectController(ISubjectService subjectService, IIdentityService identityService)
        {
            this.subjectService = subjectService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult GetAllSubjects()
        {
            var response = subjectService.GetAllSubjects();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubjectViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await subjectService.SaveSubject(vm, userName);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await subjectService.DeleteSubject(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("getSubjectbyId/{id}")]
        public ActionResult GetSubjectbyId(int id)
        {
            var response = subjectService.GetSubjectbyId(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("getSubjectList")]
        public PaginatedItemsViewModel<BasicSubjectViewModel> GetSubjectList(string searchText, int currentPage, int pageSize)
        {
            var response = subjectService.GetSubjectList(searchText, currentPage, pageSize);

            return response;
        }
    }
}
