namespace SchoolManagment.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class StudentRouting
        {
            public const string prefix = Rule + "Student";
            public const string List = prefix + "/List";
            public const string paginated = prefix + "/paginatedList";
            public const string GetByID = prefix + SingleRoute;
            public const string Create = prefix + "/AddStudent";
            public const string Edit = prefix + "/EditStudent";
            public const string Delete = prefix + "/DeleteStudent";

        }
        public static class DepartmentRouting
        {
            public const string prefix = Rule + "Department";
            public const string GetByID = prefix + "/ID";
            public const string GetDepartmentStudentsCount = prefix + "/GetDepartmentStudentsCount";
            public const string GetDepartmentStudentsCountById = prefix + "/GetDepartmentStudentsCountById/{id}";

        }
        public static class ApplicationUserRouting
        {
            public const string prefix = Rule + "User";
            public const string GetByID = prefix + "/ID";
            public const string Email = prefix + "/{email}";
            public const string Create = prefix + "/AddUser";
            public const string paginated = prefix + "/GetUserspaginatedList";
            public const string Edit = prefix + "/Edituser";
            public const string Delete = prefix + "/Deleteuser";
            public const string ChangePassword = prefix + "/ChangePassword";


        }
        public static class Authentication
        {
            public const string prefix = Rule + "Authentication";
            public const string SignIn = prefix + "/SignIn";
            public const string RefreshToken = prefix + "/RefreshToken";
            public const string ValidateToken = prefix + "/ValidateToken";
            public const string SendResetPasswordCode = prefix + "/SendResetPasswordCode";
            public const string ResetPassword = prefix + "/ResetPassword";
            public const string ConfirmResetPassward = prefix + "/ConfirmResetPassward";
            public const string ConfirmEmail = prefix + "/Api/Authentication/ConfirmEmail";


        }
        public static class AuthorizationRouting
        {
            public const string prefix = Rule + "AuthorizationRouting/Role";
            public const string Create = prefix + "/AddRole";
            public const string Update = prefix + "/EditRole";
            public const string Delete = prefix + "/DeleteRole";
            public const string RoleList = prefix + "/RoleList";
            public const string ManageUserRoles = prefix + "/ManageUserRoles/{userId}";
            public const string UpdateUserRoles = prefix + "/UpdateUserRoles";
            public const string UpdateUserClaims = prefix + "/UpdateUserClaims";
            public const string ManageUserclaims = "/ManageUserclaims/{userId}";


        }
        public static class EmailsRoute
        {
            public const string prefix = Rule + "EmailsRoute";
            public const string SendEmail = prefix + "/SendEmail";


        }

    }
}
