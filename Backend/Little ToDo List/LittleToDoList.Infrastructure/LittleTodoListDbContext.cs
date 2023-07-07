using LittleToDoList.Business.Entities;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace LittleToDoList.Infrastructure;

public class LittleTodoListDbContext : DbContext
{
    public DbSet<ToDo> Todos { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    
    public LittleTodoListDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var todoBuilder = modelBuilder.Entity<ToDo>();
        
        todoBuilder.HasKey(toDo => toDo.Id);
        todoBuilder.Property(toDo => toDo.Name).HasMaxLength(64);
        
        
        var userFriendshipBuilder = modelBuilder.Entity<UserFriendship>();
        
        userFriendshipBuilder.HasKey(friendship => friendship.Id);

        userFriendshipBuilder
            .HasOne(friendship => friendship.FirstUser)
            .WithMany()
            .HasForeignKey(friendship => friendship.FirstUserId);

        userFriendshipBuilder
            .HasOne(friendship => friendship.SecondUser)
            .WithMany()
            .HasForeignKey(friendship => friendship.SecondUserId);

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