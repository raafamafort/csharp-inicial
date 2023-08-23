using Microsoft.EntityFrameworkCore;
using RaslowApplication.Models;

namespace RaslowApplication.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Alunos> Alunos { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {

        }
    }
}
