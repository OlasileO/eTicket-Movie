using eTicket.Data.Service;
using eTicket.Data.Static;
using eTicket.Models;
using Microsoft.AspNetCore.Identity;

namespace eTicket.Data
{
    public class AppDbIntalizer
    {
        //public static void seed(IApplicationBuilder applicationBuilder)
        //{
        //    using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        var context = servicescope.ServiceProvider.GetService<AppDbContext>();
        //        context.Database.EnsureCreated();

        //        //Cinema
        //        if (!context.Cinemas.Any())
        //        {
        //            context.Cinemas.AddRange(new List<Cinema>() {
        //                new Cinema()
        //                {
        //                     CinemaName ="Cinema 1",
        //                     CinemaLogoUrl ="http://dotnethow.net/images/cinemas/cinema-1.jpg",
        //                     Description ="This is the description of the first cinema"
        //                },
        //                  new Cinema()
        //                {
        //                   CinemaName ="Cinema 2",
        //                    CinemaLogoUrl ="http://dotnethow.net/images/cinemas/cinema-2.jpg",
        //                    Description="This is the description of the first cinema"
        //                },
        //                    new Cinema()
        //                {
        //                   CinemaName ="Cinema 3",
        //                    CinemaLogoUrl ="http://dotnethow.net/images/cinemas/cinema-3.jpg",
        //                    Description="This is the description of the first cinema"

        //                },
        //                      new Cinema()
        //                {
        //                   CinemaName ="Cinema 4",
        //                    CinemaLogoUrl ="http://dotnethow.net/images/cinemas/cinema-4.jpg",
        //                    Description="This is the description of the first cinema"
        //                },

        //                });
        //            context.SaveChanges();
        //        }
        //        //Actor
        //        if (!context.Actors.Any())
        //        {
        //            context.Actors.AddRange(new List<Actor>()
        //            {
        //                new Actor()
        //                {
        //                    FullName ="Actor 1",
        //                    Biography="This is the description of the first Actor",
        //                    ProfilePictureUrl="http://dotnethow.net/images/actors/actors-1.jpg"
        //                },
        //                 new Actor()
        //                {
        //                    FullName ="Actor 2",
        //                 Biography="This is the description of the first Actor",
        //                    ProfilePictureUrl="http://dotnethow.net/images/actors/actors-2.jpg"
        //                },
        //                  new Actor()
        //                {
        //                    FullName ="Actor 3",
        //                 Biography="This is the description of the first Actor",
        //                    ProfilePictureUrl="http://dotnethow.net/images/actors/actors-3.jpg"
        //                },
        //                   new Actor()
        //                {
        //                    FullName ="Actor 4",
        //                 Biography="This is the description of the first Actor",
        //                    ProfilePictureUrl="http://dotnethow.net/images/actors/actors-4.jpg"
        //                },
        //            });
        //            context.SaveChanges();
        //        }
        //        //Producer
        //        if (!context.Producers.Any())
        //        {
        //            context.Producers.AddRange(new List<Producer> {
        //             new Producer()
        //             {
        //                 FullName="Producer 1",
        //                 Biography="This is the description of the first producer",
        //                 ProfilePictureUrl="http://dotnethow.net/images/producers/producer-1.jpg"

        //             },
        //                new Producer()
        //             {
        //                 FullName="Producer 2",
        //                 Biography="This is the description of the first producer",
        //                 ProfilePictureUrl="http://dotnethow.net/images/producers/producer-2.jpg"

        //             },
        //                   new Producer()
        //             {
        //                 FullName="Producer 3",
        //                 Biography="This is the description of the first producer",
        //                 ProfilePictureUrl="http://dotnethow.net/images/producers/producer-3.jpg"

        //             },
        //                      new Producer()
        //             {
        //                 FullName="Producer 4",
        //                 Biography="This is the description of the first producer",
        //                 ProfilePictureUrl="http://dotnethow.net/images/producers/producer-4.jpg"

        //             }
        //            });
        //            context.SaveChanges();
        //        }
        //        //Movies
        //        if (!context.Movies.Any())
        //        {
        //            context.Movies.AddRange(new List<Movie> {

        //                 new Movie()
        //                 {
        //                    Name="Cold soles",
        //                     Description="This is the description of the first Movie",
        //                     Price=20.00,
        //                     ImageUrl="http://dotnethow.net/images/movies/movie-1.jpg",
        //                     Startdate= DateTime.Now.AddDays(3),
        //                     Enddate= DateTime.Now.AddDays(20),
        //                      CinemaId= 1,
        //                      ProducerId= 4,
        //                      MovieCategory = MovieCategory.Drama
        //                 },
        //                   new Movie()
        //                 {
        //                    Name="scoob",
        //                     Description="This is the description of the first Movie",
        //                     Price=30.00,
        //                     ImageUrl="http://dotnethow.net/images/movies/movie-7.jpg",
        //                     Startdate= DateTime.Now.AddDays(3),
        //                     Enddate= DateTime.Now.AddDays(20),
        //                      CinemaId= 1,
        //                      ProducerId= 3,
        //                      MovieCategory = MovieCategory.Action
        //                 },
        //                     new Movie()
        //                 {
        //                    Name="Ghost",
        //                     Description="This is the description of the first Movie",
        //                     Price=39.00,
        //                     ImageUrl="http://dotnethow.net/images/movies/movie-4.jpg",
        //                     Startdate= DateTime.Now.AddDays(3),
        //                     Enddate= DateTime.Now.AddDays(20),
        //                      CinemaId= 3,
        //                      ProducerId= 4,
        //                      MovieCategory = MovieCategory.Horror
        //                 },

        //                 new Movie()
        //                 {
        //                    Name="The shawshank Redemption",
        //                     Description="This is the description of the first Movie",
        //                     Price=39.00,
        //                     ImageUrl="http://dotnethow.net/images/movies/movie-1.jpg",
        //                     Startdate= DateTime.Now.AddDays(3),
        //                     Enddate= DateTime.Now.AddDays(20),
        //                      CinemaId= 3,
        //                      ProducerId= 2,
        //                      MovieCategory = MovieCategory.Action
        //                 }

        //            });

        //            context.SaveChanges();
        //        }
        //        //Actor & movies
        //        if (!context.Movies.Any())
        //        {
        //            context.Actors_Movies.AddRange(new List<Actor_Movie> {
        //             new Actor_Movie()
        //             {
        //                 ActorId =1,
        //                 MovieId =1,
        //             },
        //              new Actor_Movie()
        //             {
        //                 ActorId =2,
        //                  MovieId =1,
        //             },
        //               new Actor_Movie()
        //             {
        //                 ActorId =4,
        //                   MovieId =4,
        //             },
        //                new Actor_Movie()
        //             {
        //                 ActorId =3,
        //                    MovieId =4,
        //             },
        //                 new Actor_Movie()
        //             {
        //                 ActorId =2,
        //                     MovieId =1,
        //             },
        //                  new Actor_Movie()
        //             {
        //                 ActorId =2,
        //                 MovieId =3,
        //             }


        //            });
        //            context.SaveChanges();
        //        }
        //    }
        //}

        public static async Task seedUserAndRoleAsync(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Roles
                var roleManger = servicescope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManger.RoleExistsAsync(UserRoles.Admin))
                    await roleManger.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManger.RoleExistsAsync(UserRoles.User))
                    await roleManger.CreateAsync(new IdentityRole(UserRoles.User));


                //Users

                var userManger = servicescope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEmail = "admin@ecommerce.com";

                var adminUser = await userManger.FindByEmailAsync(adminUserEmail);

                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "Admin",
                        Email = adminUserEmail
                        
                    };
                    await userManger.CreateAsync(newAdminUser, "Test123+");
                    await userManger.AddToRoleAsync(newAdminUser, UserRoles.Admin);

                }

                string appUserEmail = "appUser@gmail.com";

                var appUser = await userManger.FindByEmailAsync(appUserEmail);
                if (appUser != null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "app User",
                        UserName = "User",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManger.CreateAsync(newAppUser, "Test123+");
                    await userManger.AddToRoleAsync(newAppUser, UserRoles.User);

                }
            }
        }
    }
}
