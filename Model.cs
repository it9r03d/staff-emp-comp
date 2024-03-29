using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiDemo {
    public class StaffContext : DbContext {
        public DbSet<Emp> Emp { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=./db/sqldb;");
    }

    public class Comp {
        [Column("id"), Key]
        public int Id { get; set; }
        
        [Column("name"), Required]
        public string Name { get; set; }
    }

    public class Emp {

        [Column("id"), Key]
        public int Id { get; set; }
        
        [Column("name"), Required]
        public string Name { get; set; }
        
        [Column("surname"), Required]
        public string SurName { get; set; }
        
        [Column("phone"), Required]
        public string Phone { get; set; }

        [Column("compid"), ForeignKey("Comp"), Required]
        public int Compid { get; set; }
        public virtual Comp Comp { get; set; }
        
        [Column("passportid"), ForeignKey("Passport"), Required]
        public int Passportid { get; set; }
        public virtual Passport Passport { get; set; }
    }
    
    public class Passport {
        [Column("id"), Key]
        public int Id { get; set; }
            
        [Column("type"), Required]
        public string Type { get; set; }
        
        [Column("number"), Required]
        public string Number { get; set; }
    }
}
