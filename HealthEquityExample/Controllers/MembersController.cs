using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthEquityExample.Models;

namespace HealthEquityExample.Controllers
{
    [Route("api/Member/contact")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly MemberContext _context;

        public MembersController(MemberContext context)
        {
            _context = context;
        }

/*        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMember()
        {
            return await _context.Member.ToListAsync();
        }*/

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _context.Member.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

 /*       // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

/*        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            _context.Member.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMember), new { id = member.MemberId }, member);
        }*/

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Member>> PostMember(Member member, int id)
        {
            member.MemberId = id;
            var existingMember = await _context.Member.FindAsync(id);
            if (existingMember == null)
            {
                _context.Member.Add(member);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMember), new { id = member.MemberId }, member);
            }

            _context.Entry(existingMember).CurrentValues.SetValues(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMember), new { id = member.MemberId }, existingMember);
        }

        /*        // DELETE: api/Members/5
                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteMember(int id)
                {
                    var member = await _context.Member.FindAsync(id);
                    if (member == null)
                    {
                        return NotFound();
                    }

                    _context.Member.Remove(member);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }*/

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.MemberId == id);
        }
    }
}
