using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class EfUserDal : EfEntityRepositoryBase<User, int, RentACarContext>, IUserDal
{
    public EfUserDal(RentACarContext context) : base(context)
    {
    }
}
