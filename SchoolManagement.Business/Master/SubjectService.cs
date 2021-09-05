using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.Util.Constants.ServiceClassConstants;
using SchoolManagement.ViewModel.Common;
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
                var subject = schoolDb.Subjects.FirstOrDefault(x => x.Id == id);
                
                subject.IsActive = false;

                schoolDb.Subjects.Update(subject);
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
            
            var query = schoolDb.Subjects.Where(s => s.IsActive == true);
            
            var SubjectList = query.ToList();
            
            foreach (var subject in SubjectList)
            {
                 var subjectAcademicLevel = new List<SubjectAcademicLevelViewModel>();
                 
                 var subjectAcademicLevelList = schoolDb.SubjectAcademicLevels.Where(row => row.SubjectId == subject.Id).ToList();

                    foreach (var item in subjectAcademicLevelList)
                    {
                        var subjectAcademicLevelVM = new SubjectAcademicLevelViewModel
                        {                            
                            AcademicLevelId = item.AcademicLevelId,
                            AcademicLevelName = item.AcademicLevel.Name,
                        };
                        subjectAcademicLevel.Add(subjectAcademicLevelVM);
                    }

                var vm = new SubjectViewModel
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    SubjectCode = subject.SubjectCode,
                    SubjectCategory = subject.SubjectCategory,
                    SubjectCategoryName = GetSubjectCategoryName(subject.SubjectCategory),
                    IsParentBasketSubject = subject.IsParentBasketSubject,
                    IsBuscketSubject = subject.IsBuscketSubject,
                    ParentBasketSubjectId = subject.ParentBasketSubjectId,
                    ParentBasketSubjectName = GetParentBasketSubjectName(subject.ParentBasketSubjectId),
                    SubjectStreamId = subject.SubjectStreamId,
                    SubjectStreamName = subject.SubjectStream.Name,
                    IsActive = subject.IsActive,
                    CreatedOn = subject.CreatedOn,
                    UpdatedOn = subject.UpdatedOn,
                    SubjectAcademicLevels = subjectAcademicLevel,
                };
                response.Add(vm);
            }
            return response;
        }

        public List<DropDownViewModel> GetAllSubjectStreams()
        {
            var subjectStream = schoolDb.SubjectStreams
                .Where(x => x.IsActive == true)
                .Select(ss => new DropDownViewModel() { Id = ss.Id, Name = string.Format("{0}", ss.Name) })
                .Distinct().ToList();

            return subjectStream;
        }

        public async Task<ResponseViewModel> SaveSubject(SubjectViewModel vm, string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var subject = schoolDb.Subjects.FirstOrDefault(x => x.Id == vm.Id);

                if(subject == null)
                {
                    subject = new Subject()
                    {
                        Id = vm.Id,
                        Name = vm.Name,
                        SubjectCode = vm.SubjectCode,
                        SubjectCategory = vm.SubjectCategory,
                        IsParentBasketSubject = vm.IsParentBasketSubject,
                        IsBuscketSubject = vm.IsBuscketSubject,
                        ParentBasketSubjectId =vm.ParentBasketSubjectId,
                        SubjectStreamId = vm.SubjectStreamId,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = loggedInUser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id,
                     };

                    schoolDb.Subjects.Add(subject);
                    await schoolDb.SaveChangesAsync();

                    var insetedId = schoolDb.Subjects.Max(x =>x.Id);

                    subject.SubjectAcademicLevels = new HashSet<SubjectAcademicLevel>();

                    foreach(var unit in vm.SubjectAcademicLevels)
                    {
                        var subjectAcademicLevel = new SubjectAcademicLevel()
                        {
                            SubjectId = insetedId,
                            AcademicLevelId=unit.AcademicLevelId,
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
                    subject.SubjectCategory = vm.SubjectCategory;
                    subject.IsParentBasketSubject = vm.IsParentBasketSubject;
                    subject.IsBuscketSubject = vm.IsBuscketSubject;
                    subject.ParentBasketSubjectId = vm.ParentBasketSubjectId;
                    subject.SubjectStreamId = vm.SubjectStreamId;
                    subject.IsActive = true;
                    subject.UpdatedOn = DateTime.UtcNow;
                    subject.UpdatedById = loggedInUser.Id;

                    schoolDb.Subjects.Update(subject);

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

        private string GetParentBasketSubjectName(int? ParentBasketSubjectId)
        {
            var quary = schoolDb.Subjects.FirstOrDefault(pbs => pbs.Id == ParentBasketSubjectId);
           
            if (quary == null)
            {
                return SubjectServiceConstants.SUBJECT_EMPTY_PARENT_SUBJECT_NAME;
            }
            else
            {
                return quary.Name;
            }
        
        }
       
        private string GetSubjectCategoryName(SubjectCategory SubjectCategory)
        {
            if (((int)SubjectCategory) == 1)
                 {
                    return "Primary School Subject";
                 }
            else if (((int)SubjectCategory) == 2)
                {
                    return "Junior School Subject";
                }
            else 
                {
                    return "High School Subject";
                }
        }

      
    }
}
                
                 




                    




            
                

