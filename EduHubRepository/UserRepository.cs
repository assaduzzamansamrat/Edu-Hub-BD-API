using EduHubEntity;
using EduHubInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace EduHubRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }
        public async Task<List<User>> SearchAsync(string searchText,string searchFilter,int pageNumber,int pageSize)
        {
            try
            {
                List<User> userList = new List<User>();

                SqlParameter prmSearchText = new SqlParameter("@searchText", searchText);
                SqlParameter prmSearchFilter = new SqlParameter("@searchFilter", searchFilter);
                SqlParameter prmPageNumber = new SqlParameter("@pageNumber", pageNumber);
                SqlParameter prmpageSize = new SqlParameter("@pageSize", pageSize);

                userList = context.Users.FromSqlRaw("GetAllUserListBySearchPrm @searchText,searchFilter,@pageNumber,@pageSize",
                    prmSearchText, prmSearchFilter, prmPageNumber, prmpageSize).ToList();

                return userList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
