using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    public interface IImport
    {
        int id { get; set; }
        bool Archive { get; set; }
        DateTimeOffset CreateOn { get; set; }
        DateTimeOffset LastUpdated { get; set; }

        public static void OnModelCreating<TEntity>(ModelBuilder modelBuilder)
            where TEntity :class, IImport
        {
            modelBuilder.Entity<TEntity>().HasKey(entity => entity.id);
        }
    }
}
