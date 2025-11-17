using EuphoriaCommerce.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Context;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    
}