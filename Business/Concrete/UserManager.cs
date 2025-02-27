﻿using Business.Abstract;
using Business.Requests.User;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly IRoleService _roleService;
    private readonly ITokenHelper _tokenHelper;

    public UserManager(IUserDal userDal, ITokenHelper tokenHelper, IRoleService roleService = null)
    {
        _userDal = userDal;
        _tokenHelper = tokenHelper;
        _roleService = roleService;
    }

    public void Register(RegisterRequest request)
    {
        byte[] passwordSalt, passwordHash;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

        // TODO: Auto-Mapping
        User user = new User();
        user.Email = request.Email;
        user.Approved = false;
        user.PasswordSalt = passwordSalt;
        user.PasswordHash = passwordHash;

        _userDal.Add(user);
    }

    public AccessToken Login(LoginRequest request)
    {
        User? user = _userDal.Get(i => i.Email == request.Email);
        var roles = _roleService.GetRoles(user.Id);
        // Business Rules...

        bool isPasswordCorrect = HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

        if (!isPasswordCorrect)
            throw new Exception("Şifre yanlış.");
        return _tokenHelper.CreateToken(user, roles);
    }
}
