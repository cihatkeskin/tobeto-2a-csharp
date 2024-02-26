using Business.Abstract;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class RoleManager : IRoleService
{
    private readonly IRoleDal _roleDal;

    public RoleManager(IRoleDal roleDal)
    {
        _roleDal = roleDal;
    }

    public IList<Role> GetRoles(int userId)
    {

        var allRoles = _roleDal.GetList();

        // Belirli bir kullanıcıya ait rolleri filtrele
        var userRoles = allRoles.Where(role => role.Id == userId).ToList();

        return userRoles;
    }
}
