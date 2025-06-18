using Microsoft.AspNetCore.Identity;

namespace MicroelectronicsWarehouse.Entities
{
    public class AppUser : IdentityUser
    {

        public string? FullName { get; set; }
    
    }
}
