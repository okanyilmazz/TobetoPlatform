using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public class BusinessMessages
    {
        public static string DataNotFound = "This data could not be found.";
        public static string DataAvailable = "This data is available.";

        //User,Authorization
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password is wrong";
        public static string SuccessfulLogin = "Login to the system successful";
        public static string UserAlreadyExists = "This user already exists";
        public static string UserRegistered = "User registered successfully";
        public static string AccessTokenCreated = "Access token created successfully";
        public static string AuthorizationDenied = "You don't have authorization";
        public static string PasswordUncorrect = "Password is incorrect";

    }
}
