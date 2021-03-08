using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Models
{
    public class DBInitializer
    {
        public static void Initializer(ForumContext context)
        {
            context.Database.EnsureCreated();

            //Look for any Users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            AppUser shawnaStaff = new AppUser
            {
                UserName = "SStaff",
                Name = "Shawna Staff"
            };
            context.Users.Add(shawnaStaff);
            context.SaveChanges();

            AppUser ivyStaff = new AppUser
            {
                UserName = "IStaff",
                Name = "Ivy Staff"
            };
            context.Users.Add(ivyStaff);
            context.SaveChanges();

            AppUser mikhailGuidesse = new AppUser
            {
                UserName = "MGuidesse",
                Name = "Mikhail Guidesse"
            };
            context.Users.Add(mikhailGuidesse);
            context.SaveChanges();

            ForumPost RoseRed1 = new ForumPost
            {
                Topic = "Rose Red",
                Comments = "I loved this movie!",
                Name = shawnaStaff, Date =
                DateTime.Parse("2020-11-10")
            };
            context.ForumPosts.Add(RoseRed1);
            context.SaveChanges();

            ForumPost ThisMove = new ForumPost
            {
                Topic = "1408",
                Comments = "This movie was a trip",
                Name = ivyStaff,
                Date = DateTime.Parse("2020-11-10")
            };
            context.ForumPosts.Add(ThisMove);
            context.SaveChanges();

            Movie fourTeenOEight = new Movie { Title = "1408", Director = "Mikael Håfström", PremiereDate = DateTime.Parse("2007-06-02"), Genre = "S", Rating = 5 };
            context.Movies.Add(fourTeenOEight);
            context.SaveChanges();

            Movie catsEye = new Movie { Title = "Cat's Eye", Director = "Lewis Teague", PremiereDate = DateTime.Parse("1985-04-12"), Genre = "H", Rating = 5 };
            context.Movies.Add(catsEye);
            context.SaveChanges();

            Movie cell = new Movie { Title = "Cell", Director = "Tod Williams", PremiereDate = DateTime.Parse("2016-05-19"), Genre = "S", Rating = 5 };
            context.Movies.Add(cell);
            context.SaveChanges();

            Movie creepShow = new Movie { Title = "Creep Show", Director = "George A. Romero", PremiereDate = DateTime.Parse("1982-11-12"), Genre = "H", Rating = 5 };
            context.Movies.Add(creepShow);
            context.SaveChanges();

            Movie petCematary = new Movie { Title = "Pet Cematary", Director = "Mary Lambert", PremiereDate = DateTime.Parse("1989-04-21"), Genre = "H", Rating = 5 };
            context.Movies.Add(petCematary);
            context.SaveChanges();

            Novel bagOfBones = new Novel { Title = "Bag Of Bones", Publisher = "Scribner", PulicationDate = DateTime.Parse("1998-09-22"), Genre = "H", Rating = 5, User = ivyStaff };
            context.Novels.Add(bagOfBones);
            context.SaveChanges();

            Novel dreamCatcher = new Novel { Title = "Dream Catcher", Publisher = "Scribner", PulicationDate = DateTime.Parse("2001-02-20"), Genre = "SF", Rating = 5, User = shawnaStaff };
            context.Novels.Add(dreamCatcher);
            context.SaveChanges();

            Novel fireStarter = new Novel { Title = "Firestarter", Publisher = "Viking Press", PulicationDate = DateTime.Parse("1980-09-29"), Genre = "T", Rating = 5, User = mikhailGuidesse };
            context.Novels.Add(fireStarter);
            context.SaveChanges();

            Novel salemsLot = new Novel { Title = "Salem's Lot", Publisher = "Doubleday", PulicationDate = DateTime.Parse("1975-10-07"), Genre = "H", Rating = 5, User = ivyStaff };
            context.Novels.Add(salemsLot);
            context.SaveChanges();

            Novel theTommyKnockers = new Novel { Title = "The Tommy Knockers", Publisher = "G.P. Putnam's & Sons", PulicationDate = DateTime.Parse("1987-11-01"), Genre = "SF", Rating = 5, User = mikhailGuidesse };
            context.Novels.Add(theTommyKnockers);
            context.SaveChanges();


            Genre crime = new Genre { Code = "C", Name = "Crime" };
            context.Genres.Add(crime);
            context.SaveChanges();

            Genre drama = new Genre { Code = "D", Name = "Drama" };
            context.Genres.Add(drama);
            context.SaveChanges();

            Genre fantasy = new Genre { Code = "F", Name = "Fantasy" };
            context.Genres.Add(fantasy);
            context.SaveChanges();

            Genre horror = new Genre { Code = "H", Name = "Horror" };
            context.Genres.Add(horror);
            context.SaveChanges();

            Genre suspense = new Genre { Code = "S", Name = "Suspense" };
            context.Genres.Add(suspense);
            context.SaveChanges();

            Genre sciFi = new Genre { Code = "SF", Name = "Sci-Fi" };
            context.Genres.Add(sciFi);
            context.SaveChanges();
        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<AppUser> userManager =
                serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = "admin";
            string password = "Sesame1!";
            string roleName = "Admin";

            //if role doesn't exist create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            //if username doesn't exist, create it and add it to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                AppUser user = new AppUser { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        public static async Task CreateMemberUser(IServiceProvider serviceProvider)
        {
            UserManager<AppUser> userManager =
                serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = "Miss";
            string password = "Abc123!";
            string roleName = "Member";

            //if role doesn't exist create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            //if username doesn't exist, create it and add it to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                AppUser user = new AppUser { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}

       


        
