using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Datalayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlazorWeb.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
