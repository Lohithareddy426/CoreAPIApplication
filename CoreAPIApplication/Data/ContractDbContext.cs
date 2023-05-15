using Microsoft.EntityFrameworkCore;
using CoreAPIApplication.Models;

namespace CoreAPIApplication.Data
{
    public class ContractsDbContext : DbContext
    {
        public ContractsDbContext(DbContextOptions<ContractsDbContext> options)
    : base(options)
        {
        }

        //DBSets
        public DbSet<Assignee> Assignees { get; set; } = default!;
        public DbSet<Assignment> Assignments { get; set; } = default!;
        public DbSet<ContractInfo> Contracts { get; set; } = default!;

    }
}
