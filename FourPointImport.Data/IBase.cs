using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    public interface IBase
    {
        int id { get; set; }
        DateTimeOffset? Archive { get; set; }
        DateTimeOffset CreateOn { get; set; }
        DateTimeOffset? LastUpdated { get; set; }

        //public static void OnModelCreating<TEntity>(ModelBuilder modelBuilder)
        //    where TEntity :class, IBase
        //{
        //    modelBuilder.Entity<TEntity>().HasKey(entity => entity.id);

        //}
        void OnModelCreating(ModelBuilder modelBuilder);
    }
}
