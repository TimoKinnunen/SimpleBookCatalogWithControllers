﻿using Microsoft.EntityFrameworkCore;
using SimpleBookCatalogWithControllers.Shared.Entities;

namespace SimpleBookCatalogWithControllers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
