﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.UserLogins
{
    public class ChangePasswordDto
    {
        public string OldPassWord {  get; set; }

        public string NewPassword { get; set;}

        public string ConfirmPassword {  get; set; }
    }
}
