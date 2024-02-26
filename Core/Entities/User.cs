using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class User : Entity<int>
{
    //Genel User Field'ları
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool Approved { get; set; }

    //abc123 ==> Plain Text
    //Hashing SHA512, MD5 ==> VEFQWVQWEVQ3543FQECVQ
    //Salting => abc123 + SALT => HASH =>

    public ICollection<RoleUser> Roles { get; set; }
}
