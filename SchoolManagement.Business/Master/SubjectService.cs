using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.Model.Common.Enums;
using SchoolManagement.Util.Constants.ServiceClassConstants;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using SchoolManagement.ViewModel.Master.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Master
{
    public class SubjectService : ISubjectService
    {
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public SubjectService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)//ctor and press double tab
        {
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }


        public async Task<ResponseViewModel> DeleteSubject(int id)
        {
            var response = new ResponseViewModel();

            try
            {   
                var subject = schoolDb.HeadOfDepartment.FirstOrDefault(x => x.Id == id);
                
                subject.IsActive = false;

                schoolDb.HeadOfDepartment.Update(subject);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = SubjectServiceConstants.SUBJECT_DELETE_SUCCESS_MESSAGE;
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            return response;
        }
        public List<SubjectViewModel> GetAllSubjects()
        {
            var response = new List<SubjectViewModel>();
            
            var query = schoolDb.HeadOfDepartment.Where(s => s.IsActive == true);
            
            var SubjectList = query.ToList();
            
            foreach (var subject in SubjectList)
            {
                 var subjectAcademicLevel = new List<DropDownViewModel>();
                 
                 var subjectAcademicLevelList = schoolDb.SubjectAcademicLevels.Where(row => row.SubjectId == subject.Id).ToList();

                    foreach (var item in subjectAcademicLevelList)
                    {
                        var subjectAcademicLevelVM = new DropDownViewModel
                        {                            
                            Id = item.AcademicLevelId,
                            Name = item.AcademicLevel.Name,
                        };
                        subjectAcademicLevel.Add(subjectAcademicLevelVM);
                    }

                var vm = new SubjectViewModel
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    SubjectCode = subject.SubjectCode,
                    SubjectCategory = subject.SubjectCategory,
                    SubjectCategoryName = subject.SubjectCategory.ToString(),
                    ParentBasketSubjectId = subject.ParentBasketSubjectId,
                    ParentBasketSubjectName = GetParentBasketSubjectName(subject.ParentBasketSubjectId),
                    SubjectStreamId = subject.SubjectStreamId,
                    SubjectStreamName = subject.SubjectStream.Name,
                    IsActive = subject.IsActive,
                    SubjectAcademicLevels = subjectAcademicLevel,
                    CreatedByName = subject.CreatedBy.FullName,
                    CreatedOn = subject.CreatedOn,
                    UpdatedByName = subject.UpdatedBy.FullName,
                    UpdatedOn = subject.UpdatedOn,
                };

                if (subject.IsBuscketSubject == false && subject.IsParentBasketSubject == false)
                {
                    vm.SubjectType = SubjectType.NormalSubject;
                }
                else if (subject.IsParentBasketSubject == true)
                {
                    vm.SubjectType = SubjectType.ParentBasketSubject;
                }
                else
                {
                    vm.SubjectType = SubjectType.BasketSubject;
                }


                response.Add(vm);
            }
            return response;
        }
        public async Task<ResponseViewModel> SaveSubject(SubjectViewModel vm, string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var subject = schoolDb.HeadOfDepartment.FirstOrDefault(x => x.Id == vm.Id);

                if(subject == null)
                {
                    subject = new Subject()
                    {
                        Id = vm.Id,
                        Name = vm.Name,
                        SubjectCode = vm.SubjectCode,
                        SubjectCategory = (SubjectCategory)vm.CategorysId,
                        ParentBasketSubjectId =vm.ParentBasketSubjectId,
                        SubjectStreamId = vm.SubjectStreamId,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = loggedInUser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id,
                     };

                    if (vm.SubjectType == SubjectType.BasketSubject)
                    {
                        subject.IsBuscketSubject = true;
                        subject.IsParentBasketSubject = false;
                    }
                    else if (vm.SubjectType == SubjectType.ParentBasketSubject)
                    {
                        subject.IsParentBasketSubject = true;
                        subject.IsBuscketSubject = false;
                    }
                    else
                    {
                        subject.IsBuscketSubject = false;
                        subject.IsParentBasketSubject = false;
                    }



                    schoolDb.HeadOfDepartment.Add(subject);
                    await schoolDb.SaveChangesAsync();

                    var insetedId = schoolDb.HeadOfDepartment.Max(x =>x.Id);

                    subject.SubjectAcademicLevels = new HashSet<SubjectAcademicLevel>();

                    foreach(var unit in vm.SubjectAcademicLevels)
                    {
                        var subjectAcademicLevel = new SubjectAcademicLevel()
                        {
                            SubjectId = insetedId,
                            AcademicLevelId=unit.Id,
                        };

                        subject.SubjectAcademicLevels.Add(subjectAcademicLevel);
                        schoolDb.SubjectAcademicLevels.Add(subjectAcademicLevel);
                    }
                    response.IsSuccess = true;
                    response.Message = SubjectServiceConstants.NEW_SUBJECT_SAVE_SUCCESS_MESSAGE;
                }
                else
                {
                    subject.Name = vm.Name;
                    subject.SubjectCode = vm.SubjectCode;
                    subject.SubjectCategory = (SubjectCategory)vm.CategorysId;
                    subject.ParentBasketSubjectId = vm.ParentBasketSubjectId;
                    subject.SubjectStreamId = vm.SubjectStreamId;
                    subject.IsActive = true;
                    subject.UpdatedOn = DateTime.UtcNow;
                    subject.UpdatedById = loggedInUser.Id;

                    var existingSubjects = subject.SubjectAcademicLevels.ToList();
                    var selectedSubject = vm.SubjectAcademicLevels.ToList();
                   
                    foreach (var deletedsubject in existingSubjects)
                    {
                        subject.SubjectAcademicLevels.Remove(deletedsubject);
                    }


                    foreach (var item in selectedSubject)
                    {
                        var subjectAccodemicLevel = new SubjectAcademicLevel()
                        {
                            SubjectId = vm.Id,
                            AcademicLevelId= item.Id,
                        };

                        subject.SubjectAcademicLevels.Add(subjectAccodemicLevel);
                    }

                    schoolDb.HeadOfDepartment.Update(subject);

                    response.IsSuccess = true;
                    response.Message = SubjectServiceConstants.SUBJECT_UPDATE_SUCCESS_MESSAGE;
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
        public SubjectViewModel GetSubjectbyId(int id)
        {
            var response = new SubjectViewModel();

            var subject = schoolDb.HeadOfDepartment.FirstOrDefault(x => x.Id == id);

            response.Id = subject.Id;
            response.Name = subject.Name;
            response.SubjectCode = subject.SubjectCode;
            response.SubjectCategory = subject.SubjectCategory;
            response.SubjectCategoryName = subject.SubjectCategory.ToString();

            if (subject.IsBuscketSubject == false && subject.IsParentBasketSubject == false)
            {
                response.SubjectType = SubjectType.NormalSubject;
            }
            else if (subject.IsParentBasketSubject == true)
            {
                response.SubjectType = SubjectType.ParentBasketSubject;
            }
            else
            {
                response.SubjectType = SubjectType.BasketSubject;
            }
            response.ParentBasketSubjectId = subject.ParentBasketSubjectId;
            response.ParentBasketSubjectName = GetParentBasketSubjectName(subject.ParentBasketSubjectId);
            response.SubjectStreamId = subject.SubjectStreamId;
            response.SubjectStreamName = subject.SubjectStream.Name;

            var subjectAcademicLevels = subject.SubjectAcademicLevels.Where(x => x.SubjectId == subject.Id);

            foreach (var item in subjectAcademicLevels)
            {
                response.SubjectAcademicLevels.Add(new DropDownViewModel() { Id = item.AcademicLevelId, Name = item.AcademicLevel.Name, });
            }

            return response;
        }

        public PaginatedItemsViewModel<BasicSubjectViewModel> GetSubjectList(string searchText, int currentPage, int pageSize)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;

            var vmu = new List<BasicSubjectViewModel>();

            var subjects = schoolDb.HeadOfDepartment.Where(x => x.IsActive == true).OrderBy(s => s.Name);

            if (!string.IsNullOrEmpty(searchText))
            {
                subjects = subjects.Where(x => x.Name.Contains(searchText)).OrderBy(s => s.Name);
            }

            totalRecordCount = subjects.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var subjectList = subjects.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            subjectList.ForEach(subject =>
            {
                var vm = new BasicSubjectViewModel()
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    SubjectCode = subject.SubjectCode,
                    SubjectCategoryName = subject.SubjectCategory.ToString(),
                    ParentBasketSubjectName = GetParentBasketSubjectName(subject.ParentBasketSubjectId),
                    SubjectStreamId = subject.SubjectStreamId,
                    SubjectStreamName = subject.SubjectStream.Name,
                    CreatedByName = subject.CreatedBy.FullName,
                    CreatedOn = subject.CreatedOn,
                    UpdatedByName = subject.UpdatedBy.FullName,
                    UpdatedOn = subject.UpdatedOn,
                };
                vmu.Add(vm);
            });

            var container = new PaginatedItemsViewModel<BasicSubjectViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vmu);

            return container;
        }

        private string GetParentBasketSubjectName(int? ParentBasketSubjectId)
        {
            var quary = schoolDb.HeadOfDepartment.FirstOrDefault(pbs => pbs.Id == ParentBasketSubjectId);
           
            if (quary == null)
            {
                return SubjectServiceConstants.SUBJECT_EMPTY_PARENT_SUBJECT_NAME;
            }
            else
            {
                return quary.Name;
            }      
        }

       
    }
}
                
                 




                    




            
                

