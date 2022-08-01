using Microsoft.EntityFrameworkCore;

namespace BackendDisneyApi.DataAccess
{
    public class DisneyDBContext : DbContext
    {
        public DisneyDBContext(DbContextOptions<DisneyDBContext> options): base(options)
        {

        }

        // ADD DbSets (Tables DB).
        
    }
}
