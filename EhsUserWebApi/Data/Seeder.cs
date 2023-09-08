using EhsUserWebApi.Models;

namespace EhsUserWebApi.Data
{
    public static class Seeder
    {
        public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<UserMgmtContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {

            }

            return app;
        }

    }

    internal class DbInitializer
    {
        internal static void Initialize(UserMgmtContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            if (!dbContext.Users.Any())
            {
                //Fixture fixture = new Fixture();
                //fixture.Customize<Product>(product => product.Without(p => p.ProductId));
                ////--- The next two lines add 100 rows to you database
                //List<Product> products = fixture.CreateMany<Product>(200).ToList();
                //userMgmtContext.AddRange(products);

                dbContext.Users.Add(new User()
                {
                    FirstName = "Caleb",
                    LastName = "Sandfort",
                    Email = "csandfort@kiss.com"
                });

                dbContext.Users.Add(new User()
                {
                    FirstName = "Adam",
                    LastName = "Nelson",
                    Email = "anelson@kiss.com"
                });

                dbContext.SaveChanges();
            }
        }
    }
}
