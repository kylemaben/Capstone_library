// BooksController.cs - Demonstrates Polymorphism and API Endpoints
using WebApplication1.Models; // The 'using' statement has been updated to match the new namespace.
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers // This namespace is now correct.
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        // Data store uses the base class to hold any type of LibraryItem, demonstrating polymorphism.
        private static List<LibraryItem> _libraryItems = new List<LibraryItem>
        {
            new Book(1, "The Hitchhiker's Guide to the Galaxy", "Douglas Adams", "978-0345391803"),
            new Book(2, "1984", "George Orwell", "978-0451524935")
        };
        private static int _nextId = 3;

        // GET /books
        [HttpGet]
        public ActionResult<IEnumerable<LibraryItem>> GetBooks()
        {
            return Ok(_libraryItems);
        }

        // GET /books/{id}
        [HttpGet("{id}")]
        public ActionResult<LibraryItem> GetBook(int id)
        {
            var item = _libraryItems.FirstOrDefault(b => b.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST /books
        [HttpPost]
        public ActionResult<Book> PostBook([FromBody] Book newBook)
        {
            if (newBook == null)
            {
                return BadRequest("Book data is null.");
            }
            newBook.Id = _nextId++;
            _libraryItems.Add(newBook);
            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }

        // PUT /books/{id}
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, [FromBody] Book updatedBook)
        {
            if (updatedBook == null || id != updatedBook.Id)
            {
                return BadRequest("Invalid book data or ID mismatch.");
            }

            var existingItem = _libraryItems.FirstOrDefault(b => b.Id == id);
            // Check if the item exists and is a Book to perform the update
            if (existingItem == null || !(existingItem is Book existingBook))
            {
                return NotFound();
            }

            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.ISBN = updatedBook.ISBN;
            existingBook.IsAvailable = updatedBook.IsAvailable;

            return NoContent();
        }

        // DELETE /books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var itemToRemove = _libraryItems.FirstOrDefault(b => b.Id == id);
            if (itemToRemove == null)
            {
                return NotFound();
            }
            _libraryItems.Remove(itemToRemove);
            return NoContent();
        }

        // POST /books/{id}/loan - This uses the abstraction from the ILoanable interface
        [HttpPost("{id}/loan")]
        public IActionResult LoanItem(int id)
        {
            var item = _libraryItems.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound("Item not found.");
            }

            // Demonstrates Polymorphism: Can treat any LibraryItem as an ILoanable
            if (item is ILoanable loanableItem)
            {
                loanableItem.Loan();
                return Ok($"Item '{item.Title}' has been loaned.");
            }
            return BadRequest("This item cannot be loaned.");
        }
    }
}
