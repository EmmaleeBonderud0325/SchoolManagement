using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Util.Constants
{
    public class UserServiceConstants
    {
        //User service Error Messages
        public const string USER_SAVE_EXCEPTION_MESSAGE = "Error occured. Please try again.";
        public const string EXISTING_USER_DELETE_EXCEPTION_MESSAGE = "Error occured. Please try again.";

        //User service validation Messages
        public const string EXISTING_USERNAME_ALLREADY_TAKEN_EXCEPTION_MESSAGE = "Username is allready taken";
        public const string EXISTING_EMAIL_ALLREADY_TAKEN_EXCEPTION_MESSAGE = "Email is allready exist for registered user.";


        //user service Success Messages
        public const string NEW_USER_SAVE_SUCCESS_MESSAGE = "New user has been added successfully.";
        public const string EXISTING_USER_SAVE_SUCCESS_MESSAGE = "Profile has been updated successfully.";
        public const string EXISTING_USER_DELETE_SUCCESS_MESSAGE = "User has been deleted";
    }
}
