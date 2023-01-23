using Microsoft.EntityFrameworkCore;
using PharmacyAPI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyAPI.Tests
{
    public class TestHelper
    {
        public PharmacyContext PharmacyContext { get; private set; }

        public TestHelper() 
        {
            var builder = new DbContextOptionsBuilder <PharmacyContext>();
            builder.UseInMemoryDatabase(databaseName: "PharmacyDbInMemory");

            var dbContextOptions = builder.Options;
            PharmacyContext = new PharmacyContext(dbContextOptions);
            //Delete existing db before creating a new one
            PharmacyContext.Database.EnsureDeleted();
            PharmacyContext.Database.EnsureCreated();
        }
    }
}
