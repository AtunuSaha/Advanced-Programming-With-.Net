namespace DAL.Migrations
{
    using DAL.EF.Tables;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.BookReviewContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.BookReviewContext context)
        {
          /*  for (int i = 1; i <= 5; i++)
            {
                context.Authors.Add(new Author()
                {
                    Name = "Author " + i,
                    Bio = "Bio for author " + i,
                    Website = "www.author" + i + ".com"
                });
            }
            context.SaveChanges();

            // Add books with references to authors
            string[] genres = { "Fiction", "Mystery", "Science Fiction", "Romance", "Fantasy" };
            Random rand = new Random();

            for (int i = 1; i <= 20; i++)
            {
                context.Books.Add(new Book
                {
                    Title = "Book " + i,
                    Genre = genres[rand.Next(0, genres.Length)],
                    AuthorId = rand.Next(1, 6)  // Random author ID between 1 and 5
                });
            }
            context.SaveChanges();

            // Add reviewers
            for (int i = 1; i <= 10; i++)
            {
                context.Reviewers.Add(new Reviewer
                {
                    Name = "Reviewer " + i,
                    Email = "reviewer" + i + "@example.com",
                    Bio = "Bio for reviewer " + i
                });
            }
            context.SaveChanges();

            // Add reviews
            for (int i = 1; i <= 50; i++)
            {
                context.Reviews.Add(new Review
                {
                    Content = "This is review number " + i + ". The book was interesting...",
                    Rating = rand.Next(1, 6),  // Random rating between 1 and 5
                    BookId = rand.Next(1, 21),  // Random book ID between 1 and 20
                    ReviewerId = rand.Next(1, 11)  // Random reviewer ID between 1 and 10
                });
            }
            context.SaveChanges(); */
        
        }
    }
}
