﻿using Core.Entities;

namespace Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<Role> roles);
}
