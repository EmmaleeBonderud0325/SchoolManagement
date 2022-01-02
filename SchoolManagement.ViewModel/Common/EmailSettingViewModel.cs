using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Common
{
    public class EmailSettingViewModel
    {
        public string SMTP_Server { get; set; }
        public int SMTP_Port { get; set; }
        public string SMTP_User { get; set; }
        public string SMTP_Password { get; set; }
        public string SMTP_From { get; set; }
        public bool SMTP_SSL_Enable { get; set; }
        public bool SMTP_HTML_Enable { get; set; }
    }
}
