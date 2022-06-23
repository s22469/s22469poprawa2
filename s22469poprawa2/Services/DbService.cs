using Microsoft.EntityFrameworkCore;
using s22469poprawa2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s22469poprawa2.Services
{
    public class DbService
    {
        public ExampleDbContext _context;
        public async Task<ICollection<Team>> getTeamById(int id)
        {
            return await _context.Team.Include(c => c.OrganizationF)
                .Where(c => c.TeamID == id)
                .ToListAsync();
        }

        public async Task<ICollection<Team>> putMemberToTeam(int id)
        {
            return null;
        }
    }
}
