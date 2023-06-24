using EduHubEntity;
using EduHubInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHubRepository
{
    public class RestaurantAdminRepository : Repository<RestaurantAdmin>, IRestaurantAdminRepository
    {
        private readonly AppDbContext context;

        public RestaurantAdminRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<RestaurantAdmin> GetRestaurantAdminByEmailAndPassword(string email, string password)
        {
            try
            {
                RestaurantAdmin restaurantAdmin = new RestaurantAdmin();
                restaurantAdmin = context.Set<RestaurantAdmin>().Where(x => x.EmailAddress == email && x.Password == password).FirstOrDefault();
                return restaurantAdmin;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<RestaurantAdmin>> SearchAsync(string searchText, string searchFilter, int pageNumber, int pageSize)
        {
            try
            {
                List<RestaurantAdmin> restaurantList = new List<RestaurantAdmin>();

                SqlParameter prmSearchText = new SqlParameter("@searchText", searchText);
                SqlParameter prmSearchFilter = new SqlParameter("@searchFilter", searchFilter);
                SqlParameter prmPageNumber = new SqlParameter("@pageNumber", pageNumber);
                SqlParameter prmpageSize = new SqlParameter("@pageSize", pageSize);

                restaurantList = context.RestaurantAdmins.FromSqlRaw("GetAllReastaurantListBySearchPrm @searchText,searchFilter,@pageNumber,@pageSize",
                    prmSearchText, prmSearchFilter, prmPageNumber, prmpageSize).ToList();

                return restaurantList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
