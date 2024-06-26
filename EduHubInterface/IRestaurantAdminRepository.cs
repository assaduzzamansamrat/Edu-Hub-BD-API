﻿using EduHubEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHubInterface
{
    public interface IRestaurantAdminRepository : IRepository<RestaurantAdmin>
    {
        Task<List<RestaurantAdmin>> SearchAsync(string searchText, string searchFilter, int pageNumber, int pageSize);

        Task<RestaurantAdmin> GetRestaurantAdminByEmailAndPassword(string email, string password);
    }
}
