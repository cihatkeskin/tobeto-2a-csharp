using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class EfRoleDal : EfEntityRepositoryBase<Role, int, RentACarContext>, IRoleDal
{
    public EfRoleDal(RentACarContext context) : base(context)
    {
    }
}
