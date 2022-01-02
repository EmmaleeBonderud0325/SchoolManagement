using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.Util;
using SchoolManagement.ViewModel.Master;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Model.Common.Enums;
using SchoolManagement.Util.Constants.ServiceClassConstants;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Master.Academic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SchoolManagement.Business.Master
{
    public class HeadOfDepartmentService : IHeadOfDepartmentService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public HeadOfDepartmentService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config , ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<HeadOfDepartmentViewModel> GetAllHeadOfDepartment()
        {
            var response = new List<HeadOfDepartmentViewModel>();

            var query = schoolDb.HeadOfDepartments.Where(hod => hod.IsActive == true);

            var HeadOfDepartmentList = query.ToList();

            foreach (var HeadOfDepartment in HeadOfDepartmentList)
            {
                var viewModel = new HeadOfDepartmentViewModel
                {
                    Id = HeadOfDepartment.Id,
                    SubjectId = HeadOfDepartment.SubjectId,
                    SubjectName = HeadOfDepartment.Subject.Name,
                    AcademicLevelId = HeadOfDepartment.AcademicLevelId,
                    AcademicLevelName = HeadOfDepartment.AcademicLevel.Name,
                    AcademicYearId = HeadOfDepartment.AcademicYearId,
                    TeacherId = HeadOfDepartment.TeacherId,
                    TeacherName = GetTeacher(HeadOfDepartment.TeacherId),
                    IsActive = HeadOfDepartment.IsActive,
                    CreateOn = HeadOfDepartment.CreateOn,
                    CreatedById = HeadOfDepartment.CreatedById,
                    CreatedByName = HeadOfDepartment.CreatedBy.FullName,
                    UpdateOn = HeadOfDepartment.UpdateOn,
                    UpdatedById = HeadOfDepartment.UpdatedById,
                    UpdatedByName = HeadOfDepartment.UpdatedBy.FullName,
                };

                response.Add(viewModel);

            }

            return response;
        }

        // save and edit head of department
        public async Task<ResponseViewModel> SaveHeadOfDepartment(HeadOfDepartmentViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = currentUserService.GetUserByUsername(userName);

                var HeadOfDepartment = schoolDb.HeadOfDepartments.FirstOrDefault(hod => hod.Id == vm.Id);

                if (HeadOfDepartment == null)
                {
                    HeadOfDepartment = new HeadOfDepartment()
                    {
                        Id = vm.Id,
                        SubjectId = vm.SubjectId,
                        AcademicLevelId = vm.AcademicLevelId,
                        AcademicYearId = vm.AcademicYearId,
                        TeacherId = vm.TeacherId,
                        IsActive = true,
                        CreateOn = DateTime.UtcNow,
                        CreatedById = currentuser.Id,
                        UpdateOn = DateTime.UtcNow,
                        UpdatedById = currentuser.Id,
                    };

                    schoolDb.HeadOfDepartments.Add(HeadOfDepartment);

                    response.IsSuccess = true;
                    response.Message = "Head Of Department successfully created";
                }
                else
                {
                    HeadOfDepartment.SubjectId = vm.SubjectId;
                    HeadOfDepartment.AcademicYearId = vm.AcademicYearId;
                    HeadOfDepartment.AcademicLevelId = vm.AcademicLevelId;
                    HeadOfDepartment.TeacherId = vm.TeacherId;
                    HeadOfDepartment.IsActive = true;
                    HeadOfDepartment.UpdatedById = currentuser.Id;
                    HeadOfDepartment.UpdateOn = DateTime.UtcNow;

                    schoolDb.HeadOfDepartments.Update(HeadOfDepartment);

                    response.IsSuccess = true;
                    response.Message = "Head Of Department successfully updated";
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

        public async Task<ResponseViewModel> DeleteHeadOfDepartment(int id)
        {
            var response = new ResponseViewModel();

            try
            {
                var HeadOfDepartment = schoolDb.HeadOfDepartments.FirstOrDefault(hod => hod.Id == id);

                HeadOfDepartment.IsActive = false;
                schoolDb.HeadOfDepartments.Update(HeadOfDepartment);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Head Of Department is successfully deleted";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }

            return response;
        }

        //Search

        public PaginatedItemsViewModel<BasicHeadOfDepartmentViewModel> GetHeadOfDepartmentList(string searchText, int currentPage, int pageSize)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;

            var vmu = new List<BasicHeadOfDepartmentViewModel>();

            var headOfDepartments = schoolDb.HeadOfDepartments.Where(x => x.IsActive == true).OrderBy(hd => hd.AcademicYearId);

            if (!string.IsNullOrEmpty(searchText))
            {
                headOfDepartments = headOfDepartments.Where(x => x.AcademicLevel.Name.Contains(searchText)).OrderBy(hd => hd.AcademicYearId);
            }

            totalRecordCount = headOfDepartments.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var headOfDepartmentList = headOfDepartments.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            headOfDepartmentList.ForEach(headOfDepartment =>
            {
                var vm = new BasicHeadOfDepartmentViewModel()
                {
                    Id = headOfDepartment.Id,
                    SubjectId = headOfDepartment.SubjectId,
                    SubjectName = headOfDepartment.Subject.Name,
                    AcademicLevelId = headOfDepartment.AcademicLevelId,
                    AcademicLevelName = headOfDepartment.AcademicLevel.Name,
                    AcademicYearId = headOfDepartment.AcademicYearId,
                    TeacherId = headOfDepartment.TeacherId,
                    TeacherName = GetTeacher(headOfDepartment.TeacherId),                 
                    CreateOn = headOfDepartment.CreateOn,
                    CreatedByName = headOfDepartment.CreatedBy.FullName,
                    UpdateOn = headOfDepartment.UpdateOn,                   
                    UpdatedByName = headOfDepartment.UpdatedBy.FullName,
                };
                vmu.Add(vm);
            });

            var container = new PaginatedItemsViewModel<BasicHeadOfDepartmentViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vmu);

            return container;

        }

        //Drop down
        public List<DropDownViewModel> GetAllAcademicYears()
        {
            var academicYears = schoolDb.AcademicYears
                .Where(x => x.IsActive == true)
                .Select(ay => new DropDownViewModel() { Id = ay .Id })
                .Distinct().ToList();

            return academicYears;
        }

        public List<DropDownViewModel> GetAllAcademicLevels()
        {
            var academicLevels = schoolDb.AcademicLevels
                .Where(x => x.IsActive == true)
                .Select(al => new DropDownViewModel() { Id = al.Id, Name = string.Format("{0}", al.Name) })
                .Distinct().ToList();

            return academicLevels;
        }

        public List<DropDownViewModel> GetAllTeachers()
        {
            /* var teachers = schoolDb.UserRoles
                 .Where(x => x.RoleId == (int)RoleType.Teacher)
                 .Select(t => new DropDownViewModel() { Id = t.User.Id, Name = string.Format("{0}", t.User.FullName) })
                 .Distinct().ToList();

             return teachers;*/


            var teachers = schoolDb.SubjectTeachers
                .Where(x => x.IsActive == true)
                .Select(t => new DropDownViewModel() { Id = t.Id, Name = string.Format("{0}", t.Teacher.FullName) })
                .Distinct().ToList();

            return teachers;
        }

        public List<DropDownViewModel> GetAllSubjects ()
        {
            var subjects = schoolDb.Subjects
                .Where(x => x.IsActive == true )
                .Select(s => new DropDownViewModel() { Id = s.Id, Name = string.Format("{0}", s.Name) })
                .Distinct().ToList();

            return subjects;
        }

        private string GetTeacher(int TeacherId)
        {
            var quary = schoolDb.SubjectTeachers.FirstOrDefault(T => T.Id == TeacherId);

            if (quary == null)
            {
                return HeadOfDepartmentServiceConstants.HEAD_OF_DEPARTMENT_TEACHER_NOT_fOUND_MESSAGE;
            }
            else
            {
                return quary.Teacher.FullName;
            }
        }

        //Generate Report method
        public DownloadFileModel downloadHeadOfDepartmentListReport()
        {
            var headofDepartmentListReport = new HeadOfDepartmentListReport();

            byte[] abytes = headofDepartmentListReport.PrepareReport(GetAllHeadOfDepartment());

            var response = new DownloadFileModel();

            response.FileData = abytes;
            response.FileType = "application/pdf";


            return response;
        }

    }

    //generate reports class
    public class HeadOfDepartmentListReport
    {
        #region Declaration
        int _totalColumn = 3;
        Document _document;
        Font _fontStyle;
        iTextSharp.text.pdf.PdfPTable _pdfPTable = new PdfPTable(3);
        iTextSharp.text.pdf.PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        List<HeadOfDepartmentViewModel> _headOfDepartment = new List<HeadOfDepartmentViewModel>();
        #endregion

        public byte[] PrepareReport(List<HeadOfDepartmentViewModel> response)
        {
            _headOfDepartment = response;

            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfPTable.WidthPercentage = 100;
            _pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("TimesNewRoman", 8f, 1);

            iTextSharp.text.pdf.PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfPTable.SetWidths(new float[] { 75f, 75f, 120f });
            #endregion

            this.ReportHeader();
            this.ReportBody();
            _pdfPTable.HeaderRows = 2;
            _document.Add(_pdfPTable);
            _document.Close();
            return _memoryStream.ToArray();

        }

        private void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("TimesNewRoman", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Head Of Department List Report", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("TimesNewRoman", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Head Of Department List", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
        }

        private void ReportBody()
        {
            #region Table header
           
            _pdfPCell = new PdfPCell(new Phrase("Academic Level", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Subject Name", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);
            
            _pdfPCell = new PdfPCell(new Phrase("Teachers' Name", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
            #endregion

            #region Table Body
            _fontStyle = FontFactory.GetFont("TimesNewRoman", 11f, 0);
            foreach (HeadOfDepartmentViewModel vm in _headOfDepartment)
            {

                
                _pdfPCell = new PdfPCell(new Phrase(vm.AcademicLevelName, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _pdfPTable.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase(vm.SubjectName, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _pdfPTable.AddCell(_pdfPCell);
                

                _pdfPCell = new PdfPCell(new Phrase(vm.TeacherName, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();
            }
            #endregion

        }
    }
}
