﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hiring
{
    [ApiController]
    public class ApiControllersBase : ControllerBase
    {
        public string CurrentUserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }

        public string CurrentUserName
        {
            get
            {
                return User.FindFirst(ClaimTypes.Name).Value;
            }
        }

        public string CurrentUserEmail
        {
            get
            {
                return User.FindFirst(ClaimTypes.Email).Value;
            }
        }
    }
 }
