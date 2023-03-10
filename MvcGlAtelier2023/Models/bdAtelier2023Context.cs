using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using MVCGLATELIER2023.Models;

namespace MvcGlAtelier2023.Models
{
    public class bdAtelier2023Context:DbContext
    {
        public bdAtelier2023Context():base("ConnAtelier")
        {
           

        }
        public DbSet<Personne> personnes { get; set; }
        public DbSet<Client> clients { get; set; }

        public DbSet<Gerant> gerants { get; set; }

        public System.Data.Entity.DbSet<MvcGlAtelier2023.Models.ClientViewModel> ClientViewModels { get; set; }

       
        public DbSet<Employee> employees { get; set; }
    }
}