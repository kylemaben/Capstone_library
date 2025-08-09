// Loan.cs
using System;

namespace WebApplication1.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;
    }
}


// ILoanable.cs - Interface for Abstraction
namespace WebApplication1.Models
{
    // This interface defines a contract that any class can implement to be "loanable."
    public interface ILoanable
    {
        void Loan();
        bool IsAvailable { get; set; }
    }
}