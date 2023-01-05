using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Marinel_ui.Data.Entities;
using Marinel_ui.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using static Marinel_ui.Data.SchoolContext;
using Microsoft.Graph;

namespace Marinel_ui.Data
{
    public class SchoolContext : DbContext
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        private const string seedDataFolder = "Data/SeedData";

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<FeedingInfoItem> FeedingInfoItems { get; set; }
        public DbSet<FeedingExpense> FeedingExpenses { get; set; }
        public DbSet<ClassFeeInfoItem> ClassFeeInfoItems { get; set; }
        public DbSet<InventoryType> InventoryTypes { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<BookSale> BookSales { get; set; }
        public DbSet<UniformSale> UniformSales { get; set; }
        public DbSet<PandCUniformSale> PandCUniformSales { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }

        public DbSet<LibraryBook> LibraryBooks { get; set; }
        public DbSet<LibraryBookRental> LibraryBookRentals { get; set; }

        public SchoolContext(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = Environment.GetEnvironmentVariable("StagingConnectionString") ?? _config["StagingConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var contentRootPath = _env.ContentRootPath;

            var classLocation = Path.Combine(contentRootPath, $"{seedDataFolder}/Classes.json");
            var studentLocation = Path.Combine(contentRootPath, $"{seedDataFolder}/Students.json");
            var teacherLocation = Path.Combine(contentRootPath, $"{seedDataFolder}/Teachers.json");
            var expenseTypeLocation = Path.Combine(contentRootPath, $"{seedDataFolder}/ExpenseType.json");
            var inventoryTypeLocation = Path.Combine(contentRootPath, $"{seedDataFolder}/InventoryTypes.json");
            var inventoryItemLocation = Path.Combine(contentRootPath, $"{seedDataFolder}/InventoryItems.json");

            SeedData<Class>(modelBuilder, classLocation);
            SeedData<Student>(modelBuilder, studentLocation);
            SeedData<Teacher>(modelBuilder, teacherLocation);
            SeedData<ExpenseType>(modelBuilder, expenseTypeLocation);
            SeedData<InventoryType>(modelBuilder, inventoryTypeLocation);
            SeedData<InventoryItem>(modelBuilder, inventoryItemLocation);
        }

        private IEnumerable<T> GetEntitiesFromFile<T>(string filePath) where T : class
        {
            var json = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<IEnumerable<T>>(json);
        }

        private void GiveEntityData<T>(ModelBuilder modelBuilder, IEnumerable<T> values) where T : class
        {
            modelBuilder
                .Entity<T>()
                .HasData(values);
        }

        private void SeedData<T>(ModelBuilder modelBuilder, string filePath) where T : class
        {
            GiveEntityData<T>(modelBuilder, GetEntitiesFromFile<T>(filePath));
        }
    }
}
