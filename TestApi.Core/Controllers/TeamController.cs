using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TestApi.Core.Models;

namespace TestApi.Core.Controllers
{
    [RoutePrefix("api/team")]
    public class TeamController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(TeamModel))]
        [Route("{idTeam}")]
        public TeamModel GetTeam(int idTeam)
        {
            return new TeamModel
            {
                TeamId = System.Guid.NewGuid().ToString(),
                Name = "FC Barcelona",
                Country = "Espanya"
            };
        }

        [HttpGet]
        [ResponseType(typeof(List<TeamModel>))]
        [Route("country/{idCountry}/division/{idDivision}")]
        public List<TeamModel> GetTeams(int idCountry, int idDivision)
        {
            var teams = new List<TeamModel>();
            teams.Add(new TeamModel
            {
                TeamId = System.Guid.NewGuid().ToString(),
                Name = "FC Barcelona",
                Country = "Espanya"
            });
            teams.Add(new TeamModel
            {
                TeamId = System.Guid.NewGuid().ToString(),
                Name = "Real Madrid",
                Country = "Espanya"
            });
            teams.Add(new TeamModel
            {
                TeamId = System.Guid.NewGuid().ToString(),
                Name = "Athletico de Madrid",
                Country = "Espanya"
            });
            return teams;
        }

        [HttpGet]
        [ResponseType(typeof(bool))]
        [Route("boolean_param")]
        public async Task<IHttpActionResult> GetTestBooleanWithParam(int id)
        {
            return Ok(true);
        }

        [HttpPost]
        [ResponseType(typeof(bool))]
        [Route("boolean_post")]
        public async Task<IHttpActionResult> PostTestBoolean()
        {
            return Ok(true);
        }
    }
}
