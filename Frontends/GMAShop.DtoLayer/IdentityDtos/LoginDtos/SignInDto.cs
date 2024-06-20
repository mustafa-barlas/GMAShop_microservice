﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.IdentityDtos.LoginDtos
{
    public record SignInDto
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
