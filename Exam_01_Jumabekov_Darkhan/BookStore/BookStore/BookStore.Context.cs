﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStore
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BookStoreEntities : DbContext
    {
        public BookStoreEntities()
            : base("name=BookStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Buyers> Buyers { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Reserves> Reserves { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Sellers> Sellers { get; set; }
        public virtual DbSet<Stocks> Stocks { get; set; }
        public virtual DbSet<Substracts> Substracts { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
