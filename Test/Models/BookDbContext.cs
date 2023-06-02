using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;



namespace Test.Models
{
    public class BookDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookDbContext(DbContextOptions<BookDbContext> opt) : base(opt)
        {
        }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                 new Author { AuthorId = 1, Name = "Steve Harvey", Female = false, Born = 1957, Died = null, age = 0 },
                 new Author { AuthorId = 2, Name = "James Allen", Female = false, Born = 1864, Died = 1912, age = 0 },
                 new Author { AuthorId = 3, Name = "Robin Norwood", Female = true, Born = 1945, Died = null, age = 0},
                 new Author { AuthorId = 4, Name = "Ramit Sethi", Female = false, Born = 1982, Died = null, age = 0},
                 new Author { AuthorId = 5, Name = "Melody Beattie", Female = true, Born = 1948, Died = null, age = 0},
                 new Author { AuthorId = 6, Name = "Dale Carnegie", Female = true, Born = 1888, Died = 1955, age = 0 },
                 new Author { AuthorId = 7, Name = "Wayne Dyer", Female = false, Born = 1940, Died = null, age = 0},
                 new Author { AuthorId = 8, Name = "John T. Molloy", Female = false, Born = 1937, Died = null, age = 0},
                 new Author { AuthorId = 10, Name = "Allen Carr", Female = false, Born = 1934, Died = 2006, age = 0 },
                 new Author { AuthorId = 12, Name = "Robert Greene", Female = false, Born = 1959, Died = null, age = 0},
                 new Author { AuthorId = 13, Name = "Wendy Kaminer", Female = true, Born = 1949, Died = null, age = 0},
                 new Author { AuthorId = 14, Name = "David Schwartz", Female = false, Born = 1927, Died = 1987, age = 0 },
                 new Author { AuthorId = 15, Name = "Robin Sharma", Female = false, Born = 1964, Died = null, age = 0},
                 new Author { AuthorId = 16, Name = "Norman Vincent Peale", Female = false, Born = 1898, Died = 1993, age = 0 },
                 new Author { AuthorId = 17, Name = "Maxwell Maltz", Female = false, Born = 1899, Died = 1975, age = 0 },
                 new Author { AuthorId = 18, Name = "Rhonda Byrne", Female = true, Born = 1951, Died = null, age = 0 },
                 new Author { AuthorId = 19, Name = "Stephen Covey", Female = false, Born = 1932, Died = 2012, age = 0 },
                 new Author { AuthorId = 20, Name = "Napoleon Hill", Female = false, Born = 1883, Died = 1970, age = 0 },
                 new Author { AuthorId = 21, Name = "Anthony Robbins", Female = false, Born = 1960, Died = null, age = 0 },
                 new Author { AuthorId = 22, Name = "Louise Hay", Female = true, Born = 1926, Died = 2017, age = 0 },
                 new Author { AuthorId = 23, Name = "Charles F.Haanel", Female = false, Born = 1926, Died = 1949, age = 0 },
                 new Author { AuthorId = 24, Name = "Eckhart Tolle", Female = false, Born = 1948, Died = null, age = 0 },
                 new Author { AuthorId = 25, Name = "Diane Muldrow", Female = true, Born = 1950, Died = null, age = 0 },
                 new Author { AuthorId = 26, Name = "David Gillespie", Female = false, Born = 1957, Died = null, age = 0 },
                 new Author { AuthorId = 27, Name = "Burra Venkatesham", Female = false, Born = 1968, Died = null, age = 0 },
                 new Author { AuthorId = 28, Name = "Dr.Walter Doyle Staples", Female = false, Born = 1955, Died = null, age = 0 },
                 new Author { AuthorId = 29, Name = "Wahiduddin Khan", Female = false, Born = 1925, Died = 2021, age = 0 },
                 new Author { AuthorId = 30, Name = "Paulo Coelho", Female = false, Born = 1947, Died = null, age = 0 }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Act like a Lady, Think like a Man", Topic = "relationship",AuthorName = "Steve Harvey", PublishYear = 2009, AuthorId = 1, Price = Convert.ToDecimal(20.00), Rating = 1 },
                new Book { Id = 2, Title = "As a Man Thinketh", Topic = "positive thinking", AuthorName = "James Allen", PublishYear = 1902, AuthorId = 2, Price = Convert.ToDecimal(50.00), Rating = 2 },
                new Book { Id = 3, Title = "Women Who Love Too Much", Topic = "relationship", AuthorName = "Robin Norwood", PublishYear = 1985, AuthorId = 3, Price = Convert.ToDecimal(15.40), Rating = 3 },
                new Book { Id = 4, Title = "I Will Teach You To Be Rich", Topic = "success", AuthorName = "Ramit Sethi", PublishYear = 2009, AuthorId = 4, Price = Convert.ToDecimal(20.00), Rating = 4 },
                new Book { Id = 5, Title = "Codependent No More", Topic = "relationship", AuthorName = "Melody Beattie", PublishYear = 1986, AuthorId = 5, Price = Convert.ToDecimal(32.00), Rating = 2 },
                new Book { Id = 6, Title = "How to Stop Worrying and Start Living", Topic = "optimism", AuthorName = "Dale Carnegie", PublishYear = 1948, AuthorId = 6, Price = Convert.ToDecimal(50.00), Rating = 4 },
                new Book { Id = 7, Title = "Your Erroneous Zones", Topic = "health", AuthorName = "Wayne Dyer", PublishYear = 1976, AuthorId = 7, Price = Convert.ToDecimal(24.00), Rating = 5 },
                new Book { Id = 8, Title = "Dress for Success", Topic = "success", AuthorName = "John T. Molloy", PublishYear = 1975, AuthorId = 8, Price = Convert.ToDecimal(54.20), Rating = 3 },
                new Book { Id = 9, Title = "The Easy Way to Stop Smoking", Topic = "health", AuthorName = "Allen Carr", PublishYear = 2006, AuthorId = 10, Price = Convert.ToDecimal(45.60), Rating = 2 },
                new Book { Id = 10, Title = "How to Win Friends and Influence People", Topic = "success", AuthorName = "Dale Carnegie", PublishYear = 1936, AuthorId = 6, Price = Convert.ToDecimal(10.20), Rating = 4 },
                new Book { Id = 11, Title = "The 48 Laws of Power", Topic = "success", AuthorName = "Allen Carr", PublishYear = 1985, AuthorId = 10, Price = Convert.ToDecimal(20.50), Rating = 2 },
                new Book { Id = 12, Title = "I'm Dysfunctional, You're Dysfunctional", Topic = "anti-self-help", AuthorName = "Robert Greene", PublishYear = 1998, AuthorId = 12, Price = Convert.ToDecimal(10.05), Rating = 3 },
                new Book { Id = 13, Title = "The Magic of Thinking Big", Topic = "success", AuthorName = "Robert Greene", PublishYear = 1992, AuthorId = 12, Price = Convert.ToDecimal(100.00), Rating = 5 },
                new Book { Id = 14, Title = "The Monk Who Sold His Ferrari", Topic = "health", AuthorName = "Wendy Kaminer", PublishYear = 1959, AuthorId = 13, Price = Convert.ToDecimal(39.55), Rating = 3 },
                new Book { Id = 15, Title = "The Power of Positive Thinking", Topic = "optimism", AuthorName = "David Schwartz", PublishYear = 1952, AuthorId = 14, Price = Convert.ToDecimal(12.34), Rating = 5 },
                new Book { Id = 16, Title = "Psycho-Cybernetics", Topic = "self image", AuthorName = "Robin Sharma", PublishYear = 1960, AuthorId = 15, Price = Convert.ToDecimal(12.34), Rating = 2 },
                new Book { Id = 17, Title = "The Secret", Topic = "optimism", AuthorName = "Norman Vincent Peale", PublishYear = 2006, AuthorId = 16, Price = Convert.ToDecimal(20.50), Rating = 4 },
                new Book { Id = 18, Title = "The Seven Habits of Highly Effective People", Topic = "success", AuthorName = "Maxwell Maltz", PublishYear = 1989, AuthorId = 17, Price = Convert.ToDecimal(50.30), Rating = 1 },
                new Book { Id = 19, Title = "Think and Grow Rich", Topic = "success", AuthorName = "Rhonda Byrne", PublishYear = 1937, AuthorId = 18, Price = Convert.ToDecimal(25.50), Rating = 5 },
                new Book { Id = 20, Title = "Unlimited Power", Topic = "success", AuthorName = "Stephen Covey", PublishYear = 1986, AuthorId = 19, Price = Convert.ToDecimal(20.50), Rating = 5 },
                new Book { Id = 21, Title = "You Can Heal Your Life", Topic = "health", AuthorName = "Napoleon Hill", PublishYear = 1984, AuthorId = 20, Price = Convert.ToDecimal(100.00), Rating = 4 },
                new Book { Id = 22, Title = "The Master Key System", Topic = "optimism", AuthorName = "Anthony Robbins", PublishYear = 1916, AuthorId = 21, Price = Convert.ToDecimal(69.60), Rating = 1 },
                new Book { Id = 23, Title = "The Power of Now", Topic = "optimism", AuthorName = "Louise Hay", PublishYear = 1997, AuthorId = 22, Price = Convert.ToDecimal(45.56), Rating = 4 },
                new Book { Id = 24, Title = "The Magic Ladder To Success", Topic = "", AuthorName = "Rhonda Byrne", PublishYear = 1930, AuthorId = 18, Price = Convert.ToDecimal(100.05), Rating = 5 },
                new Book { Id = 25, Title = "Outwitting the Devil", Topic = "success", AuthorName = "Rhonda Byrne", PublishYear = 2011, AuthorId = 18, Price = Convert.ToDecimal(32.45), Rating = 3 },
                new Book { Id = 26, Title = "Selfie Of Success", Topic = "success", AuthorName = "Rhonda Byrne", PublishYear = 2019, AuthorId = 25, Price = Convert.ToDecimal(20.60), Rating = 4 },
                new Book { Id = 27, Title = "Think Like a Winner!", Topic = "optimism", AuthorName = "Rhonda Byrne", PublishYear = 1991, AuthorId = 26, Price = Convert.ToDecimal(20.50), Rating = 3 },
                new Book { Id = 28, Title = "Raaz-e-Hayat", Topic = "optimism", AuthorName = "Burra Venkatesham", PublishYear = 1987, AuthorId = 27, Price = Convert.ToDecimal(14.30), Rating = 5 }
            );
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();
            modelBuilder.Ignore<ApplicationUser>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
