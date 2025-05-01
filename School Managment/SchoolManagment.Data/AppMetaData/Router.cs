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
            public const string List = prefix + "/List";
            public const string paginated = prefix + "/paginatedList";
            public const string GetByID = prefix + SingleRoute;
            public const string Create = prefix + "/AddStudent";
            public const string Edit = prefix + "/EditStudent";
            public const string Delete = prefix + "/DeleteStudent";

        }

    }
}
