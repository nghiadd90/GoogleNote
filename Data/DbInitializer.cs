using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GoogleNote.Core.Models;

namespace GoogleNote.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User { Username = "nghiadd",     Email = "nghia@gmail.com", Name = "Nghia Dau",
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new User { Username = "admin",     Email = "admin@gmail.com", Name = "Admin",
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var notes = new Note[]
            {
                new Note { Title = "Carson",   Description = "Alexander", UserId = users.Single(i => i.Username == "nghiadd").Id,
                    ColorId = 1,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new Note { Title = "fsfsf",   Description = "fsfsf fsfsf", UserId = users.Single(i => i.Username == "nghiadd").Id,
                    ColorId = 2,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new Note { Title = "fsdfds",   Description = "fsdfsdf", UserId = users.Single(i => i.Username == "nghiadd").Id,
                    ColorId = 3,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new Note { Title = "fsdf",   Description = "dfsdf", UserId = users.Single(i => i.Username == "nghiadd").Id,
                    ColorId = 1,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new Note { Title = "Carfsdfson",   Description = "sdfsdfsdfsd", UserId = users.Single(i => i.Username == "admin").Id,
                    ColorId = 1,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new Note { Title = "Cars24324sfon",   Description = "sdfs", UserId = users.Single(i => i.Username == "admin").Id,
                    ColorId = 1,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new Note { Title = "fsdaf",   Description = "Alexafasdfnder", UserId = users.Single(i => i.Username == "admin").Id,
                    ColorId = 1,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new Note { Title = "sdfsdf",   Description = "Alexaafasdnder", UserId = users.Single(i => i.Username == "admin").Id,
                    ColorId = 1,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new Note { Title = "fsdfs",   Description = "Alexandfdsafdsfsaer", UserId = users.Single(i => i.Username == "admin").Id,
                    ColorId = 1,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
            };

            context.Notes.AddRange(notes);
            context.SaveChanges();

            var labels = new Label[]
            {
                new Label { Name = "English", UserId = users.Single(i => i.Username == "nghiadd").Id,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new Label { Name = "Drama", UserId = users.Single(i => i.Username == "nghiadd").Id,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new Label { Name = "Crime", UserId = users.Single(i => i.Username == "admin").Id,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },
                new Label { Name = "Japan", UserId = users.Single(i => i.Username == "admin").Id,
                    CreatedAt = DateTime.Parse("2010-09-01"), UpdatedAt = DateTime.Parse("2010-09-01") },

            };

            context.Labels.AddRange(labels);
            context.SaveChanges();

            var noteLabels = new NoteLabel[]
            {
                new NoteLabel {
                    NoteId = notes.Single(n => n.Title == "Carson").Id,
                    LabelId = labels.Single(l => l.Name == "English" ).Id,
                },
                new NoteLabel {
                    NoteId = notes.Single(n => n.Title == "sdfsdf").Id,
                    LabelId = labels.Single(l => l.Name == "Crime" ).Id,
                },
            };

            context.NoteLabels.AddRange(noteLabels);
            context.SaveChanges();
        }
    }
}
