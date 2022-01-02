using SchoolManagement.Business.Interfaces;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class SettingProviderService : ISettingProviderService
    {
        private readonly SchoolManagementContext _schoolDb;
        private readonly MasterDbContext _masterDb;
        private readonly ISettingProviderService _settingProviderService;

        public SettingProviderService(SchoolManagementContext _schoolDb, MasterDbContext _masterDb, ISettingProviderService _settingProviderService)
        {
            this._schoolDb = _schoolDb;
            this._masterDb = _masterDb;
            this._settingProviderService = _settingProviderService;
        }
        public EmailSettingViewModel GetEmailSetting(int tenantId)
        {
            var emailSetting = new EmailSettingViewModel();
            try
            {
                var school = _masterDb.Schools.Where(x => x.Id == tenantId).FirstOrDefault();

                emailSetting.SMTP_Server = school.SMTPServer;
                emailSetting.SMTP_Port = school.SMTPPort;
                emailSetting.SMTP_User = school.SMTPUsername;
                emailSetting.SMTP_Password = school.SMTPPassword;
                emailSetting.SMTP_From = school.SMTPFrom;
                emailSetting.SMTP_SSL_Enable = school.IsSMTPUseSSL;
            }
            catch(Exception xe)
            {

            }
            return emailSetting;
        }
    }
}
