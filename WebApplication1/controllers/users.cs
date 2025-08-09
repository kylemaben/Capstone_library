// using WebApplication1.Models; // Added this using directive
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using System.Linq;

// namespace WebApplication1.Controllers
// {
//     [ApiController]
//     [Route("[controller]")] // This will route requests to /users
//     public class UsersController : ControllerBase
//     {
//         private static List<User> _users = new List<User>
//         {
//             new User { Id = 1, Name = "Alice Smith", Email = "alice@example.com" },
//             new User { Id = 2, Name = "Bob Johnson", Email = "bob@example.com" }
//         };
//         private static int _nextId = 3;

//         /// <summary>
//         /// Retrieves a list of all users.
//         /// GET /users
//         /// </summary>
//         [HttpGet]
//         public ActionResult<IEnumerable<User>> GetUsers()
//         {
//             return Ok(_users);
//         }

//         /// <summary>
//         /// Creates a new user.
//         /// POST /users
//         /// </summary>
//         [HttpPost]
//         public ActionResult<User> PostUser([FromBody] User newUser)
//         {
//             if (newUser == null)
//             {
//                 return BadRequest("User data is null.");
//             }
//             newUser.Id = _nextId++;
//             _users.Add(newUser);
//             return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
//         }

//         /// <summary>
//         /// Retrieves a user by their ID.
//         /// GET /users/{id}
//         /// </summary>
//         [HttpGet("{id}")]
//         public ActionResult<User> GetUser(int id)
//         {
//             var user = _users.FirstOrDefault(u => u.Id == id);
//             if (user == null)
//             {
//                 return NotFound();
//             }
//             return Ok(user);
//         }
//     }
// }