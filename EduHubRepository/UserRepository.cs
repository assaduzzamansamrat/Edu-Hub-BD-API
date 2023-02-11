using EduHubEntity;
using EduHubInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHubRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }
        public async Task<List<User>> SearchAsync(string searchText)
        {
            try
            {
                List<User> userList = new List<User>();
                userList.AddRange(await this.GetAllAsync());
                userList.Where(x => x.FirstName.Contains(searchText));
                userList.Where(x => x.LastName.Contains(searchText));
                return userList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
