using BackendDisneyApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendDisneyApi.DataAccess
{
    public class DBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DisneyDBContext>();

                context.Database.EnsureCreated();

                if (!context.Characters.Any())
                {
                    context.Characters.AddRange(new List<Character>()
                    {
                        new Character()
                        {
                            Name = "Character 1",
                            Age = 23,
                            Weight = 45,
                            History = "History of character 1",
                            Image = "https://i.pinimg.com/originals/17/49/6b/17496b719809f38ade5b253adea8425e.jpg",
                        },

                        new Character()
                        {
                            Name = "Character 2",
                            Age = 36,
                            Weight = 80,
                            History = "History of character 2",
                            Image = "https://i.pinimg.com/originals/fb/f9/0a/fbf90a83b680f1a67914be509d455148.jpg",
                        },

                        new Character()
                        {
                            Name = "Character 3",
                            Age = 10,
                            Weight = 47,
                            History = "History of character 3",
                            Image = "https://i.pinimg.com/originals/20/8e/c2/208ec262bb1fe6db269c561d35183f70.jpg",
                        },

                        new Character()
                        {
                            Name = "Character 4",
                            Age = 24,
                            Weight = 75,
                            History = "History of character 4",
                            Image = "https://i.pinimg.com/originals/24/a1/ce/24a1cec879f34f570f006689a1402c9c.jpg",
                        },

                        new Character()
                        {
                            Name = "Character 5",
                            Age = 67,
                            Weight = 96,
                            History = "History of character 5",
                            Image = "https://i.pinimg.com/originals/13/e1/76/13e176fe0db4f23fcc07f28c1d545a44.jpg",
                        },

                        new Character()
                        {
                            Name = "Character 6",
                            Age = 23,
                            Weight = 45,
                            History = "History of character 6",
                            Image = "https://i.pinimg.com/originals/e4/2d/d8/e42dd8233d63df237bb321a94589657e.jpg",
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.MoviesOrSeries.Any())
                {
                    context.MoviesOrSeries.AddRange(new List<MovieOrSerie>()
                    {

                        new MovieOrSerie()
                        {
                            Name = "Movie 1",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 3,
                            GenderId = 2,
                        },

                        new MovieOrSerie()
                        {
                            Name = "Movie 2",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 4,
                            GenderId = 1,
                        },

                        new MovieOrSerie()
                        {
                            Name = "Movie 3",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 5,
                           GenderId = 3,
                        },

                        new MovieOrSerie()
                        {
                            Name = "Movie 4",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 2,
                            GenderId = 3,
                        },

                        new MovieOrSerie()
                        {
                            Name = "Movie 5",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 1,
                            GenderId = 1,
                        },

                        new MovieOrSerie()
                        {
                            Name = "Movie 6",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 3,
                            GenderId = 1,
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Genders.Any())
                {

                    context.Genders.AddRange(new List<Gender>()
                    {

                        new Gender()
                        {
                            Name = "Accion"
                        },

                        new Gender()
                        {
                            Name = "Suspenso"
                        },

                        new Gender()
                        {
                            Name = "Drama"
                        },

                        new Gender()
                        {
                            Name = "Comedia"
                        },

                        new Gender()
                        {
                            Name = "Aventura"
                        },
                    });
                    context.SaveChanges();
                }


                if (!context.CharacterMovies.Any())
                {
                    context.CharacterMovies.AddRange(new List<CharacterMovie>()
                    {

                        new CharacterMovie()
                        {
                            CharacterId = 1,
                            MovieOrSerieId = 2,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 1,
                            MovieOrSerieId = 4,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 2,
                            MovieOrSerieId = 1,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 3,
                            MovieOrSerieId = 5,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 3,
                            MovieOrSerieId = 3,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 4,
                            MovieOrSerieId = 5,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 4,
                            MovieOrSerieId = 1,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 5,
                            MovieOrSerieId = 6,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 6,
                            MovieOrSerieId = 1,
                        }

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

