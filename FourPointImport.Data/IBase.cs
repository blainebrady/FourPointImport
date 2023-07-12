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

        void OnModelCreating(ModelBuilder modelBuilder);
    }
}
