using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using SchoolManagement.Business.Interfaces;
using SchoolManagement.Business.Interfaces.AccountData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.Model.Common.Enums;
using SchoolManagement.Util;
using SchoolManagement.Util.Constants;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Account;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class UserService : IUserService
    {
        private readonly SchoolManagementContext schoolDb;
        private readonly MasterDbContext masterDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;
    private readonly IAzureBlobService azureBlobService;
    private StudentExcelContainer studentExcelContainer;

        public UserService(SchoolManagementContext schoolDb, MasterDbContext masterDb, IConfiguration config, ICurrentUserService currentUserService, IAzureBlobService azureBlobService)
        {
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
            this.masterDb = masterDb;
      this.azureBlobService = azureBlobService;

            studentExcelContainer = new StudentExcelContainer();
        }
        public async Task<ResponseViewModel> DeleteUser(int id)
        {
            var response = new ResponseViewModel();
            try
            {
                var user = schoolDb.Users.FirstOrDefault(x => x.Id == id);

                user.IsActive = false;

                schoolDb.Users.Update(user);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = UserServiceConstants.EXISTING_USER_DELETE_SUCCESS_MESSAGE;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = UserServiceConstants.EXISTING_USER_DELETE_EXCEPTION_MESSAGE;
            }

            return response;
        }
        public UserViewModel GetUserbyId(int id)
        {
            var response = new UserViewModel();

            var user = schoolDb.Users.FirstOrDefault(x => x.Id == id);


            response.Id = user.Id;
            response.FullName = user.FullName;
            response.Username = user.Username;
            response.Address = user.Address;
            response.Email = user.Email;
            response.MobileNo = user.MobileNo;
            response.IsActive = user.IsActive;
            response.ProfileImage = user.ProfileImage;

            var assignedRoles = user.UserRoles.Where(x => x.IsActive == true);

            foreach (var item in assignedRoles)
            {
                response.Roles.Add(item.RoleId);
            }

            return response;
        }
        public UserMasterViewModel GetUserDetail(string userName)
        {
            var user = new UserMasterViewModel();

            var loggedInUser = currentUserService.GetUserByUsername(userName);

            user.UserName = loggedInUser.Username;
            user.FullName = loggedInUser.FullName;
            user.Address = loggedInUser.Address;
            user.Email = loggedInUser.Email;
            user.MobileNumber = loggedInUser.MobileNo;
            user.ProfileImage = loggedInUser.ProfileImage;

      return user;
        }
        public List<UserViewModel> GetAllUsersByRole()
        {
            var response = new List<UserViewModel>();

            var query = schoolDb.Users.Where(u => u.IsActive == true);

            //if (vm.Id > 0)
            //{
            //    query = query.Where(x => x.UserRoles.Any(x => x.RoleId == vm.Id)).OrderBy(x => x.FullName);
            //}

            var userList = query.ToList();

            foreach (var user in userList)
            {
                var uvm = new UserViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Username = user.Username,
                    Address = user.Address,
                    Email = user.Email,
                    MobileNo = user.MobileNo,
                    CreatedByName = user.CreatedById.HasValue ? user.CreatedBy.FullName : string.Empty,
                    CreatedOn = user.CreatedOn,
                    UpdatedByName = user.UpdatedById.HasValue ? user.UpdatedBy.FullName : string.Empty,
                    UpdatedOn = user.UpdatedOn,

                };

                var assignedRoles = user.UserRoles.Where(x => x.IsActive == true);


                response.Add(uvm);
            }

            return response;
        }
        public async Task<ResponseViewModel> SaveUser(UserViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var user = schoolDb.Users.FirstOrDefault(x => x.Id == vm.Id);

                var getUserRoles = schoolDb.Roles.FirstOrDefault(x => x.IsActive == true);


                if (user == null)
                {
                    var exisistingUserName = schoolDb.Users.FirstOrDefault(u => u.Username.Trim().ToUpper() == vm.Username.Trim().ToUpper());

                    if (exisistingUserName != null)
                    {
                        response.IsSuccess = false;
                        response.Message = UserServiceConstants.EXISTING_USERNAME_ALLREADY_TAKEN_EXCEPTION_MESSAGE;

                        return response;
                    }

                    var exsitingEmail = schoolDb.Users.FirstOrDefault(u => u.Email.Trim().ToUpper() == vm.Email.Trim().ToUpper());

                    if (exsitingEmail != null)
                    {
                        response.IsSuccess = false;
                        response.Message = UserServiceConstants.EXISTING_EMAIL_ALLREADY_TAKEN_EXCEPTION_MESSAGE;

                        return response;
                    }

                    user = new User()
                    {
                        Id = vm.Id,
                        FullName = vm.FullName,
                        Email = vm.Email,
                        MobileNo = vm.MobileNo,
                        Username = vm.Username,
                        Address = vm.Address,
                        Password = CustomPasswordHasher.GenerateHash(vm.Password),
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = loggedInUser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id
                    };

                    user.UserRoles = new HashSet<UserRole>();

                    foreach (var item in vm.Roles)
                    {
                        var userRole = new UserRole()
                        {
                            RoleId = item,
                            IsActive = true,
                            CreatedById = loggedInUser.Id,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedById = loggedInUser.Id,
                            UpdatedOn = DateTime.UtcNow
                        };

                        user.UserRoles.Add(userRole);
                    }

                    schoolDb.Users.Add(user);
                   
                    //EmailHelper.SendRegisterted(vm.Email, vm.Username, vm.Password);
                    response.IsSuccess = true;
                    response.Message = UserServiceConstants.NEW_USER_SAVE_SUCCESS_MESSAGE;
                }
                else
                {
                    user.Address = vm.Address;
                    user.FullName = vm.FullName;
                    user.Email = vm.Email;
                    user.MobileNo = vm.MobileNo;
                    user.UpdatedById = loggedInUser.Id;
                    user.UpdatedOn = DateTime.UtcNow;

                    var existingRoles = user.UserRoles.ToList();
                    var selectedRols = vm.Roles.ToList();

                    var newRoles = (from r in vm.Roles where !existingRoles.Any(x => x.RoleId == r) select r).ToList();

                    var deletedRoles = (from r in existingRoles where !vm.Roles.Any(x => x == r.RoleId) select r).ToList();

                    foreach (var item in newRoles)
                    {
                        var userRole = new UserRole()
                        {
                            RoleId = item,
                            IsActive = true,
                            CreatedById = loggedInUser.Id,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedById = loggedInUser.Id,
                            UpdatedOn = DateTime.UtcNow
                        };

                        user.UserRoles.Add(userRole);
                    }

                    foreach (var deletedRole in deletedRoles)
                    {
                        user.UserRoles.Remove(deletedRole);
                    }

                    schoolDb.Users.Update(user);

                    response.IsSuccess = true;
                    response.Message = UserServiceConstants.EXISTING_USER_SAVE_SUCCESS_MESSAGE;

                }

                await schoolDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = UserServiceConstants.USER_SAVE_EXCEPTION_MESSAGE;
            }
            return response;
        }
        public List<DropDownViewModel> GetAllRoles()
        {
            return schoolDb.Roles.Where(x => x.IsActive == true).Select(r => new DropDownViewModel() { Id = r.Id, Name = r.Name }).ToList();
        }
        public UserMasterDataViewModel GetUserMasterData()
        {
            var response = new UserMasterDataViewModel();

            response.UserRoles = schoolDb.Roles.Where(x => x.IsActive == true).Select(r => new DropDownViewModel() { Id = r.Id, Name = r.Name }).ToList();
            response.AcademicLevels = schoolDb.AcademicLevels.OrderBy(x => x.Name).Select(a => new DropDownViewModel() { Id = a.Id, Name = a.Name }).ToList();

            return null;
        }
        public PaginatedItemsViewModel<BasicUserViewModel> GetUserList(string searchText, int currentPage, int pageSize, int roleId)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;

            var vmu = new List<BasicUserViewModel>();

            var users = schoolDb.Users.Where(x => x.IsActive == true).OrderBy(u => u.FullName);

            if (!string.IsNullOrEmpty(searchText))
            {
                users = users.Where(x => x.FullName.Contains(searchText)).OrderBy(u => u.FullName);
            }

            if (roleId > 0)
            {
                users = users.Where(x => x.UserRoles.Any(x => x.RoleId == roleId)).OrderBy(x => x.FullName);
            }


            totalRecordCount = users.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var userList = users.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            userList.ForEach(user =>
            {
                var vm = new BasicUserViewModel()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    MobileNo = user.MobileNo,
                    Username = user.Username,
                    Address = user.Address,
                    CreatedByName = user.CreatedById.HasValue ? user.CreatedBy.FullName : string.Empty,
                    CreatedOn = user.CreatedOn,
                    UpdatedByName = user.UpdatedById.HasValue ? user.UpdatedBy.FullName : string.Empty,
                    UpdatedOn = user.UpdatedOn,
                };
                vmu.Add(vm);
            });

            var container = new PaginatedItemsViewModel<BasicUserViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vmu);

            return container;

        }
        public async Task<MasterDataUploadResponse> UploadClassStudents(FileContainerViewModel container, string userName)
        {
            var response = new MasterDataUploadResponse();
            response.IsSuccess = true;

            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);
                var folderPath = config.GetSection("FileUploadPath").Value;

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var upLoadedFiles = new Dictionary<string, string>();

                foreach (var item in container.Files)
                {
                    var filePath = string.Format(@"{0}\{1}", folderPath, item.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }

                    upLoadedFiles.Add(filePath, item.FileName);
                }

                foreach (var item in upLoadedFiles)
                {
                    studentExcelContainer = new StudentExcelContainer();

                    try
                    {
                        var validateResult = ValidateExcelFileContents(item.Key);

                        response.Results.AddRange(validateResult);

                        var validationErrorCount = response.Results.Where(x => x.IsSuccess == false).Count();

                        if (response.IsSuccess == true && validationErrorCount > 0)
                        {
                            response.IsSuccess = false;
                        }
                        else
                        {
                            foreach (var student in studentExcelContainer.Students)
                            {
                                var studentRecord = schoolDb.Users.FirstOrDefault(x => x.Username.Trim().ToLower() == student.Username.Trim().ToLower());
                                if (studentRecord == null)
                                {
                                    studentRecord = new User()
                                    {
                                        FullName = studentRecord.FullName,
                                        Address = studentRecord.Address,

                                    };

                                    studentRecord.UserRoles = new HashSet<UserRole>();

                                    studentRecord.UserRoles.Add(new UserRole()
                                    {
                                        RoleId = (int)RoleType.Student,
                                        CreatedById = loggedInUser.Id,
                                        CreatedOn = DateTime.UtcNow,
                                        UpdatedById = loggedInUser.Id,
                                        UpdatedOn = DateTime.UtcNow
                                    });

                                    //  studentRecord. = new HashSet<StudentClass>();
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            catch (Exception e)
            {

            }

            return response;
        }
        public List<MasterDataFileValidateResult> ValidateExcelFileContents(string fileSavePath)
        {
            var response = new List<MasterDataFileValidateResult>();

            try
            {
                var academicYears = schoolDb.AcademicYears.ToList();
                var academicLevels = schoolDb.AcademicLevels.ToList();

                FileInfo fileInfo = new FileInfo(fileSavePath);
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    //get the first worksheet in the workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["ClassStudents"];

                    int colCount = worksheet.Dimension.End.Column;  //get Column Count
                    int rowCount = worksheet.Dimension.End.Row - 5;

                    var yearValue = worksheet.Cells[1, 2].Value.ToString().Trim();

                    if (!string.IsNullOrEmpty(yearValue))
                    {
                        int enteredYear;

                        if (int.TryParse(yearValue, out enteredYear))
                        {
                            var currentYear = DateTime.Now.Year;
                            if (!(enteredYear == currentYear || enteredYear == currentYear + 1))
                            {
                                response.Add(new MasterDataFileValidateResult()
                                { ValidateMessage = "Invalid user excel template. Year can be current year or next year only.", IsSuccess = false });
                            }
                            else
                            {
                                // studentExcelContainer.Year = schoolDb.AcademicYears.FirstOrDefault(x =>x.Id == yearValue).Id;
                            }
                        }
                        else
                        {
                            response.Add(new MasterDataFileValidateResult()
                            { ValidateMessage = "Invalid user excel template. Invalid Year format has been entered.", IsSuccess = false });
                        }

                    }
                    else
                    {
                        response.Add(new MasterDataFileValidateResult()
                        { ValidateMessage = "Invalid user excel template. Academic year is not entered.", IsSuccess = false });
                    }
                    var academicLevel = worksheet.Cells[2, 2].Value.ToString().Trim().ToLower();

                    var enteredAcademicLevel = schoolDb.AcademicLevels.FirstOrDefault(x => x.Name.Trim().ToLower() == academicLevel);

                    if (enteredAcademicLevel != null)
                    {
                        studentExcelContainer.AcademicLevelId = enteredAcademicLevel.Id;
                    }
                    else
                    {
                        response.Add(new MasterDataFileValidateResult()
                        { ValidateMessage = "Invalid user excel template. Academic Level value does not exists or invalid Academic Levele value has been entered.", IsSuccess = false });
                    }

                    if (studentExcelContainer.AcademicYear > 0 && studentExcelContainer.AcademicLevelId > 0)
                    {
                        var classValue = worksheet.Cells[3, 2].Value.ToString().Trim().ToLower();

                        var enteredClass = schoolDb.Classes
                            .FirstOrDefault(x => x.Name.Trim().ToLower() == classValue && x.AcademicLevelId == studentExcelContainer.AcademicLevelId /*x.AcademicYear == studentExcelContainer.AcademicYear*/);

                        if (enteredClass != null)
                        {
                            studentExcelContainer.ClassId = enteredClass.ClassNameId;
                        }
                        else
                        {
                            response.Add(new MasterDataFileValidateResult()
                            { ValidateMessage = "Invalid user excel template. Class name value does not exists or invalid class name value has been entered.", IsSuccess = false });
                        }

                    }

                    var teacherValue = worksheet.Cells[4, 2].Value.ToString().Trim().ToLower();

                    var enterTeacher = schoolDb.Users
                         .FirstOrDefault(x => x.Username.Trim().ToLower() == teacherValue);

                    if (enterTeacher != null)
                    {
                        studentExcelContainer.ClassTeacherId = enterTeacher.Id;
                    }
                    else
                    {
                        response.Add(new MasterDataFileValidateResult()
                        { ValidateMessage = "Invalid user excel template. Teacher username does not exists or invalid teacher username has been entered.", IsSuccess = false });
                    }

                    if (colCount != 3)
                    {
                        response.Add(new MasterDataFileValidateResult()
                        { ValidateMessage = "Invalid user excel template. Column count does not match.", IsSuccess = false });
                    }
                    else
                    {
                        response.Add(new MasterDataFileValidateResult()
                        { ValidateMessage = "Uploaded user excel template valid.", IsSuccess = true });
                    }

                    for (int row = 6; row <= rowCount; row++)
                    {
                        var user = new UserViewModel();

                        for (int col = 1; col <= colCount; col++)
                        {
                            if (row == 6)
                            {
                                if (col == 1)
                                {
                                    if (worksheet.Cells[row, col].Value.ToString().Trim() != "IndexNo")
                                    {
                                        response.Add(new MasterDataFileValidateResult()
                                        { ValidateMessage = "Invalid excel file. IndexNo column (Column index 0) is missing.", IsSuccess = false });
                                    }
                                }
                                else if (col == 2)
                                {
                                    if (worksheet.Cells[row, col].Value.ToString().Trim() != "Full Name")
                                    {
                                        response.Add(new MasterDataFileValidateResult()
                                        { ValidateMessage = "Invalid excel file. Full Name column (Column index 1) is missing.", IsSuccess = false });

                                    }
                                }
                                else if (col == 3)
                                {
                                    if (worksheet.Cells[row, col].Value.ToString().Trim() != "Gender")
                                    {
                                        response.Add(new MasterDataFileValidateResult()
                                        { ValidateMessage = "Invalid excel file. Gender column (Column index 2) is missing.", IsSuccess = false });

                                    }
                                }

                            }
                            else
                            {
                                if (col == 1)
                                {
                                    var indexNo = worksheet.Cells[row, col].Value == null ? string.Empty : worksheet.Cells[row, col].Value.ToString().Trim();
                                    if (!string.IsNullOrEmpty(indexNo))
                                    {
                                        user.Username = indexNo;
                                    }
                                    else
                                    {
                                        response.Add(new MasterDataFileValidateResult()
                                        { ValidateMessage = "Empty index number found in row " + row.ToString() + ".", IsSuccess = false });
                                    }
                                }
                                else if (col == 2)
                                {
                                    var fullName = worksheet.Cells[row, col].Value == null ? string.Empty : worksheet.Cells[row, col].Value.ToString().Trim();
                                    if (!string.IsNullOrEmpty(fullName))
                                    {
                                        user.FullName = fullName;
                                    }
                                    else
                                    {
                                        response.Add(new MasterDataFileValidateResult()
                                        { ValidateMessage = "Full name can not be empty in row " + row.ToString() + ".", IsSuccess = false });
                                    }

                                }
                                else if (col == 3)
                                {
                                    var gender = worksheet.Cells[row, col].Value == null ? string.Empty : worksheet.Cells[row, col].Value.ToString().Trim();
                                    if (!string.IsNullOrEmpty(gender))
                                    {

                                        // user.Gender = gender;
                                    }
                                    else
                                    {
                                        response.Add(new MasterDataFileValidateResult()
                                        { ValidateMessage = "Gender can not be empty in row " + row.ToString() + ".", IsSuccess = false });
                                    }
                                }
                            }

                            if (row > 6)
                                studentExcelContainer.Students.Add(user);

                        }
                    }





                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;

        }
        public async Task<ResponseViewModel> UpdateUserMasterData(UserMasterViewModel vm, string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                loggedInUser.Username = vm.UserName;
                loggedInUser.FullName = vm.FullName;
                loggedInUser.Address = vm.Address;
                loggedInUser.MobileNo = vm.MobileNumber;
                loggedInUser.UpdatedById = loggedInUser.Id;
                loggedInUser.UpdatedOn = DateTime.UtcNow;

                schoolDb.Users.Update(loggedInUser);

                response.IsSuccess = true;
                response.Message = UserServiceConstants.EXISTING_USER_SAVE_SUCCESS_MESSAGE;

                await schoolDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = UserServiceConstants.USER_SAVE_EXCEPTION_MESSAGE;
            }


            return response;

        }

        public DownloadFileModel downloadUserListReport()
        {
            var userListReport = new UserListReport();

            byte[] abytes = userListReport.PrepareReport(GetAllUsersByRole());

            var response = new DownloadFileModel();

            response.FileData = abytes;
            response.FileType = "application/pdf";


            return response;
        }

    public  async Task<ResponseViewModel> UploadUserImage(FileContainerViewModel container, string userName)
    {
      var response = new ResponseViewModel();
      try
      {
        var file = container.Files.FirstOrDefault();
        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        string fileURL = await azureBlobService.UploadAsync(file.OpenReadStream(), fileName, file.ContentType);

        var loggedInUser = currentUserService.GetUserByUsername(userName);

        loggedInUser.ProfileImage = fileURL;

        schoolDb.Users.Update(loggedInUser);

        await schoolDb.SaveChangesAsync();

        response.IsSuccess = true;
        response.Message = "user image has been updated";
      }
      catch (Exception ex)
      {
        //Log error

        response.IsSuccess = false;
        response.Message = "Error has been occerd";
      }


      return response;
    }
  }



    public class UserListReport
    {
        #region Declaration
        int _totalColumn = 3;
        Document _document;
        Font _fontStyle;
        iTextSharp.text.pdf.PdfPTable _pdfPTable = new PdfPTable(3);
        iTextSharp.text.pdf.PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        List<UserViewModel> _user = new List<UserViewModel>();
        #endregion

        public byte[] PrepareReport(List<UserViewModel> response)
        {
            _user = response;

            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfPTable.WidthPercentage = 100;
            _pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("TimesNewRoman", 8f, 1);

            iTextSharp.text.pdf.PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfPTable.SetWidths(new float[] { 20f, 150f, 100f });
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
            _pdfPCell = new PdfPCell(new Phrase("User List Report", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("TimesNewRoman", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("User List", _fontStyle));
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
            _fontStyle = FontFactory.GetFont("TimesNewRoman", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Full Name", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);


            _pdfPCell = new PdfPCell(new Phrase("Email", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Mobile Number", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
            #endregion

            #region Table Body
            _fontStyle = FontFactory.GetFont("TimesNewRoman", 11f, 0);
            foreach (UserViewModel vm in _user)
            {
                _pdfPCell = new PdfPCell(new Phrase(vm.FullName.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(vm.Email, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(vm.MobileNo, _fontStyle));
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
