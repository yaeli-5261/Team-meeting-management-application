using MeetSummarizer.Core.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext//, IDataContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<Transcript> Transcripts { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}