using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public static class RouteClass
    {
        public static class Auth
        {
            public const string Login = "Auth/Login";
            public const string Register = "Auth/Register";
        }
        public static class AdminJobCategory
        {
            public const string CreateUpdateCategory = "AdminJobCategory/CreateUpdateCategory";
            public const string DeleteJobCategory = "AdminJobCategory/DeleteJobCategory";
            public const string GetAllJobCategory = "AdminJobCategory/GetAllJobCategory";
        }

        public static class Admin
        {
            public const string GetEmployers = "AcceptOrRefuseEmolyer/GetEmployers";
            public const string UpdateActivationOfUser = "AcceptOrRefuseEmolyer/UpdateActivationOfUser";
        }
    }
}
