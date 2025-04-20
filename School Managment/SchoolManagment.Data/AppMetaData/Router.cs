using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" +version + "/";

        public static class StudentRouting
        {
            public const string prefix = Rule + "Student";
            public const string List = prefix + "/List";
            public const string GetByID = prefix + SingleRoute;

        }

    }
}
