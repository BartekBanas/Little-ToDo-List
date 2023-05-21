using LittleToDoList.Business.Entities;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace LittleToDoList.Infrastructure;

public class LittleTodoListDbContext : DbContext
{
    public DbSet<TaskItem> Todos { get; set; } = null!;
    
    public LittleTodoListDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>().HasKey(taskItem => taskItem.Id);
        modelBuilder.Entity<TaskItem>().Property(taskItem => taskItem.Name).HasMaxLength(64);
        
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException dbUpdateException)
        {
            var sqlException = dbUpdateException.InnerException as MySqlException ?? throw dbUpdateException;
            
            // Violation of DISTINCT constraint 
            if (sqlException.Number == 1062)
                throw new Exception("Item duplicated");

            throw;
        }
    }
}