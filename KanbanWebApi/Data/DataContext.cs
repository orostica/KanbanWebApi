using KanbanWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<Card> Card { get; set; }

    }
}
