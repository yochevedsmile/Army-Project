using CovidPortal.web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CovidPortal.web.Data
{
    public class ApplicationDbContext: DbContext
    {
        //ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {  
        }

        //presents a patients collection
        public DbSet<Patient> Patients { get; set; }
       
        //presents a vaccins collection
        public DbSet<VaccinDetails> Vaccins { get; set; }

    }
}
