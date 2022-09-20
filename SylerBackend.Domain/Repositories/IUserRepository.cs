using SylerBackend.Domain.Entities;
using SylerBackend.Domain.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SylerBackend.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByAuth(User user);
    }
}
