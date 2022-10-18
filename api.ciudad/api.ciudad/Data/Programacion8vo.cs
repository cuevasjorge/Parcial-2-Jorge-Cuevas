using api.ciudad.Models;
using Microsoft.EntityFrameworkCore;

namespace api.ciudad.Data
{
    public class Programacion8vo : DbContext
    {
        public Programacion8vo(DbContextOptions<Programacion8vo> options) : base(options)
        {


        }
        public DbSet<Clientes> Clientes => Set<Clientes>();
    }
}