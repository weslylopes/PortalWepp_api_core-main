using SylerBackend.Domain.Entities;
using SylerBackend.Domain.Repositories;
using SylerBackend.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly StylerContext _dbContext;

        public PersonRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
