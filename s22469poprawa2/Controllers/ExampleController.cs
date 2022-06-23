using Microsoft.AspNetCore.Mvc;
using s22469poprawa2.Models;
using s22469poprawa2.Services;
using System.Threading.Tasks;

namespace s22469poprawa2.Controllers
{
    [ApiController]
    [Route("/api/teams")]
    public class ExampleController : ControllerBase
    {
        public DbService _dbService;

        public ExampleController(DbService dbService)
        {
            _dbService = dbService;
        }

        [Route("/api/teams/{id}")]
        [HttpGet]
        public async Task<IActionResult> getTeamById(int id)
        {
            var team = await _dbService.getTeamById(id);
            return Ok(team);
        }

        [Route("/api/teams/")]
        [HttpPut]
        public async Task<IActionResult> putMemberToTeam(Member member)
        {
            return Ok();
        }
    }
}

