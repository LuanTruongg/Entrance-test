using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using Test.DTO;
using Test.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks([FromQuery] int authorid, [FromQuery] int publishYear, [FromQuery] int rating)
        {
            if (authorid != 0)
            {
                var filterByAuthorId = _context.Books!.Where(x => x.AuthorId == authorid).Select(b => new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Topic = b.Topic,
                    AuthorName = b.AuthorName,
                    PublishYear = b.PublishYear,
                    Price = b.Price,
                    Rating = b.Rating,
                });
                return Ok(filterByAuthorId);
            }
            if (publishYear != 0)
            {
                var filterByPublishYear = _context.Books!.Where(x => x.PublishYear == publishYear).Select(b => new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Topic = b.Topic,
                    AuthorName = b.AuthorName,
                    PublishYear = b.PublishYear,
                    Price = b.Price,
                    Rating = b.Rating,
                });
                return Ok(filterByPublishYear);
            }
            if (rating != 0)
            {
                var filterByRating = _context.Books!.Where(x => x.Rating == rating).Select(b => new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Topic = b.Topic,
                    AuthorName = b.AuthorName,
                    PublishYear = b.PublishYear,
                    Price = b.Price,
                    Rating = b.Rating,
                });
                return Ok(filterByRating);
            }
            if (_context.Books == null)
            {
                return NotFound();
            }
            var bookDTOs = _context.Books.Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Topic = b.Topic,
                AuthorName = b.AuthorName,
                PublishYear = b.PublishYear,
                Price = b.Price,
                Rating = b.Rating,
            });
            return Ok(bookDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var book = _context.Books.Include(e => e.Author).Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            var authorDTO = _context.Authors!.Where(x => x.AuthorId == book.AuthorId).Select(b => new AuthorDTO
            {
                AuthorId = b.AuthorId,
                Name = b.Name,
                Female = b.Female,
                Born = b.Born,
                Died = b.Died,
                age = (b.Died ?? 2023) - b.Born,
            }).FirstOrDefault();            
            var bookDTO = new UpdateDTO
            {
                Id = book.Id,
                Title = book.Title,
                Topic = book.Topic,
                Author = (AuthorDTO)authorDTO!,
                PublishYear = book.PublishYear,
                Price = book.Price,
                Rating = book.Rating,
            };
            return Ok(bookDTO);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            try
            {
                var checkTitle = _context.Books!.Where(b => b.Title == book.Title);
                //var author = await _context.Authors!.FindAsync(book.AuthorId);
                var authorDTO = _context.Authors!.Where(x => x.AuthorId == book.AuthorId).Select(b => new AuthorDTO
                {
                    AuthorId = b.AuthorId,
                    Name = b.Name,
                    Female = b.Female,
                    Born = b.Born,
                    Died = b.Died,
                    age = (b.Died ?? 2023) - b.Born,
                }).FirstOrDefault();
                var newbook = new Book();
                if (checkTitle.Any())
                {
                    return BadRequest("There are already other items in the database with the same name.");
                }
                else if (authorDTO == null)
                {
                    return BadRequest("Author is not found");
                }
                else if (book.Title.IsNullOrEmpty())
                {
                    return BadRequest("Please enter title");
                }
                else
                {
                    newbook.Id = book.Id;
                    newbook.Title = book.Title;
                    newbook.Topic = book.Topic;
                    newbook.AuthorId = book.AuthorId;
                    newbook.Author = await _context.Authors!.FindAsync(book.AuthorId);
                    newbook.PublishYear = book.PublishYear;
                    newbook.Price = decimal.Round(book.Price, 2, MidpointRounding.AwayFromZero); 
                    newbook.Rating = book.Rating;
                    _context.Books!.Add(newbook);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest("Error");
            }

        }

        [HttpPut("{id?}")]
        [Authorize]
        public async Task<IActionResult> PutBook(int id, Book editbook)
        {
            try
            {
                var book = _context.Books!.SingleOrDefault(idbook => idbook.Id == id);
                var author = await _context.Authors!.FindAsync(editbook.AuthorId);
                if (book == null)
                {
                    return NotFound();
                }
                if (author == null)
                {
                    return BadRequest("Author is not found");
                }
                else if (book.Title.IsNullOrEmpty())
                {
                    return BadRequest("Please enter title");
                }
                if (book != null)
                {
                    book.Title = editbook.Title;
                    book.Topic = editbook.Topic;
                    book.AuthorId = editbook.AuthorId;
                    book.Author = author;
                    book.PublishYear = editbook.PublishYear;
                    book.Price = decimal.Round(editbook.Price, 2, MidpointRounding.AwayFromZero);
                    book.Rating = editbook.Rating;
                    _context.Books!.Update(book);
                    await _context.SaveChangesAsync();
                    var authorDTO = _context.Authors!.Where(x => x.AuthorId == book.AuthorId).Select(b => new AuthorDTO
                    {
                        AuthorId = b.AuthorId,
                        Name = b.Name,
                        Female = b.Female,
                        Born = b.Born,
                        Died = b.Died,
                        age = (b.Died ?? 2023) - b.Born,
                    }).FirstOrDefault();
                    var bookDTO = new UpdateDTO
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Topic = book.Topic,
                        Author = (AuthorDTO)authorDTO!,
                        PublishYear = book.PublishYear,
                        Price = book.Price,
                        Rating = book.Rating,
                    };
                    return Ok(bookDTO);
                }
                else { return BadRequest("Error"); }
            }
            catch
            {
                return BadRequest("Error");
            }


        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var book = await _context.Books!.FindAsync(id);
                if (book == null)
                {
                    return NotFound("Item does not exist");

                }
                else
                {
                    _context.Books!.Remove(book);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch
            {
                return NotFound();
            }

        }
    }
}
