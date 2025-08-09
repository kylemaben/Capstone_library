// Book.cs - This class inherits from LibraryItem (Inheritance) and implements ILoanable (Abstraction)
using System;

namespace WebApplication1.Models
{
    // The Book class is a derived class that inherits from the abstract LibraryItem base class.
    public class Book : LibraryItem, ILoanable
    {
        // Book-specific properties
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int LoanDurationInDays { get; set; }

        public Book(int id, string title, string author, string isbn) : base(title)
        {
            // The Id is set here and Title is set via the base constructor, demonstrating encapsulation.
            Id = id;
            Author = author;
            ISBN = isbn;
            LoanDurationInDays = 14; // Default loan period
        }

        // Implementation of the abstract method from the base class
        public override void DisplayStatus()
        {
            Console.WriteLine($"Book: {Title} by {Author}, ISBN: {ISBN}, Available: {IsAvailable}");
        }

        // Implementation of the interface method ILoanable.Loan()
        public void Loan()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine($"Book '{Title}' has been loaned out.");
            }
            else
            {
                Console.WriteLine($"Book '{Title}' is already on loan.");
            }
        }
    }
}
