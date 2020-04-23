using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericHost
{
    class DataManager
    {
        public readonly DataContext context;
        public DataManager(DataContext dataContext) => this.context = dataContext;
        public void InsertDataToTables(string actorName, string movieName)
        {
            Actor actor = new Actor { ActorName = actorName };
            context.Actor.Add(actor);
            context.SaveChanges();

            Movie m = new Movie { MovieName = movieName, ActorId = actor.ActorID };
            context.Movie.Add(m);
            context.SaveChanges();
        }
        public void GetAllData()
        {
            try
            {
                var data = context.Actor
                        .Join(
                        context.Movie,
                        Actor => Actor.ActorID,
                        Movie => Movie.ActorId,
                        (Actor, Movie) => new { Actor.ActorName, Movie.MovieName }).ToList();

                data.ForEach(d => Console.WriteLine($"Actor {d.ActorName}\t Movie {d.MovieName} "));
            }
            catch (Exception)
            {
                Console.WriteLine("No data exists");
            }
        }
        public void UpdateActorName(string actorOldName, string actorNewName)
        {
            try
            {
                var name = context.Set<Actor>()
                              .Where(a => a.ActorName == actorOldName).FirstOrDefault();

                name.ActorName = actorNewName;
                context.Attach(name);
                context.Entry(name).State = EntityState.Modified;
                context.SaveChanges();
                //context.Entry(name).Property(p => p.ActorName).IsModified = true; both works
            }
            catch (Exception)
            {
                Console.WriteLine($"{actorOldName} does not exists in database");
            }
        }  

        public void RemoveData()
        {
            var m = context.Set<Movie>();
            context.AttachRange(m);
            context.RemoveRange(m);

            var a = context.Set<Actor>();
            context.AttachRange(a);
            context.RemoveRange(a);
            context.SaveChanges();
        }
    }
}
