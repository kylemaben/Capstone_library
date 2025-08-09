// LoansController.cs
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoansController : ControllerBase
    {
        private static List<Loan> _loans = new List<Loan>();
        private static int _nextId = 1;

        // GET /loans
        [HttpGet]
        public ActionResult<IEnumerable<Loan>> GetLoans()
        {
            return Ok(_loans);
        }

        // POST /loans
        [HttpPost]
        public ActionResult<Loan> PostLoan([FromBody] Loan newLoan)
        {
            if (newLoan == null)
            {
                return BadRequest("Loan data is null.");
            }
            newLoan.Id = _nextId++;
            newLoan.LoanDate = DateTime.UtcNow;
            _loans.Add(newLoan);
            return CreatedAtAction(nameof(GetLoan), new { id = newLoan.Id }, newLoan);
        }

        // GET /loans/{id}
        [HttpGet("{id}")]
        public ActionResult<Loan> GetLoan(int id)
        {
            var loan = _loans.FirstOrDefault(l => l.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }
    }
}