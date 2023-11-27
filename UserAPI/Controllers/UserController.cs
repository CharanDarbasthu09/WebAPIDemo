using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using UserAPI.Models;

namespace UserAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly ReactDemoDbContext _context;

    public UserController(ReactDemoDbContext context)
    {
      _context = context;
    }

    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDetail>>> GetUsers()
    {
      return await _context.UserDetails.ToListAsync();
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDetail>> GetUser(int id)
    {
      var user = await _context.UserDetails.FindAsync(id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    // PUT: api/User/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, UserDetail user)
    {
      if (id != user.Id)
      {
        return BadRequest();
      }

      _context.Entry(user).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/User
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<UserDetail>> PostUser(UserDetail user)
    {
      if(user.Id == 0)
      {
        user.Id = new Random().Next();
      }
      _context.UserDetails.Add(user);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
      var user = await _context.UserDetails.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      _context.UserDetails.Remove(user);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool UserExists(int id)
    {
      return _context.UserDetails.Any(e => e.Id == id);
    }
  }
}
