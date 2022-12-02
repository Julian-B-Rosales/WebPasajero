using Microsoft.EntityFrameworkCore;
using WebPasajero.Models;

namespace WebPasajero.Data
{
    public class DBWebPasajeroContext : DbContext
    {
        public DBWebPasajeroContext(DbContextOptions<DBWebPasajeroContext> options) : base(options)
        {
        }

        public DbSet<Pasajero> Pasajeros { get; set; }
    }
}
