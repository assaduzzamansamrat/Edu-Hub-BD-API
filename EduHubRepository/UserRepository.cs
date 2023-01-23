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
        public List<User> Search(string searchText)
        {
            try
            {
                List<User> userList = new List<User>();
                userList.AddRange(this.GetAll().Where(p => p.FirstName.Contains(searchText)).ToList());
                userList.AddRange(this.GetAll().Where(p => p.LastName.Contains(searchText)).ToList());
                return userList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
