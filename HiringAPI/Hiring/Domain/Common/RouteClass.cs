using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public static class RouteClass
    {
        public static class AuthRoute
        {
            public const string Login = "Auth/Login";
            public const string Register = "Auth/Register";
        }
        public static class AdminJobCategoryRoute
        {
            public const string CreateUpdateCategory = "AdminJobCategory/CreateUpdateCategory";
            public const string DeleteJobCategory = "AdminJobCategory/DeleteJobCategory";
            public const string GetAllJobCategory = "AdminJobCategory/GetAllJobCategory";
        }

        public static class AdminRoute
        {
            public const string GetEmployers = "AcceptOrRefuseEmolyer/GetEmployers";
            public const string UpdateActivationOfUser = "AcceptOrRefuseEmolyer/UpdateActivationOfUser";
        }
        public static class JobRoute
        {
            public const string GetCatgories = "Job/GetCatgories";
            public const string AddJob = "Job/AddJob";
            public const string DeleteJob = "Job/DeleteJob";

        }
    }
}
