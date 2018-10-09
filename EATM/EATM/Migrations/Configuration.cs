using EatmClassLibrary;

namespace EATM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EATM.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EATM.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Accounts.AddOrUpdate(a => a.CardNumber,
          new Account() { CardNumber = 1, PinNumber = 111, Balance = 1000 },
          new Account() { CardNumber = 2, PinNumber = 222, Balance = 200 },
          new Account() { CardNumber = 3, PinNumber = 333, Balance = 300 },
          new Account() { CardNumber = 4, PinNumber = 444, Balance = 769 },
          new Account() { CardNumber = 5, PinNumber = 555, Balance = 5356 },
          new Account() { CardNumber = 6, PinNumber = 666, Balance = 2300 },
          new Account() { CardNumber = 7, PinNumber = 777, Balance = 1209 },
          new Account() { CardNumber = 8, PinNumber = 888, Balance = 450 },
          new Account() { CardNumber = 9, PinNumber = 999, Balance = 2350 }

           );
        }
    }
}
