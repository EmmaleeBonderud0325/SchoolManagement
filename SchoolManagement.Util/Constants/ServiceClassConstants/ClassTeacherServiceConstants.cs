using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Util.Constants.ServiceClassConstants
{
    public class ClassTeacherServiceConstants
    {
        //ClassTeacher service Error Messages
        public const string CLASS_TEACHER_SAVE_EXCEPTION_MESSAGE = "Error occured. Please try again.";
        public const string CLASS_TEACHER_DELETE_EXCEPTION_MESSAGE = "Error occured. Please try again.";

        //ClassTeacher service Success Messages
        public const string NEW_CLASS_TEACHER_SAVE_SUCCESS_MESSAGE = "New Class has been added successfully.";
        public const string EXISTING_CLASS_TEACHER_SAVE_SUCCESS_MESSAGE = "Class has been updated successfully.";
        public const string CLASS_TEACHER_DELETE_SUCCESS_MESSAGE = "Class has been deleted";
    }
}
