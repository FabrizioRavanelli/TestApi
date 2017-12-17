using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TestApi.Core.Models;
using TestApi.Core.Services;
using System.Net.Http;
using System.Net;

namespace TestApi.Core.Controllers
{
    [RoutePrefix("api/league")]
    public class LeagueController : ApiController
    {
        #region Properties

        private LeagueService _service;

        #endregion

        #region Constructors

        public LeagueController(LeagueService service)
        {
            _service = service;
        }

        #endregion

        #region Methods

        #region Public 

        [HttpGet]
        [ResponseType(typeof(LeagueModel))]
        [Route("{idLeague}")]
        public HttpResponseMessage GetLeague(int idLeague)
        {
            var league = _service.GetLeagueById(idLeague);
            return Request.CreateResponse(HttpStatusCode.OK, league);
        }

        [HttpGet]
        [ResponseType(typeof(List<LeagueModel>))]
        [Route("list")]
        public HttpResponseMessage GetLeagues()
        {
            var leagues = _service.GetLeagues();
            return Request.CreateResponse(HttpStatusCode.OK, leagues); 
        }
        #endregion

        #endregion
    }
}
