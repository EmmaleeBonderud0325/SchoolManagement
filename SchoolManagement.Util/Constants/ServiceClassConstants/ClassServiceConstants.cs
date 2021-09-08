using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Util.Constants.ServiceClassConstants
{
    public class ClassServiceConstants
    {
        //Class service Error Messages
        public const string CLASS_SAVE_EXCEPTION_MESSAGE = "Error occured. Please try again.";
        public const string CLASS_DELETE_EXCEPTION_MESSAGE = "Error occured. Please try again.";

        //Class service Success Messages
        public const string NEW_CLASS_SAVE_SUCCESS_MESSAGE = "New Class has been added successfully.";
        public const string EXISTING_CLASS_SAVE_SUCCESS_MESSAGE = "Class has been updated successfully.";
        public const string CLASS_DELETE_SUCCESS_MESSAGE = "Class has been deleted";

        //Class Category dropdown list
        public const string CLASS_CATEGORY_PRIMARY = "Primary";
        public const string CLASS_CATEGORY_SECONDARY= "Secondary";
        public const string CLASS_CATEGORY_OLEVEL = "O/Level";
        public const string CLASS_CATEGORY_ALEVEL_MATHS = "A/Level-Maths";
        public const string CLASS_CATEGORY_ALEVEL_BIO = "A/Level-Bio";
        public const string CLASS_CATEGORY_ALEVEL_TECH = "A/Level-Technology";
        public const string CLASS_CATEGORY_ALEVEL_COMMERCE = "A/Level-Commerce";
        public const string CLASS_CATEGORY_ALEVEL_ART = "A/Level-Art";

        //Language Stream dropdown list
        public const string LANGUAGE_STREAM_SINHALA = "Sinhala";
        public const string LANGUAGE_STREAM_ENGLISH = "English";
        public const string LANGUAGE_STREAM_TAMIL = "Tamil";
        public const string LANGUAGE_STREAM_OTHER = "Other";
    }
}
