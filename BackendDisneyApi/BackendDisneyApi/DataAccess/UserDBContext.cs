using BackendDisneyApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendDisneyApi.DataAccess
{
    public class UserDBContext : IdentityDbContext<User>
    {
        private const string Schema = "users";

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);

            builder.Entity<User>()
            .Property(x => x.IsActive)
            .HasDefaultValue(true);
        }
    }
}

