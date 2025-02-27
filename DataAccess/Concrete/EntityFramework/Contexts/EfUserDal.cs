﻿using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class EfUserDal : EfEntityRepositoryBase<User, int, RentACarContext>, IUserDal
{
    public EfUserDal(RentACarContext context) : base(context)
    {
    }
}
