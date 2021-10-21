using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementCRUD.Models
{
    
    public class SubjectContext : DbContext
    {
        public SubjectContext(DbContextOptions<SubjectContext> options) : base(options)
        {

        }
        public DbSet<Subject> Subjects { get; set; }
         
        

    }
}
