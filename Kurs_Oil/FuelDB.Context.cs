﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kurs_Oil
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gr691_tkpEntities : DbContext
    {
        public gr691_tkpEntities()
            : base("name=gr691_tkpEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<K_AVGCalculations> K_AVGCalculations { get; set; }
        public virtual DbSet<K_CostCalculations> K_CostCalculations { get; set; }
        public virtual DbSet<K_DistanceCalculations> K_DistanceCalculations { get; set; }
        public virtual DbSet<K_Role> K_Role { get; set; }
        public virtual DbSet<K_TypeFuel> K_TypeFuel { get; set; }
        public virtual DbSet<K_Users> K_Users { get; set; }
    }
}