//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//using UserAPI.Models;

//namespace UserAPI.Controllers
//{
//  [Route("api/[controller]")]
//  [ApiController]
//  [Consumes("application/json")]
//  public class UsersController : ControllerBase
//  {
//    private readonly ReactDemoDbContext _context;

//    public UsersController(ReactDemoDbContext context)
//    {
//      _context = context;
//    }

//    // GET: api/Users
//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<UserDetail>>> GetUsers()
//    {
//      return await _context.UserDetails.ToListAsync();
//    }

//    // GET: api/Users/5
//    [HttpGet("{id}")]
//    public async Task<ActionResult<UserDetail>> GetUser(int id)
//    {
//      var user = await _context.UserDetails.FindAsync(id);

//      if (user == null)
//      {
//        return NotFound();
//      }

//      return user;
//    }

//    // PUT: api/Users/5
//    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//    [HttpPut("{id}")]
//    public async Task<IActionResult> PutUser(int id, [FromBody] UserDetail user)
//    {
//      if (id != user.Id)
//      {
//        return BadRequest();
//      }

//      _context.Entry(user).State = EntityState.Modified;

//      try
//      {
//        await _context.SaveChangesAsync();
//      }
//      catch (DbUpdateConcurrencyException)
//      {
//        if (!UserExists(id))
//        {
//          return NotFound();
//        }
//        else
//        {
//          throw;
//        }
//      }

//      return NoContent();
//    }

//    // POST: api/Users
//    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//    [HttpPost]
//    public async Task<ActionResult<UserDetail>> PostUser([FromBody] UserDetail user)
//    {
//      if (_context.UserDetails.Any(e => user.Email == e.Email))
//      {
//        return StatusCode(StatusCodes.Status409Conflict);
//      }
//      _context.UserDetails.Add(user);
//      await _context.SaveChangesAsync();

//      return CreatedAtAction("GetUser", new { id = user.Id }, user);
//    }

//    // DELETE: api/Users/5
//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteUser(int id)
//    {
//      var user = await _context.UserDetails.FindAsync(id);
//      if (user == null)
//      {
//        return NotFound();
//      }

//      _context.UserDetails.Remove(user);
//      await _context.SaveChangesAsync();

//      return NoContent();
//    }

//    private bool UserExists(int id)
//    {
//      return _context.UserDetails.Any(e => e.Id == id);
//    }
//  }
//}
