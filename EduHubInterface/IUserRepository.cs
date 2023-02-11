using EduHubEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHubInterface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> SearchAsync(string searchText);
    }
}
