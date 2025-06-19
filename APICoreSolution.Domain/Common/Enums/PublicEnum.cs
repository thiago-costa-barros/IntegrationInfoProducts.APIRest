﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICoreSolution.Domain.Common.Enums
{
    public enum PublicEnum
    {
        public enum UserType
    {
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0000")]
        ApiMethod = 0,

        [Display(ResourceType = typeof(UserMessages), Name = "ECM0001")]
        TeamUser = 1,

        [Display(ResourceType = typeof(UserMessages), Name = "ECM0002")]
        WorkerProcess = 2,

        [Display(ResourceType = typeof(UserMessages), Name = "ECM0003")]
        Integration = 3,

        [Display(ResourceType = typeof(UserMessages), Name = "ECM0004")]
        ScheduledTask = 4
    }

    public enum TokenType
    {
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0005")]
        AccessToken = 1,
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0006")]
        RefreshToken = 2
    }

    public enum TokenStatus
    {
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0007")]
        Active = 1,
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0008")]
        Expired = 2,
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0009")]
        Revoked = 3,
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0010")]
        Blocked = 4
    }
}

