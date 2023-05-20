using Microsoft.EntityFrameworkCore;
using MYUPDZ.Infrastructure.Context;

namespace MYUPDZ.Infrastructure.Persistance
{
    public class DatabaseInitializer
    {
        private readonly ApplicationDbContext _context;

        public DatabaseInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                throw new Exception("An error occurred while initializing the database.", ex);
            }
        }
    }
}
