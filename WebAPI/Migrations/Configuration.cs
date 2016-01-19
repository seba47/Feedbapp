namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPI.DataAccess.FeedbappContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebAPI.DataAccess.FeedbappContext context)
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


            // IMPORTAR USERS DE URUIT LICENCIAS
            //SELECT 'INSERT INTO Users VALUES ('''
            //+ CAST(descripcion as nvarchar(max)) + ''',',''''
            //+ CAST(usuario as nvarchar(max))
            //+ ''',''' + CAST(email as nvarchar(max)) + ''');'
            //  FROM[UruIT_Licencias].[dbo].[Usuario] where activo = 1


            context.Users.Add(new Models.User() { firstName = "seba", lastName = "cabrera", password = "pass", username = "seba47" });
        }
    }
}
