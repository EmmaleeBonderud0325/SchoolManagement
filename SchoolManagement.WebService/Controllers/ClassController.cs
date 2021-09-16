using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.ViewModel;
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
    public class ClassController : ControllerBase
    {
        private readonly IClassService classService;
        private readonly IIdentityService identityService;

        public ClassController(IClassService classService, IIdentityService identityService)
        {
            this.classService = classService;
            this.identityService = identityService;
        }


        [HttpGet]
        [Route("getClassList")]
        public PaginatedItemsViewModel<BasicClassViewModel> GetClassList(string searchText, int currentPage, int pageSize, int academicYearId, int academicLevelId)
        {
            var response = classService.GetClassList(searchText, currentPage, pageSize, academicYearId, academicLevelId);

            return response;
        }

        [HttpGet]
        [Route("getClassDetails/{academicYearId}/{academicLevelId}/{classNameId}")]
        public ClassViewModel GetClassDetails(int academicYearId, int academicLevelId, int classNameId)
        {
            var response = classService.GetClassDetails(academicYearId, academicLevelId, classNameId);

            return response;
        }

        [HttpGet]
        [Route("getClassSubjectsForSelectedAcademiclevel/{academicYearId}/{academicLevelId}")]
        public List<ClassSubjectTeacherViewModel> GetClassSubjectsForSelectedAcademiclevel(int academicYearId, int academicLevelId)
        {
            var response = classService.GetClassSubjectsForSelectedAcademiclevel(academicYearId, academicLevelId);

            return response;
        }

        [HttpPost]
        [Route("saveClassDetail")]
        public async Task<ResponseViewModel> SaveClassDetail(ClassViewModel vm)
        {
            var userName = identityService.GetUserName();

            var response = await classService.SaveClassDetail(vm, userName);

            return response;
        }

        [HttpGet]
        [Route("getClassMasterData")]
        public ClassMasterDataViewModel GetClassMasterData()
        {
            var response = classService.GetClassMasterData();

            return response;
        }

        [HttpDelete]
        [Route("deleteClass/{academicYearId}/{academicLevelId}/{classNameId}")]
        public async Task<ResponseViewModel> DeleteClass(int academicYearId, int academicLevelId, int classNameId)
        {
            var userName = identityService.GetUserName();

            var response = await classService.DeleteClass(academicYearId, academicLevelId, classNameId, userName);

            return response;
        }







    }
}
