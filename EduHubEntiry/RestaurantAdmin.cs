using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHubEntity
{
    public class RestaurantAdmin : Entity
    {      
        public string RestaurantName { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public int PackageId { get; set; }
        public int License { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string LogoPath { get; set; }
      
    }
}
