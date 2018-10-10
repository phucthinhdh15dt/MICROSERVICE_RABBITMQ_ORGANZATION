using Microsoft.EntityFrameworkCore;
using PlusTechPlusSystem.Data.ModelOgranzition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.Proccessor.ChangeDbConTextOrganzation
{
    public static class FContextFactory
    {
        public static OrganizationContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrganizationContext>();
            optionsBuilder.UseSqlServer(connectionString);
            // Ensure that the SQLServer database and sechema is created!
            var context = new OrganizationContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
